using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture;
using Modellic.App.Exceptions;
using Modellic.App.Extensions;
using Modellic.App.SolidWorks.Documents;
using Modellic.App.UI.Controls;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Services
{
    /// <summary>
    /// Связующее звено между формой и классом сборки приспособления.
    /// </summary>
    public class FixtureManager
    {
        #region Private Members

        private int _cursorPosition = 0;

        #endregion

        #region Service Instances

        /// <summary>
        /// Сборщик приспособления.
        /// </summary>
        private readonly FixtureBuilder _fixtureBuilder;

        /// <summary>
        /// Опциональный сервис по управлению StepsGridView. Может быть null.
        /// </summary>
        private readonly StepsGridViewService _stepsGridViewService = null;

        #endregion

        #region Public Properties

        public bool FreezeCursor { get; set; } = false;

        /// <summary>
        /// Текущая позиция курсора. Начинается с 0.
        /// </summary>
        public int CursorPosition
        {
            get
            {
                return _cursorPosition;
            }
            set
            {
                if (value < 0 || value > _fixtureBuilder.StepCount - 1)
                {
                    throw new InvalidOperationException("Курсор не может выходить за рамки массива.");
                }

                _cursorPosition = value;
            }
        }

        /// <summary>
        /// текущий шаг на который указывает курсор.
        /// </summary>
        public FixtureStep CurrentStep => _fixtureBuilder.FixtureSteps[CursorPosition];

        #endregion

        #region Public Events

        /// <summary>
        /// Вызывает, когд позиция курсора была изменена.
        /// </summary>
        public event Action<FixtureStep, int> CursorPositionChanged;

        public event Action<FixtureStep, FixtureStepStatus> FixtureStepStatusChanged;

        #endregion

        #region Constructors

        public FixtureManager(StepsGridView gridView = null)
        {
            Logger.LogInformation("Создаем FixtureManager");

            // Инициализируем сборщик приспособления
            _fixtureBuilder = new FixtureBuilder();

            // Подписываемся на изменение статуса построения шага
            _fixtureBuilder.FixtureStepStatusChanged += OnFixtureStepStatusChanged;

            // Если передан StepsGridView, создаем сервис для его управления
            if (gridView != null)
            {
                _stepsGridViewService = new StepsGridViewService(gridView);
            }

            // Обновляем сам StepsGridView
            _stepsGridViewService?.Update(_fixtureBuilder.FixtureSteps, CursorPosition);

            Logger.LogInformation("FixtureManager создан");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Поднимает курсор вверх. Уменьшает позицию курсора.
        /// </summary>
        public void CursorUp()
        {
            // Запоминаем текущее положение курсора для логов
            int previousState = _cursorPosition;

            // Проверяем, заморожен ли курсор
            if (FreezeCursor)
            {
                Logger.LogInformation("Курсор заморожен, перемещение запрещено");
                return;
            }

            // Проверяем, может ли курсор подниматься вверх
            if (_cursorPosition <= 0)
            {
                Logger.LogWarning("Курсор больше не может идти вверх");
                return;
            }

            // Уменьшаем позицию (поднимаемся вверх)
            _cursorPosition--;

            // Обновляем позицию курсора на StepsGridView
            _stepsGridViewService?.Update(_fixtureBuilder.FixtureSteps, CursorPosition);

            Logger.LogInformation($"Курсор поднят [{previousState} => {_cursorPosition}]");

            // Оповещаем подписчиков об изменении позиции курсора
            CursorPositionChanged?.Invoke(_fixtureBuilder.FixtureSteps[_cursorPosition], _cursorPosition);
        }

        /// <summary>
        /// Опускает курсор вниз. Увеличивает позицию курсора.
        /// </summary>
        public void CursorDown()
        {
            // Запоминаем текущее положение курсора для логов
            int previousState = _cursorPosition;

            // Проверяем, заморожен ли курсор
            if (FreezeCursor)
            {
                Logger.LogInformation("Курсор заморожен, перемещение запрещено");
                return;
            }

            // Проверяем, может ли курсор опускаться вниз
            if (_cursorPosition >= _fixtureBuilder.StepCount - 1)
            {
                Logger.LogWarning("Курсор больше не может идти вниз");
                return;
            }

            // Увеличиваем позицию (опускаемся вниз)
            _cursorPosition++;

            // Обновляем позицию курсора на StepsGridView
            _stepsGridViewService?.Update(_fixtureBuilder.FixtureSteps, CursorPosition);

            Logger.LogInformation($"Курсор опущен [{previousState} => {_cursorPosition}]");

            // Оповещаем подписчиков об изменении позиции курсора
            CursorPositionChanged?.Invoke(_fixtureBuilder.FixtureSteps[_cursorPosition], _cursorPosition);
        }

        /// <summary>
        /// Прикрепляет документ в котором будет строиться приспособление.
        /// </summary>
        /// <param name="document">Документ в котором будет строиться приспособление.</param>
        public void AttachDocument(SwModelDoc document)
        {
            if (!document.IsPart)
            {
                throw new Exception("Это не документ сборки");
            }

            _fixtureBuilder.AttachDocument(document.AsPartDoc());
        }

        #endregion

        #region Public Async Methods

        /// <summary>
        /// Строит шаг на который указывает курсор.
        /// </summary>
        /// <param name="cancellationToken">Токен для отмены построения шага.</param>
        /// <exception cref="FixtureBuilderException">Если какое-то из условий не удовлетворено.</exception>
        public async Task BuildStepAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                Logger.LogInformation($"Пробуем построить шаг {CursorPosition + 1}");

                // Строим шаг
                await _fixtureBuilder.BuildStepAsync(CursorPosition, cancellationToken);

                // Передвигаем курсор вниз
                CursorDown();
            }
            catch (FixtureBuilderException ex)
            {
                Logger.LogWarning($"При попытке построить шаг произошла ошибка. Подробности: {ex.Message}");

                throw ex;
            }
        }

        #endregion

        #region Private Event Handlers

        private void OnFixtureStepStatusChanged(FixtureStep step, FixtureStepStatus status)
        {
            if (_stepsGridViewService?.StepsGridView is Control gridView)
            {
                gridView.SafeInvoke(() =>
                    _stepsGridViewService.Update(_fixtureBuilder.FixtureSteps, CursorPosition)
                );
            }

            FixtureStepStatusChanged?.Invoke(step, status);
        }

        #endregion
    }
}
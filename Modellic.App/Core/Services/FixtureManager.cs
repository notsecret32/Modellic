using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
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

        #region Private Readonly Members

        /// <summary>
        /// Сборщик приспособления.
        /// </summary>
        private readonly FixtureBuilder _fixtureBuilder;

        /// <summary>
        /// Сервис по управлению StepsGridView.
        /// </summary>
        private readonly StepsGridViewService _stepsGridViewService;

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

        #endregion

        #region Public Static Properties

        /// <summary>
        /// Ссылка на единственный экземпляр класс <see cref="FixtureManager"/>.
        /// </summary>
        public static FixtureManager Instance;

        #endregion

        #region Public Events

        /// <summary>
        /// Вызывает, когд позиция курсора была изменена.
        /// </summary>
        public event Action<int> CursorPositionChanged;

        #endregion

        #region Constructors

        public FixtureManager(FixtureBuilder fixtureBuilder, StepsGridViewService stepsGridViewService)
        {
            // Проверяем, есть ли объект этого класса
            if (Instance != null)
            {
                Logger.LogCritical("Замечена попытка создать новый экземпляр");

                throw new Exception("Замечена попытка создать новый экземпляр");
            }

            // Инициализируем сборщик приспособления
            _fixtureBuilder = fixtureBuilder;

            // Инициализируем сервис по работе с StepsGridView
            _stepsGridViewService = stepsGridViewService;

            // Обновляем сам StepsGridView
            _stepsGridViewService.Update();

            // Устанавливаем ссылку на этот объект
            Instance = this;

            Logger.LogInformation("FixtureManager создан");
        }

        #endregion

        #region Cursor Methods

        /// <summary>
        /// Поднимает курсор вверх. Уменьшает позицию курсора.
        /// </summary>
        public void CursorUp()
        {
            Logger.LogInformation($"Поднимаем курсор. Текущая позиция курсора: {_cursorPosition}");

            // Проверяем, заморожен ли курсор
            if (FreezeCursor)
            {
                Logger.LogInformation("Курсор заморожен, невозможно переместить");
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

            // Синхронизируем позицию курсора с FixtureBuilder
            _fixtureBuilder.SetCurrentStepIndex(_cursorPosition);

            // Обновляем позицию курсора на StepsGridView
            _stepsGridViewService.Update();

            Logger.LogInformation($"Новая позиция курсора: {_cursorPosition}");

            // Оповещаем подписчиков об изменении позиции курсора
            CursorPositionChanged?.Invoke(_cursorPosition);
        }

        /// <summary>
        /// Опускает курсор вниз. Увеличивает позицию курсора.
        /// </summary>
        public void CursorDown()
        {
            Logger.LogInformation($"Опускаем курсор. Текущая позиция курсора: {_cursorPosition}");

            // Проверяем, заморожен ли курсор
            if (FreezeCursor)
            {
                Logger.LogInformation("Курсор заморожен, невозможно переместить");
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

            // Синхронизируем позицию курсора с FixtureBuilder
            _fixtureBuilder.SetCurrentStepIndex(_cursorPosition);

            // Обновляем позицию курсора на StepsGridView
            _stepsGridViewService.Update();

            Logger.LogInformation($"Новая позиция курсора: {_cursorPosition}");

            // Оповещаем подписчиков об изменении позиции курсора
            CursorPositionChanged?.Invoke(_cursorPosition);
        }

        #endregion

        #region Steps Methods

        public Task BuildStepAsync(CancellationToken cancellationToken = default)
        {
            return _fixtureBuilder.BuildStepAsync(cancellationToken);
        }

        #endregion
    }
}
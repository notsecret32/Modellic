using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture;
using Modellic.App.Enums;
using Modellic.App.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Services
{
    /// <summary>
    /// Класс управляющий сборкой приспособления. В его задачи входит управление шагами, их постройка, изменение, очищение и т.д.
    /// </summary>
    public class FixtureBuilder
    {
        #region Private Members

        /// <summary>
        /// Позиция курсора. Начинается с 0.
        /// </summary>
        private int _cursorPosition = 0;

        /// <summary>
        /// Индекс последнего собранного шага. -1 означает, что ни один шаг еще не построен.
        /// </summary>
        private int _lastBuiltStepIndex = -1;

        #endregion

        #region Private Readonly Members

        /// <summary>
        /// Массив, хранящий шаги построения приспособления.
        /// </summary>
        private readonly List<FixtureStep> _steps;

        #endregion

        #region Public Properties

        /// <summary>
        /// Массив со всеми шагами построения приспособления.
        /// </summary>
        public List<FixtureStep> FixtureSteps => _steps;

        /// <summary>
        /// Количество шагов.
        /// </summary>
        public int StepCount => _steps.Count;

        /// <summary>
        /// Позиция курсора. Начинается с 0.
        /// </summary>
        public int CursorPosition
        {
            get
            {
                return _cursorPosition;
            }
            set
            {
                if (value < 0 || value > _steps.Count - 1)
                {
                    throw new InvalidOperationException("Курсор не может выходить за рамки массива.");
                }

                _cursorPosition = value;
            }
        }

        /// <summary>
        /// Индекс последнего собранного шага. -1 означает, что ни один шаг еще не построен.
        /// </summary>
        public int LastBuiltStepIndex => _lastBuiltStepIndex;

        #endregion

        #region Public Static Properties

        /// <summary>
        /// Ссылка на единственный экземпляр класс <see cref="FixtureBuilder"/>.
        /// </summary>
        public static FixtureBuilder Instance => new FixtureBuilder();

        #endregion

        #region Constructors

        private FixtureBuilder()
        {
            // Инициализируем шаги сборки
            _steps = new List<FixtureStep>()
            {
                new FixtureStep1(),
                new FixtureStep2(),
                new FixtureStep3(),
                new FixtureStep4(),
            };

            Logger.LogInformation($"FixtureBuilder создан (Кол-во шагов: {_steps.Count})");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Строит текущий шаг.
        /// </summary>
        /// <param name="cancellationToken">Уведовление об остановке построения шага.</param>
        /// <exception cref="FixtureBuilderException">Если курсор указывает на неправильный шаг.</exception>
        public async Task BuildStepAsync(CancellationToken cancellationToken = default)
        {
            Logger.LogInformation("Пробуем построить шаг");

            // Проверяем, что текущий шаг еще не построен
            if (_steps[_cursorPosition].Status != FixtureStepStatus.NotBuilded)
            {
                Logger.LogWarning("Этот шаг уже построен");

                throw new FixtureBuilderException("Этот шаг уже построен.", FixtureBuilderErrorCode.AlreadyBuilded);
            }

            // Проверяем, что шаги строятся последовательно
            if (_cursorPosition != _lastBuiltStepIndex + 1)
            {
                Logger.LogWarning("Предыдущий шаг не построен");

                throw new FixtureBuilderException(
                    "Предыдущий шаг не построен. Постройте его и повторите попытку.", 
                    FixtureBuilderErrorCode.PreviousStepNotBuilded
                );
            }

            // Строим шаг
            await FixtureSteps[CursorPosition].BuildAsync(cancellationToken);

            // Обновляем счетчик
            _lastBuiltStepIndex = _cursorPosition;
        }

        #endregion
    }
}

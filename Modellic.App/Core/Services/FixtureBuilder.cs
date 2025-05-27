using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture;
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

        public Task BuildStepAsync(CancellationToken cancellationToken = default)
        {
            return FixtureSteps[CursorPosition].BuildAsync(cancellationToken);
        }

        #endregion
    }
}

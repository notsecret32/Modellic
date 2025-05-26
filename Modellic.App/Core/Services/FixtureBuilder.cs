using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture;
using System.Collections.Generic;
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
        /// Индекс, указывающий на текущий шаг в массиве.
        /// </summary>
        private int _currentStepIndex = 0;

        #endregion

        #region Private Readonly Members

        /// <summary>
        /// Массив, хранящий шаги построения приспособления.
        /// </summary>
        private readonly List<FixtureStep> _steps;

        #endregion

        #region Public Properties

        /// <summary>
        /// Количество шагов.
        /// </summary>
        public int StepCount => _steps.Count;

        /// <summary>
        /// Индекс, указывающий на текущий шаг в массиве.
        /// </summary>
        public int CurrentStepIndex => _currentStepIndex;

        /// <summary>
        /// Текущий шаг.
        /// </summary>
        public FixtureStep CurrentStep => _steps[CurrentStepIndex];

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
    }
}

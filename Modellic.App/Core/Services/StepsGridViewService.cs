using Microsoft.Extensions.Logging;
using Modellic.App.UI.Controls;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Services
{
    /// <summary>
    /// Сервис для работы с <see cref="UI.Controls.StepsGridView"/>. Предоставляет методы для удобной работы с ним.
    /// </summary>
    public class StepsGridViewService
    {
        #region Private Members

        /// <summary>
        /// Флаг, указывающий инициализирован ли StepsGridView.
        /// </summary>
        public bool _isInitialized;

        #endregion

        #region Private Readonly Members

        /// <summary>
        /// Элемент формы отображающий построение приспособления.
        /// </summary>
        private readonly StepsGridView _stepsGridView;

        /// <summary>
        /// Сборщик приспособления.
        /// </summary>
        private readonly FixtureBuilder _fixtureBuilder;

        #endregion

        #region Public Properties

        /// <summary>
        /// Элемент формы отображающий построение приспособления.
        /// </summary>
        public StepsGridView StepsGridView => _stepsGridView;

        #endregion

        #region Constructors

        public StepsGridViewService(FixtureBuilder fixtureBuilder, StepsGridView stepsGridView)
        {
            _fixtureBuilder = fixtureBuilder;

            _stepsGridView = stepsGridView;

            Logger.LogInformation("StepsGridViewService создан");
        }

        #endregion

        #region Public Methods

        public void Update()
        {
            Logger.LogInformation("Обновляем StepsGridView");

            _stepsGridView.Update((gridView, index, count) =>
            {
                bool isCurrentIndex = _fixtureBuilder.CursorPosition == index;
                string currentStepTitle = _fixtureBuilder.FixtureSteps[index].Title;

                gridView.Rows.Add(
                    isCurrentIndex ? "➤" : "",
                    index + 1,
                    currentStepTitle,
                    "Не построено"
                );
            }, _fixtureBuilder.StepCount);
        }

        #endregion
    }
}

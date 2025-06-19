using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Conductor;
using Modellic.App.UI.Controls;
using System.Collections.Generic;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Services
{
    /// <summary>
    /// Сервис для работы с <see cref="UI.Controls.StepsGridView"/>. Предоставляет методы для удобной работы с ним.
    /// </summary>
    public class StepsGridViewService
    {
        #region Private Readonly Members

        /// <summary>
        /// Элемент формы отображающий построение приспособления.
        /// </summary>
        private readonly StepsGridView _stepsGridView;

        #endregion

        #region Public Properties

        /// <summary>
        /// Элемент формы отображающий построение приспособления.
        /// </summary>
        public StepsGridView StepsGridView => _stepsGridView;

        #endregion

        #region Constructors

        public StepsGridViewService(StepsGridView stepsGridView)
        {
            // Инициализируем сервис по управлению StepsGridView
            _stepsGridView = stepsGridView;

            Logger.LogInformation("StepsGridViewService создан");
        }

        #endregion

        #region Public Methods

        public void Update(IReadOnlyList<ConductorBaseStep> steps, int cursorPosition)
        {
            _stepsGridView.Update((gridView, index, count) =>
            {
                bool isCurrentIndex = cursorPosition == index;
                string currentStepTitle = steps[index].Title;
                string currentStepStatus = GetFixtureStepStatusText(steps[index].Status);

                gridView.Rows.Add(
                    isCurrentIndex ? "➤" : "",
                    index + 1,
                    currentStepTitle,
                    currentStepStatus
                );
            }, steps.Count);
        }

        #endregion

        #region Private Methods

        private string GetFixtureStepStatusText(ConductorStepStatus fixtureStepStatus)
        {
            return fixtureStepStatus switch
            {
                ConductorStepStatus.NotBuilded => "Не построен",
                ConductorStepStatus.Building => "В процессе",
                ConductorStepStatus.Builded => "Построено",
                ConductorStepStatus.Error => "Ошибка",
                ConductorStepStatus.ValidationFailed => "Ошибка валидации",
                _ => "Не определено"
            };
        }

        #endregion
    }
}

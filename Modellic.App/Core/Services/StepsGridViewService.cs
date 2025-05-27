using Microsoft.Extensions.Logging;
using Modellic.App.Core.Models.Fixture;
using Modellic.App.Extensions;
using Modellic.App.UI.Controls;
using System;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Services
{
    /// <summary>
    /// Сервис для работы с <see cref="UI.Controls.StepsGridView"/>. Предоставляет методы для удобной работы с ним.
    /// </summary>
    public class StepsGridViewService : IDisposable
    {
        #region Private Members
        
        private bool _isDisposed;

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
            // Инициалищируем сборщик приспособления
            _fixtureBuilder = fixtureBuilder;

            // Инициализируем сервис по управлению StepsGridView
            _stepsGridView = stepsGridView;

            // Подписываемся на изменение статуса для каждого шага
            foreach (var step in _fixtureBuilder.FixtureSteps)
            {
                step.StatusChanged += OnFixtureStepStatusChanged;
            }

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
                string currentStepStatus = GetFixtureStepStatusText(_fixtureBuilder.FixtureSteps[index].Status);

                gridView.Rows.Add(
                    isCurrentIndex ? "➤" : "",
                    index + 1,
                    currentStepTitle,
                    currentStepStatus
                );
            }, _fixtureBuilder.StepCount);
        }

        #endregion

        #region Private Methods

        private string GetFixtureStepStatusText(FixtureStepStatus fixtureStepStatus)
        {
            return fixtureStepStatus switch
            {
                FixtureStepStatus.NotBuilded => "Не построен",
                FixtureStepStatus.Building => "В процессе",
                FixtureStepStatus.Builded => "Построено",
                FixtureStepStatus.Error => "Ошибка",
                FixtureStepStatus.ValidationFailed => "Ошибка валидации",
                _ => "Не определено"
            };
        }

        #endregion

        #region Private Event Handlers

        private void OnFixtureStepStatusChanged(FixtureStep step, FixtureStepStatus status)
        {
            // При изменении статуса любого шага обновляем таблицу
            StepsGridView.SafeInvoke(() => Update());
        }

        #endregion

        #region Disposing

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    foreach (var step in _fixtureBuilder.FixtureSteps)
                    {
                        step.StatusChanged += OnFixtureStepStatusChanged;
                    }
                }

                _isDisposed = true;
            }
        }

        /// <summary>
        /// Переопределяет метод для очистки неуправляемых ресурсов.
        /// Не изменять этот код. Код очистки размещать в методе "Dispose(bool disposing)".
        /// </summary>
        void IDisposable.Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

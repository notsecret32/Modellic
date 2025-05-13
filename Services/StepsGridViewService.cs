using Modellic.Interfaces;
using Modellic.UI.Controls;

namespace Modellic.Services
{
    /// <summary>
    /// Сервис по работе с StepsGridView. Предоставляет свойства и методы для работы с ним.
    /// </summary>
    public class StepsGridViewService : IStepsGridViewService
    {
        private StepsGridView _gridView;

        private IFixtureService _fixtureService;

        public StepsGridViewService(StepsGridView gridView, IFixtureService fixtureService)
        {
            // Инициализируем
            _gridView = gridView;
            _fixtureService = fixtureService;
        }

        public void Update()
        {
            _gridView.Rows.Clear();

            for (int i = 0; i < _fixtureService.Count; i++)
            {
                _gridView.Rows.Add(
                    _fixtureService.CurrentStepIndex == i ? "➤" : "",
                    i + 1,
                    "Не построен"
                );
            }

            _gridView.Rows.Add(
                _fixtureService.CurrentStepIndex == _fixtureService.Count ? "➤" : "",
                "",
                "Завершение"
            );
        }
    }
}

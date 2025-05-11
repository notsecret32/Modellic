using Modellic.Interfaces;
using Modellic.UI.Controls;

namespace Modellic.Services
{
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
                    _fixtureService.CurrentStep == i ? "➤" : "",
                    i + 1,
                    "Не построен"
                );
            }
        }
    }
}

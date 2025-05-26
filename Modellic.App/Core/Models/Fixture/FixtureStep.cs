using Microsoft.Extensions.Logging;
using static Modellic.App.Logging.LoggerService;

namespace Modellic.App.Core.Models.Fixture
{
    public abstract class FixtureStep
    {
        #region Private Members

        protected string _stepName = "Название шага не переопределено";

        #endregion

        #region Public Properties

        public abstract string Title { get; }

        #endregion

        #region Public Abstract Methods

        public abstract void Build();

        #endregion

        #region Protected Virtual Methods

        protected virtual void Validate()
        {
            Logger.LogInformation("Вызван метод Validate()");

            this.Build();
        }

        #endregion
    }
}

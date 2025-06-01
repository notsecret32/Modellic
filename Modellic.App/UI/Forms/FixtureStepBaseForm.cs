using Modellic.App.Core.Models.Fixture.Parameters;
using System.Windows.Forms;

namespace Modellic.App.UI.Forms
{
    public abstract partial class FixtureStepBaseForm : Form
    {
        public FixtureStepBaseForm()
        {
            InitializeComponent();

            ConfigureTableLayout();
        }

        #region Protected Methods

        protected abstract void ConfigureTableLayout();

        public abstract FixtureStepParameters GetParameters();

        public T GetParameters<T>() where T : FixtureStepParameters
        {
            return (T)GetParameters();
        }
        public abstract void SetParameters(FixtureStepParameters parameters);

        #endregion
    }
}

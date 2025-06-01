using System.Windows.Forms;

namespace Modellic.App.UI.Forms
{
    public partial class FixtureStepBaseForm : Form
    {
        public FixtureStepBaseForm()
        {
            InitializeComponent();

            ConfigureTableLayout();
        }

        #region Protected Methods

        protected virtual void ConfigureTableLayout() { }

        #endregion
    }
}

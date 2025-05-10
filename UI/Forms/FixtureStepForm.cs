using Modellic.Enums;
using Modellic.Interfaces;
using System.Windows.Forms;

namespace Modellic.UI.Forms
{
    public partial class FixtureStepForm : Form
    {
        private FixtureStepFormResult _result;

        public FixtureStepFormResult Result => _result;

        public PropertyGrid PropertyGrid => stepProperties;

        public FixtureStepForm(IFixtureStep step)
        {
            InitializeComponent();
            stepProperties.SelectedObject = step;
        }

        private void BtnContinue_Click(object sender, System.EventArgs e)
        {
            CloseForm(FixtureStepFormResult.Continue);
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            CloseForm(FixtureStepFormResult.Cancel);
        }

        private void CloseForm(FixtureStepFormResult result)
        {
            _result = result;
            this.Close();
        }
    }
}

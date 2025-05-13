using Modellic.Enums;
using Modellic.Interfaces;
using System;
using System.Windows.Forms;

namespace Modellic.UI.Forms
{
    public partial class FixtureStepForm : Form
    {
        public FixtureStepFormResult Result { get; private set; }

        public PropertyGrid PropertyGrid => stepProperties;

        public FixtureStepForm(IFixtureStep step)
        {
            InitializeComponent();
            InitializeForm(step);
        }

        private void InitializeForm(IFixtureStep step)
        {
            stepProperties.SelectedObject = step ?? throw new ArgumentNullException(nameof(step));
            Result = FixtureStepFormResult.Cancel;
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            SetResultAndClose(FixtureStepFormResult.Continue);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            SetResultAndClose(FixtureStepFormResult.Cancel);
        }

        private void SetResultAndClose(FixtureStepFormResult result)
        {
            Result = result;
            DialogResult = result == FixtureStepFormResult.Continue
                ? DialogResult.OK
                : DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            stepProperties.SelectedObject = null;
        }
    }
}
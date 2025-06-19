using Modellic.App.Core.Models.Conductor.Parameters;
using Modellic.App.Core.Services;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Modellic.App.UI.Forms.Conductor
{
    public partial class ConductorStep4Form : ConductorBaseForm
    {
        #region General Form Controls

        private TextBox _inputWidth;

        private TextBox _inputHeight;

        private TextBox _inputLength;

        #endregion

        #region Hole Form Controls

        private TextBox _inputHoleDiameter;

        private TextBox _inputVerticalHoleOffset;

        private TextBox _inputHorizontalHoleOffset;

        #endregion

        #region Constructor

        public ConductorStep4Form()
        {
            InitializeComponent();

            pictureFixtureStep.Image = Image.FromFile(Path.Combine(ResourceManager.ImagesDirectory, "FixtureStep1.png"));
        }

        #endregion

        #region Public Overrided Methods

        public override ConductorBaseParams GetParameters()
        {
            return new ConductorStep4Params
            {
                Width = double.Parse(_inputWidth.Text),
                Height = double.Parse(_inputHeight.Text),
                Length = double.Parse(_inputLength.Text),
                HoleDiameter = double.Parse(_inputHoleDiameter.Text),
                VerticalHoleOffset = double.Parse(_inputVerticalHoleOffset.Text),
                HorizontalHoleOffset = double.Parse(_inputHorizontalHoleOffset.Text),
            };
        }

        public override void SetParameters(ConductorBaseParams parameters)
        {
            if (parameters is ConductorStep4Params step4Params)
            {
                _inputWidth.Text = step4Params.Width.ToString();
                _inputHeight.Text = step4Params.Height.ToString();
                _inputLength.Text = step4Params.Length.ToString();
                _inputHoleDiameter.Text = step4Params.HoleDiameter.ToString();
                _inputVerticalHoleOffset.Text = step4Params.VerticalHoleOffset.ToString();
                _inputHorizontalHoleOffset.Text = step4Params.HorizontalHoleOffset.ToString();
            }
        }

        #endregion

        #region Protected Overrided Methods

        protected override void ConfigureTableLayout()
        {
            tableLayoutFixtureStepControls.Controls.Clear();

            ConfigureTableStructure();

            AddGeneralParametersGroup(1);

            AddHoleParametersGroup(2);

            AddButtons(4, 5);
        }

        #endregion

        #region Private Methods

        private void ConfigureTableStructure()
        {
            tableLayoutFixtureStepControls.RowCount = 5;
            tableLayoutFixtureStepControls.RowStyles.Clear();
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        private void AddGeneralParametersGroup(int row)
        {
            var (groupBox, tableLayout) = CreateParametersPanel("Общее", 3);

            _inputWidth = AddParameter(
                tableLayout,
                "D1 (Ширина, мм):",
                ConductorStep4Params.DefaultWidth.ToString(),
                0
            ).textBox;

            _inputHeight = AddParameter(
                tableLayout,
                "D2 (Высота, мм):",
                ConductorStep4Params.DefaultHeight.ToString(),
                1
            ).textBox;

            _inputLength = AddParameter(
                tableLayout,
                "D3 (Длина, мм):",
                ConductorStep4Params.DefaultLength.ToString(),
                2
            ).textBox;

            groupBox.Controls.Add(tableLayout);
            tableLayoutFixtureStepControls.Controls.Add(groupBox, 0, row - 1);
        }

        private void AddHoleParametersGroup(int row)
        {
            var (groupBox, tableLayout) = CreateParametersPanel("Отверстия", 3);

            _inputHoleDiameter = AddParameter(
                tableLayout,
                "L1 (Диаметр, мм):",
                ConductorStep4Params.DefaultHoleDiameter.ToString(),
                0
            ).textBox;

            _inputVerticalHoleOffset = AddParameter(
                tableLayout,
                "L2 (Верт. отступ, мм):",
                ConductorStep4Params.DefaultVerticalHoleOffset.ToString(),
                1
            ).textBox;

            _inputHorizontalHoleOffset = AddParameter(
                tableLayout,
                "L3 (Горизонт. отступ, мм):",
                ConductorStep4Params.DefaultHorizontalHoleOffset.ToString(),
                2
            ).textBox;

            groupBox.Controls.Add(tableLayout);
            tableLayoutFixtureStepControls.Controls.Add(groupBox, 0, row - 1);
        }      

        private void AddButtons(int btnCancelRow, int btnBuildStepRow)
        {
            tableLayoutFixtureStepControls.Controls.Add(btnCancel, 0, btnCancelRow - 1);
            tableLayoutFixtureStepControls.Controls.Add(btnBuildStep, 0, btnBuildStepRow - 1);
        }

        #endregion
    }
}

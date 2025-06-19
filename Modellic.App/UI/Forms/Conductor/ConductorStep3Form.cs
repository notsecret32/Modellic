using Modellic.App.Core.Models.Conductor.Parameters;
using Modellic.App.Core.Services;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Modellic.App.UI.Forms.Conductor
{
    public partial class ConductorStep3Form : ConductorBaseForm
    {
        #region General Form Controls

        private TextBox _inputWidth;

        private TextBox _inputHeight;

        private TextBox _inputChamferWidth;

        private TextBox _inputChamferAngle;

        private TextBox _inputFilletRadius;

        #endregion

        #region Hole Form Controls

        private TextBox _inputHoleDiameter;

        private TextBox _inputHoleOffset;

        private TextBox _inputMountingHolePaddingX;

        private TextBox _inputMountingHolePaddingY;

        private TextBox _inputMountingHoleGap;

        private TextBox _inputBackHoleDiameter;

        private TextBox _inputBackHoleThickness;

        #endregion

        #region Constructor

        public ConductorStep3Form()
        {
            InitializeComponent();

            pictureFixtureStep.Image = Image.FromFile(Path.Combine(ResourceManager.ImagesDirectory, "FixtureStep1.png"));
        }

        #endregion

        #region Public Overrided Methods

        public override ConductorBaseParams GetParameters()
        {
            return new ConductorStep3Params
            {
                Width = double.Parse(_inputWidth.Text),
                Height = double.Parse(_inputHeight.Text),
                ChamferWidth = double.Parse(_inputChamferWidth.Text),
                ChamferAngle = double.Parse(_inputChamferAngle.Text),
                FilletRadius = double.Parse(_inputFilletRadius.Text),
                HoleDiameter = int.Parse(_inputHoleDiameter.Text),
                HoleOffset = double.Parse(_inputHoleOffset.Text),
                MountingHolePaddingX = double.Parse(_inputMountingHolePaddingX.Text),
                MountingHolePaddingY = double.Parse(_inputMountingHolePaddingY.Text),
                MountingHoleGap = double.Parse(_inputMountingHoleGap.Text),
                BackHoleDiameter = double.Parse(_inputBackHoleDiameter.Text),
                BackHoleThickness = double.Parse(_inputBackHoleThickness.Text)
            };
        }

        public override void SetParameters(ConductorBaseParams parameters)
        {
            if (parameters is ConductorStep3Params step3Params)
            {
                _inputWidth.Text = step3Params.Width.ToString();
                _inputHeight.Text = step3Params.Height.ToString();
                _inputWidth.Text = step3Params.ChamferWidth.ToString();
                _inputChamferAngle.Text = step3Params.ChamferAngle.ToString();
                _inputFilletRadius.Text = step3Params.FilletRadius.ToString();
                _inputHoleDiameter.Text = step3Params.HoleDiameter.ToString();
                _inputHoleOffset.Text = step3Params.HoleOffset.ToString();
                _inputMountingHolePaddingX.Text = step3Params.MountingHolePaddingX.ToString();
                _inputMountingHolePaddingY.Text = step3Params.MountingHolePaddingY.ToString();
                _inputMountingHoleGap.Text = step3Params.MountingHoleGap.ToString();
                _inputBackHoleDiameter.Text = step3Params.BackHoleDiameter.ToString();
                _inputBackHoleThickness.Text = step3Params.BackHoleThickness.ToString();
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
            var (groupBox, tableLayout) = CreateParametersPanel("Общее", 5);

            _inputWidth = AddParameter(
                tableLayout,
                "D1 (Ширина, мм):",
                ConductorStep3Params.DefaultWidth.ToString(),
                0
            ).textBox;

            _inputHeight = AddParameter(
                tableLayout,
                "D2 (Высота, мм):",
                ConductorStep3Params.DefaultHeight.ToString(),
                1
            ).textBox;

            _inputChamferWidth = AddParameter(
                tableLayout,
                "D3 (Ширина фаски, мм):",
                ConductorStep3Params.DefaultChamferWidth.ToString(),
                2
            ).textBox;

            _inputChamferAngle = AddParameter(
                tableLayout,
                "D4 (Угол фаски, мм):",
                ConductorStep3Params.DefaultChamferAngle.ToString(),
                3
            ).textBox;

            _inputFilletRadius = AddParameter(
                tableLayout,
                "D5 (Радиус скругл., мм):",
                ConductorStep3Params.DefaultFilletRadius.ToString(),
                4
            ).textBox;

            groupBox.Controls.Add(tableLayout);
            tableLayoutFixtureStepControls.Controls.Add(groupBox, 0, row - 1);
        }

        private void AddHoleParametersGroup(int row)
        {
            var (groupBox, tableLayout) = CreateParametersPanel("Отверстия", 7);

            _inputHoleDiameter = AddParameter(
                tableLayout,
                "L1 (Диаметр, мм):",
                ConductorStep3Params.DefaultWidth.ToString(),
                0
            ).textBox;

            _inputHoleOffset = AddParameter(
                tableLayout,
                "L2 (Отступ, мм):",
                ConductorStep3Params.DefaultHeight.ToString(),
                1
            ).textBox;

            _inputMountingHolePaddingX = AddParameter(
                tableLayout,
                "L3 (Отступ X, мм):",
                ConductorStep3Params.DefaultChamferWidth.ToString(),
                2
            ).textBox;

            _inputMountingHolePaddingY = AddParameter(
                tableLayout,
                "L4 (Отступ Y, гр):",
                ConductorStep3Params.DefaultChamferAngle.ToString(),
                3
            ).textBox;

            _inputMountingHoleGap = AddParameter(
                tableLayout,
                "L5 (Промежуток, мм):",
                ConductorStep3Params.DefaultFilletRadius.ToString(),
                4
            ).textBox;

            _inputBackHoleDiameter = AddParameter(
                tableLayout,
                "L5 (Диаметр, мм):",
                ConductorStep3Params.DefaultFilletRadius.ToString(),
                5
            ).textBox;

            _inputBackHoleThickness = AddParameter(
                tableLayout,
                "L5 (Глубина, мм):",
                ConductorStep3Params.DefaultFilletRadius.ToString(),
                6
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

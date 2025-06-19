using Modellic.App.Core.Models.Conductor.Parameters;
using Modellic.App.Core.Services;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Modellic.App.UI.Forms.Conductor
{
    public partial class ConductorStep2Form : ConductorBaseForm
    {
        #region General Form Controls

        private TextBox _inputDiameter;

        private TextBox _inputChamferWidth;

        private TextBox _inputChamferAngle;

        private TextBox _inputOffset;

        private TextBox _inputThickness;

        #endregion

        #region Hole Form Controls

        private TextBox _inputHoleQuanity;

        private TextBox _inputHoleDiameter;

        #endregion

        #region Cutout Form Controls

        private TextBox _inputCutoutOffset;

        private TextBox _inputCutoutThickness;

        private TextBox _inputCutoutDepth;

        #endregion

        #region Constructor

        public ConductorStep2Form()
        {
            InitializeComponent();

            pictureFixtureStep.Image = Image.FromFile(Path.Combine(ResourceManager.ImagesDirectory, "FixtureStep1.png"));
        }

        #endregion

        #region Public Overrided Methods

        public override ConductorBaseParams GetParameters()
        {
            return new ConductorStep2Params
            {
                Diameter = double.Parse(_inputDiameter.Text),
                ChamferWidth = double.Parse(_inputChamferWidth.Text),
                ChamferAngle = double.Parse(_inputChamferAngle.Text),
                Offset = double.Parse(_inputOffset.Text),
                Thickness = double.Parse(_inputThickness.Text),
                HoleQuantity = int.Parse(_inputHoleQuanity.Text),
                HoleDiameter = double.Parse(_inputHoleDiameter.Text),
                CutoutOffset = double.Parse(_inputCutoutOffset.Text),
                CutoutThickness = double.Parse(_inputCutoutThickness.Text),
                CutoutDepth = double.Parse(_inputCutoutDepth.Text)
            };
        }

        public override void SetParameters(ConductorBaseParams parameters)
        {
            if (parameters is ConductorStep2Params step2Params)
            {
                _inputDiameter.Text = step2Params.Diameter.ToString();
                _inputChamferWidth.Text = step2Params.ChamferWidth.ToString();
                _inputChamferAngle.Text = step2Params.ChamferAngle.ToString();
                _inputOffset.Text = step2Params.Offset.ToString();
                _inputThickness.Text = step2Params.Thickness.ToString();
                _inputHoleQuanity.Text = step2Params.HoleQuantity.ToString();
                _inputHoleDiameter.Text = step2Params.HoleDiameter.ToString();
                _inputCutoutOffset.Text = step2Params.CutoutOffset.ToString();
                _inputCutoutThickness.Text = step2Params.CutoutThickness.ToString();
                _inputCutoutDepth.Text = step2Params.CutoutDepth.ToString();
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

            AddCutoutParametersGroup(3);

            AddButtons(5, 6);
        }

        #endregion

        #region Private Methods

        private void ConfigureTableStructure()
        {
            tableLayoutFixtureStepControls.RowCount = 6;
            tableLayoutFixtureStepControls.RowStyles.Clear();
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        private void AddGeneralParametersGroup(int row)
        {
            var (groupBox, tableLayout) = CreateParametersPanel("Общее", 5);

            _inputDiameter = AddParameter(
                tableLayout,
                "D1 (Диаметр, мм):",
                ConductorStep2Params.DefaultDiameter.ToString(),
                0
            ).textBox;

            _inputChamferWidth = AddParameter(
                tableLayout,
                "D2 (Ширина фаски, мм):",
                ConductorStep2Params.DefaultChamferWidth.ToString(),
                1
            ).textBox;

            _inputChamferAngle = AddParameter(
                tableLayout,
                "D3 (Угол фаски, гр):",
                ConductorStep2Params.DefaultChamferAngle.ToString(),
                2
            ).textBox;

            _inputOffset = AddParameter(
                tableLayout,
                "D4 (Отступ, мм):",
                ConductorStep2Params.DefaultOffset.ToString(),
                3
            ).textBox;

            _inputThickness = AddParameter(
                tableLayout,
                "D5 (Глубина, мм):",
                ConductorStep2Params.DefaultThickness.ToString(),
                4
            ).textBox;

            groupBox.Controls.Add(tableLayout);
            tableLayoutFixtureStepControls.Controls.Add(groupBox, 0, row - 1);
        }
       
        private void AddHoleParametersGroup(int row)
        {
            var (groupBox, tableLayout) = CreateParametersPanel("Отверстия", 2);

            _inputHoleQuanity = AddParameter(
                tableLayout,
                "L1 (Кол-во):",
                ConductorStep2Params.DefaultHoleQuantity.ToString(),
                0
            ).textBox;

            _inputHoleDiameter = AddParameter(
                tableLayout,
                "L2 (Диаметр, мм):",
                ConductorStep2Params.DefaultHoleDiameter.ToString(),
                1
            ).textBox;

            groupBox.Controls.Add(tableLayout);
            tableLayoutFixtureStepControls.Controls.Add(groupBox, 0, row - 1);
        }

        private void AddCutoutParametersGroup(int row)
        {
            var (groupBox, tableLayout) = CreateParametersPanel("Вырез", 3);

            _inputCutoutOffset = AddParameter(
                tableLayout,
                "P1 (Отступ, мм):",
                ConductorStep2Params.DefaultCutoutOffset.ToString(),
                0
            ).textBox;

            _inputCutoutThickness = AddParameter(
                tableLayout,
                "P2 (Толщина, мм):",
                ConductorStep2Params.DefaultCutoutThickness.ToString(),
                1
            ).textBox;

            _inputCutoutDepth = AddParameter(
                tableLayout,
                "P3 (Глубина, мм):",
                ConductorStep2Params.DefaultCutoutDepth.ToString(),
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

using Modellic.App.Core.Models.Conductor.Parameters;
using Modellic.App.Core.Services;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Modellic.App.UI.Forms.Conductor
{
    public partial class ConductorStep1Form : ConductorBaseForm
    {
        #region General Form Controls

        private TextBox _inputDiameter;

        private TextBox _inputWidth;

        private TextBox _inputThickness;

        #endregion

        #region Mount Form Controls

        private TextBox _inputMountWidth;

        private TextBox _inputMountHeight;

        private TextBox _inputMountQuantity;

        private TextBox _inputMountHoleDiameter;

        private TextBox _inputMountFillerRadius;

        #endregion

        #region Constructor

        public ConductorStep1Form()
        {
            InitializeComponent();

            pictureFixtureStep.Image = Image.FromFile(Path.Combine(ResourceManager.ImagesDirectory, "FixtureStep1.png"));
        }

        #endregion

        #region Public Overrided Methods

        public override ConductorBaseParams GetParameters()
        {
            return new ConductorStep1Params
            {
                Diameter = double.Parse(_inputDiameter.Text),
                Width = double.Parse(_inputWidth.Text),
                Thickness = double.Parse(_inputThickness.Text),
                MountWidth = double.Parse(_inputMountWidth.Text),
                MountHeight = double.Parse(_inputMountHeight.Text),
                Quantity = int.Parse(_inputMountQuantity.Text),
                HoleDiameter = double.Parse(_inputMountHoleDiameter.Text),
                FilletRadius = double.Parse(_inputMountFillerRadius.Text),
            };
        }

        public override void SetParameters(ConductorBaseParams parameters)
        {
            if (parameters is ConductorStep1Params step1Params)
            {
                _inputDiameter.Text = step1Params.Diameter.ToString();
                _inputWidth.Text = step1Params.Width.ToString();
                _inputThickness.Text = step1Params.Thickness.ToString();
                _inputMountWidth.Text = step1Params.MountWidth.ToString();
                _inputMountHeight.Text = step1Params.MountHeight.ToString();
                _inputMountQuantity.Text = step1Params.Quantity.ToString();
                _inputMountHoleDiameter.Text = step1Params.HoleDiameter.ToString();
                _inputMountFillerRadius.Text = step1Params.FilletRadius.ToString();
            }
        }

        #endregion

        #region Protected Overrided Methods

        protected override void ConfigureTableLayout()
        {
            tableLayoutFixtureStepControls.Controls.Clear();

            ConfigureTableStructure();

            AddGeneralParametersGroup();

            AddMountParametersGroup();

            AddButtons();
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

        private void AddGeneralParametersGroup()
        {
            var (groupBox, tableLayout) = CreateParametersPanel("Общее", 3);

            _inputDiameter = AddParameter(
                tableLayout,
                "D1 (Диаметр, мм):",
                ConductorStep1Params.DefaultDiameter.ToString(),
                0
            ).textBox;

            _inputWidth = AddParameter(
                tableLayout,
                "D2 (Ширина, мм):",
                ConductorStep1Params.DefaultWidth.ToString(),
                1
            ).textBox;

            _inputThickness = AddParameter(
                tableLayout,
                "D3 (Глубина, мм):",
                ConductorStep1Params.DefaultThickness.ToString(),
                2
            ).textBox;

            groupBox.Controls.Add(tableLayout);
            tableLayoutFixtureStepControls.Controls.Add(groupBox, 0, 0);
        }

        private void AddMountParametersGroup()
        {
            var (groupBoxMount, tableLayoutMount) = CreateParametersPanel("Крепление", 5);

            _inputMountWidth = AddParameter(
                tableLayoutMount,
                "D1 (Ширина, мм):",
                ConductorStep1Params.DefaultMountWidth.ToString(),
                0
            ).textBox;

            _inputMountHeight = AddParameter(
                tableLayoutMount,
                "D2 (Высота, мм):",
                ConductorStep1Params.DefaultMountHeight.ToString(),
                1
            ).textBox;

            _inputMountQuantity = AddParameter(
                tableLayoutMount,
                "D3 (Кол-во, число):",
                ConductorStep1Params.DefaultQuantity.ToString(),
                2
            ).textBox;

            _inputMountHoleDiameter = AddParameter(
                tableLayoutMount,
                "D4 (Диаметр, мм):",
                ConductorStep1Params.DefaultHoleDiameter.ToString(),
                3
            ).textBox;

            _inputMountFillerRadius = AddParameter(
                tableLayoutMount,
                "D5 (Радиус скругления, мм):",
                ConductorStep1Params.DefaultFilletRadius.ToString(),
                4
            ).textBox;

            groupBoxMount.Controls.Add(tableLayoutMount);
            tableLayoutFixtureStepControls.Controls.Add(groupBoxMount, 0, 1);
        }

        private void AddButtons()
        {
            tableLayoutFixtureStepControls.Controls.Add(btnCancel, 0, 3);
            tableLayoutFixtureStepControls.Controls.Add(btnBuildStep, 0, 4);
        }

        #endregion
    }
}

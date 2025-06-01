using Modellic.App.Core.Models.Fixture.Parameters;
using Modellic.App.Core.Services;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Modellic.App.UI.Forms
{
    public partial class FixtureStep2Form : FixtureStepBaseForm
    {
        #region Private Form Elements

        private TextBox _inputMountWidth;

        private TextBox _inputMountHeight;

        private TextBox _inputMountQuantity;

        private TextBox _inputMountHoleDiameter;

        private TextBox _inputMountFillerRadius;

        #endregion

        #region Constructor

        public FixtureStep2Form()
        {
            InitializeComponent();

            pictureFixtureStep.Image = Image.FromFile(Path.Combine(ResourceManager.ImagesDirectory, "FixtureStep1.png"));
        }

        #endregion

        #region Public Overrided Methods

        public override FixtureStepParameters GetParameters()
        {
            return new FixtureStep2Parameters
            {
                MountWidth = double.Parse(_inputMountWidth.Text),
                MountHeight = double.Parse(_inputMountHeight.Text),
                Quantity = int.Parse(_inputMountQuantity.Text),
                HoleDiameter = double.Parse(_inputMountHoleDiameter.Text),
                FilletRadius = double.Parse(_inputMountFillerRadius.Text),
            };
        }

        public override void SetParameters(FixtureStepParameters parameters)
        {
            if (parameters is FixtureStep2Parameters step2Params)
            {
                _inputMountWidth.Text = step2Params.MountWidth.ToString();
                _inputMountHeight.Text = step2Params.MountHeight.ToString();
                _inputMountQuantity.Text = step2Params.Quantity.ToString();
                _inputMountHoleDiameter.Text = step2Params.HoleDiameter.ToString();
                _inputMountFillerRadius.Text = step2Params.FilletRadius.ToString();
            }
        }

        #endregion

        #region Protected Overrided Methods

        protected override void ConfigureTableLayout()
        {
            // Сохраняем кнопки, которые нужно перенести
            var btnCancel = this.btnCancel;
            var btnBuildStep = this.btnBuildStep;

            // Удаляем все контролы из таблицы
            tableLayoutFixtureStepControls.Controls.Clear();

            // Настраиваем таблицу
            tableLayoutFixtureStepControls.RowCount = 4;
            tableLayoutFixtureStepControls.RowStyles.Clear();
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); 
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var (groupBox, tableLayout) = CreateParametersPanel("Общее", 5);

            _inputMountWidth = AddParameter(
                tableLayout,
                "D1 (Ширина, мм):",
                FixtureStep2Parameters.DefaultMountWidth.ToString(),
                0
            ).textBox;

            _inputMountHeight = AddParameter(
                tableLayout,
                "D2 (Высота, мм):",
                FixtureStep2Parameters.DefaultMountHeight.ToString(),
                1
            ).textBox;

            _inputMountQuantity = AddParameter(
                tableLayout,
                "D3 (Кол-во, число):",
                FixtureStep2Parameters.DefaultQuantity.ToString(),
                2
            ).textBox;

            _inputMountHoleDiameter = AddParameter(
                tableLayout,
                "D4 (Диаметр, мм):",
                FixtureStep2Parameters.DefaultHoleDiameter.ToString(),
                3
            ).textBox;

            _inputMountFillerRadius = AddParameter(
                tableLayout,
                "D5 (Радиус скругления, мм):",
                FixtureStep2Parameters.DefaultFilletRadius.ToString(),
                4
            ).textBox;

            groupBox.Controls.Add(tableLayout);
            tableLayoutFixtureStepControls.Controls.Add(groupBox, 0, 0);

            // Добавляем кнопки в последние две строки
            tableLayoutFixtureStepControls.Controls.Add(btnCancel, 0, 2);
            tableLayoutFixtureStepControls.Controls.Add(btnBuildStep, 0, 3);
        }

        #endregion
    }
}

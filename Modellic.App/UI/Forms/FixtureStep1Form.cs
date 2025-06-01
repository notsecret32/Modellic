using Modellic.App.Core.Models.Fixture.Parameters;
using Modellic.App.Core.Services;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Modellic.App.UI.Forms
{
    public partial class FixtureStep1Form : FixtureStepBaseForm
    {
        #region Private Form Elements
        
        private TextBox _inputDiameter;

        private TextBox _inputWidth;

        private TextBox _inputThickness;

        #endregion

        #region Constructor

        public FixtureStep1Form()
        {
            InitializeComponent();

            pictureFixtureStep.Image = Image.FromFile(Path.Combine(ResourceManager.ImagesDirectory, "FixtureStep1.png"));
        }

        #endregion

        #region Public Overrided Methods

        public override FixtureStepParameters GetParameters()
        {
            return new FixtureStep1Parameters
            {
                Diameter = double.Parse(_inputDiameter.Text),
                Width = double.Parse(_inputWidth.Text),
                Thickness = double.Parse(_inputThickness.Text),
            };
        }

        public override void SetParameters(FixtureStepParameters parameters)
        {
            if (parameters is FixtureStep1Parameters step1Params)
            {
                _inputDiameter.Text = step1Params.Diameter.ToString();
                _inputWidth.Text = step1Params.Width.ToString();
                _inputThickness.Text = step1Params.Thickness.ToString();
            }
        }

        #endregion

        #region Protected Overrided Methods

        protected override void ConfigureTableLayout()
        {
            // Удаляем все контролы из таблицы
            tableLayoutFixtureStepControls.Controls.Clear();

            // Настраиваем таблицу
            tableLayoutFixtureStepControls.RowCount = 4; 
            tableLayoutFixtureStepControls.RowStyles.Clear();
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); 
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); 
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); 

            var (groupBox, tableLayout) = CreateParametersPanel("Общее", 3);

            // Инициализируем TextBox'ы и добавляем их
            _inputDiameter = AddParameter(
                tableLayout,
                "D1 (Диаметр, мм):",
                FixtureStep1Parameters.DefaultDiameter.ToString(),
                0
            ).textBox;

            _inputWidth = AddParameter(
                tableLayout,
                "D2 (Ширина, мм):",
                FixtureStep1Parameters.DefaultWidth.ToString(),
                1
            ).textBox;

            _inputThickness = AddParameter(
                tableLayout,
                "D3 (Глубина, мм):",
                FixtureStep1Parameters.DefaultThickness.ToString(),
                2
            ).textBox;

            groupBox.Controls.Add(tableLayout);
            tableLayoutFixtureStepControls.Controls.Add(groupBox, 0, 0);

            // Добавляем кнопки
            tableLayoutFixtureStepControls.Controls.Add(btnCancel, 0, 2);
            tableLayoutFixtureStepControls.Controls.Add(btnBuildStep, 0, 3);
        }

        #endregion
    }
}

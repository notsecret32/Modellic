using Modellic.App.Core.Models.Fixture.Parameters;
using Modellic.App.Core.Services;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Modellic.App.UI.Forms
{
    public partial class FixtureStep3Form : FixtureStepBaseForm
    {
        #region Private Form Elements

        private TextBox _inputDiameter;

        private TextBox _inputChamferWidth;

        private TextBox _inputChamferAngleDeg;

        private TextBox _inputOffset;

        private TextBox _inputThickness;

        private TextBox _inputHoleQuanity;

        private TextBox _inputHoleDiameter;

        private TextBox _inputCutoutOffset;

        private TextBox _inputCutoutThickness;

        private TextBox _inputCutoutDepth;

        #endregion

        #region Constructor

        public FixtureStep3Form()
        {
            InitializeComponent();

            pictureFixtureStep.Image = Image.FromFile(Path.Combine(ResourceManager.ImagesDirectory, "FixtureStep1.png"));
        }

        #endregion

        #region Public Overrided Methods

        public override FixtureStepParameters GetParameters()
        {
            return new FixtureStep3Parameters
            {
                Diameter        = double.Parse(_inputDiameter.Text),
                ChamferWidth    = double.Parse(_inputChamferWidth.Text),
                ChamferAngleDeg = double.Parse(_inputChamferAngleDeg.Text),
                Offset          = double.Parse(_inputOffset.Text),
                Thickness       = double.Parse(_inputThickness.Text),
                HoleQuanity     = int.Parse(_inputHoleQuanity.Text),
                HoleDiameter    = double.Parse(_inputHoleDiameter.Text),
                CutoutOffset    = double.Parse(_inputCutoutOffset.Text),
                CutoutThickness = double.Parse(_inputCutoutThickness.Text),
                CutoutDepth     = double.Parse(_inputCutoutDepth.Text)
            };
        }

        public override void SetParameters(FixtureStepParameters parameters)
        {
            if (parameters is FixtureStep3Parameters step3Params)
            {
                _inputDiameter.Text         = step3Params.Diameter.ToString();
                _inputChamferWidth.Text     = step3Params.ChamferWidth.ToString();
                _inputChamferAngleDeg.Text  = step3Params.ChamferAngleDeg.ToString();
                _inputOffset.Text           = step3Params.Offset.ToString();
                _inputThickness.Text        = step3Params.Thickness.ToString();
                _inputHoleQuanity.Text      = step3Params.HoleQuanity.ToString();
                _inputHoleDiameter.Text     = step3Params.HoleDiameter.ToString();
                _inputCutoutOffset.Text     = step3Params.CutoutOffset.ToString();
                _inputCutoutThickness.Text  = step3Params.CutoutThickness.ToString();
                _inputCutoutDepth.Text      = step3Params.CutoutDepth.ToString();
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
            tableLayoutFixtureStepControls.RowCount = 6;
            tableLayoutFixtureStepControls.RowStyles.Clear();
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 1 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 1 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 1 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); 
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); 
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Добавляем общую группу
            var (generalGroup, generalTableLayout) = CreateParametersPanel("Общее", 5);

            _inputDiameter = AddParameter(
                generalTableLayout,
                "D1 (Диаметр, мм):",
                FixtureStep3Parameters.DefaultDiameter.ToString(),
                0
            ).textBox;

            _inputChamferWidth = AddParameter(
                generalTableLayout,
                "D2 (Ширина фаски, мм):",
                FixtureStep3Parameters.DefaultChamferWidth.ToString(),
                1
            ).textBox;

            _inputChamferAngleDeg = AddParameter(
                generalTableLayout,
                "D3 (Угол фаски, °):",
                FixtureStep3Parameters.DefaultChamferAngleDeg.ToString(),
                2
            ).textBox;

            _inputOffset = AddParameter(
                generalTableLayout,
                "D4 (Отступ, мм):",
                FixtureStep3Parameters.DefaultOffset.ToString(),
                3
            ).textBox;

            _inputThickness = AddParameter(
                generalTableLayout,
                "D5 (Толщина, мм):",
                FixtureStep3Parameters.DefaultThickness.ToString(),
                4
            ).textBox;

            generalGroup.Controls.Add(generalTableLayout);
            tableLayoutFixtureStepControls.Controls.Add(generalGroup, 0, 0);

            // Добавляем группу с отверстиями
            var (holeGroup, holeTableLayout) = CreateParametersPanel("Отверстие", 2);

            _inputHoleDiameter = AddParameter(
                holeTableLayout,
                "L1 (Диаметр, мм):",
                FixtureStep3Parameters.DefaultHoleDiameter.ToString(),
                0
            ).textBox;

            _inputHoleQuanity = AddParameter(
                holeTableLayout,
                "L1 (Кол-во, число):",
                FixtureStep3Parameters.DefaultHoleQuanity.ToString(),
                1
            ).textBox;

            holeGroup.Controls.Add(holeTableLayout);
            tableLayoutFixtureStepControls.Controls.Add(holeGroup, 0, 1);

            // Добавляем группу вырез
            var (cutoutGroup, cutoutTableLayout) = CreateParametersPanel("Вырез", 3);

            _inputCutoutOffset = AddParameter(
                cutoutTableLayout,
                "A1 (Смещение, мм):",
                FixtureStep3Parameters.DefaultCutoutOffset.ToString(),
                0
            ).textBox;

            _inputCutoutDepth = AddParameter(
                cutoutTableLayout,
                "A2 (Глубина, мм):",
                FixtureStep3Parameters.DefaultCutoutDepth.ToString(),
                1
            ).textBox;

            _inputCutoutThickness = AddParameter(
                cutoutTableLayout,
                "A3 (Толщина, мм):",
                FixtureStep3Parameters.DefaultCutoutThickness.ToString(),
                2
            ).textBox;

            cutoutGroup.Controls.Add(cutoutTableLayout);
            tableLayoutFixtureStepControls.Controls.Add(cutoutGroup, 0, 2);

            // Добавляем кнопки в последние две строки
            tableLayoutFixtureStepControls.Controls.Add(btnCancel, 0, 4);
            tableLayoutFixtureStepControls.Controls.Add(btnBuildStep, 0, 5);
        }

        #endregion
    }
}

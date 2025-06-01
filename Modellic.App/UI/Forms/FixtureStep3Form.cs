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

        private GroupBox _groupGeneral;

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
            tableLayoutFixtureStepControls.RowCount = 4;
            tableLayoutFixtureStepControls.RowStyles.Clear();
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 1 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // 2 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 3 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 4 строка

            // Настраиваем главную группу
            ConfigureGeneralGroup();
            tableLayoutFixtureStepControls.Controls.Add(_groupGeneral, 0, 0);

            // Добавляем кнопки в последние две строки
            tableLayoutFixtureStepControls.Controls.Add(btnCancel, 0, 2);
            tableLayoutFixtureStepControls.Controls.Add(btnBuildStep, 0, 3);
        }

        #endregion

        #region Private Methods

        private void ConfigureGeneralGroup()
        {
            _groupGeneral = new GroupBox
            {
                Text = "Общее",
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(4)
            };

            var innerTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 10,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };

            innerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            innerTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            innerTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            innerTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            innerTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            innerTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            innerTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            innerTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            innerTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            innerTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            innerTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            innerTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // ===== Строка 1 =====
            innerTable.Controls.Add(new Label
            {
                Text = "D1 (Диаметр, мм):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);

            _inputDiameter = new TextBox
            {
                Text = FixtureStep3Parameters.DefaultDiameter.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputDiameter, 1, 0);

            // ===== Строка 2 =====
            innerTable.Controls.Add(new Label
            {
                Text = "D2 (Ширина фаски, мм):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 1);

            _inputChamferWidth = new TextBox
            {
                Text = FixtureStep3Parameters.DefaultChamferWidth.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputChamferWidth, 1, 1);

            // ===== Строка 3 =====
            innerTable.Controls.Add(new Label
            {
                Text = "D3 (Угол фаски, градус):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 2);

            _inputChamferAngleDeg = new TextBox
            {
                Text = FixtureStep3Parameters.DefaultChamferAngleDeg.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputChamferAngleDeg, 1, 2);

            // ===== Строка 4 =====
            innerTable.Controls.Add(new Label
            {
                Text = "D4 (Смещение, мм):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 3);

            _inputOffset = new TextBox
            {
                Text = FixtureStep3Parameters.DefaultOffset.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputOffset, 1, 3);

            // ===== Строка 5 =====
            innerTable.Controls.Add(new Label
            {
                Text = "D5 (Толщина, мм):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 4);

            _inputThickness = new TextBox
            {
                Text = FixtureStep3Parameters.DefaultThickness.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputThickness, 1, 4);

            // ===== Строка 6 =====
            innerTable.Controls.Add(new Label
            {
                Text = "D6 (Кол-во отвестий, число):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 5);

            _inputHoleQuanity = new TextBox
            {
                Text = FixtureStep3Parameters.DefaultHoleQuanity.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputHoleQuanity, 1, 5);

            // ===== Строка 7 =====
            innerTable.Controls.Add(new Label
            {
                Text = "D7 (Диаметр отверстий, мм):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 6);

            _inputHoleDiameter = new TextBox
            {
                Text = FixtureStep3Parameters.DefaultHoleDiameter.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputHoleDiameter, 1, 6);

            // ===== Строка 8 =====
            innerTable.Controls.Add(new Label
            {
                Text = "D8 (Смещение выреза, мм):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 7);

            _inputCutoutOffset = new TextBox
            {
                Text = FixtureStep3Parameters.DefaultCutoutOffset.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputCutoutOffset, 1, 7);

            // ===== Строка 9 =====
            innerTable.Controls.Add(new Label
            {
                Text = "D9 (Глубина выреза, мм):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 8);

            _inputCutoutDepth = new TextBox
            {
                Text = FixtureStep3Parameters.DefaultCutoutDepth.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputCutoutDepth, 1, 8);

            // ===== Строка 10 =====
            innerTable.Controls.Add(new Label
            {
                Text = "D10 (Толщина выреза, мм):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 9);

            _inputCutoutThickness = new TextBox
            {
                Text = FixtureStep3Parameters.DefaultCutoutThickness.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputCutoutThickness, 1, 9);

            // ===== Конец =====
            _groupGeneral.Controls.Add(innerTable);
        }

        #endregion
    }
}

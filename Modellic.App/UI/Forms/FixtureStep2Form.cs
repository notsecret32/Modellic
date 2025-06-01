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

        private GroupBox _groupMount;

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
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 1 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // 2 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 3 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 4 строка

            // Настраиваем группу крепление
            ConfigureMountGroup();
            tableLayoutFixtureStepControls.Controls.Add(_groupMount, 0, 0);

            // Добавляем кнопки в последние две строки
            tableLayoutFixtureStepControls.Controls.Add(btnCancel, 0, 2);
            tableLayoutFixtureStepControls.Controls.Add(btnBuildStep, 0, 3);
        }

        #endregion

        #region Private Methods

        private void ConfigureMountGroup()
        {
            _groupMount = new GroupBox
            {
                Text = "Крепление",
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(4)
            };

            var innerTable = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 5,
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

            // Строка 1
            innerTable.Controls.Add(new Label
            {
                Text = "Ширина:",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);

            _inputMountWidth = new TextBox
            {
                Text = FixtureStep2Parameters.DefaultMountWidth.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputMountWidth, 1, 0);

            // Строка 2
            innerTable.Controls.Add(new Label
            {
                Text = "Высота:",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 1);

            _inputMountHeight = new TextBox
            {
                Text = FixtureStep2Parameters.DefaultMountHeight.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputMountHeight, 1, 1);

            // Строка 3
            innerTable.Controls.Add(new Label
            {
                Text = "Количество:",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 2);

            _inputMountQuantity = new TextBox
            {
                Text = FixtureStep2Parameters.DefaultQuantity.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputMountQuantity, 1, 2);

            // Строка 4
            innerTable.Controls.Add(new Label
            {
                Text = "Диаметр отверстия:",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 3);

            _inputMountHoleDiameter = new TextBox
            {
                Text = FixtureStep2Parameters.DefaultHoleDiameter.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputMountHoleDiameter, 1, 3);

            // Строка 5
            innerTable.Controls.Add(new Label
            {
                Text = "Радиус скругления:",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 4);

            _inputMountFillerRadius = new TextBox
            {
                Text = FixtureStep2Parameters.DefaultFilletRadius.ToString(),
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputMountFillerRadius, 1, 4);

            // Добавляем в группу
            _groupMount.Controls.Add(innerTable);
        }

        #endregion
    }
}

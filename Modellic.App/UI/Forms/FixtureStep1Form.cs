using Modellic.App.Core.Services;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Modellic.App.UI.Forms
{
    public partial class FixtureStep1Form : FixtureStepBaseForm
    {
        #region Private Form Elements

        private GroupBox _groupMount;

        private GroupBox _groupGeneral;

        private TextBox _inputDiameter;

        private TextBox _inputWidth;

        private TextBox _inputThickness;

        private TextBox _inputMountWidth;
        
        private TextBox _inputMountHeight;
        
        private TextBox _inputMountQuantity;

        private TextBox _inputMountHoleDiameter;
        
        private TextBox _inputMountFillerRadius;
        
        #endregion

        public FixtureStep1Form()
        {
            InitializeComponent();

            pictureFixtureStep.Image = Image.FromFile(Path.Combine(ResourceManager.ImagesDirectory, "FixtureStep1.png"));
        }

        #region Protected Overrided Methods

        protected override void ConfigureTableLayout()
        {
            base.ConfigureTableLayout();

            // Сохраняем кнопки, которые нужно перенести
            var btnCancel = this.btnCancel;
            var btnBuildStep = this.btnBuildStep;

            // Удаляем все контролы из таблицы
            tableLayoutFixtureStepControls.Controls.Clear();

            // Настраиваем таблицу
            tableLayoutFixtureStepControls.RowCount = 5;
            tableLayoutFixtureStepControls.RowStyles.Clear();
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 1 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 2 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // 3 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 4 строка
            tableLayoutFixtureStepControls.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 5 строка

            // Настраиваем главную группу
            ConfigureGeneralGroup();
            tableLayoutFixtureStepControls.Controls.Add(_groupGeneral, 0, 0);

            // Настраиваем группу крепление
            ConfigureMountGroup();
            tableLayoutFixtureStepControls.Controls.Add(_groupMount, 0, 1);

            // Добавляем кнопки в последние две строки
            tableLayoutFixtureStepControls.Controls.Add(btnCancel, 0, 3);
            tableLayoutFixtureStepControls.Controls.Add(btnBuildStep, 0, 4);
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
                RowCount = 3,
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

            innerTable.Controls.Add(new Label
            {
                Text = "Диаметр (D1):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 0);

            _inputDiameter = new TextBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputDiameter, 1, 0);

            innerTable.Controls.Add(new Label
            {
                Text = "Ширина (D2):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 1);

            _inputWidth = new TextBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputWidth, 1, 1);

            innerTable.Controls.Add(new Label
            {
                Text = "Глубина (D3):",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            }, 0, 2);

            _inputThickness = new TextBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };
            innerTable.Controls.Add(_inputThickness, 1, 2);

            _groupGeneral.Controls.Add(innerTable);
        }

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

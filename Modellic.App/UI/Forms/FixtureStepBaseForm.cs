using Modellic.App.Core.Models.Fixture.Parameters;
using System.Drawing;
using System.Windows.Forms;

namespace Modellic.App.UI.Forms
{
    public abstract partial class FixtureStepBaseForm : Form
    {
        #region Constructors

        public FixtureStepBaseForm()
        {
            InitializeComponent();
            ConfigureTableLayout();
        }

        #endregion

        #region Public Methods

        public T GetParameters<T>() where T : FixtureStepParameters
        {
            return (T)GetParameters();
        }

        #endregion

        #region Public Abstract Methods

        public abstract void SetParameters(FixtureStepParameters parameters);

        public abstract FixtureStepParameters GetParameters();

        #endregion

        #region Protected Methods

        protected (GroupBox, TableLayoutPanel) CreateParametersPanel(string title, int rowCount)
        {
            var groupBox = new GroupBox
            {
                Text = title,
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(4)
            };

            var tableLayout =  new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = rowCount,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0),
                Padding = new Padding(0),
            };

            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            for (int i = 0; i < rowCount; i++)
            {
                tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            return (groupBox, tableLayout);
        }

        protected (Label label, TextBox textBox) AddParameter(TableLayoutPanel panel, string text, string defaultValue, int row)
        {
            var label = new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var textBox = new TextBox
            {
                Text = defaultValue,
                Dock = DockStyle.Fill,
                Margin = new Padding(3, 0, 3, 5)
            };

            panel.Controls.Add(label, 0, row);
            panel.Controls.Add(textBox, 1, row);

            return (label, textBox);
        }

        #endregion

        #region Protected Abstract Methods

        protected abstract void ConfigureTableLayout();

        #endregion
    }
}

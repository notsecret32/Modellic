using System.ComponentModel;
using System.Windows.Forms;

namespace Modellic.UI.Controls
{
    [ToolboxItem(true)]
    [DesignerCategory("Custom")]
    public class StepsGridView : DataGridView
    {
        public StepsGridView()
        {
            // Базовые настройки
            Configure();

            // Добавляем дефолтные колонки
            AddDefaultColumns();
        }

        private void Configure()
        {
            this.AllowDrop = false;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = false;
        }

        private void AddDefaultColumns()
        {
            this.Columns.Clear();

            var cursorColumn = new DataGridViewTextBoxColumn
            {
                Name = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
            };

            var stepCountColumn = new DataGridViewTextBoxColumn
            {
                Name = "№ Шага",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
            };

            var statusColumn = new DataGridViewTextBoxColumn
            {
                Name = "Статус",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            };

            this.Columns.AddRange(cursorColumn, stepCountColumn, statusColumn);
        }
    }
}

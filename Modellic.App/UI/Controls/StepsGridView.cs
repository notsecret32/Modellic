using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Modellic.App.UI.Controls
{
    [ToolboxItem(true)]
    [DesignerCategory("Modellic")]
    public class StepsGridView : DataGridView
    {
        #region Constructors

        public StepsGridView()
        {
            // Базовые настройки
            Configure();

            if (!DesignMode)
            {
                // Добавляем дефолтные колонки
                AddDefaultColumns();
            }
        }

        #endregion

        #region Destructors

        ~StepsGridView()
        {
            this.Columns.Clear();

            this.Dispose();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Обноваляет строки очистих их до изменений. Для правильной работы необходимо каждый раз использовать цикл.
        /// </summary>
        /// <param name="action">Фукнция изменения строк.</param>
        public void Update(Action<StepsGridView> action)
        {
            this.Rows.Clear();

            action(this);
        }

        /// <summary>
        /// Обноваляет строки очистих их до изменений. Работает в цикле.
        /// </summary>
        /// <param name="action">Функция обновления. Принимает текущий элемент, текущий индекс, кол-во строк.</param>
        /// <param name="count">Количество строк.</param>
        public void Update(Action<StepsGridView, int, int> action, int count)
        {
            this.Rows.Clear();

            for (int i = 0; i < count; i++)
            {
                action(this, i, count);
            }
        }

        #endregion

        #region Private Methods

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
                ReadOnly = true,
            };

            var stepCountColumn = new DataGridViewTextBoxColumn
            {
                Name = "№",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                ReadOnly = true,
            };

            var stepNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "Название",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true,
            };

            var statusColumn = new DataGridViewTextBoxColumn
            {
                Name = "Статус",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true,
            };

            this.Columns.AddRange(cursorColumn, stepCountColumn, stepNameColumn, statusColumn);
        }

        #endregion
    }
}

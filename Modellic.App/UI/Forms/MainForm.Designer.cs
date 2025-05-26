namespace Modellic.App
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.appMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCreateFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSolidWorks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConnectToSw = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDisconnectFromSw = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutFixtureControl = new System.Windows.Forms.TableLayoutPanel();
            this.btnBuildStep = new System.Windows.Forms.Button();
            this.btnChangeStep = new System.Windows.Forms.Button();
            this.btnClearStep = new System.Windows.Forms.Button();
            this.btnStartAssembly = new System.Windows.Forms.Button();
            this.btnCursorDown = new System.Windows.Forms.Button();
            this.btnCursorUp = new System.Windows.Forms.Button();
            this.tableLayoutBackground = new System.Windows.Forms.TableLayoutPanel();
            this.stepsGridView1 = new Modellic.UI.Controls.StepsGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appMenu.SuspendLayout();
            this.tableLayoutFixtureControl.SuspendLayout();
            this.tableLayoutBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepsGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // appMenu
            // 
            this.appMenu.BackColor = System.Drawing.Color.White;
            this.appMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemSolidWorks});
            this.appMenu.Location = new System.Drawing.Point(0, 0);
            this.appMenu.Name = "appMenu";
            this.appMenu.Size = new System.Drawing.Size(634, 24);
            this.appMenu.TabIndex = 0;
            this.appMenu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCreateFile,
            this.menuItemOpenFile,
            this.menuItemSaveFile});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(48, 20);
            this.menuItemFile.Text = "Файл";
            // 
            // menuItemCreateFile
            // 
            this.menuItemCreateFile.Name = "menuItemCreateFile";
            this.menuItemCreateFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuItemCreateFile.Size = new System.Drawing.Size(181, 22);
            this.menuItemCreateFile.Text = "Создать";
            // 
            // menuItemOpenFile
            // 
            this.menuItemOpenFile.Name = "menuItemOpenFile";
            this.menuItemOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuItemOpenFile.Size = new System.Drawing.Size(181, 22);
            this.menuItemOpenFile.Text = "Открыть";
            // 
            // menuItemSaveFile
            // 
            this.menuItemSaveFile.Name = "menuItemSaveFile";
            this.menuItemSaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuItemSaveFile.Size = new System.Drawing.Size(181, 22);
            this.menuItemSaveFile.Text = "Сохранить";
            // 
            // menuItemSolidWorks
            // 
            this.menuItemSolidWorks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemConnectToSw,
            this.menuItemDisconnectFromSw});
            this.menuItemSolidWorks.Name = "menuItemSolidWorks";
            this.menuItemSolidWorks.Size = new System.Drawing.Size(78, 20);
            this.menuItemSolidWorks.Text = "SolidWorks";
            // 
            // menuItemConnectToSw
            // 
            this.menuItemConnectToSw.Name = "menuItemConnectToSw";
            this.menuItemConnectToSw.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.menuItemConnectToSw.Size = new System.Drawing.Size(205, 22);
            this.menuItemConnectToSw.Text = "Подключиться";
            this.menuItemConnectToSw.Click += new System.EventHandler(this.MenuItemConnectToSw_Click);
            // 
            // menuItemDisconnectFromSw
            // 
            this.menuItemDisconnectFromSw.Name = "menuItemDisconnectFromSw";
            this.menuItemDisconnectFromSw.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.menuItemDisconnectFromSw.Size = new System.Drawing.Size(205, 22);
            this.menuItemDisconnectFromSw.Text = "Отключиться";
            // 
            // tableLayoutFixtureControl
            // 
            this.tableLayoutFixtureControl.ColumnCount = 1;
            this.tableLayoutFixtureControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFixtureControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutFixtureControl.Controls.Add(this.btnBuildStep, 0, 0);
            this.tableLayoutFixtureControl.Controls.Add(this.btnChangeStep, 0, 1);
            this.tableLayoutFixtureControl.Controls.Add(this.btnClearStep, 0, 2);
            this.tableLayoutFixtureControl.Controls.Add(this.btnStartAssembly, 0, 4);
            this.tableLayoutFixtureControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutFixtureControl.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutFixtureControl.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutFixtureControl.Name = "tableLayoutFixtureControl";
            this.tableLayoutFixtureControl.RowCount = 5;
            this.tableLayoutBackground.SetRowSpan(this.tableLayoutFixtureControl, 3);
            this.tableLayoutFixtureControl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutFixtureControl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutFixtureControl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutFixtureControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFixtureControl.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutFixtureControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutFixtureControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutFixtureControl.Size = new System.Drawing.Size(228, 325);
            this.tableLayoutFixtureControl.TabIndex = 0;
            // 
            // btnBuildStep
            // 
            this.btnBuildStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuildStep.Location = new System.Drawing.Point(0, 0);
            this.btnBuildStep.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.btnBuildStep.Name = "btnBuildStep";
            this.btnBuildStep.Size = new System.Drawing.Size(228, 45);
            this.btnBuildStep.TabIndex = 1;
            this.btnBuildStep.Text = "Построить";
            this.btnBuildStep.UseVisualStyleBackColor = true;
            // 
            // btnChangeStep
            // 
            this.btnChangeStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChangeStep.Location = new System.Drawing.Point(0, 49);
            this.btnChangeStep.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.btnChangeStep.Name = "btnChangeStep";
            this.btnChangeStep.Size = new System.Drawing.Size(228, 45);
            this.btnChangeStep.TabIndex = 2;
            this.btnChangeStep.Text = "Изменить";
            this.btnChangeStep.UseVisualStyleBackColor = true;
            // 
            // btnClearStep
            // 
            this.btnClearStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearStep.Location = new System.Drawing.Point(0, 98);
            this.btnClearStep.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearStep.Name = "btnClearStep";
            this.btnClearStep.Size = new System.Drawing.Size(228, 45);
            this.btnClearStep.TabIndex = 3;
            this.btnClearStep.Text = "Очистить";
            this.btnClearStep.UseVisualStyleBackColor = true;
            // 
            // btnStartAssembly
            // 
            this.btnStartAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartAssembly.Location = new System.Drawing.Point(0, 280);
            this.btnStartAssembly.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartAssembly.Name = "btnStartAssembly";
            this.btnStartAssembly.Size = new System.Drawing.Size(228, 45);
            this.btnStartAssembly.TabIndex = 10;
            this.btnStartAssembly.Text = "Начать сборку";
            this.btnStartAssembly.UseVisualStyleBackColor = true;
            // 
            // btnCursorDown
            // 
            this.btnCursorDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCursorDown.Location = new System.Drawing.Point(576, 56);
            this.btnCursorDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnCursorDown.Name = "btnCursorDown";
            this.btnCursorDown.Size = new System.Drawing.Size(52, 50);
            this.btnCursorDown.TabIndex = 5;
            this.btnCursorDown.Text = "▼";
            this.btnCursorDown.UseVisualStyleBackColor = true;
            // 
            // btnCursorUp
            // 
            this.btnCursorUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCursorUp.Location = new System.Drawing.Point(576, 6);
            this.btnCursorUp.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.btnCursorUp.Name = "btnCursorUp";
            this.btnCursorUp.Size = new System.Drawing.Size(52, 46);
            this.btnCursorUp.TabIndex = 4;
            this.btnCursorUp.Text = "▲";
            this.btnCursorUp.UseVisualStyleBackColor = true;
            // 
            // tableLayoutBackground
            // 
            this.tableLayoutBackground.ColumnCount = 3;
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutBackground.Controls.Add(this.btnCursorUp, 2, 0);
            this.tableLayoutBackground.Controls.Add(this.btnCursorDown, 2, 1);
            this.tableLayoutBackground.Controls.Add(this.tableLayoutFixtureControl, 0, 0);
            this.tableLayoutBackground.Controls.Add(this.stepsGridView1, 1, 0);
            this.tableLayoutBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBackground.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutBackground.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutBackground.Name = "tableLayoutBackground";
            this.tableLayoutBackground.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutBackground.RowCount = 3;
            this.tableLayoutBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutBackground.Size = new System.Drawing.Size(634, 337);
            this.tableLayoutBackground.TabIndex = 0;
            // 
            // stepsGridView1
            // 
            this.stepsGridView1.AllowUserToAddRows = false;
            this.stepsGridView1.AllowUserToDeleteRows = false;
            this.stepsGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stepsGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.stepsGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepsGridView1.Location = new System.Drawing.Point(238, 7);
            this.stepsGridView1.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.stepsGridView1.Name = "stepsGridView1";
            this.tableLayoutBackground.SetRowSpan(this.stepsGridView1, 3);
            this.stepsGridView1.Size = new System.Drawing.Size(334, 323);
            this.stepsGridView1.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 175;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 175;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.tableLayoutBackground);
            this.Controls.Add(this.appMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.appMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Modellic";
            this.appMenu.ResumeLayout(false);
            this.appMenu.PerformLayout();
            this.tableLayoutFixtureControl.ResumeLayout(false);
            this.tableLayoutBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stepsGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip appMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemCreateFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSolidWorks;
        private System.Windows.Forms.ToolStripMenuItem menuItemConnectToSw;
        private System.Windows.Forms.ToolStripMenuItem menuItemDisconnectFromSw;
        private System.Windows.Forms.TableLayoutPanel tableLayoutFixtureControl;
        private System.Windows.Forms.Button btnBuildStep;
        private System.Windows.Forms.Button btnChangeStep;
        private System.Windows.Forms.Button btnClearStep;
        private System.Windows.Forms.Button btnStartAssembly;
        private System.Windows.Forms.TableLayoutPanel tableLayoutBackground;
        private System.Windows.Forms.Button btnCursorUp;
        private System.Windows.Forms.Button btnCursorDown;
        private UI.Controls.StepsGridView stepsGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}


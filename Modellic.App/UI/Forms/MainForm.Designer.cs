namespace Modellic.App.UI.Forms
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
            this.menuItemFixture = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBuildStep = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangeStep = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClearStep = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemNextStep = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPreviousStep = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAssembly = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAssemblyManager = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemPartExamples = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPartExample = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPlatformExample = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemFixtureExample = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAssemblyExamples = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStopExample = new System.Windows.Forms.ToolStripMenuItem();
            this.финальнаяСборкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutFixtureControl = new System.Windows.Forms.TableLayoutPanel();
            this.btnBuildStep = new System.Windows.Forms.Button();
            this.btnChangeStep = new System.Windows.Forms.Button();
            this.btnClearStep = new System.Windows.Forms.Button();
            this.btnStartAssembly = new System.Windows.Forms.Button();
            this.btnCursorDown = new System.Windows.Forms.Button();
            this.btnCursorUp = new System.Windows.Forms.Button();
            this.tableLayoutBackground = new System.Windows.Forms.TableLayoutPanel();
            this.stepsGridView = new Modellic.App.UI.Controls.StepsGridView();
            this.appMenu.SuspendLayout();
            this.tableLayoutFixtureControl.SuspendLayout();
            this.tableLayoutBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // appMenu
            // 
            this.appMenu.BackColor = System.Drawing.Color.White;
            this.appMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemSolidWorks,
            this.menuItemFixture,
            this.menuItemAssembly});
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
            // menuItemFixture
            // 
            this.menuItemFixture.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemBuildStep,
            this.menuItemChangeStep,
            this.menuItemClearStep,
            this.toolStripSeparator2,
            this.menuItemNextStep,
            this.menuItemPreviousStep});
            this.menuItemFixture.Name = "menuItemFixture";
            this.menuItemFixture.Size = new System.Drawing.Size(115, 20);
            this.menuItemFixture.Text = "Приспособление";
            // 
            // menuItemBuildStep
            // 
            this.menuItemBuildStep.Name = "menuItemBuildStep";
            this.menuItemBuildStep.Size = new System.Drawing.Size(170, 22);
            this.menuItemBuildStep.Text = "Построить";
            this.menuItemBuildStep.Click += new System.EventHandler(this.MenuItemBuildStep_Click);
            // 
            // menuItemChangeStep
            // 
            this.menuItemChangeStep.Name = "menuItemChangeStep";
            this.menuItemChangeStep.Size = new System.Drawing.Size(170, 22);
            this.menuItemChangeStep.Text = "Изменить";
            // 
            // menuItemClearStep
            // 
            this.menuItemClearStep.Name = "menuItemClearStep";
            this.menuItemClearStep.Size = new System.Drawing.Size(170, 22);
            this.menuItemClearStep.Text = "Очистить";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // menuItemNextStep
            // 
            this.menuItemNextStep.Name = "menuItemNextStep";
            this.menuItemNextStep.Size = new System.Drawing.Size(170, 22);
            this.menuItemNextStep.Text = "Следующий шаг";
            this.menuItemNextStep.Click += new System.EventHandler(this.MenuItemCursorDown_Click);
            // 
            // menuItemPreviousStep
            // 
            this.menuItemPreviousStep.Name = "menuItemPreviousStep";
            this.menuItemPreviousStep.Size = new System.Drawing.Size(170, 22);
            this.menuItemPreviousStep.Text = "Предудущий шаг";
            this.menuItemPreviousStep.Click += new System.EventHandler(this.MenuItemCursorUp_Click);
            // 
            // menuItemAssembly
            // 
            this.menuItemAssembly.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAssemblyManager,
            this.toolStripSeparator1,
            this.menuItemPartExamples,
            this.menuItemAssemblyExamples});
            this.menuItemAssembly.Name = "menuItemAssembly";
            this.menuItemAssembly.Size = new System.Drawing.Size(86, 20);
            this.menuItemAssembly.Text = "Построение";
            // 
            // menuItemAssemblyManager
            // 
            this.menuItemAssemblyManager.Name = "menuItemAssemblyManager";
            this.menuItemAssemblyManager.Size = new System.Drawing.Size(175, 22);
            this.menuItemAssemblyManager.Text = "Менеджер сборки";
            this.menuItemAssemblyManager.Click += new System.EventHandler(this.OpenAssemblyManager_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // menuItemPartExamples
            // 
            this.menuItemPartExamples.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPartExample,
            this.menuItemPlatformExample,
            this.menuItemFixtureExample});
            this.menuItemPartExamples.Name = "menuItemPartExamples";
            this.menuItemPartExamples.Size = new System.Drawing.Size(175, 22);
            this.menuItemPartExamples.Text = "Пример моделей";
            // 
            // menuItemPartExample
            // 
            this.menuItemPartExample.Name = "menuItemPartExample";
            this.menuItemPartExample.Size = new System.Drawing.Size(170, 22);
            this.menuItemPartExample.Tag = "PartExample";
            this.menuItemPartExample.Text = "Деталь";
            this.menuItemPartExample.Click += new System.EventHandler(this.MenuItemOpenPartExample_Click);
            // 
            // menuItemPlatformExample
            // 
            this.menuItemPlatformExample.Name = "menuItemPlatformExample";
            this.menuItemPlatformExample.Size = new System.Drawing.Size(170, 22);
            this.menuItemPlatformExample.Tag = "PlatformExample";
            this.menuItemPlatformExample.Text = "Платформа";
            this.menuItemPlatformExample.Click += new System.EventHandler(this.MenuItemOpenPartExample_Click);
            // 
            // menuItemFixtureExample
            // 
            this.menuItemFixtureExample.Name = "menuItemFixtureExample";
            this.menuItemFixtureExample.Size = new System.Drawing.Size(170, 22);
            this.menuItemFixtureExample.Tag = "FixtureExample";
            this.menuItemFixtureExample.Text = "Приспособление";
            this.menuItemFixtureExample.Click += new System.EventHandler(this.MenuItemOpenPartExample_Click);
            // 
            // menuItemAssemblyExamples
            // 
            this.menuItemAssemblyExamples.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemStopExample,
            this.финальнаяСборкаToolStripMenuItem});
            this.menuItemAssemblyExamples.Name = "menuItemAssemblyExamples";
            this.menuItemAssemblyExamples.Size = new System.Drawing.Size(175, 22);
            this.menuItemAssemblyExamples.Text = "Пример сборок";
            // 
            // menuItemStopExample
            // 
            this.menuItemStopExample.Name = "menuItemStopExample";
            this.menuItemStopExample.Size = new System.Drawing.Size(177, 22);
            this.menuItemStopExample.Tag = "StopExample";
            this.menuItemStopExample.Text = "Упор";
            this.menuItemStopExample.Click += new System.EventHandler(this.MenuItemOpenAssemblyExample_Click);
            // 
            // финальнаяСборкаToolStripMenuItem
            // 
            this.финальнаяСборкаToolStripMenuItem.Name = "финальнаяСборкаToolStripMenuItem";
            this.финальнаяСборкаToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.финальнаяСборкаToolStripMenuItem.Tag = "AssemblyExample";
            this.финальнаяСборкаToolStripMenuItem.Text = "Финальная сборка";
            this.финальнаяСборкаToolStripMenuItem.Click += new System.EventHandler(this.MenuItemOpenAssemblyExample_Click);
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
            this.btnBuildStep.Click += new System.EventHandler(this.BtnBuildStep_Click);
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
            this.btnStartAssembly.Click += new System.EventHandler(this.OpenAssemblyManager_Click);
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
            this.btnCursorDown.Click += new System.EventHandler(this.BtnCursorDown_Click);
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
            this.btnCursorUp.Click += new System.EventHandler(this.BtnCursorUp_Click);
            // 
            // tableLayoutBackground
            // 
            this.tableLayoutBackground.ColumnCount = 3;
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutBackground.Controls.Add(this.btnCursorUp, 2, 0);
            this.tableLayoutBackground.Controls.Add(this.btnCursorDown, 2, 1);
            this.tableLayoutBackground.Controls.Add(this.tableLayoutFixtureControl, 0, 0);
            this.tableLayoutBackground.Controls.Add(this.stepsGridView, 1, 0);
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
            // stepsGridView
            // 
            this.stepsGridView.AllowUserToAddRows = false;
            this.stepsGridView.AllowUserToDeleteRows = false;
            this.stepsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stepsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepsGridView.Location = new System.Drawing.Point(238, 7);
            this.stepsGridView.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.stepsGridView.Name = "stepsGridView";
            this.tableLayoutBackground.SetRowSpan(this.stepsGridView, 3);
            this.stepsGridView.Size = new System.Drawing.Size(334, 323);
            this.stepsGridView.TabIndex = 6;
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modellic";
            this.appMenu.ResumeLayout(false);
            this.appMenu.PerformLayout();
            this.tableLayoutFixtureControl.ResumeLayout(false);
            this.tableLayoutBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stepsGridView)).EndInit();
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
        private UI.Controls.StepsGridView stepsGridView;
        private System.Windows.Forms.ToolStripMenuItem menuItemAssembly;
        private System.Windows.Forms.ToolStripMenuItem menuItemAssemblyExamples;
        private System.Windows.Forms.ToolStripMenuItem финальнаяСборкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemAssemblyManager;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemPartExamples;
        private System.Windows.Forms.ToolStripMenuItem menuItemPartExample;
        private System.Windows.Forms.ToolStripMenuItem menuItemPlatformExample;
        private System.Windows.Forms.ToolStripMenuItem menuItemFixtureExample;
        private System.Windows.Forms.ToolStripMenuItem menuItemStopExample;
        private System.Windows.Forms.ToolStripMenuItem menuItemFixture;
        private System.Windows.Forms.ToolStripMenuItem menuItemBuildStep;
        private System.Windows.Forms.ToolStripMenuItem menuItemChangeStep;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearStep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemNextStep;
        private System.Windows.Forms.ToolStripMenuItem menuItemPreviousStep;
    }
}


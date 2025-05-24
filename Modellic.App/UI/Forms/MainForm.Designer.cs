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
            this.menuItemNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSolidWorks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConnectToSw = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDisconnectFromSw = new System.Windows.Forms.ToolStripMenuItem();
            this.appMenu.SuspendLayout();
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
            this.appMenu.Size = new System.Drawing.Size(800, 24);
            this.appMenu.TabIndex = 0;
            this.appMenu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewFile,
            this.menuItemOpenFile,
            this.menuItemSaveFile});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(48, 20);
            this.menuItemFile.Text = "Файл";
            // 
            // menuItemNewFile
            // 
            this.menuItemNewFile.Name = "menuItemNewFile";
            this.menuItemNewFile.Size = new System.Drawing.Size(133, 22);
            this.menuItemNewFile.Text = "Новый";
            // 
            // menuItemOpenFile
            // 
            this.menuItemOpenFile.Name = "menuItemOpenFile";
            this.menuItemOpenFile.Size = new System.Drawing.Size(133, 22);
            this.menuItemOpenFile.Text = "Открыть";
            // 
            // menuItemSaveFile
            // 
            this.menuItemSaveFile.Name = "menuItemSaveFile";
            this.menuItemSaveFile.Size = new System.Drawing.Size(133, 22);
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
            this.menuItemConnectToSw.Size = new System.Drawing.Size(180, 22);
            this.menuItemConnectToSw.Text = "Подключиться";
            this.menuItemConnectToSw.Click += new System.EventHandler(this.MenuItemConnectToSw_Click);
            // 
            // menuItemDisconnectFromSw
            // 
            this.menuItemDisconnectFromSw.Name = "menuItemDisconnectFromSw";
            this.menuItemDisconnectFromSw.Size = new System.Drawing.Size(180, 22);
            this.menuItemDisconnectFromSw.Text = "Отключиться";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.appMenu);
            this.MainMenuStrip = this.appMenu;
            this.Name = "MainForm";
            this.Text = "Modellic";
            this.appMenu.ResumeLayout(false);
            this.appMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip appMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemSolidWorks;
        private System.Windows.Forms.ToolStripMenuItem menuItemConnectToSw;
        private System.Windows.Forms.ToolStripMenuItem menuItemDisconnectFromSw;
    }
}


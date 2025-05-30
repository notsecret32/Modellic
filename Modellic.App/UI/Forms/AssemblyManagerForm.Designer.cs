namespace Modellic.App.UI.Forms
{
    partial class AssemblyManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutBackground = new System.Windows.Forms.TableLayoutPanel();
            this.groupFixture = new System.Windows.Forms.GroupBox();
            this.tableLayoutFixture = new System.Windows.Forms.TableLayoutPanel();
            this.lblFixture = new System.Windows.Forms.Label();
            this.dropdownFixtures = new System.Windows.Forms.ComboBox();
            this.btnLoadFixtures = new System.Windows.Forms.Button();
            this.btnAssembly = new System.Windows.Forms.Button();
            this.tableLayoutBackground.SuspendLayout();
            this.groupFixture.SuspendLayout();
            this.tableLayoutFixture.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutBackground
            // 
            this.tableLayoutBackground.ColumnCount = 1;
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBackground.Controls.Add(this.groupFixture, 0, 0);
            this.tableLayoutBackground.Controls.Add(this.btnAssembly, 0, 2);
            this.tableLayoutBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBackground.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutBackground.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutBackground.Name = "tableLayoutBackground";
            this.tableLayoutBackground.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutBackground.RowCount = 3;
            this.tableLayoutBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutBackground.Size = new System.Drawing.Size(384, 411);
            this.tableLayoutBackground.TabIndex = 0;
            // 
            // groupFixture
            // 
            this.groupFixture.Controls.Add(this.tableLayoutFixture);
            this.groupFixture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupFixture.Location = new System.Drawing.Point(7, 4);
            this.groupFixture.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupFixture.Name = "groupFixture";
            this.groupFixture.Padding = new System.Windows.Forms.Padding(8, 2, 8, 10);
            this.groupFixture.Size = new System.Drawing.Size(370, 133);
            this.groupFixture.TabIndex = 0;
            this.groupFixture.TabStop = false;
            this.groupFixture.Text = "Настройки";
            // 
            // tableLayoutFixture
            // 
            this.tableLayoutFixture.ColumnCount = 1;
            this.tableLayoutFixture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFixture.Controls.Add(this.lblFixture, 0, 0);
            this.tableLayoutFixture.Controls.Add(this.dropdownFixtures, 0, 1);
            this.tableLayoutFixture.Controls.Add(this.btnLoadFixtures, 0, 3);
            this.tableLayoutFixture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutFixture.Location = new System.Drawing.Point(8, 15);
            this.tableLayoutFixture.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutFixture.Name = "tableLayoutFixture";
            this.tableLayoutFixture.RowCount = 4;
            this.tableLayoutFixture.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutFixture.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutFixture.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFixture.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutFixture.Size = new System.Drawing.Size(354, 108);
            this.tableLayoutFixture.TabIndex = 0;
            // 
            // lblFixture
            // 
            this.lblFixture.AutoSize = true;
            this.lblFixture.Location = new System.Drawing.Point(0, 2);
            this.lblFixture.Margin = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.lblFixture.Name = "lblFixture";
            this.lblFixture.Size = new System.Drawing.Size(96, 13);
            this.lblFixture.TabIndex = 0;
            this.lblFixture.Text = "Приспособление:";
            // 
            // dropdownFixtures
            // 
            this.dropdownFixtures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropdownFixtures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownFixtures.FormattingEnabled = true;
            this.dropdownFixtures.Location = new System.Drawing.Point(1, 20);
            this.dropdownFixtures.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dropdownFixtures.Name = "dropdownFixtures";
            this.dropdownFixtures.Size = new System.Drawing.Size(352, 21);
            this.dropdownFixtures.Sorted = true;
            this.dropdownFixtures.TabIndex = 1;
            // 
            // btnLoadFixtures
            // 
            this.btnLoadFixtures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadFixtures.Location = new System.Drawing.Point(0, 58);
            this.btnLoadFixtures.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoadFixtures.Name = "btnLoadFixtures";
            this.btnLoadFixtures.Size = new System.Drawing.Size(354, 50);
            this.btnLoadFixtures.TabIndex = 2;
            this.btnLoadFixtures.Text = "Загрузить";
            this.btnLoadFixtures.UseVisualStyleBackColor = true;
            // 
            // btnAssembly
            // 
            this.btnAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAssembly.Location = new System.Drawing.Point(7, 353);
            this.btnAssembly.Name = "btnAssembly";
            this.btnAssembly.Size = new System.Drawing.Size(370, 51);
            this.btnAssembly.TabIndex = 1;
            this.btnAssembly.Text = "Собрать";
            this.btnAssembly.UseVisualStyleBackColor = true;
            this.btnAssembly.Click += new System.EventHandler(this.BtnAssembly_Click);
            // 
            // AssemblyManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.tableLayoutBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "AssemblyManagerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Менеджер сборки";
            this.tableLayoutBackground.ResumeLayout(false);
            this.groupFixture.ResumeLayout(false);
            this.tableLayoutFixture.ResumeLayout(false);
            this.tableLayoutFixture.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutBackground;
        private System.Windows.Forms.GroupBox groupFixture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutFixture;
        private System.Windows.Forms.Label lblFixture;
        private System.Windows.Forms.ComboBox dropdownFixtures;
        private System.Windows.Forms.Button btnLoadFixtures;
        private System.Windows.Forms.Button btnAssembly;
    }
}
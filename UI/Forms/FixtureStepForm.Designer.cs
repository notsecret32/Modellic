namespace Modellic.UI.Forms
{
    partial class FixtureStepForm
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
            this.tableLayoutBg = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.stepProperties = new System.Windows.Forms.PropertyGrid();
            this.btnContinue = new System.Windows.Forms.Button();
            this.tableLayoutBg.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutBg
            // 
            this.tableLayoutBg.ColumnCount = 2;
            this.tableLayoutBg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBg.Controls.Add(this.btnCancel, 0, 1);
            this.tableLayoutBg.Controls.Add(this.stepProperties, 0, 0);
            this.tableLayoutBg.Controls.Add(this.btnContinue, 1, 1);
            this.tableLayoutBg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBg.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutBg.Name = "tableLayoutBg";
            this.tableLayoutBg.RowCount = 2;
            this.tableLayoutBg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutBg.Size = new System.Drawing.Size(434, 561);
            this.tableLayoutBg.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(3, 516);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(211, 42);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // stepProperties
            // 
            this.tableLayoutBg.SetColumnSpan(this.stepProperties, 2);
            this.stepProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepProperties.Location = new System.Drawing.Point(3, 3);
            this.stepProperties.Name = "stepProperties";
            this.stepProperties.Size = new System.Drawing.Size(428, 507);
            this.stepProperties.TabIndex = 1;
            // 
            // btnContinue
            // 
            this.btnContinue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnContinue.Location = new System.Drawing.Point(220, 516);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(211, 42);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "Продолжить";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // FixtureStepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 561);
            this.Controls.Add(this.tableLayoutBg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FixtureStepForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка шага";
            this.tableLayoutBg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutBg;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PropertyGrid stepProperties;
        private System.Windows.Forms.Button btnContinue;
    }
}
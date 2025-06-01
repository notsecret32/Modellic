namespace Modellic.App.UI.Forms
{
    partial class FixtureStepBaseForm
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
            this.pictureFixtureStep = new System.Windows.Forms.PictureBox();
            this.tableLayoutFixtureStepControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBuildStep = new System.Windows.Forms.Button();
            this.tableLayoutBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFixtureStep)).BeginInit();
            this.tableLayoutFixtureStepControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutBackground
            // 
            this.tableLayoutBackground.ColumnCount = 2;
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutBackground.Controls.Add(this.pictureFixtureStep, 0, 0);
            this.tableLayoutBackground.Controls.Add(this.tableLayoutFixtureStepControls, 1, 0);
            this.tableLayoutBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBackground.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutBackground.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutBackground.Name = "tableLayoutBackground";
            this.tableLayoutBackground.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutBackground.RowCount = 1;
            this.tableLayoutBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBackground.Size = new System.Drawing.Size(784, 461);
            this.tableLayoutBackground.TabIndex = 0;
            // 
            // pictureFixtureStep
            // 
            this.pictureFixtureStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureFixtureStep.Location = new System.Drawing.Point(4, 4);
            this.pictureFixtureStep.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.pictureFixtureStep.Name = "pictureFixtureStep";
            this.pictureFixtureStep.Size = new System.Drawing.Size(463, 453);
            this.pictureFixtureStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureFixtureStep.TabIndex = 0;
            this.pictureFixtureStep.TabStop = false;
            // 
            // tableLayoutFixtureStepControls
            // 
            this.tableLayoutFixtureStepControls.ColumnCount = 1;
            this.tableLayoutFixtureStepControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFixtureStepControls.Controls.Add(this.btnCancel, 0, 2);
            this.tableLayoutFixtureStepControls.Controls.Add(this.btnBuildStep, 0, 3);
            this.tableLayoutFixtureStepControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutFixtureStepControls.Location = new System.Drawing.Point(471, 4);
            this.tableLayoutFixtureStepControls.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.tableLayoutFixtureStepControls.Name = "tableLayoutFixtureStepControls";
            this.tableLayoutFixtureStepControls.RowCount = 4;
            this.tableLayoutFixtureStepControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutFixtureStepControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFixtureStepControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutFixtureStepControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutFixtureStepControls.Size = new System.Drawing.Size(309, 453);
            this.tableLayoutFixtureStepControls.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(0, 349);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(309, 50);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnBuildStep
            // 
            this.btnBuildStep.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBuildStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuildStep.Location = new System.Drawing.Point(0, 403);
            this.btnBuildStep.Margin = new System.Windows.Forms.Padding(0);
            this.btnBuildStep.Name = "btnBuildStep";
            this.btnBuildStep.Size = new System.Drawing.Size(309, 50);
            this.btnBuildStep.TabIndex = 1;
            this.btnBuildStep.Text = "Построить";
            this.btnBuildStep.UseVisualStyleBackColor = true;
            // 
            // FixtureStepBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tableLayoutBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "FixtureStepBaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка шага";
            this.tableLayoutBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureFixtureStep)).EndInit();
            this.tableLayoutFixtureStepControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutBackground;
        protected System.Windows.Forms.PictureBox pictureFixtureStep;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnBuildStep;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutFixtureStepControls;
    }
}
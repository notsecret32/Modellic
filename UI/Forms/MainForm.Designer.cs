namespace Modellic.UI.Forms
{
    partial class MainForm
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
            this.groupFixture = new System.Windows.Forms.GroupBox();
            this.tableLayoutDevice = new System.Windows.Forms.TableLayoutPanel();
            this.btnAssembly = new System.Windows.Forms.Button();
            this.labelState7 = new System.Windows.Forms.Label();
            this.labelState6 = new System.Windows.Forms.Label();
            this.labelState5 = new System.Windows.Forms.Label();
            this.labelState4 = new System.Windows.Forms.Label();
            this.labelState3 = new System.Windows.Forms.Label();
            this.labelState2 = new System.Windows.Forms.Label();
            this.labelState1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnNextStage = new System.Windows.Forms.Button();
            this.btnStageSettings = new System.Windows.Forms.Button();
            this.groupSw = new System.Windows.Forms.GroupBox();
            this.tableLayoutSw = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelConnectionState = new System.Windows.Forms.Label();
            this.btnConnectToSw = new System.Windows.Forms.Button();
            this.tableLayoutBg.SuspendLayout();
            this.groupFixture.SuspendLayout();
            this.tableLayoutDevice.SuspendLayout();
            this.groupSw.SuspendLayout();
            this.tableLayoutSw.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutBg
            // 
            this.tableLayoutBg.ColumnCount = 1;
            this.tableLayoutBg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBg.Controls.Add(this.groupFixture, 0, 0);
            this.tableLayoutBg.Controls.Add(this.groupSw, 0, 1);
            this.tableLayoutBg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBg.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutBg.Name = "tableLayoutBg";
            this.tableLayoutBg.RowCount = 2;
            this.tableLayoutBg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBg.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutBg.Size = new System.Drawing.Size(334, 451);
            this.tableLayoutBg.TabIndex = 0;
            // 
            // groupFixture
            // 
            this.groupFixture.AutoSize = true;
            this.groupFixture.Controls.Add(this.tableLayoutDevice);
            this.groupFixture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupFixture.Location = new System.Drawing.Point(3, 3);
            this.groupFixture.Name = "groupFixture";
            this.groupFixture.Size = new System.Drawing.Size(328, 351);
            this.groupFixture.TabIndex = 0;
            this.groupFixture.TabStop = false;
            this.groupFixture.Text = "Приспособление";
            // 
            // tableLayoutDevice
            // 
            this.tableLayoutDevice.ColumnCount = 2;
            this.tableLayoutDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutDevice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutDevice.Controls.Add(this.btnAssembly, 0, 10);
            this.tableLayoutDevice.Controls.Add(this.labelState7, 1, 6);
            this.tableLayoutDevice.Controls.Add(this.labelState6, 1, 5);
            this.tableLayoutDevice.Controls.Add(this.labelState5, 1, 4);
            this.tableLayoutDevice.Controls.Add(this.labelState4, 1, 3);
            this.tableLayoutDevice.Controls.Add(this.labelState3, 1, 2);
            this.tableLayoutDevice.Controls.Add(this.labelState2, 1, 1);
            this.tableLayoutDevice.Controls.Add(this.labelState1, 1, 0);
            this.tableLayoutDevice.Controls.Add(this.label2, 0, 0);
            this.tableLayoutDevice.Controls.Add(this.label3, 0, 1);
            this.tableLayoutDevice.Controls.Add(this.label4, 0, 2);
            this.tableLayoutDevice.Controls.Add(this.label5, 0, 3);
            this.tableLayoutDevice.Controls.Add(this.label6, 0, 4);
            this.tableLayoutDevice.Controls.Add(this.label7, 0, 5);
            this.tableLayoutDevice.Controls.Add(this.label8, 0, 6);
            this.tableLayoutDevice.Controls.Add(this.btnUndo, 0, 7);
            this.tableLayoutDevice.Controls.Add(this.btnRedo, 1, 7);
            this.tableLayoutDevice.Controls.Add(this.btnNextStage, 0, 8);
            this.tableLayoutDevice.Controls.Add(this.btnStageSettings, 0, 9);
            this.tableLayoutDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutDevice.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutDevice.Name = "tableLayoutDevice";
            this.tableLayoutDevice.RowCount = 11;
            this.tableLayoutDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDevice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDevice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutDevice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutDevice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutDevice.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutDevice.Size = new System.Drawing.Size(322, 332);
            this.tableLayoutDevice.TabIndex = 0;
            // 
            // btnAssembly
            // 
            this.tableLayoutDevice.SetColumnSpan(this.btnAssembly, 2);
            this.btnAssembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAssembly.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAssembly.Location = new System.Drawing.Point(3, 287);
            this.btnAssembly.Name = "btnAssembly";
            this.btnAssembly.Size = new System.Drawing.Size(316, 42);
            this.btnAssembly.TabIndex = 18;
            this.btnAssembly.Text = "Сборка";
            this.btnAssembly.UseVisualStyleBackColor = true;
            // 
            // labelState7
            // 
            this.labelState7.AutoSize = true;
            this.labelState7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelState7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelState7.Location = new System.Drawing.Point(164, 120);
            this.labelState7.Name = "labelState7";
            this.labelState7.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelState7.Size = new System.Drawing.Size(155, 20);
            this.labelState7.TabIndex = 13;
            this.labelState7.Text = "[stageState]";
            // 
            // labelState6
            // 
            this.labelState6.AutoSize = true;
            this.labelState6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelState6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelState6.Location = new System.Drawing.Point(164, 100);
            this.labelState6.Name = "labelState6";
            this.labelState6.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelState6.Size = new System.Drawing.Size(155, 20);
            this.labelState6.TabIndex = 12;
            this.labelState6.Text = "[stageState]";
            // 
            // labelState5
            // 
            this.labelState5.AutoSize = true;
            this.labelState5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelState5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelState5.Location = new System.Drawing.Point(164, 80);
            this.labelState5.Name = "labelState5";
            this.labelState5.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelState5.Size = new System.Drawing.Size(155, 20);
            this.labelState5.TabIndex = 11;
            this.labelState5.Text = "[stageState]";
            // 
            // labelState4
            // 
            this.labelState4.AutoSize = true;
            this.labelState4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelState4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelState4.Location = new System.Drawing.Point(164, 60);
            this.labelState4.Name = "labelState4";
            this.labelState4.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelState4.Size = new System.Drawing.Size(155, 20);
            this.labelState4.TabIndex = 10;
            this.labelState4.Text = "[stageState]";
            // 
            // labelState3
            // 
            this.labelState3.AutoSize = true;
            this.labelState3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelState3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelState3.Location = new System.Drawing.Point(164, 40);
            this.labelState3.Name = "labelState3";
            this.labelState3.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelState3.Size = new System.Drawing.Size(155, 20);
            this.labelState3.TabIndex = 9;
            this.labelState3.Text = "[stageState]";
            // 
            // labelState2
            // 
            this.labelState2.AutoSize = true;
            this.labelState2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelState2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelState2.Location = new System.Drawing.Point(164, 20);
            this.labelState2.Name = "labelState2";
            this.labelState2.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelState2.Size = new System.Drawing.Size(155, 20);
            this.labelState2.TabIndex = 8;
            this.labelState2.Text = "[stageState]";
            // 
            // labelState1
            // 
            this.labelState1.AutoSize = true;
            this.labelState1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelState1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelState1.Location = new System.Drawing.Point(164, 0);
            this.labelState1.Name = "labelState1";
            this.labelState1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelState1.Size = new System.Drawing.Size(155, 20);
            this.labelState1.TabIndex = 7;
            this.labelState1.Text = "[stageState]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Этап 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Этап 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(3, 40);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Этап 3:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(3, 60);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Этап 4:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 80);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Size = new System.Drawing.Size(155, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Этап 5:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(3, 100);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Size = new System.Drawing.Size(155, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Этап 6:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(3, 120);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Size = new System.Drawing.Size(155, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Этап 7:";
            // 
            // btnUndo
            // 
            this.btnUndo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUndo.Location = new System.Drawing.Point(3, 143);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(155, 42);
            this.btnUndo.TabIndex = 14;
            this.btnUndo.Text = "Назад";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRedo.Location = new System.Drawing.Point(164, 143);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(155, 42);
            this.btnRedo.TabIndex = 15;
            this.btnRedo.Text = "Вперед";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.BtnRedo_Click);
            // 
            // btnNextStage
            // 
            this.tableLayoutDevice.SetColumnSpan(this.btnNextStage, 2);
            this.btnNextStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNextStage.Location = new System.Drawing.Point(3, 191);
            this.btnNextStage.Name = "btnNextStage";
            this.btnNextStage.Size = new System.Drawing.Size(316, 42);
            this.btnNextStage.TabIndex = 16;
            this.btnNextStage.Text = "[btnNextStage]";
            this.btnNextStage.UseVisualStyleBackColor = true;
            this.btnNextStage.Click += new System.EventHandler(this.BtnNextStage_Click);
            // 
            // btnStageSettings
            // 
            this.tableLayoutDevice.SetColumnSpan(this.btnStageSettings, 2);
            this.btnStageSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStageSettings.Location = new System.Drawing.Point(3, 239);
            this.btnStageSettings.Name = "btnStageSettings";
            this.btnStageSettings.Size = new System.Drawing.Size(316, 42);
            this.btnStageSettings.TabIndex = 17;
            this.btnStageSettings.Text = "Параметры";
            this.btnStageSettings.UseVisualStyleBackColor = true;
            // 
            // groupSw
            // 
            this.groupSw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSw.Controls.Add(this.tableLayoutSw);
            this.groupSw.Location = new System.Drawing.Point(3, 360);
            this.groupSw.Name = "groupSw";
            this.groupSw.Size = new System.Drawing.Size(328, 88);
            this.groupSw.TabIndex = 1;
            this.groupSw.TabStop = false;
            this.groupSw.Text = "Solidworks";
            // 
            // tableLayoutSw
            // 
            this.tableLayoutSw.ColumnCount = 2;
            this.tableLayoutSw.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSw.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSw.Controls.Add(this.label1, 0, 0);
            this.tableLayoutSw.Controls.Add(this.labelConnectionState, 1, 0);
            this.tableLayoutSw.Controls.Add(this.btnConnectToSw, 0, 1);
            this.tableLayoutSw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSw.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutSw.Name = "tableLayoutSw";
            this.tableLayoutSw.RowCount = 2;
            this.tableLayoutSw.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutSw.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSw.Size = new System.Drawing.Size(322, 69);
            this.tableLayoutSw.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Состояние:";
            // 
            // labelConnectionState
            // 
            this.labelConnectionState.AutoSize = true;
            this.labelConnectionState.Location = new System.Drawing.Point(164, 0);
            this.labelConnectionState.Name = "labelConnectionState";
            this.labelConnectionState.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.labelConnectionState.Size = new System.Drawing.Size(91, 21);
            this.labelConnectionState.TabIndex = 1;
            this.labelConnectionState.Text = "[connectionState]";
            // 
            // btnConnectToSw
            // 
            this.tableLayoutSw.SetColumnSpan(this.btnConnectToSw, 2);
            this.btnConnectToSw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectToSw.Location = new System.Drawing.Point(3, 24);
            this.btnConnectToSw.Name = "btnConnectToSw";
            this.btnConnectToSw.Size = new System.Drawing.Size(316, 42);
            this.btnConnectToSw.TabIndex = 2;
            this.btnConnectToSw.Text = "Подключиться";
            this.btnConnectToSw.UseVisualStyleBackColor = true;
            this.btnConnectToSw.Click += new System.EventHandler(this.BtnConnectToSw_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 451);
            this.Controls.Add(this.tableLayoutBg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modellic";
            this.tableLayoutBg.ResumeLayout(false);
            this.tableLayoutBg.PerformLayout();
            this.groupFixture.ResumeLayout(false);
            this.tableLayoutDevice.ResumeLayout(false);
            this.tableLayoutDevice.PerformLayout();
            this.groupSw.ResumeLayout(false);
            this.tableLayoutSw.ResumeLayout(false);
            this.tableLayoutSw.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutBg;
        private System.Windows.Forms.GroupBox groupFixture;
        private System.Windows.Forms.GroupBox groupSw;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelConnectionState;
        private System.Windows.Forms.Button btnConnectToSw;
        private System.Windows.Forms.TableLayoutPanel tableLayoutDevice;
        private System.Windows.Forms.Label labelState7;
        private System.Windows.Forms.Label labelState6;
        private System.Windows.Forms.Label labelState5;
        private System.Windows.Forms.Label labelState4;
        private System.Windows.Forms.Label labelState3;
        private System.Windows.Forms.Label labelState2;
        private System.Windows.Forms.Label labelState1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnNextStage;
        private System.Windows.Forms.Button btnStageSettings;
        private System.Windows.Forms.Button btnAssembly;
    }
}
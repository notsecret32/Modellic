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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutDataGrid = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridSteps = new System.Windows.Forms.DataGridView();
            this.columnCursor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStepNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutControls = new System.Windows.Forms.TableLayoutPanel();
            this.groupFixture = new System.Windows.Forms.GroupBox();
            this.groupSw = new System.Windows.Forms.GroupBox();
            this.tableLayoutFixture = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutSolidworks = new System.Windows.Forms.TableLayoutPanel();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.btnAssembly = new System.Windows.Forms.Button();
            this.btnConnectToSw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSteps)).BeginInit();
            this.tableLayoutControls.SuspendLayout();
            this.groupFixture.SuspendLayout();
            this.groupSw.SuspendLayout();
            this.tableLayoutFixture.SuspendLayout();
            this.tableLayoutSolidworks.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tableLayoutControls);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutDataGrid);
            this.splitContainer.Size = new System.Drawing.Size(484, 217);
            this.splitContainer.SplitterDistance = 209;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;
            // 
            // tableLayoutDataGrid
            // 
            this.tableLayoutDataGrid.ColumnCount = 1;
            this.tableLayoutDataGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutDataGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDataGrid.Controls.Add(this.dataGridSteps, 0, 0);
            this.tableLayoutDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutDataGrid.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutDataGrid.Name = "tableLayoutDataGrid";
            this.tableLayoutDataGrid.Padding = new System.Windows.Forms.Padding(0, 6, 2, 1);
            this.tableLayoutDataGrid.RowCount = 1;
            this.tableLayoutDataGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutDataGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutDataGrid.Size = new System.Drawing.Size(274, 217);
            this.tableLayoutDataGrid.TabIndex = 0;
            // 
            // dataGridSteps
            // 
            this.dataGridSteps.AllowUserToAddRows = false;
            this.dataGridSteps.AllowUserToDeleteRows = false;
            this.dataGridSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSteps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnCursor,
            this.columnStepNumber,
            this.columnStatus});
            this.dataGridSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridSteps.Location = new System.Drawing.Point(3, 9);
            this.dataGridSteps.Name = "dataGridSteps";
            this.dataGridSteps.ReadOnly = true;
            this.dataGridSteps.Size = new System.Drawing.Size(266, 204);
            this.dataGridSteps.TabIndex = 1;
            // 
            // columnCursor
            // 
            this.columnCursor.HeaderText = "";
            this.columnCursor.Name = "columnCursor";
            this.columnCursor.ReadOnly = true;
            this.columnCursor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnCursor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnCursor.Width = 30;
            // 
            // columnStepNumber
            // 
            this.columnStepNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.columnStepNumber.HeaderText = "№ Шага";
            this.columnStepNumber.Name = "columnStepNumber";
            this.columnStepNumber.ReadOnly = true;
            this.columnStepNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.columnStepNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnStepNumber.Width = 53;
            // 
            // columnStatus
            // 
            this.columnStatus.HeaderText = "Статус";
            this.columnStatus.Name = "columnStatus";
            this.columnStatus.ReadOnly = true;
            this.columnStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tableLayoutControls
            // 
            this.tableLayoutControls.ColumnCount = 1;
            this.tableLayoutControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutControls.Controls.Add(this.groupFixture, 0, 0);
            this.tableLayoutControls.Controls.Add(this.groupSw, 0, 1);
            this.tableLayoutControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutControls.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutControls.Name = "tableLayoutControls";
            this.tableLayoutControls.RowCount = 2;
            this.tableLayoutControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutControls.Size = new System.Drawing.Size(209, 217);
            this.tableLayoutControls.TabIndex = 0;
            // 
            // groupFixture
            // 
            this.groupFixture.Controls.Add(this.tableLayoutFixture);
            this.groupFixture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupFixture.Location = new System.Drawing.Point(3, 3);
            this.groupFixture.Name = "groupFixture";
            this.groupFixture.Size = new System.Drawing.Size(203, 117);
            this.groupFixture.TabIndex = 0;
            this.groupFixture.TabStop = false;
            this.groupFixture.Text = "Приспособления";
            // 
            // groupSw
            // 
            this.groupSw.Controls.Add(this.tableLayoutSolidworks);
            this.groupSw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupSw.Location = new System.Drawing.Point(3, 126);
            this.groupSw.Name = "groupSw";
            this.groupSw.Size = new System.Drawing.Size(203, 88);
            this.groupSw.TabIndex = 1;
            this.groupSw.TabStop = false;
            this.groupSw.Text = "Solidworks";
            // 
            // tableLayoutFixture
            // 
            this.tableLayoutFixture.ColumnCount = 1;
            this.tableLayoutFixture.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutFixture.Controls.Add(this.btnNextStep, 0, 0);
            this.tableLayoutFixture.Controls.Add(this.btnAssembly, 0, 1);
            this.tableLayoutFixture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutFixture.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutFixture.Name = "tableLayoutFixture";
            this.tableLayoutFixture.RowCount = 2;
            this.tableLayoutFixture.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutFixture.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutFixture.Size = new System.Drawing.Size(197, 98);
            this.tableLayoutFixture.TabIndex = 0;
            // 
            // tableLayoutSolidworks
            // 
            this.tableLayoutSolidworks.ColumnCount = 2;
            this.tableLayoutSolidworks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSolidworks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutSolidworks.Controls.Add(this.btnConnectToSw, 0, 1);
            this.tableLayoutSolidworks.Controls.Add(this.label1, 0, 0);
            this.tableLayoutSolidworks.Controls.Add(this.labelConnectionStatus, 1, 0);
            this.tableLayoutSolidworks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSolidworks.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutSolidworks.Name = "tableLayoutSolidworks";
            this.tableLayoutSolidworks.RowCount = 2;
            this.tableLayoutSolidworks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutSolidworks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutSolidworks.Size = new System.Drawing.Size(197, 69);
            this.tableLayoutSolidworks.TabIndex = 0;
            // 
            // btnNextStep
            // 
            this.btnNextStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextStep.Location = new System.Drawing.Point(3, 3);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(191, 42);
            this.btnNextStep.TabIndex = 0;
            this.btnNextStep.Text = "[btnNextStep]";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.BtnNextStep_Click);
            // 
            // btnAssembly
            // 
            this.btnAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssembly.Location = new System.Drawing.Point(3, 52);
            this.btnAssembly.Name = "btnAssembly";
            this.btnAssembly.Size = new System.Drawing.Size(191, 42);
            this.btnAssembly.TabIndex = 1;
            this.btnAssembly.Text = "Сборка";
            this.btnAssembly.UseVisualStyleBackColor = true;
            // 
            // btnConnectToSw
            // 
            this.btnConnectToSw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutSolidworks.SetColumnSpan(this.btnConnectToSw, 2);
            this.btnConnectToSw.Location = new System.Drawing.Point(3, 24);
            this.btnConnectToSw.Name = "btnConnectToSw";
            this.btnConnectToSw.Size = new System.Drawing.Size(191, 42);
            this.btnConnectToSw.TabIndex = 1;
            this.btnConnectToSw.Text = "[btnConnectToSw]";
            this.btnConnectToSw.UseVisualStyleBackColor = true;
            this.btnConnectToSw.Click += new System.EventHandler(this.BtnConnectToSw_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label1.Size = new System.Drawing.Size(44, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Статус:";
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(101, 0);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.labelConnectionStatus.Size = new System.Drawing.Size(66, 21);
            this.labelConnectionStatus.TabIndex = 3;
            this.labelConnectionStatus.Text = "[connection]";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 217);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modellic";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSteps)).EndInit();
            this.tableLayoutControls.ResumeLayout(false);
            this.groupFixture.ResumeLayout(false);
            this.groupSw.ResumeLayout(false);
            this.tableLayoutFixture.ResumeLayout(false);
            this.tableLayoutSolidworks.ResumeLayout(false);
            this.tableLayoutSolidworks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutDataGrid;
        private System.Windows.Forms.DataGridView dataGridSteps;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCursor;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStepNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutControls;
        private System.Windows.Forms.GroupBox groupFixture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutFixture;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.GroupBox groupSw;
        private System.Windows.Forms.TableLayoutPanel tableLayoutSolidworks;
        private System.Windows.Forms.Button btnAssembly;
        private System.Windows.Forms.Button btnConnectToSw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelConnectionStatus;
    }
}
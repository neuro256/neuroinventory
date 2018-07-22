namespace NeuroInventory
{
    partial class DemandEditor
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
            this.lvDemandData = new BrightIdeasSoftware.DataListView();
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnSum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.highlightTextRenderer1 = new BrightIdeasSoftware.HighlightTextRenderer();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelLeftUpper = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnReleased = new System.Windows.Forms.Button();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.lvDemandData)).BeginInit();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelLeftUpper.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvDemandData
            // 
            this.lvDemandData.AllColumns.Add(this.olvColumn7);
            this.lvDemandData.AllColumns.Add(this.olvColumn1);
            this.lvDemandData.AllColumns.Add(this.olvColumn2);
            this.lvDemandData.AllColumns.Add(this.olvColumn8);
            this.lvDemandData.AllColumns.Add(this.olvColumn3);
            this.lvDemandData.AllColumns.Add(this.columnPrice);
            this.lvDemandData.AllColumns.Add(this.olvColumn5);
            this.lvDemandData.AllColumns.Add(this.columnSum);
            this.lvDemandData.CellEditUseWholeCell = false;
            this.lvDemandData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn7,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn8,
            this.olvColumn3,
            this.columnPrice,
            this.olvColumn5,
            this.columnSum});
            this.lvDemandData.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvDemandData.DataSource = null;
            this.lvDemandData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDemandData.FullRowSelect = true;
            this.lvDemandData.GridLines = true;
            this.lvDemandData.Location = new System.Drawing.Point(3, 3);
            this.lvDemandData.Name = "lvDemandData";
            this.lvDemandData.ShowGroups = false;
            this.lvDemandData.ShowItemToolTips = true;
            this.lvDemandData.Size = new System.Drawing.Size(840, 629);
            this.lvDemandData.TabIndex = 0;
            this.lvDemandData.UseCompatibleStateImageBehavior = false;
            this.lvDemandData.View = System.Windows.Forms.View.Details;
            this.lvDemandData.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.lvDemandData_CellEditFinishing);
            this.lvDemandData.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.lvDemandData_CellEditStarting);
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "";
            this.olvColumn7.IsEditable = false;
            this.olvColumn7.MaximumWidth = 1000;
            this.olvColumn7.MinimumWidth = 50;
            this.olvColumn7.Text = "№";
            this.olvColumn7.Width = 50;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "name";
            this.olvColumn1.ButtonPadding = new System.Drawing.Size(10, 10);
            this.olvColumn1.IsTileViewColumn = true;
            this.olvColumn1.MaximumWidth = 1000;
            this.olvColumn1.MinimumWidth = 50;
            this.olvColumn1.Text = "Название";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 250;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "OKEIcode";
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.MaximumWidth = 1000;
            this.olvColumn2.MinimumWidth = 50;
            this.olvColumn2.Text = "Код ОКЕИ";
            this.olvColumn2.Width = 90;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "invoice_code";
            this.olvColumn8.IsEditable = false;
            this.olvColumn8.MaximumWidth = 1000;
            this.olvColumn8.MinimumWidth = 50;
            this.olvColumn8.Text = "Номер накладной";
            this.olvColumn8.Width = 140;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "measurement";
            this.olvColumn3.IsEditable = false;
            this.olvColumn3.MaximumWidth = 1000;
            this.olvColumn3.MinimumWidth = 50;
            this.olvColumn3.Text = "Единица измерения";
            this.olvColumn3.Width = 150;
            // 
            // columnPrice
            // 
            this.columnPrice.AspectName = "price";
            this.columnPrice.AspectToStringFormat = "";
            this.columnPrice.IsEditable = false;
            this.columnPrice.MaximumWidth = 1000;
            this.columnPrice.MinimumWidth = 50;
            this.columnPrice.Text = "Цена";
            this.columnPrice.Width = 100;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "amount";
            this.olvColumn5.MaximumWidth = 1000;
            this.olvColumn5.MinimumWidth = 50;
            this.olvColumn5.Text = "Количество";
            this.olvColumn5.Width = 100;
            // 
            // columnSum
            // 
            this.columnSum.AspectName = "sum";
            this.columnSum.AspectToStringFormat = "";
            this.columnSum.IsEditable = false;
            this.columnSum.MaximumWidth = 1000;
            this.columnSum.MinimumWidth = 50;
            this.columnSum.Text = "Сумма";
            this.columnSum.Width = 100;
            // 
            // highlightTextRenderer1
            // 
            this.highlightTextRenderer1.CanWrap = true;
            this.highlightTextRenderer1.UseGdiTextRendering = false;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.59237F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.40763F));
            this.tableLayoutPanelMain.Controls.Add(this.lvDemandData, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelLeftUpper, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1182, 635);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // panelLeftUpper
            // 
            this.panelLeftUpper.Controls.Add(this.lblDate);
            this.panelLeftUpper.Controls.Add(this.dateTimePicker);
            this.panelLeftUpper.Controls.Add(this.btnReleased);
            this.panelLeftUpper.Controls.Add(this.lblEmployee);
            this.panelLeftUpper.Controls.Add(this.cbEmployee);
            this.panelLeftUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftUpper.Location = new System.Drawing.Point(849, 3);
            this.panelLeftUpper.Name = "panelLeftUpper";
            this.panelLeftUpper.Size = new System.Drawing.Size(330, 629);
            this.panelLeftUpper.TabIndex = 7;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Silver;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDate.Location = new System.Drawing.Point(3, 74);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 18);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "Дата";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.Location = new System.Drawing.Point(3, 95);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(318, 22);
            this.dateTimePicker.TabIndex = 9;
            // 
            // btnReleased
            // 
            this.btnReleased.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReleased.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnReleased.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReleased.Location = new System.Drawing.Point(3, 587);
            this.btnReleased.Name = "btnReleased";
            this.btnReleased.Size = new System.Drawing.Size(318, 33);
            this.btnReleased.TabIndex = 5;
            this.btnReleased.Text = "Сформировать отчет";
            this.btnReleased.UseVisualStyleBackColor = true;
            this.btnReleased.Click += new System.EventHandler(this.btnReleased_Click);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.BackColor = System.Drawing.Color.Silver;
            this.lblEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEmployee.Location = new System.Drawing.Point(3, 16);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(75, 18);
            this.lblEmployee.TabIndex = 8;
            this.lblEmployee.Text = "Работник";
            // 
            // cbEmployee
            // 
            this.cbEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEmployee.DropDownHeight = 115;
            this.cbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.IntegralHeight = false;
            this.cbEmployee.Location = new System.Drawing.Point(6, 37);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(315, 24);
            this.cbEmployee.TabIndex = 7;
            // 
            // DemandEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 635);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DemandEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор требований";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DemandEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.lvDemandData)).EndInit();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelLeftUpper.ResumeLayout(false);
            this.panelLeftUpper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.DataListView lvDemandData;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.HighlightTextRenderer highlightTextRenderer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn columnPrice;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn columnSum;
        private System.Windows.Forms.Button btnReleased;
        private System.Windows.Forms.Panel panelLeftUpper;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
    }
}
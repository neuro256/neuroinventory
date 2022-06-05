namespace NeuroInventory
{
    partial class DemandReportList
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelDemandReportListBottom = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dlvDemandReport = new BrightIdeasSoftware.FastDataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStripDemandReportList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelDemandReportListBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvDemandReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.panelDemandReportListBottom, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.dlvDemandReport, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(782, 560);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelDemandReportListBottom
            // 
            this.panelDemandReportListBottom.BackColor = Definitions.COLOR_FORM_MAIN_BACK_COLOR;
            this.panelDemandReportListBottom.Controls.Add(this.btnDelete);
            this.panelDemandReportListBottom.Controls.Add(this.btnAdd);
            this.panelDemandReportListBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDemandReportListBottom.Location = new System.Drawing.Point(3, 513);
            this.panelDemandReportListBottom.Name = "panelDemandReportListBottom";
            this.panelDemandReportListBottom.Size = new System.Drawing.Size(776, 44);
            this.panelDemandReportListBottom.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.FlatAppearance.BorderColor = Definitions.COLOR_FORM_MAIN_BACK_COLOR;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.Location = new System.Drawing.Point(9, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 29);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatAppearance.BorderColor = Definitions.COLOR_FORM_MAIN_BACK_COLOR;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(113, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 29);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            // 
            // dlvDemandReport
            // 
            this.dlvDemandReport.AllColumns.Add(this.olvColumn1);
            this.dlvDemandReport.AllColumns.Add(this.olvColumn2);
            this.dlvDemandReport.AllColumns.Add(this.columnDate);
            this.dlvDemandReport.AllColumns.Add(this.olvColumn4);
            this.dlvDemandReport.CellEditUseWholeCell = false;
            this.dlvDemandReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.columnDate,
            this.olvColumn4});
            this.dlvDemandReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.dlvDemandReport.DataSource = null;
            this.dlvDemandReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvDemandReport.Location = new System.Drawing.Point(3, 3);
            this.dlvDemandReport.Name = "dlvDemandReport";
            this.dlvDemandReport.Size = new System.Drawing.Size(776, 504);
            this.dlvDemandReport.TabIndex = 2;
            this.dlvDemandReport.UseCompatibleStateImageBehavior = false;
            this.dlvDemandReport.View = System.Windows.Forms.View.Details;
            this.dlvDemandReport.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.dlvDemandReport_CellClick);
            this.dlvDemandReport.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.dlvDemandReport_CellRightClick);
            this.dlvDemandReport.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.dlvDemandReport_FormatCell);
            // 
            // olvColumn1
            // 
            this.olvColumn1.Groupable = false;
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.MaximumWidth = 1000;
            this.olvColumn1.MinimumWidth = 50;
            this.olvColumn1.Searchable = false;
            this.olvColumn1.Sortable = false;
            this.olvColumn1.Text = "№";
            this.olvColumn1.Width = 50;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "employeeId";
            this.olvColumn2.Groupable = false;
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.MaximumWidth = 1000;
            this.olvColumn2.MinimumWidth = 50;
            this.olvColumn2.Text = "Работник";
            this.olvColumn2.Width = 200;
            // 
            // columnDate
            // 
            this.columnDate.AspectName = "date";
            this.columnDate.Groupable = false;
            this.columnDate.IsEditable = false;
            this.columnDate.MaximumWidth = 1000;
            this.columnDate.MinimumWidth = 50;
            this.columnDate.Text = "Дата";
            this.columnDate.Width = 200;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "document";
            this.olvColumn4.Groupable = false;
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.MaximumWidth = 1000;
            this.olvColumn4.MinimumWidth = 50;
            this.olvColumn4.Searchable = false;
            this.olvColumn4.Sortable = false;
            this.olvColumn4.Text = "Документ";
            this.olvColumn4.Width = 200;
            // 
            // contextMenuStripDemandReportList
            // 
            this.contextMenuStripDemandReportList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripDemandReportList.Name = "contextMenuStripDemandReportList";
            this.contextMenuStripDemandReportList.Size = new System.Drawing.Size(61, 4);
            // 
            // DemandReportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 560);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DemandReportList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Список требований";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DemandReportList_FormClosing);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelDemandReportListBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvDemandReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelDemandReportListBottom;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDemandReportList;
        private BrightIdeasSoftware.FastDataListView dlvDemandReport;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn columnDate;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
    }
}
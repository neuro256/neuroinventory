namespace NeuroInventory
{
    partial class DebitReportList
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
            this.panelDebitReportListBottom = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dlvDebitReport = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStripDebitReportList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelDebitReportListBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvDebitReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.panelDebitReportListBottom, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.dlvDebitReport, 0, 0);
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
            // panelDebitReportListBottom
            // 
            this.panelDebitReportListBottom.Controls.Add(this.btnDelete);
            this.panelDebitReportListBottom.Controls.Add(this.btnAdd);
            this.panelDebitReportListBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDebitReportListBottom.Location = new System.Drawing.Point(3, 513);
            this.panelDebitReportListBottom.Name = "panelDebitReportListBottom";
            this.panelDebitReportListBottom.Size = new System.Drawing.Size(776, 44);
            this.panelDebitReportListBottom.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
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
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
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
            // dlvDebitReport
            // 
            this.dlvDebitReport.AllColumns.Add(this.olvColumn1);
            this.dlvDebitReport.AllColumns.Add(this.olvColumn2);
            this.dlvDebitReport.AllColumns.Add(this.olvColumn3);
            this.dlvDebitReport.CellEditUseWholeCell = false;
            this.dlvDebitReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
            this.dlvDebitReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.dlvDebitReport.DataSource = null;
            this.dlvDebitReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvDebitReport.Location = new System.Drawing.Point(3, 3);
            this.dlvDebitReport.Name = "dlvDebitReport";
            this.dlvDebitReport.Size = new System.Drawing.Size(776, 504);
            this.dlvDebitReport.TabIndex = 2;
            this.dlvDebitReport.UseCompatibleStateImageBehavior = false;
            this.dlvDebitReport.View = System.Windows.Forms.View.Details;
            this.dlvDebitReport.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.dlvDebitReport_CellClick);
            this.dlvDebitReport.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.dlvDebitReport_CellRightClick);
            this.dlvDebitReport.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.dlvDebitReport_FormatCell);
            // 
            // olvColumn1
            // 
            this.olvColumn1.Groupable = false;
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.Text = "№";
            this.olvColumn1.Width = 50;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "date";
            this.olvColumn2.Groupable = false;
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.Text = "Дата";
            this.olvColumn2.Width = 200;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "document";
            this.olvColumn3.Groupable = false;
            this.olvColumn3.IsEditable = false;
            this.olvColumn3.Text = "Документ";
            this.olvColumn3.Width = 200;
            // 
            // contextMenuStripDebitReportList
            // 
            this.contextMenuStripDebitReportList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripDebitReportList.Name = "contextMenuStripDebitReportList";
            this.contextMenuStripDebitReportList.Size = new System.Drawing.Size(61, 4);
            // 
            // DebitReportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 560);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DebitReportList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Список требований";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebitReportList_FormClosing);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelDebitReportListBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvDebitReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelDebitReportListBottom;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDebitReportList;
        private BrightIdeasSoftware.DataListView dlvDebitReport;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
    }
}
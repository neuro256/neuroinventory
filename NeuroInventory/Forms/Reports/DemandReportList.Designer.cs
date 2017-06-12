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
            this.lvDemandReportList = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmployee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelDemandReportListBottom = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.contextMenuStripDemandReportList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelDemandReportListBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.lvDemandReportList, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelDemandReportListBottom, 0, 1);
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
            // lvDemandReportList
            // 
            this.lvDemandReportList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvDemandReportList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderNumber,
            this.columnHeaderEmployee,
            this.columnHeaderDate,
            this.columnHeaderDoc});
            this.lvDemandReportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDemandReportList.FullRowSelect = true;
            this.lvDemandReportList.GridLines = true;
            this.lvDemandReportList.Location = new System.Drawing.Point(3, 3);
            this.lvDemandReportList.MultiSelect = false;
            this.lvDemandReportList.Name = "lvDemandReportList";
            this.lvDemandReportList.Size = new System.Drawing.Size(776, 504);
            this.lvDemandReportList.TabIndex = 0;
            this.lvDemandReportList.UseCompatibleStateImageBehavior = false;
            this.lvDemandReportList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "id";
            // 
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.Text = "#";
            // 
            // columnHeaderEmployee
            // 
            this.columnHeaderEmployee.Text = "Работник";
            this.columnHeaderEmployee.Width = 120;
            // 
            // columnHeaderDate
            // 
            this.columnHeaderDate.Text = "Дата";
            this.columnHeaderDate.Width = 100;
            // 
            // columnHeaderDoc
            // 
            this.columnHeaderDoc.Text = "Документ";
            this.columnHeaderDoc.Width = 250;
            // 
            // panelDemandReportListBottom
            // 
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
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.Location = new System.Drawing.Point(113, 6);
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
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(9, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 29);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // contextMenuStripDemandReportList
            // 
            this.contextMenuStripDemandReportList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripDemandReportList.Name = "contextMenuStripDemandReportList";
            this.contextMenuStripDemandReportList.Size = new System.Drawing.Size(67, 4);
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
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelDemandReportListBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.ListView lvDemandReportList;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderEmployee;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderDoc;
        private System.Windows.Forms.Panel panelDemandReportListBottom;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDemandReportList;
    }
}
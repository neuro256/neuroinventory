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
            this.lvDebitReportList = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelDebitReportListBottom = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.contextMenuStripDebitReportList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelDebitReportListBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.lvDebitReportList, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelDebitReportListBottom, 0, 1);
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
            // lvDebitReportList
            // 
            this.lvDebitReportList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvDebitReportList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderNumber,
            this.columnHeaderDate,
            this.columnHeaderDoc});
            this.lvDebitReportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDebitReportList.FullRowSelect = true;
            this.lvDebitReportList.GridLines = true;
            this.lvDebitReportList.Location = new System.Drawing.Point(3, 3);
            this.lvDebitReportList.MultiSelect = false;
            this.lvDebitReportList.Name = "lvDebitReportList";
            this.lvDebitReportList.Size = new System.Drawing.Size(776, 504);
            this.lvDebitReportList.TabIndex = 0;
            this.lvDebitReportList.UseCompatibleStateImageBehavior = false;
            this.lvDebitReportList.View = System.Windows.Forms.View.Details;
            this.lvDebitReportList.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvDebitReportList_ColumnWidthChanged);
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "id";
            // 
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.Text = "#";
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
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelDebitReportListBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.ListView lvDebitReportList;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderDate;
        private System.Windows.Forms.ColumnHeader columnHeaderDoc;
        private System.Windows.Forms.Panel panelDebitReportListBottom;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDebitReportList;
    }
}
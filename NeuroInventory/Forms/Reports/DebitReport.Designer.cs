namespace NeuroInventory
{
    partial class DebitReport
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
            this.tableLayoutPanelDebitReport = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCatalog = new System.Windows.Forms.ComboBox();
            this.lblCatalog = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lwDebitReport = new System.Windows.Forms.ListView();
            this.panelDebitReportBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.tableLayoutPanelDebitReport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelDebitReportBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelDebitReport
            // 
            this.tableLayoutPanelDebitReport.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanelDebitReport.ColumnCount = 1;
            this.tableLayoutPanelDebitReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDebitReport.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanelDebitReport.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanelDebitReport.Controls.Add(this.panelDebitReportBottom, 0, 2);
            this.tableLayoutPanelDebitReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDebitReport.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDebitReport.Name = "tableLayoutPanelDebitReport";
            this.tableLayoutPanelDebitReport.RowCount = 3;
            this.tableLayoutPanelDebitReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.82327F));
            this.tableLayoutPanelDebitReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.17673F));
            this.tableLayoutPanelDebitReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelDebitReport.Size = new System.Drawing.Size(782, 560);
            this.tableLayoutPanelDebitReport.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Controls.Add(this.cbCatalog);
            this.groupBox1.Controls.Add(this.lblCatalog);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор каталога";
            // 
            // cbCatalog
            // 
            this.cbCatalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCatalog.FormattingEnabled = true;
            this.cbCatalog.Location = new System.Drawing.Point(77, 30);
            this.cbCatalog.Name = "cbCatalog";
            this.cbCatalog.Size = new System.Drawing.Size(260, 24);
            this.cbCatalog.TabIndex = 3;
            this.cbCatalog.SelectionChangeCommitted += new System.EventHandler(this.cbCatalog_SelectionChangeCommitted);
            // 
            // lblCatalog
            // 
            this.lblCatalog.AutoSize = true;
            this.lblCatalog.Location = new System.Drawing.Point(10, 33);
            this.lblCatalog.Name = "lblCatalog";
            this.lblCatalog.Size = new System.Drawing.Size(61, 17);
            this.lblCatalog.TabIndex = 2;
            this.lblCatalog.Text = "Каталог";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lwDebitReport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 78);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 427);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбор записей";
            // 
            // lwDebitReport
            // 
            this.lwDebitReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwDebitReport.Location = new System.Drawing.Point(3, 18);
            this.lwDebitReport.Name = "lwDebitReport";
            this.lwDebitReport.Size = new System.Drawing.Size(772, 406);
            this.lwDebitReport.TabIndex = 0;
            this.lwDebitReport.UseCompatibleStateImageBehavior = false;
            this.lwDebitReport.View = System.Windows.Forms.View.Details;
            this.lwDebitReport.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lwDebitReport_ColumnClick);
            this.lwDebitReport.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lwDebitReport_DrawColumnHeader);
            this.lwDebitReport.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lwDebitReport_DrawItem);
            this.lwDebitReport.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lwDebitReport_DrawSubItem);
            this.lwDebitReport.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lwDebitReport_ItemSelectionChanged);
            // 
            // panelDebitReportBottom
            // 
            this.panelDebitReportBottom.Controls.Add(this.btnClose);
            this.panelDebitReportBottom.Controls.Add(this.btnReport);
            this.panelDebitReportBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDebitReportBottom.Location = new System.Drawing.Point(5, 510);
            this.panelDebitReportBottom.Name = "panelDebitReportBottom";
            this.panelDebitReportBottom.Size = new System.Drawing.Size(772, 45);
            this.panelDebitReportBottom.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(596, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(169, 34);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Закрыть окно";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(7, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(169, 34);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Сформировать отчет";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(568, 28);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(432, 31);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(130, 17);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Дата составления";
            // 
            // DebitReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 560);
            this.Controls.Add(this.tableLayoutPanelDebitReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DebitReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Формирование документа списания";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebitReport_FormClosing);
            this.Shown += new System.EventHandler(this.DebitReport_Shown);
            this.tableLayoutPanelDebitReport.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelDebitReportBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDebitReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lwDebitReport;
        private System.Windows.Forms.ComboBox cbCatalog;
        private System.Windows.Forms.Label lblCatalog;
        private System.Windows.Forms.Panel panelDebitReportBottom;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}
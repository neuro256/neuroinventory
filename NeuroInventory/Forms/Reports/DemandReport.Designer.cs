namespace NeuroInventory
{
    partial class DemandReport
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
            this.tableLayoutPanelDemandReport = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCatalog = new System.Windows.Forms.ComboBox();
            this.lblCatalog = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lwDemandReport = new System.Windows.Forms.ListView();
            this.panelDemandReportBottom = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.tableLayoutPanelDemandReport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelDemandReportBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelDemandReport
            // 
            this.tableLayoutPanelDemandReport.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanelDemandReport.ColumnCount = 1;
            this.tableLayoutPanelDemandReport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDemandReport.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanelDemandReport.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanelDemandReport.Controls.Add(this.panelDemandReportBottom, 0, 2);
            this.tableLayoutPanelDemandReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDemandReport.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDemandReport.Name = "tableLayoutPanelDemandReport";
            this.tableLayoutPanelDemandReport.RowCount = 3;
            this.tableLayoutPanelDemandReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.80943F));
            this.tableLayoutPanelDemandReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.19057F));
            this.tableLayoutPanelDemandReport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelDemandReport.Size = new System.Drawing.Size(782, 560);
            this.tableLayoutPanelDemandReport.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCatalog);
            this.groupBox1.Controls.Add(this.lblCatalog);
            this.groupBox1.Controls.Add(this.lblEmployee);
            this.groupBox1.Controls.Add(this.cbEmployee);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор сотрудника и каталога";
            // 
            // cbCatalog
            // 
            this.cbCatalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCatalog.FormattingEnabled = true;
            this.cbCatalog.Location = new System.Drawing.Point(87, 73);
            this.cbCatalog.Name = "cbCatalog";
            this.cbCatalog.Size = new System.Drawing.Size(260, 24);
            this.cbCatalog.TabIndex = 3;
            this.cbCatalog.SelectionChangeCommitted += new System.EventHandler(this.cbCatalog_SelectionChangeCommitted);
            // 
            // lblCatalog
            // 
            this.lblCatalog.AutoSize = true;
            this.lblCatalog.Location = new System.Drawing.Point(20, 76);
            this.lblCatalog.Name = "lblCatalog";
            this.lblCatalog.Size = new System.Drawing.Size(61, 17);
            this.lblCatalog.TabIndex = 2;
            this.lblCatalog.Text = "Каталог";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(10, 28);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(71, 17);
            this.lblEmployee.TabIndex = 1;
            this.lblEmployee.Text = "Работник";
            // 
            // cbEmployee
            // 
            this.cbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(87, 25);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(260, 24);
            this.cbEmployee.TabIndex = 0;
            this.cbEmployee.SelectionChangeCommitted += new System.EventHandler(this.cbEmployee_SelectionChangeCommitted);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lwDemandReport);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 133);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 372);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбор записей";
            // 
            // lwDemandReport
            // 
            this.lwDemandReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwDemandReport.Location = new System.Drawing.Point(3, 18);
            this.lwDemandReport.Name = "lwDemandReport";
            this.lwDemandReport.Size = new System.Drawing.Size(772, 351);
            this.lwDemandReport.TabIndex = 0;
            this.lwDemandReport.UseCompatibleStateImageBehavior = false;
            this.lwDemandReport.View = System.Windows.Forms.View.Details;
            this.lwDemandReport.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lwDemandReport_ColumnClick);
            this.lwDemandReport.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lwDemandReport_DrawColumnHeader);
            this.lwDemandReport.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lwDemandReport_DrawItem);
            this.lwDemandReport.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lwDemandReport_DrawSubItem);
            this.lwDemandReport.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lwDemandReport_ItemSelectionChanged);
            // 
            // panelDemandReportBottom
            // 
            this.panelDemandReportBottom.Controls.Add(this.btnReport);
            this.panelDemandReportBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDemandReportBottom.Location = new System.Drawing.Point(5, 510);
            this.panelDemandReportBottom.Name = "panelDemandReportBottom";
            this.panelDemandReportBottom.Size = new System.Drawing.Size(772, 45);
            this.panelDemandReportBottom.TabIndex = 2;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(7, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(169, 34);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Сформировать отчет";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // DemandReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 560);
            this.Controls.Add(this.tableLayoutPanelDemandReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DemandReport";
            this.Text = "Формирование требования-накладной";
            this.Shown += new System.EventHandler(this.DemandReport_Shown);
            this.tableLayoutPanelDemandReport.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelDemandReportBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDemandReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lwDemandReport;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.ComboBox cbCatalog;
        private System.Windows.Forms.Label lblCatalog;
        private System.Windows.Forms.Panel panelDemandReportBottom;
        private System.Windows.Forms.Button btnReport;
    }
}
namespace NeuroInventory
{
    partial class DebitReportNew
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
            this.tableLayoutPanelDebitReportNew = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFilter = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lwDebitReportNew = new System.Windows.Forms.ListView();
            this.panelDebitReportNewBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.tableLayoutPanelDebitReportNew.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelDebitReportNewBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelDebitReportNew
            // 
            this.tableLayoutPanelDebitReportNew.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanelDebitReportNew.ColumnCount = 1;
            this.tableLayoutPanelDebitReportNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDebitReportNew.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanelDebitReportNew.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanelDebitReportNew.Controls.Add(this.panelDebitReportNewBottom, 0, 2);
            this.tableLayoutPanelDebitReportNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDebitReportNew.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDebitReportNew.Name = "tableLayoutPanelDebitReportNew";
            this.tableLayoutPanelDebitReportNew.RowCount = 3;
            this.tableLayoutPanelDebitReportNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.13079F));
            this.tableLayoutPanelDebitReportNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.86922F));
            this.tableLayoutPanelDebitReportNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelDebitReportNew.Size = new System.Drawing.Size(782, 560);
            this.tableLayoutPanelDebitReportNew.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFilter);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // cbFilter
            // 
            this.cbFilter.AutoSize = true;
            this.cbFilter.Checked = true;
            this.cbFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFilter.Location = new System.Drawing.Point(10, 30);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(247, 21);
            this.cbFilter.TabIndex = 6;
            this.cbFilter.Text = "Включать только списанные тмц";
            this.cbFilter.UseVisualStyleBackColor = true;
            this.cbFilter.CheckedChanged += new System.EventHandler(this.cbFilter_CheckedChanged);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(432, 31);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(130, 17);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Дата составления";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(568, 28);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lwDebitReportNew);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 95);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 410);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Выбор записей";
            // 
            // lwDebitReportNew
            // 
            this.lwDebitReportNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwDebitReportNew.Location = new System.Drawing.Point(3, 18);
            this.lwDebitReportNew.Name = "lwDebitReportNew";
            this.lwDebitReportNew.Size = new System.Drawing.Size(772, 389);
            this.lwDebitReportNew.TabIndex = 0;
            this.lwDebitReportNew.UseCompatibleStateImageBehavior = false;
            this.lwDebitReportNew.View = System.Windows.Forms.View.Details;
            this.lwDebitReportNew.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lwDebitReportNew_ColumnClick);
            this.lwDebitReportNew.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lwDebitReportNew_DrawColumnHeader);
            this.lwDebitReportNew.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lwDebitReportNew_DrawItem);
            this.lwDebitReportNew.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lwDebitReportNew_DrawSubItem);
            this.lwDebitReportNew.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lwDebitReportNew_ItemSelectionChanged);
            // 
            // panelDebitReportNewBottom
            // 
            this.panelDebitReportNewBottom.Controls.Add(this.btnClose);
            this.panelDebitReportNewBottom.Controls.Add(this.btnReport);
            this.panelDebitReportNewBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDebitReportNewBottom.Location = new System.Drawing.Point(5, 510);
            this.panelDebitReportNewBottom.Name = "panelDebitReportNewBottom";
            this.panelDebitReportNewBottom.Size = new System.Drawing.Size(772, 45);
            this.panelDebitReportNewBottom.TabIndex = 2;
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
            // DebitReportNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 560);
            this.Controls.Add(this.tableLayoutPanelDebitReportNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DebitReportNew";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Формирование документа списания";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebitReportNew_FormClosing);
            this.Shown += new System.EventHandler(this.DebitReportNew_Shown);
            this.tableLayoutPanelDebitReportNew.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelDebitReportNewBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDebitReportNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lwDebitReportNew;
        private System.Windows.Forms.Panel panelDebitReportNewBottom;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.CheckBox cbFilter;
    }
}
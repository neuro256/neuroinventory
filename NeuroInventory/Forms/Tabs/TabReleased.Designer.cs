using System;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    partial class TabReleased
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
            this.tableLayoutPanelReleased = new System.Windows.Forms.TableLayoutPanel();
            this.panelReleasedBottom = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnDebitCancel = new System.Windows.Forms.Button();
            this.btnDebitReport = new System.Windows.Forms.Button();
            this.btnReleasedRemove = new System.Windows.Forms.Button();
            this.dlvReleased = new BrightIdeasSoftware.FastDataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnDate1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnDate2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnDate3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnAmount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnSum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn13 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn14 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStripReleased = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxShowAll = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelReleased.SuspendLayout();
            this.panelReleasedBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvReleased)).BeginInit();
            this.contextMenuStripReleased.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelReleased
            // 
            this.tableLayoutPanelReleased.ColumnCount = 1;
            this.tableLayoutPanelReleased.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelReleased.Controls.Add(this.panelReleasedBottom, 0, 0);
            this.tableLayoutPanelReleased.Controls.Add(this.dlvReleased, 0, 1);
            this.tableLayoutPanelReleased.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelReleased.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelReleased.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelReleased.Name = "tableLayoutPanelReleased";
            this.tableLayoutPanelReleased.RowCount = 2;
            this.tableLayoutPanelReleased.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelReleased.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelReleased.Size = new System.Drawing.Size(1200, 650);
            this.tableLayoutPanelReleased.TabIndex = 1;
            // 
            // panelReleasedBottom
            // 
            this.panelReleasedBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelReleasedBottom.Controls.Add(this.checkBoxShowAll);
            this.panelReleasedBottom.Controls.Add(this.lblFilter);
            this.panelReleasedBottom.Controls.Add(this.tbFilter);
            this.panelReleasedBottom.Controls.Add(this.btnDebitCancel);
            this.panelReleasedBottom.Controls.Add(this.btnDebitReport);
            this.panelReleasedBottom.Controls.Add(this.btnReleasedRemove);
            this.panelReleasedBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReleasedBottom.Location = new System.Drawing.Point(0, 0);
            this.panelReleasedBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelReleasedBottom.Name = "panelReleasedBottom";
            this.panelReleasedBottom.Size = new System.Drawing.Size(1200, 55);
            this.panelReleasedBottom.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(915, 15);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(62, 16);
            this.lblFilter.TabIndex = 9;
            this.lblFilter.Text = "Фильтр: ";
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilter.Location = new System.Drawing.Point(988, 12);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(200, 22);
            this.tbFilter.TabIndex = 8;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // btnDebitCancel
            // 
            this.btnDebitCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnDebitCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnDebitCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDebitCancel.Location = new System.Drawing.Point(202, 12);
            this.btnDebitCancel.Name = "btnDebitCancel";
            this.btnDebitCancel.Size = new System.Drawing.Size(184, 33);
            this.btnDebitCancel.TabIndex = 5;
            this.btnDebitCancel.Text = "Отменить списание";
            this.btnDebitCancel.UseVisualStyleBackColor = false;
            this.btnDebitCancel.Click += new System.EventHandler(this.btnDebitCancel_Click);
            // 
            // btnDebitReport
            // 
            this.btnDebitReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(189)))));
            this.btnDebitReport.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnDebitReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDebitReport.Location = new System.Drawing.Point(12, 12);
            this.btnDebitReport.Name = "btnDebitReport";
            this.btnDebitReport.Size = new System.Drawing.Size(184, 33);
            this.btnDebitReport.TabIndex = 4;
            this.btnDebitReport.Text = "Списать ТМЦ";
            this.btnDebitReport.UseVisualStyleBackColor = false;
            this.btnDebitReport.Click += new System.EventHandler(this.btnDebitReport_Click);
            // 
            // btnReleasedRemove
            // 
            this.btnReleasedRemove.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnReleasedRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReleasedRemove.Location = new System.Drawing.Point(392, 12);
            this.btnReleasedRemove.Name = "btnReleasedRemove";
            this.btnReleasedRemove.Size = new System.Drawing.Size(184, 33);
            this.btnReleasedRemove.TabIndex = 1;
            this.btnReleasedRemove.Text = "Отменить отпуск";
            this.btnReleasedRemove.UseVisualStyleBackColor = true;
            this.btnReleasedRemove.Click += new System.EventHandler(this.btnReleasedRemove_Click);
            // 
            // dlvReleased
            // 
            this.dlvReleased.AllColumns.Add(this.olvColumn1);
            this.dlvReleased.AllColumns.Add(this.columnDate1);
            this.dlvReleased.AllColumns.Add(this.columnDate2);
            this.dlvReleased.AllColumns.Add(this.olvColumn4);
            this.dlvReleased.AllColumns.Add(this.columnDate3);
            this.dlvReleased.AllColumns.Add(this.olvColumn6);
            this.dlvReleased.AllColumns.Add(this.olvColumn7);
            this.dlvReleased.AllColumns.Add(this.olvColumn8);
            this.dlvReleased.AllColumns.Add(this.olvColumn9);
            this.dlvReleased.AllColumns.Add(this.columnAmount);
            this.dlvReleased.AllColumns.Add(this.columnPrice);
            this.dlvReleased.AllColumns.Add(this.columnSum);
            this.dlvReleased.AllColumns.Add(this.olvColumn13);
            this.dlvReleased.AllColumns.Add(this.olvColumn14);
            this.dlvReleased.CellEditUseWholeCell = false;
            this.dlvReleased.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.columnDate1,
            this.columnDate2,
            this.olvColumn4,
            this.columnDate3,
            this.olvColumn6,
            this.olvColumn7,
            this.olvColumn8,
            this.olvColumn9,
            this.columnAmount,
            this.columnPrice,
            this.columnSum,
            this.olvColumn13,
            this.olvColumn14});
            this.dlvReleased.Cursor = System.Windows.Forms.Cursors.Default;
            this.dlvReleased.DataSource = null;
            this.dlvReleased.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvReleased.HideSelection = false;
            this.dlvReleased.Location = new System.Drawing.Point(3, 58);
            this.dlvReleased.Name = "dlvReleased";
            this.dlvReleased.ShowGroups = false;
            this.dlvReleased.Size = new System.Drawing.Size(1194, 589);
            this.dlvReleased.TabIndex = 2;
            this.dlvReleased.UseCompatibleStateImageBehavior = false;
            this.dlvReleased.View = System.Windows.Forms.View.Details;
            this.dlvReleased.VirtualMode = true;
            this.dlvReleased.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.dlvReleased_CellClick);
            this.dlvReleased.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.dlvReleased_CellRightClick);
            this.dlvReleased.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.dlvReleased_ItemChecked);
            // 
            // olvColumn1
            // 
            this.olvColumn1.Groupable = false;
            this.olvColumn1.HeaderCheckBox = true;
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.MaximumWidth = 1000;
            this.olvColumn1.MinimumWidth = 50;
            this.olvColumn1.Searchable = false;
            this.olvColumn1.Sortable = false;
            this.olvColumn1.Text = "№";
            this.olvColumn1.Width = 50;
            // 
            // columnDate1
            // 
            this.columnDate1.AspectName = "ordate";
            this.columnDate1.Groupable = false;
            this.columnDate1.IsEditable = false;
            this.columnDate1.Text = "Дата поступления";
            this.columnDate1.Width = 200;
            // 
            // columnDate2
            // 
            this.columnDate2.AspectName = "mydate";
            this.columnDate2.Groupable = false;
            this.columnDate2.IsEditable = false;
            this.columnDate2.Text = "Дата отпуска";
            this.columnDate2.Width = 200;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "invoiceCodeStr";
            this.olvColumn4.Groupable = false;
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.Text = "Номер накладной";
            this.olvColumn4.Width = 200;
            // 
            // columnDate3
            // 
            this.columnDate3.AspectName = "invoiceDate";
            this.columnDate3.AspectToStringFormat = "";
            this.columnDate3.Groupable = false;
            this.columnDate3.IsEditable = false;
            this.columnDate3.Text = "Дата накладной";
            this.columnDate3.Width = 200;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "name";
            this.olvColumn6.Groupable = false;
            this.olvColumn6.IsEditable = false;
            this.olvColumn6.Text = "Наименование";
            this.olvColumn6.Width = 200;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "OKEIcode";
            this.olvColumn7.Groupable = false;
            this.olvColumn7.IsEditable = false;
            this.olvColumn7.Text = "Код ОКЕИ";
            this.olvColumn7.Width = 200;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "measurement";
            this.olvColumn8.Groupable = false;
            this.olvColumn8.IsEditable = false;
            this.olvColumn8.Text = "Единица измерения";
            this.olvColumn8.Width = 200;
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "employee";
            this.olvColumn9.Groupable = false;
            this.olvColumn9.IsEditable = false;
            this.olvColumn9.Text = "Кому отпущено";
            this.olvColumn9.Width = 200;
            // 
            // columnAmount
            // 
            this.columnAmount.AspectName = "amount";
            this.columnAmount.Groupable = false;
            this.columnAmount.IsEditable = false;
            this.columnAmount.Text = "Количество";
            this.columnAmount.Width = 200;
            // 
            // columnPrice
            // 
            this.columnPrice.AspectName = "price";
            this.columnPrice.AspectToStringFormat = "";
            this.columnPrice.Groupable = false;
            this.columnPrice.IsEditable = false;
            this.columnPrice.Text = "Цена";
            this.columnPrice.Width = 200;
            // 
            // columnSum
            // 
            this.columnSum.AspectName = "sum";
            this.columnSum.AspectToStringFormat = "";
            this.columnSum.Groupable = false;
            this.columnSum.IsEditable = false;
            this.columnSum.Text = "Сумма";
            this.columnSum.Width = 200;
            // 
            // olvColumn13
            // 
            this.olvColumn13.AspectName = "document";
            this.olvColumn13.Groupable = false;
            this.olvColumn13.IsEditable = false;
            this.olvColumn13.Searchable = false;
            this.olvColumn13.Sortable = false;
            this.olvColumn13.Text = "Документ";
            this.olvColumn13.Width = 200;
            // 
            // olvColumn14
            // 
            this.olvColumn14.AspectName = "balance";
            this.olvColumn14.Groupable = false;
            this.olvColumn14.IsEditable = false;
            this.olvColumn14.Searchable = false;
            this.olvColumn14.Text = "Состояние списания";
            this.olvColumn14.Width = 200;
            // 
            // contextMenuStripReleased
            // 
            this.contextMenuStripReleased.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripReleased.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStripReleased.Name = "contextMenuStrip1";
            this.contextMenuStripReleased.Size = new System.Drawing.Size(181, 76);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.addToolStripMenuItem1.Text = "Добавить";
            this.addToolStripMenuItem1.Visible = false;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.editToolStripMenuItem.Text = "Редактировать";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.removeToolStripMenuItem.Text = "Удалить";
            // 
            // checkBoxShowAll
            // 
            this.checkBoxShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShowAll.AutoSize = true;
            this.checkBoxShowAll.Location = new System.Drawing.Point(791, 14);
            this.checkBoxShowAll.Name = "checkBoxShowAll";
            this.checkBoxShowAll.Size = new System.Drawing.Size(118, 20);
            this.checkBoxShowAll.TabIndex = 11;
            this.checkBoxShowAll.Text = "Показать все";
            this.checkBoxShowAll.UseVisualStyleBackColor = true;
            this.checkBoxShowAll.CheckedChanged += new System.EventHandler(this.checkBoxShowAll_CheckedChanged);
            // 
            // TabReleased
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelReleased);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabReleased";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TabDemand";
            this.tableLayoutPanelReleased.ResumeLayout(false);
            this.panelReleasedBottom.ResumeLayout(false);
            this.panelReleasedBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvReleased)).EndInit();
            this.contextMenuStripReleased.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelReleased;
        private System.Windows.Forms.Panel panelReleasedBottom;
        private System.Windows.Forms.Button btnReleasedRemove;
        private ContextMenuStrip contextMenuStripReleased;
        private ToolStripMenuItem addToolStripMenuItem1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private Button btnDebitReport;
        private Button btnDebitCancel;
        private BrightIdeasSoftware.FastDataListView dlvReleased;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn columnDate1;
        private BrightIdeasSoftware.OLVColumn columnDate2;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn columnDate3;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn columnAmount;
        private BrightIdeasSoftware.OLVColumn columnPrice;
        private BrightIdeasSoftware.OLVColumn columnSum;
        private BrightIdeasSoftware.OLVColumn olvColumn13;
        private BrightIdeasSoftware.OLVColumn olvColumn14;
        private Label lblFilter;
        private TextBox tbFilter;
        private CheckBox checkBoxShowAll;
    }
}
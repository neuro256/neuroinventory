using System;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    partial class TabEmployees
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
            this.tableLayoutPanelEmployees = new System.Windows.Forms.TableLayoutPanel();
            this.dlvEmployees = new BrightIdeasSoftware.FastDataListView();
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelEmployeesBottom = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnEmployeeEdit = new System.Windows.Forms.Button();
            this.btnEmployeeRemove = new System.Windows.Forms.Button();
            this.btnEmployeeAdd = new System.Windows.Forms.Button();
            this.contextMenuStripEmployees = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightTextRenderer1 = new BrightIdeasSoftware.HighlightTextRenderer();
            this.tableLayoutPanelEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvEmployees)).BeginInit();
            this.panelEmployeesBottom.SuspendLayout();
            this.contextMenuStripEmployees.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelEmployees
            // 
            this.tableLayoutPanelEmployees.ColumnCount = 1;
            this.tableLayoutPanelEmployees.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEmployees.Controls.Add(this.dlvEmployees, 0, 1);
            this.tableLayoutPanelEmployees.Controls.Add(this.panelEmployeesBottom, 0, 0);
            this.tableLayoutPanelEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEmployees.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelEmployees.Name = "tableLayoutPanelEmployees";
            this.tableLayoutPanelEmployees.RowCount = 2;
            this.tableLayoutPanelEmployees.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelEmployees.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEmployees.Size = new System.Drawing.Size(1200, 650);
            this.tableLayoutPanelEmployees.TabIndex = 1;
            // 
            // dlvEmployees
            // 
            this.dlvEmployees.AllColumns.Add(this.olvColumn6);
            this.dlvEmployees.AllColumns.Add(this.olvColumn1);
            this.dlvEmployees.AllColumns.Add(this.olvColumn2);
            this.dlvEmployees.AllColumns.Add(this.olvColumn3);
            this.dlvEmployees.AllColumns.Add(this.olvColumn4);
            this.dlvEmployees.AllColumns.Add(this.olvColumn5);
            this.dlvEmployees.CellEditUseWholeCell = false;
            this.dlvEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn6,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5});
            this.dlvEmployees.Cursor = System.Windows.Forms.Cursors.Default;
            this.dlvEmployees.DataSource = null;
            this.dlvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvEmployees.EmptyListMsg = "";
            this.dlvEmployees.FullRowSelect = true;
            this.dlvEmployees.GridLines = true;
            this.dlvEmployees.HideSelection = false;
            this.dlvEmployees.Location = new System.Drawing.Point(3, 58);
            this.dlvEmployees.Name = "dlvEmployees";
            this.dlvEmployees.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.dlvEmployees.ShowCommandMenuOnRightClick = true;
            this.dlvEmployees.ShowGroups = false;
            this.dlvEmployees.ShowItemToolTips = true;
            this.dlvEmployees.Size = new System.Drawing.Size(1194, 589);
            this.dlvEmployees.TabIndex = 4;
            this.dlvEmployees.UseCellFormatEvents = true;
            this.dlvEmployees.UseCompatibleStateImageBehavior = false;
            this.dlvEmployees.UseFilterIndicator = true;
            this.dlvEmployees.UseFiltering = true;
            this.dlvEmployees.View = System.Windows.Forms.View.Details;
            this.dlvEmployees.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.dlvEmployees_CellRightClick);
            // 
            // olvColumn6
            // 
            this.olvColumn6.Groupable = false;
            this.olvColumn6.IsEditable = false;
            this.olvColumn6.MaximumWidth = 1000;
            this.olvColumn6.MinimumWidth = 50;
            this.olvColumn6.Searchable = false;
            this.olvColumn6.Sortable = false;
            this.olvColumn6.Text = "№";
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "surename";
            this.olvColumn1.Groupable = false;
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.MaximumWidth = 1000;
            this.olvColumn1.MinimumWidth = 50;
            this.olvColumn1.Text = "Фамилия";
            this.olvColumn1.Width = 200;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "firstname";
            this.olvColumn2.Groupable = false;
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.MaximumWidth = 1000;
            this.olvColumn2.MinimumWidth = 50;
            this.olvColumn2.Text = "Имя";
            this.olvColumn2.Width = 200;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "lastname";
            this.olvColumn3.Groupable = false;
            this.olvColumn3.IsEditable = false;
            this.olvColumn3.MaximumWidth = 1000;
            this.olvColumn3.MinimumWidth = 50;
            this.olvColumn3.Text = "Отчество";
            this.olvColumn3.Width = 200;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "post";
            this.olvColumn4.Groupable = false;
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.MaximumWidth = 1000;
            this.olvColumn4.MinimumWidth = 50;
            this.olvColumn4.Text = "Должность";
            this.olvColumn4.Width = 200;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "department";
            this.olvColumn5.Groupable = false;
            this.olvColumn5.IsEditable = false;
            this.olvColumn5.MaximumWidth = 1000;
            this.olvColumn5.MinimumWidth = 50;
            this.olvColumn5.Text = "Отдел";
            this.olvColumn5.Width = 200;
            // 
            // panelEmployeesBottom
            // 
            this.panelEmployeesBottom.BackColor = Definitions.COLOR_FORM_MAIN_BACK_COLOR;
            this.panelEmployeesBottom.Controls.Add(this.lblFilter);
            this.panelEmployeesBottom.Controls.Add(this.tbFilter);
            this.panelEmployeesBottom.Controls.Add(this.btnEmployeeEdit);
            this.panelEmployeesBottom.Controls.Add(this.btnEmployeeRemove);
            this.panelEmployeesBottom.Controls.Add(this.btnEmployeeAdd);
            this.panelEmployeesBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEmployeesBottom.Location = new System.Drawing.Point(0, 0);
            this.panelEmployeesBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelEmployeesBottom.Name = "panelEmployeesBottom";
            this.panelEmployeesBottom.Size = new System.Drawing.Size(1200, 55);
            this.panelEmployeesBottom.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(915, 15);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(67, 17);
            this.lblFilter.TabIndex = 4;
            this.lblFilter.Text = "Фильтр: ";
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilter.Location = new System.Drawing.Point(988, 12);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(200, 22);
            this.tbFilter.TabIndex = 3;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // btnEmployeeEdit
            // 
            this.btnEmployeeEdit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEmployeeEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmployeeEdit.Location = new System.Drawing.Point(392, 12);
            this.btnEmployeeEdit.Name = "btnEmployeeEdit";
            this.btnEmployeeEdit.Size = new System.Drawing.Size(184, 33);
            this.btnEmployeeEdit.TabIndex = 2;
            this.btnEmployeeEdit.Text = "Редактировать";
            this.btnEmployeeEdit.UseVisualStyleBackColor = true;
            this.btnEmployeeEdit.Click += new System.EventHandler(this.btnEmployeeEdit_Click);
            // 
            // btnEmployeeRemove
            // 
            this.btnEmployeeRemove.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEmployeeRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmployeeRemove.Location = new System.Drawing.Point(202, 12);
            this.btnEmployeeRemove.Name = "btnEmployeeRemove";
            this.btnEmployeeRemove.Size = new System.Drawing.Size(184, 33);
            this.btnEmployeeRemove.TabIndex = 1;
            this.btnEmployeeRemove.Text = "Удалить сотрудника";
            this.btnEmployeeRemove.UseVisualStyleBackColor = true;
            this.btnEmployeeRemove.Click += new System.EventHandler(this.btnEmployeeRemove_Click);
            // 
            // btnEmployeeAdd
            // 
            this.btnEmployeeAdd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEmployeeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmployeeAdd.Location = new System.Drawing.Point(12, 12);
            this.btnEmployeeAdd.Name = "btnEmployeeAdd";
            this.btnEmployeeAdd.Size = new System.Drawing.Size(184, 33);
            this.btnEmployeeAdd.TabIndex = 0;
            this.btnEmployeeAdd.Text = "Добавить сотрудника";
            this.btnEmployeeAdd.UseVisualStyleBackColor = true;
            this.btnEmployeeAdd.Click += new System.EventHandler(this.btnEmployeeAdd_Click);
            // 
            // contextMenuStripEmployees
            // 
            this.contextMenuStripEmployees.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripEmployees.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStripEmployees.Name = "contextMenuStrip1";
            this.contextMenuStripEmployees.Size = new System.Drawing.Size(181, 76);
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
            // TabEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelEmployees);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabEmployees";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TabEmployees";
            this.tableLayoutPanelEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvEmployees)).EndInit();
            this.panelEmployeesBottom.ResumeLayout(false);
            this.panelEmployeesBottom.PerformLayout();
            this.contextMenuStripEmployees.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEmployees;
        private System.Windows.Forms.Panel panelEmployeesBottom;
        private System.Windows.Forms.Button btnEmployeeEdit;
        private System.Windows.Forms.Button btnEmployeeRemove;
        private System.Windows.Forms.Button btnEmployeeAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEmployees;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private BrightIdeasSoftware.FastDataListView dlvEmployees;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private TextBox tbFilter;
        private Label lblFilter;
        private BrightIdeasSoftware.HighlightTextRenderer highlightTextRenderer1;
    }
}
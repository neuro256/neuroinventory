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
            this.panelEmployeesBottom = new System.Windows.Forms.Panel();
            this.btnEmployeeEdit = new System.Windows.Forms.Button();
            this.btnEmployeeRemove = new System.Windows.Forms.Button();
            this.btnEmployeeAdd = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lvEmployees = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSurename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFirstname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripEmployees = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelEmployees.SuspendLayout();
            this.panelEmployeesBottom.SuspendLayout();
            this.contextMenuStripEmployees.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelEmployees
            // 
            this.tableLayoutPanelEmployees.ColumnCount = 1;
            this.tableLayoutPanelEmployees.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEmployees.Controls.Add(this.panelEmployeesBottom, 0, 1);
            this.tableLayoutPanelEmployees.Controls.Add(this.lvEmployees, 0, 0);
            this.tableLayoutPanelEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEmployees.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelEmployees.Name = "tableLayoutPanelEmployees";
            this.tableLayoutPanelEmployees.RowCount = 2;
            this.tableLayoutPanelEmployees.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEmployees.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelEmployees.Size = new System.Drawing.Size(1200, 650);
            this.tableLayoutPanelEmployees.TabIndex = 1;
            // 
            // panelEmployeesBottom
            // 
            this.panelEmployeesBottom.BackColor = System.Drawing.Color.Silver;
            this.panelEmployeesBottom.Controls.Add(this.btnEmployeeEdit);
            this.panelEmployeesBottom.Controls.Add(this.btnEmployeeRemove);
            this.panelEmployeesBottom.Controls.Add(this.btnEmployeeAdd);
            this.panelEmployeesBottom.Controls.Add(this.btnFilter);
            this.panelEmployeesBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEmployeesBottom.Location = new System.Drawing.Point(0, 595);
            this.panelEmployeesBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelEmployeesBottom.Name = "panelEmployeesBottom";
            this.panelEmployeesBottom.Size = new System.Drawing.Size(1200, 55);
            this.panelEmployeesBottom.TabIndex = 1;
            // 
            // btnEmployeeEdit
            // 
            this.btnEmployeeEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmployeeEdit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEmployeeEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmployeeEdit.Location = new System.Drawing.Point(392, 10);
            this.btnEmployeeEdit.Name = "btnEmployeeEdit";
            this.btnEmployeeEdit.Size = new System.Drawing.Size(184, 33);
            this.btnEmployeeEdit.TabIndex = 2;
            this.btnEmployeeEdit.Text = "Редактировать";
            this.btnEmployeeEdit.UseVisualStyleBackColor = true;
            this.btnEmployeeEdit.Click += new System.EventHandler(this.btnEmployeeEdit_Click);
            // 
            // btnEmployeeRemove
            // 
            this.btnEmployeeRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmployeeRemove.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEmployeeRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmployeeRemove.Location = new System.Drawing.Point(202, 10);
            this.btnEmployeeRemove.Name = "btnEmployeeRemove";
            this.btnEmployeeRemove.Size = new System.Drawing.Size(184, 33);
            this.btnEmployeeRemove.TabIndex = 1;
            this.btnEmployeeRemove.Text = "Удалить сотрудника";
            this.btnEmployeeRemove.UseVisualStyleBackColor = true;
            this.btnEmployeeRemove.Click += new System.EventHandler(this.btnEmployeeRemove_Click);
            // 
            // btnEmployeeAdd
            // 
            this.btnEmployeeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmployeeAdd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEmployeeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmployeeAdd.Location = new System.Drawing.Point(12, 10);
            this.btnEmployeeAdd.Name = "btnEmployeeAdd";
            this.btnEmployeeAdd.Size = new System.Drawing.Size(184, 33);
            this.btnEmployeeAdd.TabIndex = 0;
            this.btnEmployeeAdd.Text = "Добавить сотрудника";
            this.btnEmployeeAdd.UseVisualStyleBackColor = true;
            this.btnEmployeeAdd.Click += new System.EventHandler(this.btnEmployeeAdd_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilter.Location = new System.Drawing.Point(1004, 10);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(184, 33);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Фильтр";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lvEmployees
            // 
            this.lvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvEmployees.CheckBoxes = true;
            this.lvEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chNumber,
            this.chSurename,
            this.chFirstname,
            this.chLastname,
            this.chPost,
            this.chDepartment});
            this.lvEmployees.ContextMenuStrip = this.contextMenuStripEmployees;
            this.lvEmployees.FullRowSelect = true;
            this.lvEmployees.GridLines = true;
            this.lvEmployees.Location = new System.Drawing.Point(0, 0);
            this.lvEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.lvEmployees.MultiSelect = false;
            this.lvEmployees.Name = "lvEmployees";
            this.lvEmployees.Size = new System.Drawing.Size(1200, 595);
            this.lvEmployees.TabIndex = 2;
            this.lvEmployees.UseCompatibleStateImageBehavior = false;
            this.lvEmployees.View = System.Windows.Forms.View.Details;
            this.lvEmployees.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvEmployees_ColumnWidthChanged);
            // 
            // chID
            // 
            this.chID.Text = "ID";
            // 
            // chNumber
            // 
            this.chNumber.Text = "№";
            this.chNumber.Width = 40;
            // 
            // chSurename
            // 
            this.chSurename.Text = "Фамилия";
            this.chSurename.Width = 200;
            // 
            // chFirstname
            // 
            this.chFirstname.Text = "Имя";
            this.chFirstname.Width = 200;
            // 
            // chLastname
            // 
            this.chLastname.Text = "Отчество";
            this.chLastname.Width = 200;
            // 
            // chPost
            // 
            this.chPost.Text = "Должность";
            this.chPost.Width = 200;
            // 
            // chDepartment
            // 
            this.chDepartment.Text = "Отдел";
            this.chDepartment.Width = 200;
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
            this.panelEmployeesBottom.ResumeLayout(false);
            this.contextMenuStripEmployees.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEmployees;
        private System.Windows.Forms.Panel panelEmployeesBottom;
        private System.Windows.Forms.Button btnEmployeeEdit;
        private System.Windows.Forms.Button btnEmployeeRemove;
        private System.Windows.Forms.Button btnEmployeeAdd;
        private System.Windows.Forms.ListView lvEmployees;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chSurename;
        private System.Windows.Forms.ColumnHeader chFirstname;
        private System.Windows.Forms.ColumnHeader chLastname;
        private System.Windows.Forms.ColumnHeader chPost;
        private System.Windows.Forms.ColumnHeader chDepartment;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEmployees;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private Button btnFilter;
    }
}
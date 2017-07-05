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
            this.btnDebitReport = new System.Windows.Forms.Button();
            this.btnReleasedRemove = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lwReleased = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSurename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFirstname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripReleased = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelReleased.SuspendLayout();
            this.panelReleasedBottom.SuspendLayout();
            this.contextMenuStripReleased.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelReleased
            // 
            this.tableLayoutPanelReleased.ColumnCount = 1;
            this.tableLayoutPanelReleased.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelReleased.Controls.Add(this.panelReleasedBottom, 0, 1);
            this.tableLayoutPanelReleased.Controls.Add(this.lwReleased, 0, 0);
            this.tableLayoutPanelReleased.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelReleased.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelReleased.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelReleased.Name = "tableLayoutPanelReleased";
            this.tableLayoutPanelReleased.RowCount = 2;
            this.tableLayoutPanelReleased.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelReleased.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelReleased.Size = new System.Drawing.Size(1200, 650);
            this.tableLayoutPanelReleased.TabIndex = 1;
            // 
            // panelReleasedBottom
            // 
            this.panelReleasedBottom.BackColor = System.Drawing.Color.Silver;
            this.panelReleasedBottom.Controls.Add(this.btnDebitReport);
            this.panelReleasedBottom.Controls.Add(this.btnReleasedRemove);
            this.panelReleasedBottom.Controls.Add(this.btnFilter);
            this.panelReleasedBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReleasedBottom.Location = new System.Drawing.Point(0, 595);
            this.panelReleasedBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelReleasedBottom.Name = "panelReleasedBottom";
            this.panelReleasedBottom.Size = new System.Drawing.Size(1200, 55);
            this.panelReleasedBottom.TabIndex = 1;
            // 
            // btnDebitReport
            // 
            this.btnDebitReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDebitReport.BackColor = System.Drawing.Color.CadetBlue;
            this.btnDebitReport.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnDebitReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDebitReport.Location = new System.Drawing.Point(202, 10);
            this.btnDebitReport.Name = "btnDebitReport";
            this.btnDebitReport.Size = new System.Drawing.Size(184, 33);
            this.btnDebitReport.TabIndex = 4;
            this.btnDebitReport.Text = "Списать ТМЦ";
            this.btnDebitReport.UseVisualStyleBackColor = false;
            this.btnDebitReport.Click += new System.EventHandler(this.btnDebitReport_Click);
            // 
            // btnReleasedRemove
            // 
            this.btnReleasedRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReleasedRemove.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnReleasedRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReleasedRemove.Location = new System.Drawing.Point(12, 10);
            this.btnReleasedRemove.Name = "btnReleasedRemove";
            this.btnReleasedRemove.Size = new System.Drawing.Size(184, 33);
            this.btnReleasedRemove.TabIndex = 1;
            this.btnReleasedRemove.Text = "Удалить";
            this.btnReleasedRemove.UseVisualStyleBackColor = true;
            this.btnReleasedRemove.Click += new System.EventHandler(this.btnReleasedRemove_Click);
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
            // lwReleased
            // 
            this.lwReleased.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lwReleased.CheckBoxes = true;
            this.lwReleased.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chNumber,
            this.chSurename,
            this.chFirstname,
            this.chLastname,
            this.chPost,
            this.chDepartment});
            this.lwReleased.ContextMenuStrip = this.contextMenuStripReleased;
            this.lwReleased.FullRowSelect = true;
            this.lwReleased.GridLines = true;
            this.lwReleased.Location = new System.Drawing.Point(0, 0);
            this.lwReleased.Margin = new System.Windows.Forms.Padding(0);
            this.lwReleased.MultiSelect = false;
            this.lwReleased.Name = "lwReleased";
            this.lwReleased.Size = new System.Drawing.Size(1200, 595);
            this.lwReleased.TabIndex = 2;
            this.lwReleased.UseCompatibleStateImageBehavior = false;
            this.lwReleased.View = System.Windows.Forms.View.Details;
            this.lwReleased.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lwReleased_DrawColumnHeader);
            this.lwReleased.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lwReleased_DrawItem);
            this.lwReleased.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lwReleased_DrawSubItem);
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
            // contextMenuStripReleased
            // 
            this.contextMenuStripReleased.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripReleased.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStripReleased.Name = "contextMenuStrip1";
            this.contextMenuStripReleased.Size = new System.Drawing.Size(187, 82);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(186, 26);
            this.addToolStripMenuItem1.Text = "Добавить";
            this.addToolStripMenuItem1.Visible = false;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.editToolStripMenuItem.Text = "Редактировать";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.removeToolStripMenuItem.Text = "Удалить";
            // 
            // TabReleased
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelReleased);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabReleased";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TabDemand";
            this.tableLayoutPanelReleased.ResumeLayout(false);
            this.panelReleasedBottom.ResumeLayout(false);
            this.contextMenuStripReleased.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelReleased;
        private System.Windows.Forms.Panel panelReleasedBottom;
        private System.Windows.Forms.Button btnReleasedRemove;
        private System.Windows.Forms.ListView lwReleased;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chSurename;
        private System.Windows.Forms.ColumnHeader chFirstname;
        private System.Windows.Forms.ColumnHeader chLastname;
        private System.Windows.Forms.ColumnHeader chPost;
        private System.Windows.Forms.ColumnHeader chDepartment;
        private System.Windows.Forms.ColumnHeader chID;
        private Button btnFilter;
        private ContextMenuStrip contextMenuStripReleased;
        private ToolStripMenuItem addToolStripMenuItem1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private Button btnDebitReport;
    }
}
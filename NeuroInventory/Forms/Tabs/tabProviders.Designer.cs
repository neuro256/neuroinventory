namespace NeuroInventory
{
    partial class TabProviders
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
            this.tableLayoutPanelProviders = new System.Windows.Forms.TableLayoutPanel();
            this.lwProviders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelProvidersBottom = new System.Windows.Forms.Panel();
            this.btnProviderEdit = new System.Windows.Forms.Button();
            this.btnProviderRemove = new System.Windows.Forms.Button();
            this.btnProviderAdd = new System.Windows.Forms.Button();
            this.contextMenuStripProviders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanelProviders.SuspendLayout();
            this.panelProvidersBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelProviders
            // 
            this.tableLayoutPanelProviders.ColumnCount = 1;
            this.tableLayoutPanelProviders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProviders.Controls.Add(this.lwProviders, 0, 0);
            this.tableLayoutPanelProviders.Controls.Add(this.panelProvidersBottom, 0, 1);
            this.tableLayoutPanelProviders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProviders.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelProviders.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelProviders.Name = "tableLayoutPanelProviders";
            this.tableLayoutPanelProviders.RowCount = 2;
            this.tableLayoutPanelProviders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.25271F));
            this.tableLayoutPanelProviders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.747292F));
            this.tableLayoutPanelProviders.Size = new System.Drawing.Size(1200, 650);
            this.tableLayoutPanelProviders.TabIndex = 0;
            // 
            // lwProviders
            // 
            this.lwProviders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lwProviders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lwProviders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lwProviders.GridLines = true;
            this.lwProviders.Location = new System.Drawing.Point(0, 0);
            this.lwProviders.Margin = new System.Windows.Forms.Padding(0);
            this.lwProviders.MultiSelect = false;
            this.lwProviders.Name = "lwProviders";
            this.lwProviders.Size = new System.Drawing.Size(1200, 586);
            this.lwProviders.TabIndex = 0;
            this.lwProviders.UseCompatibleStateImageBehavior = false;
            this.lwProviders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "id";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "№";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Название ";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Адрес";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "телефон";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "е-mail";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "карточка предприятия";
            this.columnHeader7.Width = 205;
            // 
            // panelProvidersBottom
            // 
            this.panelProvidersBottom.BackColor = System.Drawing.Color.Silver;
            this.panelProvidersBottom.Controls.Add(this.btnProviderEdit);
            this.panelProvidersBottom.Controls.Add(this.btnProviderRemove);
            this.panelProvidersBottom.Controls.Add(this.btnProviderAdd);
            this.panelProvidersBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProvidersBottom.Location = new System.Drawing.Point(0, 586);
            this.panelProvidersBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelProvidersBottom.Name = "panelProvidersBottom";
            this.panelProvidersBottom.Size = new System.Drawing.Size(1200, 64);
            this.panelProvidersBottom.TabIndex = 1;
            // 
            // btnProviderEdit
            // 
            this.btnProviderEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProviderEdit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnProviderEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProviderEdit.Location = new System.Drawing.Point(392, 19);
            this.btnProviderEdit.Name = "btnProviderEdit";
            this.btnProviderEdit.Size = new System.Drawing.Size(184, 33);
            this.btnProviderEdit.TabIndex = 5;
            this.btnProviderEdit.Text = "Редактировать";
            this.btnProviderEdit.UseVisualStyleBackColor = true;
            this.btnProviderEdit.Click += new System.EventHandler(this.btnProviderEdit_Click);
            // 
            // btnProviderRemove
            // 
            this.btnProviderRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProviderRemove.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnProviderRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProviderRemove.Location = new System.Drawing.Point(202, 19);
            this.btnProviderRemove.Name = "btnProviderRemove";
            this.btnProviderRemove.Size = new System.Drawing.Size(184, 33);
            this.btnProviderRemove.TabIndex = 4;
            this.btnProviderRemove.Text = "Удалить поставщика";
            this.btnProviderRemove.UseVisualStyleBackColor = true;
            this.btnProviderRemove.Click += new System.EventHandler(this.btnProviderRemove_Click);
            // 
            // btnProviderAdd
            // 
            this.btnProviderAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProviderAdd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnProviderAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProviderAdd.Location = new System.Drawing.Point(12, 19);
            this.btnProviderAdd.Name = "btnProviderAdd";
            this.btnProviderAdd.Size = new System.Drawing.Size(184, 33);
            this.btnProviderAdd.TabIndex = 3;
            this.btnProviderAdd.Text = "Добавить поставщика";
            this.btnProviderAdd.UseVisualStyleBackColor = true;
            this.btnProviderAdd.Click += new System.EventHandler(this.btnProviderAdd_Click);
            // 
            // contextMenuStripProviders
            // 
            this.contextMenuStripProviders.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripProviders.Name = "contextMenuStripProviders";
            this.contextMenuStripProviders.Size = new System.Drawing.Size(67, 4);
            // 
            // TabProviders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelProviders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabProviders";
            this.ShowInTaskbar = false;
            this.Text = "tabProviders";
            this.tableLayoutPanelProviders.ResumeLayout(false);
            this.panelProvidersBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProviders;
        private System.Windows.Forms.ListView lwProviders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Panel panelProvidersBottom;
        private System.Windows.Forms.Button btnProviderEdit;
        private System.Windows.Forms.Button btnProviderRemove;
        private System.Windows.Forms.Button btnProviderAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProviders;
    }
}
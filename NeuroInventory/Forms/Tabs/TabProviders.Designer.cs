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
            this.dlvProviders = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panelProvidersBottom = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnProviderEdit = new System.Windows.Forms.Button();
            this.btnProviderRemove = new System.Windows.Forms.Button();
            this.btnProviderAdd = new System.Windows.Forms.Button();
            this.contextMenuStripProviders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanelProviders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvProviders)).BeginInit();
            this.panelProvidersBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelProviders
            // 
            this.tableLayoutPanelProviders.ColumnCount = 1;
            this.tableLayoutPanelProviders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProviders.Controls.Add(this.dlvProviders, 0, 1);
            this.tableLayoutPanelProviders.Controls.Add(this.panelProvidersBottom, 0, 0);
            this.tableLayoutPanelProviders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProviders.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelProviders.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelProviders.Name = "tableLayoutPanelProviders";
            this.tableLayoutPanelProviders.RowCount = 2;
            this.tableLayoutPanelProviders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelProviders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProviders.Size = new System.Drawing.Size(1200, 650);
            this.tableLayoutPanelProviders.TabIndex = 0;
            // 
            // dlvProviders
            // 
            this.dlvProviders.AllColumns.Add(this.olvColumn1);
            this.dlvProviders.AllColumns.Add(this.columnName);
            this.dlvProviders.AllColumns.Add(this.olvColumn3);
            this.dlvProviders.AllColumns.Add(this.olvColumn4);
            this.dlvProviders.AllColumns.Add(this.olvColumn5);
            this.dlvProviders.AllColumns.Add(this.olvColumn6);
            this.dlvProviders.AllColumns.Add(this.olvColumn7);
            this.dlvProviders.CellEditUseWholeCell = false;
            this.dlvProviders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.columnName,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn6,
            this.olvColumn7});
            this.dlvProviders.Cursor = System.Windows.Forms.Cursors.Default;
            this.dlvProviders.DataSource = null;
            this.dlvProviders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvProviders.FullRowSelect = true;
            this.dlvProviders.GridLines = true;
            this.dlvProviders.HideSelection = false;
            this.dlvProviders.Location = new System.Drawing.Point(3, 58);
            this.dlvProviders.Name = "dlvProviders";
            this.dlvProviders.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.dlvProviders.ShowCommandMenuOnRightClick = true;
            this.dlvProviders.ShowGroups = false;
            this.dlvProviders.ShowItemToolTips = true;
            this.dlvProviders.Size = new System.Drawing.Size(1194, 589);
            this.dlvProviders.TabIndex = 2;
            this.dlvProviders.UseCellFormatEvents = true;
            this.dlvProviders.UseCompatibleStateImageBehavior = false;
            this.dlvProviders.UseFilterIndicator = true;
            this.dlvProviders.UseFiltering = true;
            this.dlvProviders.View = System.Windows.Forms.View.Details;
            this.dlvProviders.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.dlvProviders_CellClick);
            this.dlvProviders.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.dlvProviders_CellRightClick);
            this.dlvProviders.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.dlvProviders_FormatCell);
            // 
            // olvColumn1
            // 
            this.olvColumn1.Groupable = false;
            this.olvColumn1.IsEditable = false;
            this.olvColumn1.MaximumWidth = 1000;
            this.olvColumn1.MinimumWidth = 50;
            this.olvColumn1.Searchable = false;
            this.olvColumn1.Sortable = false;
            this.olvColumn1.Text = "№";
            this.olvColumn1.Width = 50;
            // 
            // columnName
            // 
            this.columnName.AspectName = "name";
            this.columnName.Groupable = false;
            this.columnName.IsEditable = false;
            this.columnName.MaximumWidth = 1000;
            this.columnName.MinimumWidth = 50;
            this.columnName.Text = "Название";
            this.columnName.Width = 200;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "address";
            this.olvColumn3.Groupable = false;
            this.olvColumn3.IsEditable = false;
            this.olvColumn3.MaximumWidth = 1000;
            this.olvColumn3.MinimumWidth = 50;
            this.olvColumn3.Text = "адрес";
            this.olvColumn3.Width = 200;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "phone";
            this.olvColumn4.Groupable = false;
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.MaximumWidth = 1000;
            this.olvColumn4.MinimumWidth = 50;
            this.olvColumn4.Text = "телефон";
            this.olvColumn4.Width = 200;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "mail";
            this.olvColumn5.Groupable = false;
            this.olvColumn5.IsEditable = false;
            this.olvColumn5.MaximumWidth = 1000;
            this.olvColumn5.MinimumWidth = 50;
            this.olvColumn5.Text = "e-mail";
            this.olvColumn5.Width = 200;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "inn";
            this.olvColumn6.Groupable = false;
            this.olvColumn6.IsEditable = false;
            this.olvColumn6.MaximumWidth = 1000;
            this.olvColumn6.MinimumWidth = 50;
            this.olvColumn6.Text = "ИНН";
            this.olvColumn6.Width = 200;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "document";
            this.olvColumn7.Groupable = false;
            this.olvColumn7.IsEditable = false;
            this.olvColumn7.MaximumWidth = 1000;
            this.olvColumn7.MinimumWidth = 50;
            this.olvColumn7.Searchable = false;
            this.olvColumn7.Sortable = false;
            this.olvColumn7.Text = "Карточка предприятия";
            this.olvColumn7.Width = 200;
            // 
            // panelProvidersBottom
            // 
            this.panelProvidersBottom.BackColor = System.Drawing.Color.Silver;
            this.panelProvidersBottom.Controls.Add(this.lblFilter);
            this.panelProvidersBottom.Controls.Add(this.tbFilter);
            this.panelProvidersBottom.Controls.Add(this.btnProviderEdit);
            this.panelProvidersBottom.Controls.Add(this.btnProviderRemove);
            this.panelProvidersBottom.Controls.Add(this.btnProviderAdd);
            this.panelProvidersBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProvidersBottom.Location = new System.Drawing.Point(0, 0);
            this.panelProvidersBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelProvidersBottom.Name = "panelProvidersBottom";
            this.panelProvidersBottom.Size = new System.Drawing.Size(1200, 55);
            this.panelProvidersBottom.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(915, 15);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(67, 17);
            this.lblFilter.TabIndex = 7;
            this.lblFilter.Text = "Фильтр: ";
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilter.Location = new System.Drawing.Point(988, 12);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(200, 22);
            this.tbFilter.TabIndex = 6;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // btnProviderEdit
            // 
            this.btnProviderEdit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnProviderEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProviderEdit.Location = new System.Drawing.Point(392, 12);
            this.btnProviderEdit.Name = "btnProviderEdit";
            this.btnProviderEdit.Size = new System.Drawing.Size(184, 33);
            this.btnProviderEdit.TabIndex = 5;
            this.btnProviderEdit.Text = "Редактировать";
            this.btnProviderEdit.UseVisualStyleBackColor = true;
            this.btnProviderEdit.Click += new System.EventHandler(this.btnProviderEdit_Click);
            // 
            // btnProviderRemove
            // 
            this.btnProviderRemove.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnProviderRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProviderRemove.Location = new System.Drawing.Point(202, 12);
            this.btnProviderRemove.Name = "btnProviderRemove";
            this.btnProviderRemove.Size = new System.Drawing.Size(184, 33);
            this.btnProviderRemove.TabIndex = 4;
            this.btnProviderRemove.Text = "Удалить поставщика";
            this.btnProviderRemove.UseVisualStyleBackColor = true;
            this.btnProviderRemove.Click += new System.EventHandler(this.btnProviderRemove_Click);
            // 
            // btnProviderAdd
            // 
            this.btnProviderAdd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnProviderAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProviderAdd.Location = new System.Drawing.Point(12, 12);
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
            this.contextMenuStripProviders.Size = new System.Drawing.Size(61, 4);
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
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TabProviders";
            this.tableLayoutPanelProviders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlvProviders)).EndInit();
            this.panelProvidersBottom.ResumeLayout(false);
            this.panelProvidersBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProviders;
        private System.Windows.Forms.Panel panelProvidersBottom;
        private System.Windows.Forms.Button btnProviderEdit;
        private System.Windows.Forms.Button btnProviderRemove;
        private System.Windows.Forms.Button btnProviderAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProviders;
        private BrightIdeasSoftware.DataListView dlvProviders;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn columnName;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox tbFilter;
    }
}
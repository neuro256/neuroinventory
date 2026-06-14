namespace NeuroInventory
{
    partial class TabInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabInventory));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.panelLeftPanelBottom = new System.Windows.Forms.Panel();
            this.tbSelectionHelp = new System.Windows.Forms.TextBox();
            this.dtlCatalogs = new BrightIdeasSoftware.DataTreeListView();
            this.catalogsNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.catalogsTypeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelInventory = new System.Windows.Forms.TableLayoutPanel();
            this.panelMainBottom = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnDemand = new System.Windows.Forms.Button();
            this.btnInventoryEdit = new System.Windows.Forms.Button();
            this.btnInventoryRemove = new System.Windows.Forms.Button();
            this.btnInventoryAdd = new System.Windows.Forms.Button();
            this.dlvInventory = new BrightIdeasSoftware.FastDataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnInvoiceDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnAmount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnSum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.columnBalance = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStripInventory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripCatalogs = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.panelLeftPanelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlCatalogs)).BeginInit();
            this.tableLayoutPanelRight.SuspendLayout();
            this.tableLayoutPanelInventory.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.AutoScroll = true;
            this.splitContainerMain.Panel1.Controls.Add(this.tableLayoutPanelLeft);
            this.splitContainerMain.Panel1MinSize = 150;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tableLayoutPanelRight);
            this.splitContainerMain.Panel2MinSize = 600;
            this.splitContainerMain.Size = new System.Drawing.Size(1200, 650);
            this.splitContainerMain.SplitterDistance = 200;
            this.splitContainerMain.SplitterWidth = 2;
            this.splitContainerMain.TabIndex = 0;
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.panelLeftPanelBottom, 0, 1);
            this.tableLayoutPanelLeft.Controls.Add(this.dtlCatalogs, 0, 0);
            this.tableLayoutPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelLeft.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 2;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(198, 648);
            this.tableLayoutPanelLeft.TabIndex = 0;
            // 
            // panelLeftPanelBottom
            // 
            this.panelLeftPanelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelLeftPanelBottom.Controls.Add(this.tbSelectionHelp);
            this.panelLeftPanelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftPanelBottom.Location = new System.Drawing.Point(0, 593);
            this.panelLeftPanelBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelLeftPanelBottom.Name = "panelLeftPanelBottom";
            this.panelLeftPanelBottom.Size = new System.Drawing.Size(198, 55);
            this.panelLeftPanelBottom.TabIndex = 1;
            // 
            // tbSelectionHelp
            // 
            this.tbSelectionHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tbSelectionHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSelectionHelp.Location = new System.Drawing.Point(0, 0);
            this.tbSelectionHelp.Multiline = true;
            this.tbSelectionHelp.Name = "tbSelectionHelp";
            this.tbSelectionHelp.ReadOnly = true;
            this.tbSelectionHelp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSelectionHelp.Size = new System.Drawing.Size(198, 55);
            this.tbSelectionHelp.TabIndex = 1;
            this.tbSelectionHelp.Text = "Для того чтобы выделить несколько каталогов, используйте комбинацию ctrl+левый кл" +
    "ик мышью";
            // 
            // dtlCatalogs
            // 
            this.dtlCatalogs.AllColumns.Add(this.catalogsNameColumn);
            this.dtlCatalogs.AllColumns.Add(this.catalogsTypeColumn);
            this.dtlCatalogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtlCatalogs.CellEditUseWholeCell = false;
            this.dtlCatalogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.catalogsNameColumn});
            this.dtlCatalogs.DataSource = null;
            this.dtlCatalogs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.dtlCatalogs.HideSelection = false;
            this.dtlCatalogs.KeyAspectName = "id";
            this.dtlCatalogs.Location = new System.Drawing.Point(3, 3);
            this.dtlCatalogs.Name = "dtlCatalogs";
            this.dtlCatalogs.ParentKeyAspectName = "parent";
            this.dtlCatalogs.RootKeyValueString = "";
            this.dtlCatalogs.ShowGroups = false;
            this.dtlCatalogs.ShowImagesOnSubItems = true;
            this.dtlCatalogs.ShowKeyColumns = false;
            this.dtlCatalogs.Size = new System.Drawing.Size(192, 587);
            this.dtlCatalogs.SmallImageList = this.imageListMain;
            this.dtlCatalogs.TabIndex = 2;
            this.dtlCatalogs.UseCompatibleStateImageBehavior = false;
            this.dtlCatalogs.View = System.Windows.Forms.View.Details;
            this.dtlCatalogs.VirtualMode = true;
            this.dtlCatalogs.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.dtlCatalogs_CellClick);
            this.dtlCatalogs.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.dtlCatalogs_CellRightClick);
            // 
            // catalogsNameColumn
            // 
            this.catalogsNameColumn.AspectName = "name";
            this.catalogsNameColumn.FillsFreeSpace = true;
            this.catalogsNameColumn.IsTileViewColumn = true;
            this.catalogsNameColumn.Text = "Каталоги";
            this.catalogsNameColumn.Width = 200;
            // 
            // catalogsTypeColumn
            // 
            this.catalogsTypeColumn.AspectName = "type";
            this.catalogsTypeColumn.DisplayIndex = 1;
            this.catalogsTypeColumn.IsVisible = false;
            this.catalogsTypeColumn.Text = "Тип";
            // 
            // imageListMain
            // 
            this.imageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMain.ImageStream")));
            this.imageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMain.Images.SetKeyName(0, "folder");
            this.imageListMain.Images.SetKeyName(1, "file");
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.ColumnCount = 1;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelRight.Controls.Add(this.tableLayoutPanelInventory, 0, 0);
            this.tableLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRight.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 1;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(996, 648);
            this.tableLayoutPanelRight.TabIndex = 0;
            // 
            // tableLayoutPanelInventory
            // 
            this.tableLayoutPanelInventory.ColumnCount = 1;
            this.tableLayoutPanelInventory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInventory.Controls.Add(this.panelMainBottom, 0, 0);
            this.tableLayoutPanelInventory.Controls.Add(this.dlvInventory, 0, 1);
            this.tableLayoutPanelInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInventory.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelInventory.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelInventory.Name = "tableLayoutPanelInventory";
            this.tableLayoutPanelInventory.RowCount = 2;
            this.tableLayoutPanelInventory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelInventory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInventory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelInventory.Size = new System.Drawing.Size(996, 648);
            this.tableLayoutPanelInventory.TabIndex = 2;
            // 
            // panelMainBottom
            // 
            this.panelMainBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelMainBottom.Controls.Add(this.lblFilter);
            this.panelMainBottom.Controls.Add(this.tbFilter);
            this.panelMainBottom.Controls.Add(this.btnDemand);
            this.panelMainBottom.Controls.Add(this.btnInventoryEdit);
            this.panelMainBottom.Controls.Add(this.btnInventoryRemove);
            this.panelMainBottom.Controls.Add(this.btnInventoryAdd);
            this.panelMainBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainBottom.Location = new System.Drawing.Point(0, 0);
            this.panelMainBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelMainBottom.Name = "panelMainBottom";
            this.panelMainBottom.Size = new System.Drawing.Size(996, 55);
            this.panelMainBottom.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(712, 14);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(62, 16);
            this.lblFilter.TabIndex = 9;
            this.lblFilter.Text = "Фильтр: ";
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilter.Location = new System.Drawing.Point(785, 11);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(200, 22);
            this.tbFilter.TabIndex = 8;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // btnDemand
            // 
            this.btnDemand.AutoSize = true;
            this.btnDemand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(189)))));
            this.btnDemand.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnDemand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDemand.Location = new System.Drawing.Point(580, 11);
            this.btnDemand.Name = "btnDemand";
            this.btnDemand.Size = new System.Drawing.Size(184, 33);
            this.btnDemand.TabIndex = 4;
            this.btnDemand.Text = "Отпустить ТМЦ";
            this.btnDemand.UseVisualStyleBackColor = false;
            this.btnDemand.Click += new System.EventHandler(this.btnDemand_Click);
            // 
            // btnInventoryEdit
            // 
            this.btnInventoryEdit.AutoSize = true;
            this.btnInventoryEdit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnInventoryEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventoryEdit.Location = new System.Drawing.Point(390, 11);
            this.btnInventoryEdit.Name = "btnInventoryEdit";
            this.btnInventoryEdit.Size = new System.Drawing.Size(184, 33);
            this.btnInventoryEdit.TabIndex = 2;
            this.btnInventoryEdit.Text = "Редактировать";
            this.btnInventoryEdit.UseVisualStyleBackColor = true;
            this.btnInventoryEdit.Click += new System.EventHandler(this.btnInventoryEdit_Click);
            // 
            // btnInventoryRemove
            // 
            this.btnInventoryRemove.AutoSize = true;
            this.btnInventoryRemove.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnInventoryRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventoryRemove.Location = new System.Drawing.Point(200, 11);
            this.btnInventoryRemove.Name = "btnInventoryRemove";
            this.btnInventoryRemove.Size = new System.Drawing.Size(184, 33);
            this.btnInventoryRemove.TabIndex = 1;
            this.btnInventoryRemove.Text = "Удалить тмц";
            this.btnInventoryRemove.UseVisualStyleBackColor = true;
            this.btnInventoryRemove.Click += new System.EventHandler(this.btnInventoryRemove_Click);
            // 
            // btnInventoryAdd
            // 
            this.btnInventoryAdd.AutoSize = true;
            this.btnInventoryAdd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnInventoryAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventoryAdd.Location = new System.Drawing.Point(10, 11);
            this.btnInventoryAdd.Name = "btnInventoryAdd";
            this.btnInventoryAdd.Size = new System.Drawing.Size(184, 33);
            this.btnInventoryAdd.TabIndex = 0;
            this.btnInventoryAdd.Text = "Добавить тмц";
            this.btnInventoryAdd.UseVisualStyleBackColor = true;
            this.btnInventoryAdd.Click += new System.EventHandler(this.btnInventoryAdd_Click);
            // 
            // dlvInventory
            // 
            this.dlvInventory.AllColumns.Add(this.olvColumn1);
            this.dlvInventory.AllColumns.Add(this.olvColumn2);
            this.dlvInventory.AllColumns.Add(this.columnDate);
            this.dlvInventory.AllColumns.Add(this.olvColumn4);
            this.dlvInventory.AllColumns.Add(this.olvColumn5);
            this.dlvInventory.AllColumns.Add(this.columnInvoiceDate);
            this.dlvInventory.AllColumns.Add(this.olvColumn7);
            this.dlvInventory.AllColumns.Add(this.olvColumn8);
            this.dlvInventory.AllColumns.Add(this.olvColumn9);
            this.dlvInventory.AllColumns.Add(this.columnAmount);
            this.dlvInventory.AllColumns.Add(this.columnPrice);
            this.dlvInventory.AllColumns.Add(this.columnSum);
            this.dlvInventory.AllColumns.Add(this.columnBalance);
            this.dlvInventory.CellEditUseWholeCell = false;
            this.dlvInventory.CheckBoxes = true;
            this.dlvInventory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.columnDate,
            this.olvColumn4,
            this.olvColumn5,
            this.columnInvoiceDate,
            this.olvColumn7,
            this.olvColumn8,
            this.olvColumn9,
            this.columnAmount,
            this.columnPrice,
            this.columnSum,
            this.columnBalance});
            this.dlvInventory.Cursor = System.Windows.Forms.Cursors.Default;
            this.dlvInventory.DataSource = null;
            this.dlvInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dlvInventory.HideSelection = false;
            this.dlvInventory.Location = new System.Drawing.Point(3, 58);
            this.dlvInventory.Name = "dlvInventory";
            this.dlvInventory.ShowGroups = false;
            this.dlvInventory.ShowImagesOnSubItems = true;
            this.dlvInventory.Size = new System.Drawing.Size(990, 587);
            this.dlvInventory.TabIndex = 4;
            this.dlvInventory.UseCompatibleStateImageBehavior = false;
            this.dlvInventory.View = System.Windows.Forms.View.Details;
            this.dlvInventory.VirtualMode = true;
            this.dlvInventory.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.dlvInventory_CellClick);
            this.dlvInventory.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.dlvInventory_CellRightClick);
            this.dlvInventory.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.dlvInventory_CellToolTipShowing);
            this.dlvInventory.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.dlvInventory_ItemChecked);
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
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "providerId";
            this.olvColumn2.Groupable = false;
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.MaximumWidth = 1000;
            this.olvColumn2.MinimumWidth = 50;
            this.olvColumn2.Text = "Поставщик";
            this.olvColumn2.ToolTipText = "";
            this.olvColumn2.Width = 200;
            // 
            // columnDate
            // 
            this.columnDate.AspectName = "date";
            this.columnDate.Groupable = false;
            this.columnDate.IsEditable = false;
            this.columnDate.MaximumWidth = 1000;
            this.columnDate.MinimumWidth = 50;
            this.columnDate.Text = "Дата поступления";
            this.columnDate.Width = 200;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "invoice";
            this.olvColumn4.Groupable = false;
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.MaximumWidth = 1000;
            this.olvColumn4.MinimumWidth = 50;
            this.olvColumn4.Searchable = false;
            this.olvColumn4.Sortable = false;
            this.olvColumn4.Text = "Накладная";
            this.olvColumn4.Width = 200;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "invoiceCodeStr";
            this.olvColumn5.Groupable = false;
            this.olvColumn5.IsEditable = false;
            this.olvColumn5.MaximumWidth = 1000;
            this.olvColumn5.MinimumWidth = 50;
            this.olvColumn5.Text = "Номер накладной";
            this.olvColumn5.Width = 200;
            // 
            // columnInvoiceDate
            // 
            this.columnInvoiceDate.AspectName = "invoiceDate";
            this.columnInvoiceDate.Groupable = false;
            this.columnInvoiceDate.IsEditable = false;
            this.columnInvoiceDate.MaximumWidth = 1000;
            this.columnInvoiceDate.MinimumWidth = 50;
            this.columnInvoiceDate.Text = "Дата накладной";
            this.columnInvoiceDate.Width = 200;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "name";
            this.olvColumn7.Groupable = false;
            this.olvColumn7.IsEditable = false;
            this.olvColumn7.MaximumWidth = 1000;
            this.olvColumn7.MinimumWidth = 50;
            this.olvColumn7.Text = "Наименование";
            this.olvColumn7.Width = 200;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "OKEIcode";
            this.olvColumn8.Groupable = false;
            this.olvColumn8.IsEditable = false;
            this.olvColumn8.MaximumWidth = 1000;
            this.olvColumn8.MinimumWidth = 50;
            this.olvColumn8.Text = "Код ОКЕИ";
            this.olvColumn8.Width = 200;
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "measurement";
            this.olvColumn9.Groupable = false;
            this.olvColumn9.IsEditable = false;
            this.olvColumn9.MaximumWidth = 1000;
            this.olvColumn9.MinimumWidth = 50;
            this.olvColumn9.Text = "Единица измерения";
            this.olvColumn9.Width = 200;
            // 
            // columnAmount
            // 
            this.columnAmount.AspectName = "amount";
            this.columnAmount.Groupable = false;
            this.columnAmount.IsEditable = false;
            this.columnAmount.MaximumWidth = 1000;
            this.columnAmount.MinimumWidth = 50;
            this.columnAmount.Text = "Количество";
            this.columnAmount.Width = 200;
            // 
            // columnPrice
            // 
            this.columnPrice.AspectName = "price";
            this.columnPrice.Groupable = false;
            this.columnPrice.IsEditable = false;
            this.columnPrice.MaximumWidth = 1000;
            this.columnPrice.MinimumWidth = 50;
            this.columnPrice.Text = "Цена";
            this.columnPrice.Width = 200;
            // 
            // columnSum
            // 
            this.columnSum.AspectName = "sum";
            this.columnSum.Groupable = false;
            this.columnSum.IsEditable = false;
            this.columnSum.MaximumWidth = 1000;
            this.columnSum.MinimumWidth = 50;
            this.columnSum.Text = "Сумма";
            this.columnSum.Width = 200;
            // 
            // columnBalance
            // 
            this.columnBalance.AspectName = "balance";
            this.columnBalance.Groupable = false;
            this.columnBalance.IsEditable = false;
            this.columnBalance.MaximumWidth = 1000;
            this.columnBalance.MinimumWidth = 50;
            this.columnBalance.Text = "Остаток";
            this.columnBalance.Width = 200;
            // 
            // contextMenuStripInventory
            // 
            this.contextMenuStripInventory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripInventory.Name = "contextMenuStripInventory";
            this.contextMenuStripInventory.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStripCatalogs
            // 
            this.contextMenuStripCatalogs.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripCatalogs.Name = "contextMenuStripCatalogs";
            this.contextMenuStripCatalogs.Size = new System.Drawing.Size(61, 4);
            // 
            // TabInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabInventory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TabInventory";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.panelLeftPanelBottom.ResumeLayout(false);
            this.panelLeftPanelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlCatalogs)).EndInit();
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.tableLayoutPanelInventory.ResumeLayout(false);
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlvInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInventory;
        private System.Windows.Forms.Panel panelMainBottom;
        private System.Windows.Forms.Button btnInventoryEdit;
        private System.Windows.Forms.Button btnInventoryRemove;
        private System.Windows.Forms.Button btnInventoryAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInventory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.Panel panelLeftPanelBottom;
        private System.Windows.Forms.ImageList imageListMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCatalogs;
        private System.Windows.Forms.Button btnDemand;
        private System.Windows.Forms.TextBox tbSelectionHelp;
        private BrightIdeasSoftware.FastDataListView dlvInventory;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn columnDate;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn columnInvoiceDate;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn9;
        private BrightIdeasSoftware.OLVColumn columnAmount;
        private BrightIdeasSoftware.OLVColumn columnPrice;
        private BrightIdeasSoftware.OLVColumn columnSum;
        private BrightIdeasSoftware.OLVColumn columnBalance;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox tbFilter;
        private BrightIdeasSoftware.DataTreeListView dtlCatalogs;
        private BrightIdeasSoftware.OLVColumn catalogsNameColumn;
        private BrightIdeasSoftware.OLVColumn catalogsTypeColumn;
    }
}
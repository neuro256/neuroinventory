namespace NeuroInventory
{
    partial class TabMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabMain));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.treeView = new NeuroInventory.MultiSelectTreeview();
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.panelLeftPanelBottom = new System.Windows.Forms.Panel();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelInventory = new System.Windows.Forms.TableLayoutPanel();
            this.panelMainBottom = new System.Windows.Forms.Panel();
            this.btnDemand = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnInventoryEdit = new System.Windows.Forms.Button();
            this.btnInventoryRemove = new System.Windows.Forms.Button();
            this.btnInventoryAdd = new System.Windows.Forms.Button();
            this.lwInventory = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chInvoice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOKEICode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMeasurement = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReleased = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDebit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripInventory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripCatalogs = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            this.tableLayoutPanelInventory.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
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
            this.tableLayoutPanelLeft.Controls.Add(this.treeView, 0, 0);
            this.tableLayoutPanelLeft.Controls.Add(this.panelLeftPanelBottom, 0, 1);
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
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageListMain;
            this.treeView.Location = new System.Drawing.Point(0, 5);
            this.treeView.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.SelectedNodes = ((System.Collections.Generic.List<System.Windows.Forms.TreeNode>)(resources.GetObject("treeView.SelectedNodes")));
            this.treeView.Size = new System.Drawing.Size(198, 588);
            this.treeView.TabIndex = 0;
            this.treeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeSelect);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);
            this.treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
            this.treeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseUp);
            // 
            // imageListMain
            // 
            this.imageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMain.ImageStream")));
            this.imageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMain.Images.SetKeyName(0, "folder_20.png");
            this.imageListMain.Images.SetKeyName(1, "file_20.png");
            // 
            // panelLeftPanelBottom
            // 
            this.panelLeftPanelBottom.BackColor = System.Drawing.Color.Silver;
            this.panelLeftPanelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftPanelBottom.Location = new System.Drawing.Point(0, 593);
            this.panelLeftPanelBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelLeftPanelBottom.Name = "panelLeftPanelBottom";
            this.panelLeftPanelBottom.Size = new System.Drawing.Size(198, 55);
            this.panelLeftPanelBottom.TabIndex = 1;
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
            this.tableLayoutPanelInventory.Controls.Add(this.panelMainBottom, 0, 1);
            this.tableLayoutPanelInventory.Controls.Add(this.lwInventory, 0, 0);
            this.tableLayoutPanelInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInventory.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelInventory.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelInventory.Name = "tableLayoutPanelInventory";
            this.tableLayoutPanelInventory.RowCount = 2;
            this.tableLayoutPanelInventory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInventory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanelInventory.Size = new System.Drawing.Size(996, 648);
            this.tableLayoutPanelInventory.TabIndex = 2;
            // 
            // panelMainBottom
            // 
            this.panelMainBottom.BackColor = System.Drawing.Color.Silver;
            this.panelMainBottom.Controls.Add(this.btnDemand);
            this.panelMainBottom.Controls.Add(this.btnFilter);
            this.panelMainBottom.Controls.Add(this.btnInventoryEdit);
            this.panelMainBottom.Controls.Add(this.btnInventoryRemove);
            this.panelMainBottom.Controls.Add(this.btnInventoryAdd);
            this.panelMainBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainBottom.Location = new System.Drawing.Point(0, 593);
            this.panelMainBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelMainBottom.Name = "panelMainBottom";
            this.panelMainBottom.Size = new System.Drawing.Size(996, 55);
            this.panelMainBottom.TabIndex = 1;
            // 
            // btnDemand
            // 
            this.btnDemand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDemand.AutoSize = true;
            this.btnDemand.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnDemand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDemand.Location = new System.Drawing.Point(586, 11);
            this.btnDemand.Name = "btnDemand";
            this.btnDemand.Size = new System.Drawing.Size(184, 33);
            this.btnDemand.TabIndex = 4;
            this.btnDemand.Text = "Отпустить ТМЦ";
            this.btnDemand.UseVisualStyleBackColor = true;
            this.btnDemand.Click += new System.EventHandler(this.btnDemand_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.AutoSize = true;
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilter.Location = new System.Drawing.Point(800, 10);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(184, 33);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Фильтр";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnInventoryEdit
            // 
            this.btnInventoryEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInventoryEdit.AutoSize = true;
            this.btnInventoryEdit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnInventoryEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventoryEdit.Location = new System.Drawing.Point(396, 10);
            this.btnInventoryEdit.Name = "btnInventoryEdit";
            this.btnInventoryEdit.Size = new System.Drawing.Size(184, 33);
            this.btnInventoryEdit.TabIndex = 2;
            this.btnInventoryEdit.Text = "Редактировать";
            this.btnInventoryEdit.UseVisualStyleBackColor = true;
            this.btnInventoryEdit.Click += new System.EventHandler(this.btnInventoryEdit_Click);
            // 
            // btnInventoryRemove
            // 
            this.btnInventoryRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInventoryRemove.AutoSize = true;
            this.btnInventoryRemove.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnInventoryRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventoryRemove.Location = new System.Drawing.Point(206, 10);
            this.btnInventoryRemove.Name = "btnInventoryRemove";
            this.btnInventoryRemove.Size = new System.Drawing.Size(184, 33);
            this.btnInventoryRemove.TabIndex = 1;
            this.btnInventoryRemove.Text = "Удалить тмц";
            this.btnInventoryRemove.UseVisualStyleBackColor = true;
            this.btnInventoryRemove.Click += new System.EventHandler(this.btnInventoryRemove_Click);
            // 
            // btnInventoryAdd
            // 
            this.btnInventoryAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInventoryAdd.AutoSize = true;
            this.btnInventoryAdd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnInventoryAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventoryAdd.Location = new System.Drawing.Point(16, 10);
            this.btnInventoryAdd.Name = "btnInventoryAdd";
            this.btnInventoryAdd.Size = new System.Drawing.Size(184, 33);
            this.btnInventoryAdd.TabIndex = 0;
            this.btnInventoryAdd.Text = "Добавить тмц";
            this.btnInventoryAdd.UseVisualStyleBackColor = true;
            this.btnInventoryAdd.Click += new System.EventHandler(this.btnInventoryAdd_Click);
            // 
            // lwInventory
            // 
            this.lwInventory.AllowDrop = true;
            this.lwInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lwInventory.CheckBoxes = true;
            this.lwInventory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chNumber,
            this.chDate,
            this.chInvoice,
            this.chName,
            this.chOKEICode,
            this.chMeasurement,
            this.chAmount,
            this.chPrice,
            this.chSum,
            this.chReleased,
            this.chDebit,
            this.chBalance});
            this.lwInventory.FullRowSelect = true;
            this.lwInventory.GridLines = true;
            this.lwInventory.Location = new System.Drawing.Point(0, 0);
            this.lwInventory.Margin = new System.Windows.Forms.Padding(0);
            this.lwInventory.MultiSelect = false;
            this.lwInventory.Name = "lwInventory";
            this.lwInventory.Size = new System.Drawing.Size(996, 593);
            this.lwInventory.TabIndex = 2;
            this.lwInventory.UseCompatibleStateImageBehavior = false;
            this.lwInventory.View = System.Windows.Forms.View.Details;
            this.lwInventory.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lwInventory_DrawColumnHeader);
            this.lwInventory.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lwInventory_DrawItem);
            this.lwInventory.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lwInventory_DrawSubItem);
            this.lwInventory.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lwInventory_ItemCheck);
            this.lwInventory.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lwInventory_ItemDrag);
            this.lwInventory.DragOver += new System.Windows.Forms.DragEventHandler(this.lwInventory_DragOver);
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 20;
            // 
            // chNumber
            // 
            this.chNumber.Text = "№";
            this.chNumber.Width = 20;
            // 
            // chDate
            // 
            this.chDate.Text = "Дата";
            this.chDate.Width = 100;
            // 
            // chInvoice
            // 
            this.chInvoice.Text = "Накладная";
            this.chInvoice.Width = 200;
            // 
            // chName
            // 
            this.chName.Text = "Название";
            this.chName.Width = 200;
            // 
            // chOKEICode
            // 
            this.chOKEICode.Text = "код ОКЕИ";
            // 
            // chMeasurement
            // 
            this.chMeasurement.Text = "Единица измерения";
            // 
            // chAmount
            // 
            this.chAmount.Text = "Количество";
            // 
            // chPrice
            // 
            this.chPrice.Text = "Цена";
            // 
            // chSum
            // 
            this.chSum.DisplayIndex = 12;
            this.chSum.Text = "Сумма";
            // 
            // chReleased
            // 
            this.chReleased.DisplayIndex = 9;
            this.chReleased.Text = "Отпущено";
            // 
            // chDebit
            // 
            this.chDebit.DisplayIndex = 10;
            this.chDebit.Text = "Списание";
            // 
            // chBalance
            // 
            this.chBalance.DisplayIndex = 11;
            this.chBalance.Text = "Остаток";
            // 
            // contextMenuStripInventory
            // 
            this.contextMenuStripInventory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripInventory.Name = "contextMenuStripInventory";
            this.contextMenuStripInventory.Size = new System.Drawing.Size(67, 4);
            // 
            // contextMenuStripCatalogs
            // 
            this.contextMenuStripCatalogs.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripCatalogs.Name = "contextMenuStripCatalogs";
            this.contextMenuStripCatalogs.Size = new System.Drawing.Size(67, 4);
            // 
            // TabMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TabMain";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.tableLayoutPanelInventory.ResumeLayout(false);
            this.panelMainBottom.ResumeLayout(false);
            this.panelMainBottom.PerformLayout();
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
        private System.Windows.Forms.ListView lwInventory;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chInvoice;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chOKEICode;
        private System.Windows.Forms.ColumnHeader chMeasurement;
        private System.Windows.Forms.ColumnHeader chAmount;
        private System.Windows.Forms.ColumnHeader chPrice;
        private System.Windows.Forms.ColumnHeader chSum;
        private System.Windows.Forms.ColumnHeader chReleased;
        private System.Windows.Forms.ColumnHeader chDebit;
        private System.Windows.Forms.ColumnHeader chBalance;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInventory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private MultiSelectTreeview treeView;
        private System.Windows.Forms.Panel panelLeftPanelBottom;
        private System.Windows.Forms.ImageList imageListMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCatalogs;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnDemand;
    }
}
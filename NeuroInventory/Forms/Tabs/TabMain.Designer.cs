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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelInventory = new System.Windows.Forms.TableLayoutPanel();
            this.panelMainBottom = new System.Windows.Forms.Panel();
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
            this.chDemand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDebit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCollapseExpand = new System.Windows.Forms.Button();
            this.contextMenuStripInventory = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            this.tableLayoutPanelInventory.SuspendLayout();
            this.panelMainBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.AutoScroll = true;
            this.splitContainerMain.Panel1MinSize = 200;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tableLayoutPanelRight);
            this.splitContainerMain.Panel2MinSize = 800;
            this.splitContainerMain.Size = new System.Drawing.Size(1200, 650);
            this.splitContainerMain.SplitterDistance = 250;
            this.splitContainerMain.SplitterWidth = 1;
            this.splitContainerMain.TabIndex = 0;
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.ColumnCount = 2;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.Controls.Add(this.tableLayoutPanelInventory, 1, 0);
            this.tableLayoutPanelRight.Controls.Add(this.btnCollapseExpand, 0, 0);
            this.tableLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRight.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 1;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(949, 650);
            this.tableLayoutPanelRight.TabIndex = 0;
            // 
            // tableLayoutPanelInventory
            // 
            this.tableLayoutPanelInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelInventory.ColumnCount = 1;
            this.tableLayoutPanelInventory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelInventory.Controls.Add(this.panelMainBottom, 0, 1);
            this.tableLayoutPanelInventory.Controls.Add(this.lwInventory, 0, 0);
            this.tableLayoutPanelInventory.Location = new System.Drawing.Point(20, 0);
            this.tableLayoutPanelInventory.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelInventory.Name = "tableLayoutPanelInventory";
            this.tableLayoutPanelInventory.RowCount = 2;
            this.tableLayoutPanelInventory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.99181F));
            this.tableLayoutPanelInventory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.008189F));
            this.tableLayoutPanelInventory.Size = new System.Drawing.Size(929, 650);
            this.tableLayoutPanelInventory.TabIndex = 2;
            // 
            // panelMainBottom
            // 
            this.panelMainBottom.Controls.Add(this.btnInventoryEdit);
            this.panelMainBottom.Controls.Add(this.btnInventoryRemove);
            this.panelMainBottom.Controls.Add(this.btnInventoryAdd);
            this.panelMainBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainBottom.Location = new System.Drawing.Point(0, 591);
            this.panelMainBottom.Margin = new System.Windows.Forms.Padding(0);
            this.panelMainBottom.Name = "panelMainBottom";
            this.panelMainBottom.Size = new System.Drawing.Size(929, 59);
            this.panelMainBottom.TabIndex = 1;
            // 
            // btnInventoryEdit
            // 
            this.btnInventoryEdit.Location = new System.Drawing.Point(392, 14);
            this.btnInventoryEdit.Name = "btnInventoryEdit";
            this.btnInventoryEdit.Size = new System.Drawing.Size(184, 33);
            this.btnInventoryEdit.TabIndex = 2;
            this.btnInventoryEdit.Text = "Редактировать";
            this.btnInventoryEdit.UseVisualStyleBackColor = true;
            this.btnInventoryEdit.Click += new System.EventHandler(this.btnInventoryEdit_Click);
            // 
            // btnInventoryRemove
            // 
            this.btnInventoryRemove.Location = new System.Drawing.Point(202, 14);
            this.btnInventoryRemove.Name = "btnInventoryRemove";
            this.btnInventoryRemove.Size = new System.Drawing.Size(184, 33);
            this.btnInventoryRemove.TabIndex = 1;
            this.btnInventoryRemove.Text = "Удалить тмц";
            this.btnInventoryRemove.UseVisualStyleBackColor = true;
            this.btnInventoryRemove.Click += new System.EventHandler(this.btnInventoryRemove_Click);
            // 
            // btnInventoryAdd
            // 
            this.btnInventoryAdd.Location = new System.Drawing.Point(12, 14);
            this.btnInventoryAdd.Name = "btnInventoryAdd";
            this.btnInventoryAdd.Size = new System.Drawing.Size(184, 33);
            this.btnInventoryAdd.TabIndex = 0;
            this.btnInventoryAdd.Text = "Добавить тмц";
            this.btnInventoryAdd.UseVisualStyleBackColor = true;
            this.btnInventoryAdd.Click += new System.EventHandler(this.btnInventoryAdd_Click);
            // 
            // lwInventory
            // 
            this.lwInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.chDemand,
            this.chDebit,
            this.chBalance});
            this.lwInventory.FullRowSelect = true;
            this.lwInventory.GridLines = true;
            this.lwInventory.Location = new System.Drawing.Point(0, 0);
            this.lwInventory.Margin = new System.Windows.Forms.Padding(0);
            this.lwInventory.MinimumSize = new System.Drawing.Size(800, 600);
            this.lwInventory.MultiSelect = false;
            this.lwInventory.Name = "lwInventory";
            this.lwInventory.Size = new System.Drawing.Size(929, 600);
            this.lwInventory.TabIndex = 2;
            this.lwInventory.UseCompatibleStateImageBehavior = false;
            this.lwInventory.View = System.Windows.Forms.View.Details;
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
            this.chSum.DisplayIndex = 13;
            this.chSum.Text = "Сумма";
            // 
            // chReleased
            // 
            this.chReleased.DisplayIndex = 9;
            this.chReleased.Text = "Отпущено";
            // 
            // chDemand
            // 
            this.chDemand.DisplayIndex = 10;
            this.chDemand.Text = "Требование";
            // 
            // chDebit
            // 
            this.chDebit.DisplayIndex = 11;
            this.chDebit.Text = "Списание";
            // 
            // chBalance
            // 
            this.chBalance.DisplayIndex = 12;
            this.chBalance.Text = "Остаток";
            // 
            // btnCollapseExpand
            // 
            this.btnCollapseExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCollapseExpand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCollapseExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapseExpand.Location = new System.Drawing.Point(0, 0);
            this.btnCollapseExpand.Margin = new System.Windows.Forms.Padding(0);
            this.btnCollapseExpand.Name = "btnCollapseExpand";
            this.btnCollapseExpand.Size = new System.Drawing.Size(20, 650);
            this.btnCollapseExpand.TabIndex = 0;
            this.btnCollapseExpand.Text = "<";
            this.btnCollapseExpand.UseVisualStyleBackColor = false;
            this.btnCollapseExpand.Click += new System.EventHandler(this.btnCollapseExpand_Click);
            // 
            // contextMenuStripInventory
            // 
            this.contextMenuStripInventory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripInventory.Name = "contextMenuStripInventory";
            this.contextMenuStripInventory.Size = new System.Drawing.Size(61, 4);
            // 
            // TabMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "TabMain";
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.tableLayoutPanelInventory.ResumeLayout(false);
            this.panelMainBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
        private System.Windows.Forms.Button btnCollapseExpand;
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
        private System.Windows.Forms.ColumnHeader chDemand;
        private System.Windows.Forms.ColumnHeader chDebit;
        private System.Windows.Forms.ColumnHeader chBalance;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInventory;
    }
}
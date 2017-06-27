namespace NeuroInventory
{
    partial class DemandEditorNew
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
            this.lwDemandData = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.highlightTextRenderer1 = new BrightIdeasSoftware.HighlightTextRenderer();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelBottonLeft = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReleased = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lwDemandData)).BeginInit();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelBottonLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // lwDemandData
            // 
            this.lwDemandData.AllColumns.Add(this.olvColumn7);
            this.lwDemandData.AllColumns.Add(this.olvColumn1);
            this.lwDemandData.AllColumns.Add(this.olvColumn2);
            this.lwDemandData.AllColumns.Add(this.olvColumn3);
            this.lwDemandData.AllColumns.Add(this.olvColumn4);
            this.lwDemandData.AllColumns.Add(this.olvColumn5);
            this.lwDemandData.AllColumns.Add(this.olvColumn6);
            this.lwDemandData.CellEditUseWholeCell = false;
            this.lwDemandData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn7,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn6});
            this.lwDemandData.Cursor = System.Windows.Forms.Cursors.Default;
            this.lwDemandData.DataSource = null;
            this.lwDemandData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwDemandData.FullRowSelect = true;
            this.lwDemandData.GridLines = true;
            this.lwDemandData.Location = new System.Drawing.Point(3, 3);
            this.lwDemandData.Name = "lwDemandData";
            this.lwDemandData.ShowGroups = false;
            this.lwDemandData.Size = new System.Drawing.Size(820, 546);
            this.lwDemandData.TabIndex = 0;
            this.lwDemandData.UseCompatibleStateImageBehavior = false;
            this.lwDemandData.View = System.Windows.Forms.View.Details;
            this.lwDemandData.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.lwDemandData_CellEditFinishing);
            this.lwDemandData.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.lwDemandData_CellEditStarting);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "name";
            this.olvColumn1.ButtonPadding = new System.Drawing.Size(10, 10);
            this.olvColumn1.IsTileViewColumn = true;
            this.olvColumn1.Text = "Название";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 250;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "id";
            this.olvColumn7.Text = "id";
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "OKEIcode";
            this.olvColumn2.IsEditable = false;
            this.olvColumn2.Text = "Код ОКЕИ";
            this.olvColumn2.Width = 90;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "measurement";
            this.olvColumn3.IsEditable = false;
            this.olvColumn3.Text = "Единица измерения";
            this.olvColumn3.Width = 150;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "price";
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.Text = "Цена";
            this.olvColumn4.Width = 100;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "amount";
            this.olvColumn5.Text = "Количество";
            this.olvColumn5.Width = 100;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "sum";
            this.olvColumn6.IsEditable = false;
            this.olvColumn6.Text = "Сумма";
            this.olvColumn6.Width = 100;
            // 
            // highlightTextRenderer1
            // 
            this.highlightTextRenderer1.CanWrap = true;
            this.highlightTextRenderer1.UseGdiTextRendering = false;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.88791F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.11209F));
            this.tableLayoutPanelMain.Controls.Add(this.lwDemandData, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelBottonLeft, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.95652F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.04348F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1182, 635);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // panelBottonLeft
            // 
            this.panelBottonLeft.Controls.Add(this.btnClose);
            this.panelBottonLeft.Controls.Add(this.btnReleased);
            this.panelBottonLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottonLeft.Location = new System.Drawing.Point(829, 555);
            this.panelBottonLeft.Name = "panelBottonLeft";
            this.panelBottonLeft.Size = new System.Drawing.Size(350, 77);
            this.panelBottonLeft.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.AutoSize = true;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(3, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(184, 33);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReleased
            // 
            this.btnReleased.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReleased.AutoSize = true;
            this.btnReleased.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnReleased.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReleased.Location = new System.Drawing.Point(3, 3);
            this.btnReleased.Name = "btnReleased";
            this.btnReleased.Size = new System.Drawing.Size(184, 33);
            this.btnReleased.TabIndex = 5;
            this.btnReleased.Text = "Отпустить";
            this.btnReleased.UseVisualStyleBackColor = true;
            // 
            // DemandEditorNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 635);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DemandEditorNew";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор требований";
            ((System.ComponentModel.ISupportInitialize)(this.lwDemandData)).EndInit();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelBottonLeft.ResumeLayout(false);
            this.panelBottonLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.DataListView lwDemandData;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.HighlightTextRenderer highlightTextRenderer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private System.Windows.Forms.Panel panelBottonLeft;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReleased;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
    }
}
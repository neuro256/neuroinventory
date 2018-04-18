namespace NeuroInventory
{
    partial class DebitEditor
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
            this.lwDebitData = new BrightIdeasSoftware.DataListView();
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.highlightTextRenderer1 = new BrightIdeasSoftware.HighlightTextRenderer();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelLeftUpper = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnReleased = new System.Windows.Forms.Button();
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.lwDebitData)).BeginInit();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelLeftUpper.SuspendLayout();
            this.SuspendLayout();
            // 
            // lwDebitData
            // 
            this.lwDebitData.AllColumns.Add(this.olvColumn7);
            this.lwDebitData.AllColumns.Add(this.olvColumn1);
            this.lwDebitData.AllColumns.Add(this.olvColumn2);
            this.lwDebitData.AllColumns.Add(this.olvColumn8);
            this.lwDebitData.AllColumns.Add(this.olvColumn3);
            this.lwDebitData.AllColumns.Add(this.olvColumn4);
            this.lwDebitData.AllColumns.Add(this.olvColumn5);
            this.lwDebitData.AllColumns.Add(this.olvColumn6);
            this.lwDebitData.CellEditUseWholeCell = false;
            this.lwDebitData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn7,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn8,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn6});
            this.lwDebitData.Cursor = System.Windows.Forms.Cursors.Default;
            this.lwDebitData.DataSource = null;
            this.lwDebitData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwDebitData.FullRowSelect = true;
            this.lwDebitData.GridLines = true;
            this.lwDebitData.Location = new System.Drawing.Point(3, 3);
            this.lwDebitData.Name = "lwDebitData";
            this.lwDebitData.ShowGroups = false;
            this.lwDebitData.Size = new System.Drawing.Size(840, 629);
            this.lwDebitData.TabIndex = 0;
            this.lwDebitData.UseCompatibleStateImageBehavior = false;
            this.lwDebitData.View = System.Windows.Forms.View.Details;
            this.lwDebitData.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.lwDebitData_CellEditFinishing);
            this.lwDebitData.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.lwDebitData_CellEditStarting);
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "";
            this.olvColumn7.IsEditable = false;
            this.olvColumn7.Text = "№";
            this.olvColumn7.Width = 50;
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
            this.olvColumn4.AspectToStringFormat = "{0:C}";
            this.olvColumn4.IsEditable = false;
            this.olvColumn4.Text = "Цена";
            this.olvColumn4.Width = 100;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "amount";
            this.olvColumn5.IsEditable = false;
            this.olvColumn5.Text = "Количество";
            this.olvColumn5.Width = 100;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "sum";
            this.olvColumn6.AspectToStringFormat = "{0:C}";
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
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.59237F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.40763F));
            this.tableLayoutPanelMain.Controls.Add(this.lwDebitData, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelLeftUpper, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1182, 635);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // panelLeftUpper
            // 
            this.panelLeftUpper.Controls.Add(this.lblDate);
            this.panelLeftUpper.Controls.Add(this.dateTimePicker);
            this.panelLeftUpper.Controls.Add(this.btnReleased);
            this.panelLeftUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftUpper.Location = new System.Drawing.Point(849, 3);
            this.panelLeftUpper.Name = "panelLeftUpper";
            this.panelLeftUpper.Size = new System.Drawing.Size(330, 629);
            this.panelLeftUpper.TabIndex = 7;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Silver;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDate.Location = new System.Drawing.Point(3, 6);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(43, 18);
            this.lblDate.TabIndex = 11;
            this.lblDate.Text = "Дата";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.Location = new System.Drawing.Point(3, 27);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(318, 22);
            this.dateTimePicker.TabIndex = 9;
            // 
            // btnReleased
            // 
            this.btnReleased.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReleased.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnReleased.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReleased.Location = new System.Drawing.Point(3, 587);
            this.btnReleased.Name = "btnReleased";
            this.btnReleased.Size = new System.Drawing.Size(318, 33);
            this.btnReleased.TabIndex = 5;
            this.btnReleased.Text = "Сформировать отчет";
            this.btnReleased.UseVisualStyleBackColor = true;
            this.btnReleased.Click += new System.EventHandler(this.btnReleased_Click);
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "invoice_code";
            this.olvColumn8.IsEditable = false;
            this.olvColumn8.Text = "Код накладной";
            this.olvColumn8.Width = 120;
            // 
            // DebitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 635);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DebitEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор списаний";
            ((System.ComponentModel.ISupportInitialize)(this.lwDebitData)).EndInit();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelLeftUpper.ResumeLayout(false);
            this.panelLeftUpper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.DataListView lwDebitData;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.HighlightTextRenderer highlightTextRenderer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private System.Windows.Forms.Button btnReleased;
        private System.Windows.Forms.Panel panelLeftUpper;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
    }
}
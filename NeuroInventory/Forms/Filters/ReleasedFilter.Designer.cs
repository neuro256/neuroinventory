namespace NeuroInventory
{
    partial class ReleasedFilter
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
            this.lblDate = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblOKEI = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbOKEI = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMeasurement = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cbMeasurement = new System.Windows.Forms.ComboBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.chbDate = new System.Windows.Forms.CheckBox();
            this.chbMeasurement = new System.Windows.Forms.CheckBox();
            this.chbAmount = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbPrice = new System.Windows.Forms.CheckBox();
            this.tbEmployee = new System.Windows.Forms.TextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.tbPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.flowPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tbPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanelMain = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.tbPanel1.SuspendLayout();
            this.tbPanel2.SuspendLayout();
            this.tbPanel3.SuspendLayout();
            this.tbPanel4.SuspendLayout();
            this.tbPanel5.SuspendLayout();
            this.tbPanel6.SuspendLayout();
            this.tbPanel7.SuspendLayout();
            this.flowPanel1.SuspendLayout();
            this.tbPanelButtons.SuspendLayout();
            this.tbPanelBottom.SuspendLayout();
            this.tbPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Silver;
            this.lblDate.Location = new System.Drawing.Point(27, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(98, 17);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата отпуска";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(72, 17);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Название";
            // 
            // lblOKEI
            // 
            this.lblOKEI.AutoSize = true;
            this.lblOKEI.Location = new System.Drawing.Point(3, 0);
            this.lblOKEI.Name = "lblOKEI";
            this.lblOKEI.Size = new System.Drawing.Size(76, 17);
            this.lblOKEI.TabIndex = 4;
            this.lblOKEI.Text = "Код ОКЕИ";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(3, 20);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 22);
            this.tbName.TabIndex = 8;
            // 
            // tbOKEI
            // 
            this.tbOKEI.Location = new System.Drawing.Point(3, 20);
            this.tbOKEI.Name = "tbOKEI";
            this.tbOKEI.Size = new System.Drawing.Size(200, 22);
            this.tbOKEI.TabIndex = 9;
            // 
            // btnFilter
            // 
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilter.Location = new System.Drawing.Point(10, 3);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(98, 29);
            this.btnFilter.TabIndex = 10;
            this.btnFilter.Text = "Поиск";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(128, 3);
            this.btnClear.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 29);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(246, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 29);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Скрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMeasurement
            // 
            this.lblMeasurement.AutoSize = true;
            this.lblMeasurement.Location = new System.Drawing.Point(27, 0);
            this.lblMeasurement.Name = "lblMeasurement";
            this.lblMeasurement.Size = new System.Drawing.Size(141, 17);
            this.lblMeasurement.TabIndex = 13;
            this.lblMeasurement.Text = "Единица измерения";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(27, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(86, 17);
            this.lblAmount.TabIndex = 14;
            this.lblAmount.Text = "Количество";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(27, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(43, 17);
            this.lblPrice.TabIndex = 15;
            this.lblPrice.Text = "Цена";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(27, 20);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 17;
            this.dateTimePicker.CloseUp += new System.EventHandler(this.dateTimePicker_CloseUp);
            // 
            // cbMeasurement
            // 
            this.cbMeasurement.FormattingEnabled = true;
            this.cbMeasurement.Location = new System.Drawing.Point(27, 20);
            this.cbMeasurement.Name = "cbMeasurement";
            this.cbMeasurement.Size = new System.Drawing.Size(200, 24);
            this.cbMeasurement.TabIndex = 18;
            this.cbMeasurement.SelectionChangeCommitted += new System.EventHandler(this.cbMeasurement_SelectionChangeCommitted);
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(27, 20);
            this.nudAmount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(200, 22);
            this.nudAmount.TabIndex = 19;
            this.nudAmount.ValueChanged += new System.EventHandler(this.nudAmount_ValueChanged);
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(27, 20);
            this.nudPrice.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(200, 22);
            this.nudPrice.TabIndex = 20;
            this.nudPrice.ValueChanged += new System.EventHandler(this.nudPrice_ValueChanged);
            // 
            // chbDate
            // 
            this.chbDate.AutoSize = true;
            this.chbDate.Location = new System.Drawing.Point(3, 20);
            this.chbDate.Name = "chbDate";
            this.chbDate.Size = new System.Drawing.Size(18, 17);
            this.chbDate.TabIndex = 22;
            this.chbDate.UseVisualStyleBackColor = true;
            // 
            // chbMeasurement
            // 
            this.chbMeasurement.AutoSize = true;
            this.chbMeasurement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbMeasurement.Location = new System.Drawing.Point(3, 20);
            this.chbMeasurement.Name = "chbMeasurement";
            this.chbMeasurement.Size = new System.Drawing.Size(18, 24);
            this.chbMeasurement.TabIndex = 23;
            this.chbMeasurement.UseVisualStyleBackColor = true;
            // 
            // chbAmount
            // 
            this.chbAmount.AutoSize = true;
            this.chbAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbAmount.Location = new System.Drawing.Point(3, 20);
            this.chbAmount.Name = "chbAmount";
            this.chbAmount.Size = new System.Drawing.Size(18, 22);
            this.chbAmount.TabIndex = 24;
            this.chbAmount.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(825, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(816, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Наличие галочки включает поиск по  соответствующему столбцу таблицы";
            // 
            // chbPrice
            // 
            this.chbPrice.AutoSize = true;
            this.chbPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbPrice.Location = new System.Drawing.Point(3, 20);
            this.chbPrice.Name = "chbPrice";
            this.chbPrice.Size = new System.Drawing.Size(18, 22);
            this.chbPrice.TabIndex = 25;
            this.chbPrice.UseVisualStyleBackColor = true;
            // 
            // tbEmployee
            // 
            this.tbEmployee.Location = new System.Drawing.Point(3, 20);
            this.tbEmployee.Name = "tbEmployee";
            this.tbEmployee.Size = new System.Drawing.Size(200, 22);
            this.tbEmployee.TabIndex = 28;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(3, 0);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(71, 17);
            this.lblEmployee.TabIndex = 27;
            this.lblEmployee.Text = "Работник";
            // 
            // tbPanel1
            // 
            this.tbPanel1.AutoSize = true;
            this.tbPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel1.ColumnCount = 1;
            this.tbPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel1.Controls.Add(this.lblName, 0, 0);
            this.tbPanel1.Controls.Add(this.tbName, 0, 1);
            this.tbPanel1.Location = new System.Drawing.Point(3, 3);
            this.tbPanel1.Name = "tbPanel1";
            this.tbPanel1.RowCount = 2;
            this.tbPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel1.Size = new System.Drawing.Size(206, 45);
            this.tbPanel1.TabIndex = 29;
            // 
            // tbPanel2
            // 
            this.tbPanel2.AutoSize = true;
            this.tbPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel2.ColumnCount = 2;
            this.tbPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel2.Controls.Add(this.lblDate, 1, 0);
            this.tbPanel2.Controls.Add(this.chbDate, 0, 1);
            this.tbPanel2.Controls.Add(this.dateTimePicker, 1, 1);
            this.tbPanel2.Location = new System.Drawing.Point(215, 3);
            this.tbPanel2.Name = "tbPanel2";
            this.tbPanel2.RowCount = 2;
            this.tbPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel2.Size = new System.Drawing.Size(230, 45);
            this.tbPanel2.TabIndex = 30;
            // 
            // tbPanel3
            // 
            this.tbPanel3.AutoSize = true;
            this.tbPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel3.ColumnCount = 1;
            this.tbPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel3.Controls.Add(this.tbOKEI, 0, 1);
            this.tbPanel3.Controls.Add(this.lblOKEI, 0, 0);
            this.tbPanel3.Location = new System.Drawing.Point(451, 3);
            this.tbPanel3.Name = "tbPanel3";
            this.tbPanel3.RowCount = 2;
            this.tbPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel3.Size = new System.Drawing.Size(206, 45);
            this.tbPanel3.TabIndex = 31;
            // 
            // tbPanel4
            // 
            this.tbPanel4.AutoSize = true;
            this.tbPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel4.ColumnCount = 2;
            this.tbPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel4.Controls.Add(this.lblMeasurement, 1, 0);
            this.tbPanel4.Controls.Add(this.chbMeasurement, 0, 1);
            this.tbPanel4.Controls.Add(this.cbMeasurement, 1, 1);
            this.tbPanel4.Location = new System.Drawing.Point(663, 3);
            this.tbPanel4.Name = "tbPanel4";
            this.tbPanel4.RowCount = 2;
            this.tbPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel4.Size = new System.Drawing.Size(230, 47);
            this.tbPanel4.TabIndex = 32;
            // 
            // tbPanel5
            // 
            this.tbPanel5.AutoSize = true;
            this.tbPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel5.ColumnCount = 2;
            this.tbPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel5.Controls.Add(this.lblAmount, 1, 0);
            this.tbPanel5.Controls.Add(this.chbAmount, 0, 1);
            this.tbPanel5.Controls.Add(this.nudAmount, 1, 1);
            this.tbPanel5.Location = new System.Drawing.Point(899, 3);
            this.tbPanel5.Name = "tbPanel5";
            this.tbPanel5.RowCount = 2;
            this.tbPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel5.Size = new System.Drawing.Size(230, 45);
            this.tbPanel5.TabIndex = 33;
            // 
            // tbPanel6
            // 
            this.tbPanel6.AutoSize = true;
            this.tbPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel6.ColumnCount = 1;
            this.tbPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel6.Controls.Add(this.lblEmployee, 0, 0);
            this.tbPanel6.Controls.Add(this.tbEmployee, 0, 1);
            this.tbPanel6.Location = new System.Drawing.Point(1135, 3);
            this.tbPanel6.Name = "tbPanel6";
            this.tbPanel6.RowCount = 2;
            this.tbPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel6.Size = new System.Drawing.Size(206, 45);
            this.tbPanel6.TabIndex = 34;
            // 
            // tbPanel7
            // 
            this.tbPanel7.AutoSize = true;
            this.tbPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel7.ColumnCount = 2;
            this.tbPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel7.Controls.Add(this.lblPrice, 1, 0);
            this.tbPanel7.Controls.Add(this.chbPrice, 0, 1);
            this.tbPanel7.Controls.Add(this.nudPrice, 1, 1);
            this.tbPanel7.Location = new System.Drawing.Point(1347, 3);
            this.tbPanel7.Name = "tbPanel7";
            this.tbPanel7.RowCount = 2;
            this.tbPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel7.Size = new System.Drawing.Size(230, 45);
            this.tbPanel7.TabIndex = 35;
            // 
            // flowPanel1
            // 
            this.flowPanel1.AutoScroll = true;
            this.flowPanel1.Controls.Add(this.tbPanel1);
            this.flowPanel1.Controls.Add(this.tbPanel2);
            this.flowPanel1.Controls.Add(this.tbPanel3);
            this.flowPanel1.Controls.Add(this.tbPanel4);
            this.flowPanel1.Controls.Add(this.tbPanel5);
            this.flowPanel1.Controls.Add(this.tbPanel6);
            this.flowPanel1.Controls.Add(this.tbPanel7);
            this.flowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowPanel1.Name = "flowPanel1";
            this.flowPanel1.Size = new System.Drawing.Size(1644, 98);
            this.flowPanel1.TabIndex = 36;
            // 
            // tbPanelButtons
            // 
            this.tbPanelButtons.ColumnCount = 3;
            this.tbPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanelButtons.Controls.Add(this.btnFilter, 0, 0);
            this.tbPanelButtons.Controls.Add(this.btnClear, 1, 0);
            this.tbPanelButtons.Controls.Add(this.btnClose, 2, 0);
            this.tbPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbPanelButtons.Location = new System.Drawing.Point(3, 12);
            this.tbPanelButtons.Name = "tbPanelButtons";
            this.tbPanelButtons.RowCount = 1;
            this.tbPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanelButtons.Size = new System.Drawing.Size(816, 35);
            this.tbPanelButtons.TabIndex = 37;
            // 
            // tbPanelBottom
            // 
            this.tbPanelBottom.ColumnCount = 2;
            this.tbPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanelBottom.Controls.Add(this.tbPanelButtons, 0, 0);
            this.tbPanelBottom.Controls.Add(this.label1, 1, 0);
            this.tbPanelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPanelBottom.Location = new System.Drawing.Point(3, 107);
            this.tbPanelBottom.Name = "tbPanelBottom";
            this.tbPanelBottom.RowCount = 1;
            this.tbPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanelBottom.Size = new System.Drawing.Size(1644, 50);
            this.tbPanelBottom.TabIndex = 38;
            // 
            // tbPanelMain
            // 
            this.tbPanelMain.ColumnCount = 1;
            this.tbPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbPanelMain.Controls.Add(this.flowPanel1, 0, 0);
            this.tbPanelMain.Controls.Add(this.tbPanelBottom, 0, 1);
            this.tbPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tbPanelMain.Name = "tbPanelMain";
            this.tbPanelMain.RowCount = 2;
            this.tbPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tbPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tbPanelMain.Size = new System.Drawing.Size(1650, 160);
            this.tbPanelMain.TabIndex = 39;
            // 
            // ReleasedFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1650, 160);
            this.Controls.Add(this.tbPanelMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReleasedFilter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск сотрудника";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReleasedFilter_FormClosing);
            this.Shown += new System.EventHandler(this.ReleasedFilter_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.tbPanel1.ResumeLayout(false);
            this.tbPanel1.PerformLayout();
            this.tbPanel2.ResumeLayout(false);
            this.tbPanel2.PerformLayout();
            this.tbPanel3.ResumeLayout(false);
            this.tbPanel3.PerformLayout();
            this.tbPanel4.ResumeLayout(false);
            this.tbPanel4.PerformLayout();
            this.tbPanel5.ResumeLayout(false);
            this.tbPanel5.PerformLayout();
            this.tbPanel6.ResumeLayout(false);
            this.tbPanel6.PerformLayout();
            this.tbPanel7.ResumeLayout(false);
            this.tbPanel7.PerformLayout();
            this.flowPanel1.ResumeLayout(false);
            this.flowPanel1.PerformLayout();
            this.tbPanelButtons.ResumeLayout(false);
            this.tbPanelBottom.ResumeLayout(false);
            this.tbPanelBottom.PerformLayout();
            this.tbPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblOKEI;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbOKEI;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMeasurement;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox cbMeasurement;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.CheckBox chbDate;
        private System.Windows.Forms.CheckBox chbMeasurement;
        private System.Windows.Forms.CheckBox chbAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbPrice;
        private System.Windows.Forms.TextBox tbEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.TableLayoutPanel tbPanel1;
        private System.Windows.Forms.TableLayoutPanel tbPanel2;
        private System.Windows.Forms.TableLayoutPanel tbPanel3;
        private System.Windows.Forms.TableLayoutPanel tbPanel4;
        private System.Windows.Forms.TableLayoutPanel tbPanel5;
        private System.Windows.Forms.TableLayoutPanel tbPanel6;
        private System.Windows.Forms.TableLayoutPanel tbPanel7;
        private System.Windows.Forms.FlowLayoutPanel flowPanel1;
        private System.Windows.Forms.TableLayoutPanel tbPanelButtons;
        private System.Windows.Forms.TableLayoutPanel tbPanelBottom;
        private System.Windows.Forms.TableLayoutPanel tbPanelMain;
    }
}
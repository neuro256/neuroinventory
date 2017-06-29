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
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Silver;
            this.lblDate.Location = new System.Drawing.Point(264, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 17);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(33, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(72, 17);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Название";
            // 
            // lblOKEI
            // 
            this.lblOKEI.AutoSize = true;
            this.lblOKEI.Location = new System.Drawing.Point(493, 9);
            this.lblOKEI.Name = "lblOKEI";
            this.lblOKEI.Size = new System.Drawing.Size(76, 17);
            this.lblOKEI.TabIndex = 4;
            this.lblOKEI.Text = "Код ОКЕИ";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(36, 31);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 22);
            this.tbName.TabIndex = 8;
            // 
            // tbOKEI
            // 
            this.tbOKEI.Location = new System.Drawing.Point(496, 29);
            this.tbOKEI.Name = "tbOKEI";
            this.tbOKEI.Size = new System.Drawing.Size(200, 22);
            this.tbOKEI.TabIndex = 9;
            // 
            // btnFilter
            // 
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilter.Location = new System.Drawing.Point(12, 113);
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
            this.btnClear.Location = new System.Drawing.Point(116, 113);
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
            this.btnClose.Location = new System.Drawing.Point(220, 113);
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
            this.lblMeasurement.Location = new System.Drawing.Point(731, 9);
            this.lblMeasurement.Name = "lblMeasurement";
            this.lblMeasurement.Size = new System.Drawing.Size(141, 17);
            this.lblMeasurement.TabIndex = 13;
            this.lblMeasurement.Text = "Единица измерения";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(970, 9);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(86, 17);
            this.lblAmount.TabIndex = 14;
            this.lblAmount.Text = "Количество";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(263, 56);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(43, 17);
            this.lblPrice.TabIndex = 15;
            this.lblPrice.Text = "Цена";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(267, 31);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 17;
            this.dateTimePicker.CloseUp += new System.EventHandler(this.dateTimePicker_CloseUp);
            // 
            // cbMeasurement
            // 
            this.cbMeasurement.FormattingEnabled = true;
            this.cbMeasurement.Location = new System.Drawing.Point(734, 29);
            this.cbMeasurement.Name = "cbMeasurement";
            this.cbMeasurement.Size = new System.Drawing.Size(200, 24);
            this.cbMeasurement.TabIndex = 18;
            this.cbMeasurement.SelectionChangeCommitted += new System.EventHandler(this.cbMeasurement_SelectionChangeCommitted);
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(973, 30);
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
            this.nudPrice.Location = new System.Drawing.Point(266, 77);
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
            this.chbDate.Location = new System.Drawing.Point(243, 33);
            this.chbDate.Name = "chbDate";
            this.chbDate.Size = new System.Drawing.Size(18, 17);
            this.chbDate.TabIndex = 22;
            this.chbDate.UseVisualStyleBackColor = true;
            // 
            // chbMeasurement
            // 
            this.chbMeasurement.AutoSize = true;
            this.chbMeasurement.Location = new System.Drawing.Point(710, 33);
            this.chbMeasurement.Name = "chbMeasurement";
            this.chbMeasurement.Size = new System.Drawing.Size(18, 17);
            this.chbMeasurement.TabIndex = 23;
            this.chbMeasurement.UseVisualStyleBackColor = true;
            // 
            // chbAmount
            // 
            this.chbAmount.AutoSize = true;
            this.chbAmount.Location = new System.Drawing.Point(949, 33);
            this.chbAmount.Name = "chbAmount";
            this.chbAmount.Size = new System.Drawing.Size(18, 17);
            this.chbAmount.TabIndex = 24;
            this.chbAmount.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(627, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(502, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Наличие галочки включает поиск по  соответствующему столбцу таблицы";
            // 
            // chbPrice
            // 
            this.chbPrice.AutoSize = true;
            this.chbPrice.Location = new System.Drawing.Point(242, 80);
            this.chbPrice.Name = "chbPrice";
            this.chbPrice.Size = new System.Drawing.Size(18, 17);
            this.chbPrice.TabIndex = 25;
            this.chbPrice.UseVisualStyleBackColor = true;
            // 
            // tbEmployee
            // 
            this.tbEmployee.Location = new System.Drawing.Point(36, 78);
            this.tbEmployee.Name = "tbEmployee";
            this.tbEmployee.Size = new System.Drawing.Size(200, 22);
            this.tbEmployee.TabIndex = 28;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(33, 58);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(71, 17);
            this.lblEmployee.TabIndex = 27;
            this.lblEmployee.Text = "Работник";
            // 
            // ReleasedFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1200, 154);
            this.Controls.Add(this.tbEmployee);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbPrice);
            this.Controls.Add(this.chbAmount);
            this.Controls.Add(this.chbMeasurement);
            this.Controls.Add(this.chbDate);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.cbMeasurement);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblMeasurement);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.tbOKEI);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblOKEI);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReleasedFilter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Поиск сотрудника";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReleasedFilter_FormClosing);
            this.Shown += new System.EventHandler(this.ReleasedFilter_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
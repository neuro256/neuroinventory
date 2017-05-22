namespace NeuroInventory
{
    partial class InventoryEditor
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
            this.lblProvider = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblOKEI = new System.Windows.Forms.Label();
            this.lblMeasurement = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.cbProviders = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tbInvoice = new System.Windows.Forms.TextBox();
            this.btnLink = new System.Windows.Forms.Button();
            this.btnCLear = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbOKEI = new System.Windows.Forms.TextBox();
            this.cbMeasurement = new System.Windows.Forms.ComboBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProvider
            // 
            this.lblProvider.AutoSize = true;
            this.lblProvider.Location = new System.Drawing.Point(26, 29);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(81, 17);
            this.lblProvider.TabIndex = 0;
            this.lblProvider.Text = "Поставщик";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(26, 69);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(131, 17);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Дата поступления";
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Location = new System.Drawing.Point(26, 111);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(81, 17);
            this.lblInvoice.TabIndex = 2;
            this.lblInvoice.Text = "Накладная";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(26, 153);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(106, 17);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Наименование";
            // 
            // lblOKEI
            // 
            this.lblOKEI.AutoSize = true;
            this.lblOKEI.Location = new System.Drawing.Point(26, 194);
            this.lblOKEI.Name = "lblOKEI";
            this.lblOKEI.Size = new System.Drawing.Size(76, 17);
            this.lblOKEI.TabIndex = 4;
            this.lblOKEI.Text = "Код ОКЕИ";
            // 
            // lblMeasurement
            // 
            this.lblMeasurement.AutoSize = true;
            this.lblMeasurement.Location = new System.Drawing.Point(26, 235);
            this.lblMeasurement.Name = "lblMeasurement";
            this.lblMeasurement.Size = new System.Drawing.Size(141, 17);
            this.lblMeasurement.TabIndex = 5;
            this.lblMeasurement.Text = "Единица измерения";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(26, 277);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(86, 17);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Количество";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(26, 319);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(43, 17);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Цена";
            // 
            // cbProviders
            // 
            this.cbProviders.FormattingEnabled = true;
            this.cbProviders.Location = new System.Drawing.Point(186, 26);
            this.cbProviders.Name = "cbProviders";
            this.cbProviders.Size = new System.Drawing.Size(267, 24);
            this.cbProviders.TabIndex = 8;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(186, 64);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(185, 22);
            this.dateTimePicker.TabIndex = 9;
            // 
            // tbInvoice
            // 
            this.tbInvoice.Location = new System.Drawing.Point(186, 108);
            this.tbInvoice.Name = "tbInvoice";
            this.tbInvoice.ReadOnly = true;
            this.tbInvoice.Size = new System.Drawing.Size(267, 22);
            this.tbInvoice.TabIndex = 10;
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(459, 108);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(75, 23);
            this.btnLink.TabIndex = 11;
            this.btnLink.Text = "Обзор";
            this.btnLink.UseVisualStyleBackColor = true;
            // 
            // btnCLear
            // 
            this.btnCLear.Location = new System.Drawing.Point(549, 108);
            this.btnCLear.Name = "btnCLear";
            this.btnCLear.Size = new System.Drawing.Size(88, 23);
            this.btnCLear.TabIndex = 12;
            this.btnCLear.Text = "Очистить";
            this.btnCLear.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(186, 150);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(267, 22);
            this.tbName.TabIndex = 13;
            // 
            // tbOKEI
            // 
            this.tbOKEI.Location = new System.Drawing.Point(186, 191);
            this.tbOKEI.Name = "tbOKEI";
            this.tbOKEI.Size = new System.Drawing.Size(267, 22);
            this.tbOKEI.TabIndex = 14;
            // 
            // cbMeasurement
            // 
            this.cbMeasurement.FormattingEnabled = true;
            this.cbMeasurement.Location = new System.Drawing.Point(186, 232);
            this.cbMeasurement.Name = "cbMeasurement";
            this.cbMeasurement.Size = new System.Drawing.Size(121, 24);
            this.cbMeasurement.TabIndex = 15;
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(186, 275);
            this.nudAmount.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(120, 22);
            this.nudAmount.TabIndex = 16;
            this.nudAmount.ThousandsSeparator = true;
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Location = new System.Drawing.Point(186, 317);
            this.nudPrice.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            131072});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(120, 22);
            this.nudPrice.TabIndex = 17;
            this.nudPrice.ThousandsSeparator = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(140, 389);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(103, 34);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(284, 389);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 34);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // InventoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 435);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.nudAmount);
            this.Controls.Add(this.cbMeasurement);
            this.Controls.Add(this.tbOKEI);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnCLear);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.tbInvoice);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.cbProviders);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblMeasurement);
            this.Controls.Add(this.lblOKEI);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblProvider);
            this.Name = "InventoryEditor";
            this.Text = "Редактор ТМЦ";
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProvider;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblOKEI;
        private System.Windows.Forms.Label lblMeasurement;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ComboBox cbProviders;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox tbInvoice;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Button btnCLear;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbOKEI;
        private System.Windows.Forms.ComboBox cbMeasurement;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
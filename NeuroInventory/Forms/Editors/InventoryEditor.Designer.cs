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
            this.components = new System.ComponentModel.Container();
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
            this.errorProviderInventory = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblInvoiceCode = new System.Windows.Forms.Label();
            this.tbInvoiceCodeStr = new System.Windows.Forms.TextBox();
            this.tbLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.invoiceDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tbLayoutBottom = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInventory)).BeginInit();
            this.tbLayoutMain.SuspendLayout();
            this.tbLayoutBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProvider
            // 
            this.lblProvider.AutoSize = true;
            this.lblProvider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(189)))));
            this.lblProvider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProvider.Location = new System.Drawing.Point(3, 0);
            this.lblProvider.Name = "lblProvider";
            this.lblProvider.Size = new System.Drawing.Size(170, 40);
            this.lblProvider.TabIndex = 0;
            this.lblProvider.Text = "Поставщик";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(189)))));
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Location = new System.Drawing.Point(3, 40);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(170, 40);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Дата поступления";
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInvoice.Location = new System.Drawing.Point(3, 80);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(170, 40);
            this.lblInvoice.TabIndex = 2;
            this.lblInvoice.Text = "Накладная";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(189)))));
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 200);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(170, 40);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Наименование";
            // 
            // lblOKEI
            // 
            this.lblOKEI.AutoSize = true;
            this.lblOKEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOKEI.Location = new System.Drawing.Point(3, 280);
            this.lblOKEI.Name = "lblOKEI";
            this.lblOKEI.Size = new System.Drawing.Size(170, 40);
            this.lblOKEI.TabIndex = 4;
            this.lblOKEI.Text = "Код ОКЕИ";
            // 
            // lblMeasurement
            // 
            this.lblMeasurement.AutoSize = true;
            this.lblMeasurement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeasurement.Location = new System.Drawing.Point(3, 240);
            this.lblMeasurement.Name = "lblMeasurement";
            this.lblMeasurement.Size = new System.Drawing.Size(170, 40);
            this.lblMeasurement.TabIndex = 5;
            this.lblMeasurement.Text = "Единица измерения";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(189)))));
            this.lblAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAmount.Location = new System.Drawing.Point(3, 320);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(170, 40);
            this.lblAmount.TabIndex = 6;
            this.lblAmount.Text = "Количество";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(189)))));
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrice.Location = new System.Drawing.Point(3, 360);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(170, 40);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "Цена";
            // 
            // cbProviders
            // 
            this.cbProviders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbProviders.FormattingEnabled = true;
            this.cbProviders.Location = new System.Drawing.Point(179, 3);
            this.cbProviders.Name = "cbProviders";
            this.cbProviders.Size = new System.Drawing.Size(382, 24);
            this.cbProviders.TabIndex = 8;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(179, 43);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(382, 22);
            this.dateTimePicker.TabIndex = 9;
            // 
            // tbInvoice
            // 
            this.tbInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInvoice.Location = new System.Drawing.Point(179, 83);
            this.tbInvoice.Name = "tbInvoice";
            this.tbInvoice.ReadOnly = true;
            this.tbInvoice.Size = new System.Drawing.Size(382, 22);
            this.tbInvoice.TabIndex = 10;
            this.tbInvoice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbInvoice_MouseClick);
            // 
            // btnLink
            // 
            this.btnLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLink.Location = new System.Drawing.Point(567, 83);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(99, 34);
            this.btnLink.TabIndex = 11;
            this.btnLink.Text = "Обзор";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnCLear
            // 
            this.btnCLear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCLear.Location = new System.Drawing.Point(672, 83);
            this.btnCLear.Name = "btnCLear";
            this.btnCLear.Size = new System.Drawing.Size(102, 34);
            this.btnCLear.TabIndex = 12;
            this.btnCLear.Text = "Очистить";
            this.btnCLear.UseVisualStyleBackColor = true;
            this.btnCLear.Click += new System.EventHandler(this.btnCLear_Click);
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(179, 203);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(382, 22);
            this.tbName.TabIndex = 13;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbOKEI
            // 
            this.tbOKEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOKEI.Location = new System.Drawing.Point(179, 283);
            this.tbOKEI.MaxLength = 3;
            this.tbOKEI.Name = "tbOKEI";
            this.tbOKEI.Size = new System.Drawing.Size(382, 22);
            this.tbOKEI.TabIndex = 14;
            // 
            // cbMeasurement
            // 
            this.cbMeasurement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMeasurement.FormattingEnabled = true;
            this.cbMeasurement.Location = new System.Drawing.Point(179, 243);
            this.cbMeasurement.Name = "cbMeasurement";
            this.cbMeasurement.Size = new System.Drawing.Size(382, 24);
            this.cbMeasurement.TabIndex = 15;
            this.cbMeasurement.SelectionChangeCommitted += new System.EventHandler(this.cbMeasurement_SelectionChangeCommitted);
            // 
            // nudAmount
            // 
            this.nudAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudAmount.Location = new System.Drawing.Point(179, 323);
            this.nudAmount.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(382, 22);
            this.nudAmount.TabIndex = 16;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.ValueChanged += new System.EventHandler(this.nudAmount_ValueChanged);
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudPrice.Location = new System.Drawing.Point(179, 363);
            this.nudPrice.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            131072});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(382, 22);
            this.nudPrice.TabIndex = 17;
            this.nudPrice.ThousandsSeparator = true;
            this.nudPrice.ValueChanged += new System.EventHandler(this.nudPrice_ValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Location = new System.Drawing.Point(287, 10);
            this.btnOK.Margin = new System.Windows.Forms.Padding(10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(103, 34);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(410, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 34);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProviderInventory
            // 
            this.errorProviderInventory.BlinkRate = 0;
            this.errorProviderInventory.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderInventory.ContainerControl = this;
            // 
            // lblInvoiceCode
            // 
            this.lblInvoiceCode.AutoSize = true;
            this.lblInvoiceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInvoiceCode.Location = new System.Drawing.Point(3, 120);
            this.lblInvoiceCode.Name = "lblInvoiceCode";
            this.lblInvoiceCode.Size = new System.Drawing.Size(170, 40);
            this.lblInvoiceCode.TabIndex = 21;
            this.lblInvoiceCode.Text = "Номер накладной";
            // 
            // tbInvoiceCodeStr
            // 
            this.tbInvoiceCodeStr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInvoiceCodeStr.Location = new System.Drawing.Point(179, 123);
            this.tbInvoiceCodeStr.MaxLength = 30;
            this.tbInvoiceCodeStr.Name = "tbInvoiceCodeStr";
            this.tbInvoiceCodeStr.Size = new System.Drawing.Size(382, 22);
            this.tbInvoiceCodeStr.TabIndex = 22;
            // 
            // tbLayoutMain
            // 
            this.tbLayoutMain.ColumnCount = 4;
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tbLayoutMain.Controls.Add(this.lblInvoiceDate, 0, 4);
            this.tbLayoutMain.Controls.Add(this.lblProvider, 0, 0);
            this.tbLayoutMain.Controls.Add(this.tbInvoiceCodeStr, 1, 3);
            this.tbLayoutMain.Controls.Add(this.nudPrice, 1, 9);
            this.tbLayoutMain.Controls.Add(this.cbProviders, 1, 0);
            this.tbLayoutMain.Controls.Add(this.lblPrice, 0, 9);
            this.tbLayoutMain.Controls.Add(this.nudAmount, 1, 8);
            this.tbLayoutMain.Controls.Add(this.lblInvoiceCode, 0, 3);
            this.tbLayoutMain.Controls.Add(this.tbOKEI, 1, 7);
            this.tbLayoutMain.Controls.Add(this.lblAmount, 0, 8);
            this.tbLayoutMain.Controls.Add(this.cbMeasurement, 1, 6);
            this.tbLayoutMain.Controls.Add(this.lblDate, 0, 1);
            this.tbLayoutMain.Controls.Add(this.dateTimePicker, 1, 1);
            this.tbLayoutMain.Controls.Add(this.lblOKEI, 0, 7);
            this.tbLayoutMain.Controls.Add(this.tbName, 1, 5);
            this.tbLayoutMain.Controls.Add(this.lblInvoice, 0, 2);
            this.tbLayoutMain.Controls.Add(this.lblMeasurement, 0, 6);
            this.tbLayoutMain.Controls.Add(this.tbInvoice, 1, 2);
            this.tbLayoutMain.Controls.Add(this.btnLink, 2, 2);
            this.tbLayoutMain.Controls.Add(this.btnCLear, 3, 2);
            this.tbLayoutMain.Controls.Add(this.invoiceDateTimePicker, 1, 4);
            this.tbLayoutMain.Controls.Add(this.lblName, 0, 5);
            this.tbLayoutMain.Location = new System.Drawing.Point(12, 12);
            this.tbLayoutMain.Name = "tbLayoutMain";
            this.tbLayoutMain.RowCount = 10;
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.Size = new System.Drawing.Size(777, 400);
            this.tbLayoutMain.TabIndex = 23;
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblInvoiceDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInvoiceDate.Location = new System.Drawing.Point(3, 160);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(170, 40);
            this.lblInvoiceDate.TabIndex = 24;
            this.lblInvoiceDate.Text = "Дата накладной";
            // 
            // invoiceDateTimePicker
            // 
            this.invoiceDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoiceDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.invoiceDateTimePicker.Location = new System.Drawing.Point(179, 163);
            this.invoiceDateTimePicker.Name = "invoiceDateTimePicker";
            this.invoiceDateTimePicker.Size = new System.Drawing.Size(382, 22);
            this.invoiceDateTimePicker.TabIndex = 25;
            // 
            // tbLayoutBottom
            // 
            this.tbLayoutBottom.ColumnCount = 2;
            this.tbLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutBottom.Controls.Add(this.btnOK, 0, 0);
            this.tbLayoutBottom.Controls.Add(this.btnCancel, 1, 0);
            this.tbLayoutBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbLayoutBottom.Location = new System.Drawing.Point(0, 435);
            this.tbLayoutBottom.Name = "tbLayoutBottom";
            this.tbLayoutBottom.RowCount = 1;
            this.tbLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutBottom.Size = new System.Drawing.Size(800, 58);
            this.tbLayoutBottom.TabIndex = 24;
            // 
            // InventoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.tbLayoutBottom);
            this.Controls.Add(this.tbLayoutMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InventoryEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Редактор ТМЦ";
            this.Shown += new System.EventHandler(this.InventoryEditor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInventory)).EndInit();
            this.tbLayoutMain.ResumeLayout(false);
            this.tbLayoutMain.PerformLayout();
            this.tbLayoutBottom.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ErrorProvider errorProviderInventory;
        private System.Windows.Forms.Label lblInvoiceCode;
        private System.Windows.Forms.TextBox tbInvoiceCodeStr;
        private System.Windows.Forms.TableLayoutPanel tbLayoutMain;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.DateTimePicker invoiceDateTimePicker;
        private System.Windows.Forms.TableLayoutPanel tbLayoutBottom;
    }
}
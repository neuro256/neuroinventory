namespace NeuroInventory
{
    partial class ProviderEditor
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.Label();
            this.tbDocument = new System.Windows.Forms.TextBox();
            this.btnLink = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClearPath = new System.Windows.Forms.Button();
            this.errorProviderProviders = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblINN = new System.Windows.Forms.Label();
            this.tbINN = new System.Windows.Forms.TextBox();
            this.tbLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbLayoutBottom = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProviders)).BeginInit();
            this.tbLayoutMain.SuspendLayout();
            this.tbLayoutBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(187, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(364, 22);
            this.tbName.TabIndex = 5;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            this.tbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbName_KeyPress);
            // 
            // tbAddress
            // 
            this.tbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAddress.Location = new System.Drawing.Point(187, 43);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(364, 22);
            this.tbAddress.TabIndex = 6;
            this.tbAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAddress_KeyPress);
            // 
            // tbPhone
            // 
            this.tbPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPhone.Location = new System.Drawing.Point(187, 83);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(364, 22);
            this.tbPhone.TabIndex = 7;
            this.tbPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPhone_KeyPress);
            // 
            // tbMail
            // 
            this.tbMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMail.Location = new System.Drawing.Point(187, 123);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(364, 22);
            this.tbMail.TabIndex = 8;
            this.tbMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMail_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.LightCyan;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(178, 40);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Location = new System.Drawing.Point(3, 40);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(178, 40);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Адрес";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhone.Location = new System.Drawing.Point(3, 80);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(178, 40);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Телефон";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMail.Location = new System.Drawing.Point(3, 120);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(178, 40);
            this.lblMail.TabIndex = 3;
            this.lblMail.Text = "Электронная почта";
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLink.Location = new System.Drawing.Point(3, 200);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(178, 40);
            this.lblLink.TabIndex = 4;
            this.lblLink.Text = "Ссылка на документ";
            // 
            // tbDocument
            // 
            this.tbDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDocument.Location = new System.Drawing.Point(187, 203);
            this.tbDocument.Name = "tbDocument";
            this.tbDocument.ReadOnly = true;
            this.tbDocument.Size = new System.Drawing.Size(364, 22);
            this.tbDocument.TabIndex = 12;
            this.tbDocument.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbDocument_MouseClick);
            // 
            // btnLink
            // 
            this.btnLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLink.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnLink.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLink.Location = new System.Drawing.Point(557, 203);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(104, 34);
            this.btnLink.TabIndex = 9;
            this.btnLink.Text = "Обзор";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(409, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 29);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Location = new System.Drawing.Point(291, 10);
            this.btnOk.Margin = new System.Windows.Forms.Padding(10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(98, 29);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClearPath
            // 
            this.btnClearPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearPath.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClearPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearPath.Location = new System.Drawing.Point(667, 203);
            this.btnClearPath.Name = "btnClearPath";
            this.btnClearPath.Size = new System.Drawing.Size(107, 34);
            this.btnClearPath.TabIndex = 13;
            this.btnClearPath.Text = "Очистить";
            this.btnClearPath.UseVisualStyleBackColor = true;
            this.btnClearPath.Click += new System.EventHandler(this.btnClearPath_Click);
            // 
            // errorProviderProviders
            // 
            this.errorProviderProviders.BlinkRate = 0;
            this.errorProviderProviders.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderProviders.ContainerControl = this;
            // 
            // lblINN
            // 
            this.lblINN.AutoSize = true;
            this.lblINN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblINN.Location = new System.Drawing.Point(3, 160);
            this.lblINN.Name = "lblINN";
            this.lblINN.Size = new System.Drawing.Size(178, 40);
            this.lblINN.TabIndex = 14;
            this.lblINN.Text = "ИНН";
            // 
            // tbINN
            // 
            this.tbINN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbINN.Location = new System.Drawing.Point(187, 163);
            this.tbINN.Name = "tbINN";
            this.tbINN.Size = new System.Drawing.Size(364, 22);
            this.tbINN.TabIndex = 15;
            this.tbINN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbINN_KeyPress);
            // 
            // tbLayoutMain
            // 
            this.tbLayoutMain.ColumnCount = 4;
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tbLayoutMain.Controls.Add(this.lblName, 0, 0);
            this.tbLayoutMain.Controls.Add(this.btnClearPath, 3, 5);
            this.tbLayoutMain.Controls.Add(this.tbINN, 1, 4);
            this.tbLayoutMain.Controls.Add(this.lblINN, 0, 4);
            this.tbLayoutMain.Controls.Add(this.tbName, 1, 0);
            this.tbLayoutMain.Controls.Add(this.btnLink, 2, 5);
            this.tbLayoutMain.Controls.Add(this.lblAddress, 0, 1);
            this.tbLayoutMain.Controls.Add(this.tbDocument, 1, 5);
            this.tbLayoutMain.Controls.Add(this.tbAddress, 1, 1);
            this.tbLayoutMain.Controls.Add(this.lblLink, 0, 5);
            this.tbLayoutMain.Controls.Add(this.lblPhone, 0, 2);
            this.tbLayoutMain.Controls.Add(this.tbPhone, 1, 2);
            this.tbLayoutMain.Controls.Add(this.lblMail, 0, 3);
            this.tbLayoutMain.Controls.Add(this.tbMail, 1, 3);
            this.tbLayoutMain.Location = new System.Drawing.Point(12, 12);
            this.tbLayoutMain.Name = "tbLayoutMain";
            this.tbLayoutMain.RowCount = 6;
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.Size = new System.Drawing.Size(777, 240);
            this.tbLayoutMain.TabIndex = 16;
            // 
            // tbLayoutBottom
            // 
            this.tbLayoutBottom.ColumnCount = 2;
            this.tbLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutBottom.Controls.Add(this.btnOk, 0, 0);
            this.tbLayoutBottom.Controls.Add(this.btnCancel, 1, 0);
            this.tbLayoutBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbLayoutBottom.Location = new System.Drawing.Point(0, 282);
            this.tbLayoutBottom.Name = "tbLayoutBottom";
            this.tbLayoutBottom.RowCount = 1;
            this.tbLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutBottom.Size = new System.Drawing.Size(798, 53);
            this.tbLayoutBottom.TabIndex = 17;
            // 
            // ProviderEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(798, 335);
            this.Controls.Add(this.tbLayoutBottom);
            this.Controls.Add(this.tbLayoutMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProviderEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Редактор поставщика";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProviders)).EndInit();
            this.tbLayoutMain.ResumeLayout(false);
            this.tbLayoutMain.PerformLayout();
            this.tbLayoutBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.TextBox tbDocument;
        private System.Windows.Forms.Button btnLink;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClearPath;
        private System.Windows.Forms.ErrorProvider errorProviderProviders;
        private System.Windows.Forms.Label lblINN;
        private System.Windows.Forms.TextBox tbINN;
        private System.Windows.Forms.TableLayoutPanel tbLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tbLayoutBottom;
    }
}
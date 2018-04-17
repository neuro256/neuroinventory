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
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProviders)).BeginInit();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(202, 41);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(292, 22);
            this.tbName.TabIndex = 5;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            this.tbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbName_KeyPress);
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(202, 77);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(292, 22);
            this.tbAddress.TabIndex = 6;
            this.tbAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAddress_KeyPress);
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(202, 116);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(292, 22);
            this.tbPhone.TabIndex = 7;
            this.tbPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPhone_KeyPress);
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(202, 156);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(292, 22);
            this.tbMail.TabIndex = 8;
            this.tbMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMail_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.LightCyan;
            this.lblName.Location = new System.Drawing.Point(35, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(72, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(35, 80);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 17);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Адрес";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(35, 119);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(68, 17);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Телефон";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(35, 159);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(138, 17);
            this.lblMail.TabIndex = 3;
            this.lblMail.Text = "Электронная почта";
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(35, 238);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(143, 17);
            this.lblLink.TabIndex = 4;
            this.lblLink.Text = "Ссылка на документ";
            // 
            // tbDocument
            // 
            this.tbDocument.Location = new System.Drawing.Point(202, 235);
            this.tbDocument.Name = "tbDocument";
            this.tbDocument.ReadOnly = true;
            this.tbDocument.Size = new System.Drawing.Size(292, 22);
            this.tbDocument.TabIndex = 12;
            this.tbDocument.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbDocument_MouseClick);
            // 
            // btnLink
            // 
            this.btnLink.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnLink.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLink.Location = new System.Drawing.Point(501, 233);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(88, 24);
            this.btnLink.TabIndex = 9;
            this.btnLink.Text = "Обзор";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(396, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 29);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Location = new System.Drawing.Point(202, 301);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(98, 29);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClearPath
            // 
            this.btnClearPath.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnClearPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClearPath.Location = new System.Drawing.Point(595, 233);
            this.btnClearPath.Name = "btnClearPath";
            this.btnClearPath.Size = new System.Drawing.Size(88, 24);
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
            this.lblINN.Location = new System.Drawing.Point(35, 198);
            this.lblINN.Name = "lblINN";
            this.lblINN.Size = new System.Drawing.Size(38, 17);
            this.lblINN.TabIndex = 14;
            this.lblINN.Text = "ИНН";
            // 
            // tbINN
            // 
            this.tbINN.Location = new System.Drawing.Point(202, 195);
            this.tbINN.Name = "tbINN";
            this.tbINN.Size = new System.Drawing.Size(292, 22);
            this.tbINN.TabIndex = 15;
            this.tbINN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbINN_KeyPress);
            // 
            // ProviderEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(695, 342);
            this.Controls.Add(this.lblINN);
            this.Controls.Add(this.tbINN);
            this.Controls.Add(this.btnClearPath);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.tbDocument);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProviderEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Редактор поставщика";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProviders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
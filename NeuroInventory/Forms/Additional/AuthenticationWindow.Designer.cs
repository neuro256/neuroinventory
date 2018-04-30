namespace NeuroInventory
{
    partial class AuthenticationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationWindow));
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbLayoutBottom = new System.Windows.Forms.TableLayoutPanel();
            this.tbLayoutMain.SuspendLayout();
            this.tbLayoutBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(59, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(47, 17);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Логин";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(49, 40);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 17);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Пароль";
            // 
            // tbLogin
            // 
            this.tbLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLogin.Location = new System.Drawing.Point(112, 3);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(242, 22);
            this.tbLogin.TabIndex = 2;
            this.tbLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLogin_KeyPress);
            // 
            // tbPassword
            // 
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassword.Location = new System.Drawing.Point(112, 43);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(242, 22);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.Location = new System.Drawing.Point(74, 10);
            this.btnOK.Margin = new System.Windows.Forms.Padding(10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(109, 33);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(203, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 33);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbLayoutMain
            // 
            this.tbLayoutMain.ColumnCount = 2;
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.67485F));
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.32515F));
            this.tbLayoutMain.Controls.Add(this.lblLogin, 0, 0);
            this.tbLayoutMain.Controls.Add(this.tbLogin, 1, 0);
            this.tbLayoutMain.Controls.Add(this.tbPassword, 1, 1);
            this.tbLayoutMain.Controls.Add(this.lblPassword, 0, 1);
            this.tbLayoutMain.Location = new System.Drawing.Point(12, 12);
            this.tbLayoutMain.Name = "tbLayoutMain";
            this.tbLayoutMain.RowCount = 2;
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.Size = new System.Drawing.Size(357, 80);
            this.tbLayoutMain.TabIndex = 6;
            // 
            // tbLayoutBottom
            // 
            this.tbLayoutBottom.ColumnCount = 2;
            this.tbLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutBottom.Controls.Add(this.btnOK, 0, 0);
            this.tbLayoutBottom.Controls.Add(this.btnCancel, 1, 0);
            this.tbLayoutBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbLayoutBottom.Location = new System.Drawing.Point(0, 131);
            this.tbLayoutBottom.Name = "tbLayoutBottom";
            this.tbLayoutBottom.RowCount = 1;
            this.tbLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbLayoutBottom.Size = new System.Drawing.Size(386, 61);
            this.tbLayoutBottom.TabIndex = 7;
            // 
            // AuthenticationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(386, 192);
            this.ControlBox = false;
            this.Controls.Add(this.tbLayoutBottom);
            this.Controls.Add(this.tbLayoutMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthenticationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация пользователя";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AuthenticationWindow_Load);
            this.tbLayoutMain.ResumeLayout(false);
            this.tbLayoutMain.PerformLayout();
            this.tbLayoutBottom.ResumeLayout(false);
            this.tbLayoutBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tbLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tbLayoutBottom;
    }
}
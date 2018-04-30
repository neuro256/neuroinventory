namespace NeuroInventory
{
    partial class AuthenticationEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationEditor));
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbPasswordRepeat = new System.Windows.Forms.TextBox();
            this.lblPasswordRepeat = new System.Windows.Forms.Label();
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
            this.lblLogin.Location = new System.Drawing.Point(155, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(47, 17);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Логин";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(145, 40);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(57, 17);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Пароль";
            // 
            // tbLogin
            // 
            this.tbLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLogin.Location = new System.Drawing.Point(208, 3);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(293, 22);
            this.tbLogin.TabIndex = 2;
            this.tbLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLogin_KeyPress);
            // 
            // tbPassword
            // 
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassword.Location = new System.Drawing.Point(208, 43);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(293, 22);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(147, 10);
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
            this.btnCancel.Location = new System.Drawing.Point(276, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 33);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbPasswordRepeat
            // 
            this.tbPasswordRepeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPasswordRepeat.Location = new System.Drawing.Point(208, 83);
            this.tbPasswordRepeat.Name = "tbPasswordRepeat";
            this.tbPasswordRepeat.Size = new System.Drawing.Size(293, 22);
            this.tbPasswordRepeat.TabIndex = 6;
            this.tbPasswordRepeat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPasswordRepeat_KeyPress);
            // 
            // lblPasswordRepeat
            // 
            this.lblPasswordRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPasswordRepeat.AutoSize = true;
            this.lblPasswordRepeat.Location = new System.Drawing.Point(72, 80);
            this.lblPasswordRepeat.Name = "lblPasswordRepeat";
            this.lblPasswordRepeat.Size = new System.Drawing.Size(130, 17);
            this.lblPasswordRepeat.TabIndex = 7;
            this.lblPasswordRepeat.Text = "Повторите пароль";
            // 
            // tbLayoutMain
            // 
            this.tbLayoutMain.ColumnCount = 2;
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.75F));
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.25F));
            this.tbLayoutMain.Controls.Add(this.lblLogin, 0, 0);
            this.tbLayoutMain.Controls.Add(this.tbPasswordRepeat, 1, 2);
            this.tbLayoutMain.Controls.Add(this.lblPasswordRepeat, 0, 2);
            this.tbLayoutMain.Controls.Add(this.lblPassword, 0, 1);
            this.tbLayoutMain.Controls.Add(this.tbLogin, 1, 0);
            this.tbLayoutMain.Controls.Add(this.tbPassword, 1, 1);
            this.tbLayoutMain.Location = new System.Drawing.Point(12, 12);
            this.tbLayoutMain.Name = "tbLayoutMain";
            this.tbLayoutMain.RowCount = 3;
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.Size = new System.Drawing.Size(504, 120);
            this.tbLayoutMain.TabIndex = 8;
            // 
            // tbLayoutBottom
            // 
            this.tbLayoutBottom.ColumnCount = 2;
            this.tbLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayoutBottom.Controls.Add(this.btnOK, 0, 0);
            this.tbLayoutBottom.Controls.Add(this.btnCancel, 1, 0);
            this.tbLayoutBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbLayoutBottom.Location = new System.Drawing.Point(0, 186);
            this.tbLayoutBottom.Name = "tbLayoutBottom";
            this.tbLayoutBottom.RowCount = 1;
            this.tbLayoutBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbLayoutBottom.Size = new System.Drawing.Size(532, 60);
            this.tbLayoutBottom.TabIndex = 9;
            // 
            // AuthenticationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(532, 246);
            this.ControlBox = false;
            this.Controls.Add(this.tbLayoutBottom);
            this.Controls.Add(this.tbLayoutMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthenticationEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сменить логин и/или пароль";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AuthenticationEditor_Load);
            this.tbLayoutMain.ResumeLayout(false);
            this.tbLayoutMain.PerformLayout();
            this.tbLayoutBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbPasswordRepeat;
        private System.Windows.Forms.Label lblPasswordRepeat;
        private System.Windows.Forms.TableLayoutPanel tbLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tbLayoutBottom;
    }
}
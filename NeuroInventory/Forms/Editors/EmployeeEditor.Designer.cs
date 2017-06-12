namespace NeuroInventory
{
    partial class EmployeeEditor
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
            this.lblFirstname = new System.Windows.Forms.Label();
            this.lblSurename = new System.Windows.Forms.Label();
            this.lblLastname = new System.Windows.Forms.Label();
            this.lblPost = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.tbSurename = new System.Windows.Forms.TextBox();
            this.tbFirstname = new System.Windows.Forms.TextBox();
            this.tbLastname = new System.Windows.Forms.TextBox();
            this.tbPost = new System.Windows.Forms.TextBox();
            this.tbDepartment = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProviderEmployees = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFirstname
            // 
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.BackColor = System.Drawing.Color.LightCyan;
            this.lblFirstname.Location = new System.Drawing.Point(24, 62);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(35, 17);
            this.lblFirstname.TabIndex = 0;
            this.lblFirstname.Text = "Имя";
            // 
            // lblSurename
            // 
            this.lblSurename.AutoSize = true;
            this.lblSurename.BackColor = System.Drawing.Color.LightCyan;
            this.lblSurename.Location = new System.Drawing.Point(24, 27);
            this.lblSurename.Name = "lblSurename";
            this.lblSurename.Size = new System.Drawing.Size(70, 17);
            this.lblSurename.TabIndex = 1;
            this.lblSurename.Text = "Фамилия";
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.BackColor = System.Drawing.Color.LightCyan;
            this.lblLastname.Location = new System.Drawing.Point(23, 100);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(71, 17);
            this.lblLastname.TabIndex = 2;
            this.lblLastname.Text = "Отчество";
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.Location = new System.Drawing.Point(23, 141);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(81, 17);
            this.lblPost.TabIndex = 3;
            this.lblPost.Text = "Должность";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(24, 181);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(50, 17);
            this.lblDepartment.TabIndex = 4;
            this.lblDepartment.Text = "Отдел";
            // 
            // tbSurename
            // 
            this.tbSurename.Location = new System.Drawing.Point(133, 27);
            this.tbSurename.Name = "tbSurename";
            this.tbSurename.Size = new System.Drawing.Size(292, 22);
            this.tbSurename.TabIndex = 5;
            this.tbSurename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSurename_KeyPress);
            // 
            // tbFirstname
            // 
            this.tbFirstname.Location = new System.Drawing.Point(133, 62);
            this.tbFirstname.Name = "tbFirstname";
            this.tbFirstname.Size = new System.Drawing.Size(292, 22);
            this.tbFirstname.TabIndex = 6;
            this.tbFirstname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstname_KeyPress);
            // 
            // tbLastname
            // 
            this.tbLastname.Location = new System.Drawing.Point(133, 100);
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.Size = new System.Drawing.Size(292, 22);
            this.tbLastname.TabIndex = 7;
            this.tbLastname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLastname_KeyPress);
            // 
            // tbPost
            // 
            this.tbPost.Location = new System.Drawing.Point(133, 138);
            this.tbPost.Name = "tbPost";
            this.tbPost.Size = new System.Drawing.Size(292, 22);
            this.tbPost.TabIndex = 8;
            this.tbPost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPost_KeyPress);
            // 
            // tbDepartment
            // 
            this.tbDepartment.Location = new System.Drawing.Point(133, 178);
            this.tbDepartment.Name = "tbDepartment";
            this.tbDepartment.Size = new System.Drawing.Size(292, 22);
            this.tbDepartment.TabIndex = 9;
            this.tbDepartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDepartment_KeyPress);
            // 
            // btnOk
            // 
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Location = new System.Drawing.Point(133, 244);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(98, 29);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "ОК";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(327, 244);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 29);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProviderEmployees
            // 
            this.errorProviderEmployees.BlinkRate = 0;
            this.errorProviderEmployees.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderEmployees.ContainerControl = this;
            // 
            // EmployeeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(458, 285);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbDepartment);
            this.Controls.Add(this.tbPost);
            this.Controls.Add(this.tbLastname);
            this.Controls.Add(this.tbFirstname);
            this.Controls.Add(this.tbSurename);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblPost);
            this.Controls.Add(this.lblLastname);
            this.Controls.Add(this.lblSurename);
            this.Controls.Add(this.lblFirstname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EmployeeEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Редактор сотрудника";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstname;
        private System.Windows.Forms.Label lblSurename;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.Label lblPost;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox tbSurename;
        private System.Windows.Forms.TextBox tbFirstname;
        private System.Windows.Forms.TextBox tbLastname;
        private System.Windows.Forms.TextBox tbPost;
        private System.Windows.Forms.TextBox tbDepartment;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProviderEmployees;
    }
}
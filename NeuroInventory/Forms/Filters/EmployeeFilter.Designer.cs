namespace NeuroInventory
{
    partial class EmployeeFilter
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
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFirstname
            // 
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.BackColor = System.Drawing.Color.Silver;
            this.lblFirstname.Location = new System.Drawing.Point(215, 9);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(35, 17);
            this.lblFirstname.TabIndex = 0;
            this.lblFirstname.Text = "Имя";
            // 
            // lblSurename
            // 
            this.lblSurename.AutoSize = true;
            this.lblSurename.BackColor = System.Drawing.Color.Silver;
            this.lblSurename.Location = new System.Drawing.Point(9, 9);
            this.lblSurename.Name = "lblSurename";
            this.lblSurename.Size = new System.Drawing.Size(70, 17);
            this.lblSurename.TabIndex = 1;
            this.lblSurename.Text = "Фамилия";
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.BackColor = System.Drawing.Color.Silver;
            this.lblLastname.Location = new System.Drawing.Point(421, 9);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(71, 17);
            this.lblLastname.TabIndex = 2;
            this.lblLastname.Text = "Отчество";
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.Location = new System.Drawing.Point(627, 9);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(81, 17);
            this.lblPost.TabIndex = 3;
            this.lblPost.Text = "Должность";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(833, 9);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(50, 17);
            this.lblDepartment.TabIndex = 4;
            this.lblDepartment.Text = "Отдел";
            // 
            // tbSurename
            // 
            this.tbSurename.Location = new System.Drawing.Point(12, 29);
            this.tbSurename.Name = "tbSurename";
            this.tbSurename.Size = new System.Drawing.Size(200, 22);
            this.tbSurename.TabIndex = 5;
            this.tbSurename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSurename_KeyPress);
            // 
            // tbFirstname
            // 
            this.tbFirstname.Location = new System.Drawing.Point(218, 29);
            this.tbFirstname.Name = "tbFirstname";
            this.tbFirstname.Size = new System.Drawing.Size(200, 22);
            this.tbFirstname.TabIndex = 6;
            this.tbFirstname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstname_KeyPress);
            // 
            // tbLastname
            // 
            this.tbLastname.Location = new System.Drawing.Point(424, 29);
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.Size = new System.Drawing.Size(200, 22);
            this.tbLastname.TabIndex = 7;
            this.tbLastname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLastname_KeyPress);
            // 
            // tbPost
            // 
            this.tbPost.Location = new System.Drawing.Point(630, 29);
            this.tbPost.Name = "tbPost";
            this.tbPost.Size = new System.Drawing.Size(200, 22);
            this.tbPost.TabIndex = 8;
            this.tbPost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPost_KeyPress);
            // 
            // tbDepartment
            // 
            this.tbDepartment.Location = new System.Drawing.Point(836, 29);
            this.tbDepartment.Name = "tbDepartment";
            this.tbDepartment.Size = new System.Drawing.Size(200, 22);
            this.tbDepartment.TabIndex = 9;
            this.tbDepartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDepartment_KeyPress);
            // 
            // btnFilter
            // 
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilter.Location = new System.Drawing.Point(12, 57);
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
            this.btnClear.Location = new System.Drawing.Point(116, 57);
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
            this.btnClose.Location = new System.Drawing.Point(220, 57);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 29);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Скрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EmployeeFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1200, 90);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFilter);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeFilter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Поиск сотрудника";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeFilter_FormClosing);
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
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
    }
}
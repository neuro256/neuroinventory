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
            this.tbLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmployees)).BeginInit();
            this.tbLayoutMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirstname
            // 
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(189)))));
            this.lblFirstname.Location = new System.Drawing.Point(3, 40);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(35, 17);
            this.lblFirstname.TabIndex = 0;
            this.lblFirstname.Text = "Имя";
            // 
            // lblSurename
            // 
            this.lblSurename.AutoSize = true;
            this.lblSurename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(189)))));
            this.lblSurename.Location = new System.Drawing.Point(3, 0);
            this.lblSurename.Name = "lblSurename";
            this.lblSurename.Size = new System.Drawing.Size(70, 17);
            this.lblSurename.TabIndex = 1;
            this.lblSurename.Text = "Фамилия";
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(189)))));
            this.lblLastname.Location = new System.Drawing.Point(3, 80);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(71, 17);
            this.lblLastname.TabIndex = 2;
            this.lblLastname.Text = "Отчество";
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.Location = new System.Drawing.Point(3, 120);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(81, 17);
            this.lblPost.TabIndex = 3;
            this.lblPost.Text = "Должность";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(3, 160);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(50, 17);
            this.lblDepartment.TabIndex = 4;
            this.lblDepartment.Text = "Отдел";
            // 
            // tbSurename
            // 
            this.tbSurename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSurename.Location = new System.Drawing.Point(141, 3);
            this.tbSurename.Name = "tbSurename";
            this.tbSurename.Size = new System.Drawing.Size(388, 22);
            this.tbSurename.TabIndex = 5;
            this.tbSurename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSurename_KeyPress);
            // 
            // tbFirstname
            // 
            this.tbFirstname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFirstname.Location = new System.Drawing.Point(141, 43);
            this.tbFirstname.Name = "tbFirstname";
            this.tbFirstname.Size = new System.Drawing.Size(388, 22);
            this.tbFirstname.TabIndex = 6;
            this.tbFirstname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstname_KeyPress);
            // 
            // tbLastname
            // 
            this.tbLastname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLastname.Location = new System.Drawing.Point(141, 83);
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.Size = new System.Drawing.Size(388, 22);
            this.tbLastname.TabIndex = 7;
            this.tbLastname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLastname_KeyPress);
            // 
            // tbPost
            // 
            this.tbPost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPost.Location = new System.Drawing.Point(141, 123);
            this.tbPost.Name = "tbPost";
            this.tbPost.Size = new System.Drawing.Size(388, 22);
            this.tbPost.TabIndex = 8;
            this.tbPost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPost_KeyPress);
            // 
            // tbDepartment
            // 
            this.tbDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDepartment.Location = new System.Drawing.Point(141, 163);
            this.tbDepartment.Name = "tbDepartment";
            this.tbDepartment.Size = new System.Drawing.Size(388, 22);
            this.tbDepartment.TabIndex = 9;
            this.tbDepartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDepartment_KeyPress);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Location = new System.Drawing.Point(169, 10);
            this.btnOk.Margin = new System.Windows.Forms.Padding(10);
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
            this.btnCancel.Location = new System.Drawing.Point(287, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(10);
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
            // tbLayoutMain
            // 
            this.tbLayoutMain.ColumnCount = 2;
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.95041F));
            this.tbLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.04958F));
            this.tbLayoutMain.Controls.Add(this.lblSurename, 0, 0);
            this.tbLayoutMain.Controls.Add(this.lblFirstname, 0, 1);
            this.tbLayoutMain.Controls.Add(this.lblLastname, 0, 2);
            this.tbLayoutMain.Controls.Add(this.tbDepartment, 1, 4);
            this.tbLayoutMain.Controls.Add(this.lblPost, 0, 3);
            this.tbLayoutMain.Controls.Add(this.tbPost, 1, 3);
            this.tbLayoutMain.Controls.Add(this.lblDepartment, 0, 4);
            this.tbLayoutMain.Controls.Add(this.tbLastname, 1, 2);
            this.tbLayoutMain.Controls.Add(this.tbSurename, 1, 0);
            this.tbLayoutMain.Controls.Add(this.tbFirstname, 1, 1);
            this.tbLayoutMain.Location = new System.Drawing.Point(12, 12);
            this.tbLayoutMain.Name = "tbLayoutMain";
            this.tbLayoutMain.RowCount = 5;
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbLayoutMain.Size = new System.Drawing.Size(532, 200);
            this.tbLayoutMain.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 233);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(555, 50);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // EmployeeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(555, 283);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tbLayoutMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EmployeeEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Редактор сотрудника";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderEmployees)).EndInit();
            this.tbLayoutMain.ResumeLayout(false);
            this.tbLayoutMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tbLayoutMain;
    }
}
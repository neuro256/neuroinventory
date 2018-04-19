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
            this.tbPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.flowPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tbPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanelMain.SuspendLayout();
            this.tbPanel1.SuspendLayout();
            this.tbPanel2.SuspendLayout();
            this.tbPanel3.SuspendLayout();
            this.tbPanel4.SuspendLayout();
            this.tbPanel5.SuspendLayout();
            this.flowPanel1.SuspendLayout();
            this.tbPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirstname
            // 
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.BackColor = System.Drawing.Color.Silver;
            this.lblFirstname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirstname.Location = new System.Drawing.Point(3, 0);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(200, 17);
            this.lblFirstname.TabIndex = 0;
            this.lblFirstname.Text = "Имя";
            // 
            // lblSurename
            // 
            this.lblSurename.AutoSize = true;
            this.lblSurename.BackColor = System.Drawing.Color.Silver;
            this.lblSurename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSurename.Location = new System.Drawing.Point(3, 0);
            this.lblSurename.Name = "lblSurename";
            this.lblSurename.Size = new System.Drawing.Size(200, 17);
            this.lblSurename.TabIndex = 1;
            this.lblSurename.Text = "Фамилия";
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.BackColor = System.Drawing.Color.Silver;
            this.lblLastname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastname.Location = new System.Drawing.Point(3, 0);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(200, 17);
            this.lblLastname.TabIndex = 2;
            this.lblLastname.Text = "Отчество";
            // 
            // lblPost
            // 
            this.lblPost.AutoSize = true;
            this.lblPost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPost.Location = new System.Drawing.Point(3, 0);
            this.lblPost.Name = "lblPost";
            this.lblPost.Size = new System.Drawing.Size(200, 17);
            this.lblPost.TabIndex = 3;
            this.lblPost.Text = "Должность";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDepartment.Location = new System.Drawing.Point(3, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(200, 17);
            this.lblDepartment.TabIndex = 4;
            this.lblDepartment.Text = "Отдел";
            // 
            // tbSurename
            // 
            this.tbSurename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSurename.Location = new System.Drawing.Point(3, 20);
            this.tbSurename.Name = "tbSurename";
            this.tbSurename.Size = new System.Drawing.Size(200, 22);
            this.tbSurename.TabIndex = 5;
            this.tbSurename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSurename_KeyPress);
            // 
            // tbFirstname
            // 
            this.tbFirstname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFirstname.Location = new System.Drawing.Point(3, 20);
            this.tbFirstname.Name = "tbFirstname";
            this.tbFirstname.Size = new System.Drawing.Size(200, 22);
            this.tbFirstname.TabIndex = 6;
            this.tbFirstname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstname_KeyPress);
            // 
            // tbLastname
            // 
            this.tbLastname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLastname.Location = new System.Drawing.Point(3, 20);
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.Size = new System.Drawing.Size(200, 22);
            this.tbLastname.TabIndex = 7;
            this.tbLastname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLastname_KeyPress);
            // 
            // tbPost
            // 
            this.tbPost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPost.Location = new System.Drawing.Point(3, 20);
            this.tbPost.Name = "tbPost";
            this.tbPost.Size = new System.Drawing.Size(200, 22);
            this.tbPost.TabIndex = 8;
            this.tbPost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPost_KeyPress);
            // 
            // tbDepartment
            // 
            this.tbDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDepartment.Location = new System.Drawing.Point(3, 20);
            this.tbDepartment.Name = "tbDepartment";
            this.tbDepartment.Size = new System.Drawing.Size(200, 22);
            this.tbDepartment.TabIndex = 9;
            this.tbDepartment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDepartment_KeyPress);
            // 
            // btnFilter
            // 
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilter.Location = new System.Drawing.Point(3, 3);
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
            this.btnClear.Location = new System.Drawing.Point(107, 3);
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
            this.btnClose.Location = new System.Drawing.Point(211, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 29);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Скрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbPanelMain
            // 
            this.tbPanelMain.ColumnCount = 1;
            this.tbPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbPanelMain.Controls.Add(this.flowPanel1, 0, 0);
            this.tbPanelMain.Controls.Add(this.tbPanelBottom, 0, 1);
            this.tbPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tbPanelMain.Name = "tbPanelMain";
            this.tbPanelMain.RowCount = 2;
            this.tbPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tbPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tbPanelMain.Size = new System.Drawing.Size(1650, 160);
            this.tbPanelMain.TabIndex = 13;
            // 
            // tbPanel1
            // 
            this.tbPanel1.AutoSize = true;
            this.tbPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel1.ColumnCount = 1;
            this.tbPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel1.Controls.Add(this.tbSurename, 0, 1);
            this.tbPanel1.Controls.Add(this.lblSurename, 0, 0);
            this.tbPanel1.Location = new System.Drawing.Point(3, 3);
            this.tbPanel1.Name = "tbPanel1";
            this.tbPanel1.RowCount = 3;
            this.tbPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbPanel1.Size = new System.Drawing.Size(206, 65);
            this.tbPanel1.TabIndex = 14;
            // 
            // tbPanel2
            // 
            this.tbPanel2.AutoSize = true;
            this.tbPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel2.ColumnCount = 1;
            this.tbPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel2.Controls.Add(this.lblFirstname, 0, 0);
            this.tbPanel2.Controls.Add(this.tbFirstname, 0, 1);
            this.tbPanel2.Location = new System.Drawing.Point(215, 3);
            this.tbPanel2.Name = "tbPanel2";
            this.tbPanel2.RowCount = 2;
            this.tbPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel2.Size = new System.Drawing.Size(206, 45);
            this.tbPanel2.TabIndex = 15;
            // 
            // tbPanel3
            // 
            this.tbPanel3.AutoSize = true;
            this.tbPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel3.ColumnCount = 1;
            this.tbPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel3.Controls.Add(this.lblLastname, 0, 0);
            this.tbPanel3.Controls.Add(this.tbLastname, 0, 1);
            this.tbPanel3.Location = new System.Drawing.Point(427, 3);
            this.tbPanel3.Name = "tbPanel3";
            this.tbPanel3.RowCount = 2;
            this.tbPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel3.Size = new System.Drawing.Size(206, 45);
            this.tbPanel3.TabIndex = 16;
            // 
            // tbPanel4
            // 
            this.tbPanel4.AutoSize = true;
            this.tbPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel4.ColumnCount = 1;
            this.tbPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel4.Controls.Add(this.lblPost, 0, 0);
            this.tbPanel4.Controls.Add(this.tbPost, 0, 1);
            this.tbPanel4.Location = new System.Drawing.Point(639, 3);
            this.tbPanel4.Name = "tbPanel4";
            this.tbPanel4.RowCount = 2;
            this.tbPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbPanel4.Size = new System.Drawing.Size(206, 45);
            this.tbPanel4.TabIndex = 17;
            // 
            // tbPanel5
            // 
            this.tbPanel5.AutoSize = true;
            this.tbPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel5.ColumnCount = 1;
            this.tbPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel5.Controls.Add(this.lblDepartment, 0, 0);
            this.tbPanel5.Controls.Add(this.tbDepartment, 0, 1);
            this.tbPanel5.Location = new System.Drawing.Point(851, 3);
            this.tbPanel5.Name = "tbPanel5";
            this.tbPanel5.RowCount = 3;
            this.tbPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbPanel5.Size = new System.Drawing.Size(206, 65);
            this.tbPanel5.TabIndex = 18;
            // 
            // flowPanel1
            // 
            this.flowPanel1.AutoScroll = true;
            this.flowPanel1.Controls.Add(this.tbPanel1);
            this.flowPanel1.Controls.Add(this.tbPanel2);
            this.flowPanel1.Controls.Add(this.tbPanel3);
            this.flowPanel1.Controls.Add(this.tbPanel4);
            this.flowPanel1.Controls.Add(this.tbPanel5);
            this.flowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowPanel1.Name = "flowPanel1";
            this.flowPanel1.Size = new System.Drawing.Size(1644, 98);
            this.flowPanel1.TabIndex = 19;
            // 
            // tbPanelBottom
            // 
            this.tbPanelBottom.ColumnCount = 3;
            this.tbPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanelBottom.Controls.Add(this.btnFilter, 0, 0);
            this.tbPanelBottom.Controls.Add(this.btnClear, 1, 0);
            this.tbPanelBottom.Controls.Add(this.btnClose, 2, 0);
            this.tbPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbPanelBottom.Location = new System.Drawing.Point(10, 115);
            this.tbPanelBottom.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.tbPanelBottom.Name = "tbPanelBottom";
            this.tbPanelBottom.RowCount = 1;
            this.tbPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanelBottom.Size = new System.Drawing.Size(1630, 42);
            this.tbPanelBottom.TabIndex = 14;
            // 
            // EmployeeFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1650, 160);
            this.Controls.Add(this.tbPanelMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeFilter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск сотрудника";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeFilter_FormClosing);
            this.tbPanelMain.ResumeLayout(false);
            this.tbPanel1.ResumeLayout(false);
            this.tbPanel1.PerformLayout();
            this.tbPanel2.ResumeLayout(false);
            this.tbPanel2.PerformLayout();
            this.tbPanel3.ResumeLayout(false);
            this.tbPanel3.PerformLayout();
            this.tbPanel4.ResumeLayout(false);
            this.tbPanel4.PerformLayout();
            this.tbPanel5.ResumeLayout(false);
            this.tbPanel5.PerformLayout();
            this.flowPanel1.ResumeLayout(false);
            this.flowPanel1.PerformLayout();
            this.tbPanelBottom.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tbPanelMain;
        private System.Windows.Forms.TableLayoutPanel tbPanel1;
        private System.Windows.Forms.TableLayoutPanel tbPanel2;
        private System.Windows.Forms.TableLayoutPanel tbPanel3;
        private System.Windows.Forms.TableLayoutPanel tbPanel4;
        private System.Windows.Forms.TableLayoutPanel tbPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowPanel1;
        private System.Windows.Forms.TableLayoutPanel tbPanelBottom;
    }
}
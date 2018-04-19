namespace NeuroInventory
{
    partial class ProvidersFilter
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
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblDocument = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.tbDocument = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbINN = new System.Windows.Forms.TextBox();
            this.lblINN = new System.Windows.Forms.Label();
            this.tbPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.flowPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tbPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tbPanel1.SuspendLayout();
            this.tbPanel2.SuspendLayout();
            this.tbPanel3.SuspendLayout();
            this.tbPanel4.SuspendLayout();
            this.tbPanel5.SuspendLayout();
            this.tbPanel6.SuspendLayout();
            this.flowPanel1.SuspendLayout();
            this.tbPanelBottom.SuspendLayout();
            this.tbPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Silver;
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Location = new System.Drawing.Point(3, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(200, 17);
            this.lblAddress.TabIndex = 0;
            this.lblAddress.Text = "Адрес";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Silver;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(200, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Название";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Silver;
            this.lblPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhone.Location = new System.Drawing.Point(3, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(200, 17);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Телефон";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMail.Location = new System.Drawing.Point(3, 0);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(200, 17);
            this.lblMail.TabIndex = 3;
            this.lblMail.Text = "Эл. почта";
            // 
            // lblDocument
            // 
            this.lblDocument.AutoSize = true;
            this.lblDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDocument.Location = new System.Drawing.Point(3, 0);
            this.lblDocument.Name = "lblDocument";
            this.lblDocument.Size = new System.Drawing.Size(200, 17);
            this.lblDocument.TabIndex = 4;
            this.lblDocument.Text = "Документ";
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(3, 20);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 22);
            this.tbName.TabIndex = 5;
            this.tbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSurename_KeyPress);
            // 
            // tbAddress
            // 
            this.tbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAddress.Location = new System.Drawing.Point(3, 20);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(200, 22);
            this.tbAddress.TabIndex = 6;
            this.tbAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstname_KeyPress);
            // 
            // tbPhone
            // 
            this.tbPhone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPhone.Location = new System.Drawing.Point(3, 20);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(200, 22);
            this.tbPhone.TabIndex = 7;
            this.tbPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLastname_KeyPress);
            // 
            // tbMail
            // 
            this.tbMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMail.Location = new System.Drawing.Point(3, 20);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(200, 22);
            this.tbMail.TabIndex = 8;
            this.tbMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPost_KeyPress);
            // 
            // tbDocument
            // 
            this.tbDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDocument.Location = new System.Drawing.Point(3, 20);
            this.tbDocument.Name = "tbDocument";
            this.tbDocument.Size = new System.Drawing.Size(200, 22);
            this.tbDocument.TabIndex = 9;
            this.tbDocument.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDepartment_KeyPress);
            // 
            // btnFilter
            // 
            this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilter.Location = new System.Drawing.Point(10, 3);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
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
            this.btnClear.Location = new System.Drawing.Point(128, 3);
            this.btnClear.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
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
            this.btnClose.Location = new System.Drawing.Point(246, 3);
            this.btnClose.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 29);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Скрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbINN
            // 
            this.tbINN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbINN.Location = new System.Drawing.Point(3, 20);
            this.tbINN.MaxLength = 12;
            this.tbINN.Name = "tbINN";
            this.tbINN.Size = new System.Drawing.Size(200, 22);
            this.tbINN.TabIndex = 14;
            this.tbINN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbINN_KeyPress);
            // 
            // lblINN
            // 
            this.lblINN.AutoSize = true;
            this.lblINN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblINN.Location = new System.Drawing.Point(3, 0);
            this.lblINN.Name = "lblINN";
            this.lblINN.Size = new System.Drawing.Size(200, 17);
            this.lblINN.TabIndex = 13;
            this.lblINN.Text = "ИНН";
            // 
            // tbPanel1
            // 
            this.tbPanel1.AutoSize = true;
            this.tbPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel1.ColumnCount = 1;
            this.tbPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel1.Controls.Add(this.lblName, 0, 0);
            this.tbPanel1.Controls.Add(this.tbName, 0, 1);
            this.tbPanel1.Location = new System.Drawing.Point(3, 3);
            this.tbPanel1.Name = "tbPanel1";
            this.tbPanel1.RowCount = 2;
            this.tbPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel1.Size = new System.Drawing.Size(206, 45);
            this.tbPanel1.TabIndex = 15;
            // 
            // tbPanel2
            // 
            this.tbPanel2.AutoSize = true;
            this.tbPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel2.ColumnCount = 1;
            this.tbPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel2.Controls.Add(this.lblAddress, 0, 0);
            this.tbPanel2.Controls.Add(this.tbAddress, 0, 1);
            this.tbPanel2.Location = new System.Drawing.Point(215, 3);
            this.tbPanel2.Name = "tbPanel2";
            this.tbPanel2.RowCount = 2;
            this.tbPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel2.Size = new System.Drawing.Size(206, 45);
            this.tbPanel2.TabIndex = 16;
            // 
            // tbPanel3
            // 
            this.tbPanel3.AutoSize = true;
            this.tbPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel3.ColumnCount = 1;
            this.tbPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel3.Controls.Add(this.lblPhone, 0, 0);
            this.tbPanel3.Controls.Add(this.tbPhone, 0, 1);
            this.tbPanel3.Location = new System.Drawing.Point(427, 3);
            this.tbPanel3.Name = "tbPanel3";
            this.tbPanel3.RowCount = 2;
            this.tbPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel3.Size = new System.Drawing.Size(206, 45);
            this.tbPanel3.TabIndex = 17;
            // 
            // tbPanel4
            // 
            this.tbPanel4.AutoSize = true;
            this.tbPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel4.ColumnCount = 1;
            this.tbPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel4.Controls.Add(this.lblMail, 0, 0);
            this.tbPanel4.Controls.Add(this.tbMail, 0, 1);
            this.tbPanel4.Location = new System.Drawing.Point(639, 3);
            this.tbPanel4.Name = "tbPanel4";
            this.tbPanel4.RowCount = 2;
            this.tbPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel4.Size = new System.Drawing.Size(206, 45);
            this.tbPanel4.TabIndex = 18;
            // 
            // tbPanel5
            // 
            this.tbPanel5.AutoSize = true;
            this.tbPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel5.ColumnCount = 1;
            this.tbPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel5.Controls.Add(this.lblINN, 0, 0);
            this.tbPanel5.Controls.Add(this.tbINN, 0, 1);
            this.tbPanel5.Location = new System.Drawing.Point(851, 3);
            this.tbPanel5.Name = "tbPanel5";
            this.tbPanel5.RowCount = 2;
            this.tbPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel5.Size = new System.Drawing.Size(206, 45);
            this.tbPanel5.TabIndex = 19;
            // 
            // tbPanel6
            // 
            this.tbPanel6.AutoSize = true;
            this.tbPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbPanel6.ColumnCount = 1;
            this.tbPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tbPanel6.Controls.Add(this.lblDocument, 0, 0);
            this.tbPanel6.Controls.Add(this.tbDocument, 0, 1);
            this.tbPanel6.Location = new System.Drawing.Point(1063, 3);
            this.tbPanel6.Name = "tbPanel6";
            this.tbPanel6.RowCount = 2;
            this.tbPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanel6.Size = new System.Drawing.Size(206, 45);
            this.tbPanel6.TabIndex = 20;
            // 
            // flowPanel1
            // 
            this.flowPanel1.AutoScroll = true;
            this.flowPanel1.Controls.Add(this.tbPanel1);
            this.flowPanel1.Controls.Add(this.tbPanel2);
            this.flowPanel1.Controls.Add(this.tbPanel3);
            this.flowPanel1.Controls.Add(this.tbPanel4);
            this.flowPanel1.Controls.Add(this.tbPanel5);
            this.flowPanel1.Controls.Add(this.tbPanel6);
            this.flowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowPanel1.Name = "flowPanel1";
            this.flowPanel1.Size = new System.Drawing.Size(1644, 98);
            this.flowPanel1.TabIndex = 21;
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
            this.tbPanelBottom.Location = new System.Drawing.Point(3, 116);
            this.tbPanelBottom.Name = "tbPanelBottom";
            this.tbPanelBottom.RowCount = 1;
            this.tbPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tbPanelBottom.Size = new System.Drawing.Size(1644, 41);
            this.tbPanelBottom.TabIndex = 22;
            // 
            // tbPanelMain
            // 
            this.tbPanelMain.ColumnCount = 1;
            this.tbPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbPanelMain.Controls.Add(this.tbPanelBottom, 0, 1);
            this.tbPanelMain.Controls.Add(this.flowPanel1, 0, 0);
            this.tbPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tbPanelMain.Name = "tbPanelMain";
            this.tbPanelMain.RowCount = 2;
            this.tbPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tbPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tbPanelMain.Size = new System.Drawing.Size(1650, 160);
            this.tbPanelMain.TabIndex = 23;
            // 
            // ProvidersFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1650, 160);
            this.Controls.Add(this.tbPanelMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProvidersFilter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск сотрудника";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProvidersFilter_FormClosing);
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
            this.tbPanel6.ResumeLayout(false);
            this.tbPanel6.PerformLayout();
            this.flowPanel1.ResumeLayout(false);
            this.flowPanel1.PerformLayout();
            this.tbPanelBottom.ResumeLayout(false);
            this.tbPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblDocument;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.TextBox tbDocument;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbINN;
        private System.Windows.Forms.Label lblINN;
        private System.Windows.Forms.TableLayoutPanel tbPanel1;
        private System.Windows.Forms.TableLayoutPanel tbPanel2;
        private System.Windows.Forms.TableLayoutPanel tbPanel3;
        private System.Windows.Forms.TableLayoutPanel tbPanel4;
        private System.Windows.Forms.TableLayoutPanel tbPanel5;
        private System.Windows.Forms.TableLayoutPanel tbPanel6;
        private System.Windows.Forms.FlowLayoutPanel flowPanel1;
        private System.Windows.Forms.TableLayoutPanel tbPanelBottom;
        private System.Windows.Forms.TableLayoutPanel tbPanelMain;
    }
}
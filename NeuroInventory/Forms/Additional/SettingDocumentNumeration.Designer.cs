namespace NeuroInventory
{
    partial class SettingDocumentNumeration
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
            this.lblDemand = new System.Windows.Forms.Label();
            this.nudDemandNumeration = new System.Windows.Forms.NumericUpDown();
            this.tbDemandPrefix = new System.Windows.Forms.TextBox();
            this.lblDemandPrefix = new System.Windows.Forms.Label();
            this.cbDemandDate = new System.Windows.Forms.CheckBox();
            this.cbDebitDate = new System.Windows.Forms.CheckBox();
            this.lblDebitPrefix = new System.Windows.Forms.Label();
            this.tbDebitPrefix = new System.Windows.Forms.TextBox();
            this.nudDebitNumeration = new System.Windows.Forms.NumericUpDown();
            this.lblDebit = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDemandNumeration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDebitNumeration)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDemand
            // 
            this.lblDemand.AutoSize = true;
            this.lblDemand.Location = new System.Drawing.Point(34, 40);
            this.lblDemand.Name = "lblDemand";
            this.lblDemand.Size = new System.Drawing.Size(336, 17);
            this.lblDemand.TabIndex = 0;
            this.lblDemand.Text = "Продолжить нумерацию требования-накладной с";
            // 
            // nudDemandNumeration
            // 
            this.nudDemandNumeration.Location = new System.Drawing.Point(376, 38);
            this.nudDemandNumeration.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudDemandNumeration.Name = "nudDemandNumeration";
            this.nudDemandNumeration.Size = new System.Drawing.Size(120, 22);
            this.nudDemandNumeration.TabIndex = 1;
            this.nudDemandNumeration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbDemandPrefix
            // 
            this.tbDemandPrefix.Location = new System.Drawing.Point(376, 66);
            this.tbDemandPrefix.Name = "tbDemandPrefix";
            this.tbDemandPrefix.Size = new System.Drawing.Size(120, 22);
            this.tbDemandPrefix.TabIndex = 2;
            // 
            // lblDemandPrefix
            // 
            this.lblDemandPrefix.AutoSize = true;
            this.lblDemandPrefix.Location = new System.Drawing.Point(303, 69);
            this.lblDemandPrefix.Name = "lblDemandPrefix";
            this.lblDemandPrefix.Size = new System.Drawing.Size(67, 17);
            this.lblDemandPrefix.TabIndex = 3;
            this.lblDemandPrefix.Text = "Префикс";
            // 
            // cbDemandDate
            // 
            this.cbDemandDate.AutoSize = true;
            this.cbDemandDate.Location = new System.Drawing.Point(376, 94);
            this.cbDemandDate.Name = "cbDemandDate";
            this.cbDemandDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbDemandDate.Size = new System.Drawing.Size(128, 21);
            this.cbDemandDate.TabIndex = 4;
            this.cbDemandDate.Text = "Включить дату";
            this.cbDemandDate.UseVisualStyleBackColor = true;
            // 
            // cbDebitDate
            // 
            this.cbDebitDate.AutoSize = true;
            this.cbDebitDate.Location = new System.Drawing.Point(376, 209);
            this.cbDebitDate.Name = "cbDebitDate";
            this.cbDebitDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbDebitDate.Size = new System.Drawing.Size(128, 21);
            this.cbDebitDate.TabIndex = 9;
            this.cbDebitDate.Text = "Включить дату";
            this.cbDebitDate.UseVisualStyleBackColor = true;
            // 
            // lblDebitPrefix
            // 
            this.lblDebitPrefix.AutoSize = true;
            this.lblDebitPrefix.Location = new System.Drawing.Point(303, 184);
            this.lblDebitPrefix.Name = "lblDebitPrefix";
            this.lblDebitPrefix.Size = new System.Drawing.Size(67, 17);
            this.lblDebitPrefix.TabIndex = 8;
            this.lblDebitPrefix.Text = "Префикс";
            // 
            // tbDebitPrefix
            // 
            this.tbDebitPrefix.Location = new System.Drawing.Point(376, 181);
            this.tbDebitPrefix.Name = "tbDebitPrefix";
            this.tbDebitPrefix.Size = new System.Drawing.Size(120, 22);
            this.tbDebitPrefix.TabIndex = 7;
            // 
            // nudDebitNumeration
            // 
            this.nudDebitNumeration.Location = new System.Drawing.Point(376, 153);
            this.nudDebitNumeration.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudDebitNumeration.Name = "nudDebitNumeration";
            this.nudDebitNumeration.Size = new System.Drawing.Size(120, 22);
            this.nudDebitNumeration.TabIndex = 6;
            this.nudDebitNumeration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDebit
            // 
            this.lblDebit.AutoSize = true;
            this.lblDebit.Location = new System.Drawing.Point(126, 155);
            this.lblDebit.Name = "lblDebit";
            this.lblDebit.Size = new System.Drawing.Size(244, 17);
            this.lblDebit.TabIndex = 5;
            this.lblDebit.Text = "Продолжить нумерацию списания с";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(383, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 28);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Location = new System.Drawing.Point(170, 276);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(113, 28);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SettingDocumentNumeration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(572, 330);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbDebitDate);
            this.Controls.Add(this.lblDebitPrefix);
            this.Controls.Add(this.tbDebitPrefix);
            this.Controls.Add(this.nudDebitNumeration);
            this.Controls.Add(this.lblDebit);
            this.Controls.Add(this.cbDemandDate);
            this.Controls.Add(this.lblDemandPrefix);
            this.Controls.Add(this.tbDemandPrefix);
            this.Controls.Add(this.nudDemandNumeration);
            this.Controls.Add(this.lblDemand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SettingDocumentNumeration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройка нумерации документов";
            this.Load += new System.EventHandler(this.SettingDocumentNumeration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDemandNumeration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDebitNumeration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDemand;
        private System.Windows.Forms.NumericUpDown nudDemandNumeration;
        private System.Windows.Forms.TextBox tbDemandPrefix;
        private System.Windows.Forms.Label lblDemandPrefix;
        private System.Windows.Forms.CheckBox cbDemandDate;
        private System.Windows.Forms.CheckBox cbDebitDate;
        private System.Windows.Forms.Label lblDebitPrefix;
        private System.Windows.Forms.TextBox tbDebitPrefix;
        private System.Windows.Forms.NumericUpDown nudDebitNumeration;
        private System.Windows.Forms.Label lblDebit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
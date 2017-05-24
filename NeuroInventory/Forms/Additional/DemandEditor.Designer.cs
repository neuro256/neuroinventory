namespace NeuroInventory
{
    partial class DemandEditor
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
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lblDemand = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.splitContainerDemand = new System.Windows.Forms.SplitContainer();
            this.lwDemand = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEmployee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDemand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEdit = new System.Windows.Forms.Button();
            this.contextMenuStripDemand = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnLink = new System.Windows.Forms.Button();
            this.tbLink = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDemand)).BeginInit();
            this.splitContainerDemand.Panel1.SuspendLayout();
            this.splitContainerDemand.Panel2.SuspendLayout();
            this.splitContainerDemand.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(45, 27);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(78, 17);
            this.lblEmployee.TabIndex = 0;
            this.lblEmployee.Text = "Сотрудник";
            // 
            // cbEmployee
            // 
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(129, 24);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(274, 24);
            this.cbEmployee.TabIndex = 1;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(18, 67);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(204, 17);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "Количество отпущенного тмц";
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(228, 65);
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(175, 22);
            this.nudAmount.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(180, 114);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 17);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Дата";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(228, 109);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(175, 22);
            this.dateTimePicker.TabIndex = 5;
            // 
            // lblDemand
            // 
            this.lblDemand.AutoSize = true;
            this.lblDemand.Location = new System.Drawing.Point(35, 160);
            this.lblDemand.Name = "lblDemand";
            this.lblDemand.Size = new System.Drawing.Size(88, 17);
            this.lblDemand.TabIndex = 6;
            this.lblDemand.Text = "Требование";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(240, 185);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 29);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(305, 564);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 29);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(57, 564);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 29);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splitContainerDemand
            // 
            this.splitContainerDemand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDemand.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDemand.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerDemand.Name = "splitContainerDemand";
            // 
            // splitContainerDemand.Panel1
            // 
            this.splitContainerDemand.Panel1.Controls.Add(this.lwDemand);
            // 
            // splitContainerDemand.Panel2
            // 
            this.splitContainerDemand.Panel2.AutoScroll = true;
            this.splitContainerDemand.Panel2.BackColor = System.Drawing.Color.Silver;
            this.splitContainerDemand.Panel2.Controls.Add(this.tbLink);
            this.splitContainerDemand.Panel2.Controls.Add(this.btnLink);
            this.splitContainerDemand.Panel2.Controls.Add(this.btnEdit);
            this.splitContainerDemand.Panel2.Controls.Add(this.lblEmployee);
            this.splitContainerDemand.Panel2.Controls.Add(this.btnDelete);
            this.splitContainerDemand.Panel2.Controls.Add(this.cbEmployee);
            this.splitContainerDemand.Panel2.Controls.Add(this.btnAdd);
            this.splitContainerDemand.Panel2.Controls.Add(this.lblAmount);
            this.splitContainerDemand.Panel2.Controls.Add(this.btnClear);
            this.splitContainerDemand.Panel2.Controls.Add(this.nudAmount);
            this.splitContainerDemand.Panel2.Controls.Add(this.lblDate);
            this.splitContainerDemand.Panel2.Controls.Add(this.lblDemand);
            this.splitContainerDemand.Panel2.Controls.Add(this.dateTimePicker);
            this.splitContainerDemand.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainerDemand.Size = new System.Drawing.Size(1182, 605);
            this.splitContainerDemand.SplitterDistance = 750;
            this.splitContainerDemand.TabIndex = 14;
            // 
            // lwDemand
            // 
            this.lwDemand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lwDemand.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chNumber,
            this.chEmployee,
            this.chAmount,
            this.chDate,
            this.chDemand});
            this.lwDemand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwDemand.FullRowSelect = true;
            this.lwDemand.GridLines = true;
            this.lwDemand.Location = new System.Drawing.Point(0, 0);
            this.lwDemand.Margin = new System.Windows.Forms.Padding(0);
            this.lwDemand.MultiSelect = false;
            this.lwDemand.Name = "lwDemand";
            this.lwDemand.Size = new System.Drawing.Size(750, 605);
            this.lwDemand.TabIndex = 0;
            this.lwDemand.UseCompatibleStateImageBehavior = false;
            this.lwDemand.View = System.Windows.Forms.View.Details;
            // 
            // chId
            // 
            this.chId.Text = "id";
            // 
            // chNumber
            // 
            this.chNumber.Text = "№";
            // 
            // chEmployee
            // 
            this.chEmployee.Text = "Сотрудник";
            this.chEmployee.Width = 200;
            // 
            // chAmount
            // 
            this.chAmount.Text = "Количество";
            this.chAmount.Width = 100;
            // 
            // chDate
            // 
            this.chDate.Text = "Дата";
            this.chDate.Width = 100;
            // 
            // chDemand
            // 
            this.chDemand.Text = "Требование";
            this.chDemand.Width = 200;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(183, 564);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 29);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // contextMenuStripDemand
            // 
            this.contextMenuStripDemand.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripDemand.Name = "contextMenuStripDemand";
            this.contextMenuStripDemand.Size = new System.Drawing.Size(67, 4);
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(129, 185);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(105, 29);
            this.btnLink.TabIndex = 15;
            this.btnLink.Text = "Обзор";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // tbLink
            // 
            this.tbLink.Location = new System.Drawing.Point(129, 157);
            this.tbLink.Name = "tbLink";
            this.tbLink.ReadOnly = true;
            this.tbLink.Size = new System.Drawing.Size(274, 22);
            this.tbLink.TabIndex = 16;
            // 
            // DemandEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1182, 605);
            this.Controls.Add(this.splitContainerDemand);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DemandEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор требований";
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.splitContainerDemand.Panel1.ResumeLayout(false);
            this.splitContainerDemand.Panel2.ResumeLayout(false);
            this.splitContainerDemand.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDemand)).EndInit();
            this.splitContainerDemand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label lblDemand;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.SplitContainer splitContainerDemand;
        private System.Windows.Forms.ListView lwDemand;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chEmployee;
        private System.Windows.Forms.ColumnHeader chAmount;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chDemand;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDemand;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox tbLink;
        private System.Windows.Forms.Button btnLink;
    }
}
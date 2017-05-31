namespace NeuroInventory
{
    partial class DebitEditor
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
            this.lblAmount = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.lblDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.splitContainerDebit = new System.Windows.Forms.SplitContainer();
            this.lwDebit = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDebit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnCreateDebit = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.contextMenuStripDebit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.errorProviderDebit = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDebit)).BeginInit();
            this.splitContainerDebit.Panel1.SuspendLayout();
            this.splitContainerDebit.Panel2.SuspendLayout();
            this.splitContainerDebit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDebit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.LightCyan;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAmount.Location = new System.Drawing.Point(36, 32);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(188, 17);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "Количество списанных тмц";
            // 
            // nudAmount
            // 
            this.nudAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAmount.DecimalPlaces = 3;
            this.nudAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudAmount.Location = new System.Drawing.Point(230, 30);
            this.nudAmount.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(175, 22);
            this.nudAmount.TabIndex = 1;
            this.nudAmount.ThousandsSeparator = true;
            this.nudAmount.ValueChanged += new System.EventHandler(this.nudAmount_ValueChanged);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDate.Location = new System.Drawing.Point(182, 79);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 17);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Дата";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(230, 74);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(175, 22);
            this.dateTimePicker.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.Location = new System.Drawing.Point(305, 564);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 29);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(57, 564);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 29);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splitContainerDebit
            // 
            this.splitContainerDebit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDebit.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDebit.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerDebit.Name = "splitContainerDebit";
            // 
            // splitContainerDebit.Panel1
            // 
            this.splitContainerDebit.Panel1.Controls.Add(this.lwDebit);
            // 
            // splitContainerDebit.Panel2
            // 
            this.splitContainerDebit.Panel2.AutoScroll = true;
            this.splitContainerDebit.Panel2.BackColor = System.Drawing.Color.Silver;
            this.splitContainerDebit.Panel2.Controls.Add(this.btnOpenFolder);
            this.splitContainerDebit.Panel2.Controls.Add(this.btnCreateDebit);
            this.splitContainerDebit.Panel2.Controls.Add(this.btnEdit);
            this.splitContainerDebit.Panel2.Controls.Add(this.btnDelete);
            this.splitContainerDebit.Panel2.Controls.Add(this.btnAdd);
            this.splitContainerDebit.Panel2.Controls.Add(this.lblAmount);
            this.splitContainerDebit.Panel2.Controls.Add(this.nudAmount);
            this.splitContainerDebit.Panel2.Controls.Add(this.lblDate);
            this.splitContainerDebit.Panel2.Controls.Add(this.dateTimePicker);
            this.splitContainerDebit.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainerDebit.Size = new System.Drawing.Size(1182, 605);
            this.splitContainerDebit.SplitterDistance = 750;
            this.splitContainerDebit.TabIndex = 14;
            // 
            // lwDebit
            // 
            this.lwDebit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lwDebit.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chNumber,
            this.chAmount,
            this.chDate,
            this.chDebit});
            this.lwDebit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwDebit.FullRowSelect = true;
            this.lwDebit.GridLines = true;
            this.lwDebit.Location = new System.Drawing.Point(0, 0);
            this.lwDebit.Margin = new System.Windows.Forms.Padding(0);
            this.lwDebit.MultiSelect = false;
            this.lwDebit.Name = "lwDebit";
            this.lwDebit.Size = new System.Drawing.Size(750, 605);
            this.lwDebit.TabIndex = 0;
            this.lwDebit.UseCompatibleStateImageBehavior = false;
            this.lwDebit.View = System.Windows.Forms.View.Details;
            // 
            // chId
            // 
            this.chId.Text = "id";
            // 
            // chNumber
            // 
            this.chNumber.Text = "№";
            // 
            // chAmount
            // 
            this.chAmount.Text = "Количество списанного";
            this.chAmount.Width = 200;
            // 
            // chDate
            // 
            this.chDate.Text = "Дата";
            this.chDate.Width = 100;
            // 
            // chDebit
            // 
            this.chDebit.Text = "Списание";
            this.chDebit.Width = 200;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenFolder.Location = new System.Drawing.Point(150, 164);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(255, 29);
            this.btnOpenFolder.TabIndex = 4;
            this.btnOpenFolder.Text = "Открыть папку с документом";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnCreateDebit
            // 
            this.btnCreateDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateDebit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnCreateDebit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateDebit.Location = new System.Drawing.Point(150, 118);
            this.btnCreateDebit.Name = "btnCreateDebit";
            this.btnCreateDebit.Size = new System.Drawing.Size(255, 29);
            this.btnCreateDebit.TabIndex = 3;
            this.btnCreateDebit.Text = "Сформировать документ списания";
            this.btnCreateDebit.UseVisualStyleBackColor = true;
            this.btnCreateDebit.Click += new System.EventHandler(this.btnCreateDebit_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEdit.Location = new System.Drawing.Point(183, 564);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 29);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // contextMenuStripDebit
            // 
            this.contextMenuStripDebit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripDebit.Name = "contextMenuStripDemand";
            this.contextMenuStripDebit.Size = new System.Drawing.Size(67, 4);
            // 
            // errorProviderDebit
            // 
            this.errorProviderDebit.BlinkRate = 0;
            this.errorProviderDebit.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderDebit.ContainerControl = this;
            // 
            // DebitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1182, 605);
            this.Controls.Add(this.splitContainerDebit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "DebitEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор списаний";
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.splitContainerDebit.Panel1.ResumeLayout(false);
            this.splitContainerDebit.Panel2.ResumeLayout(false);
            this.splitContainerDebit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDebit)).EndInit();
            this.splitContainerDebit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDebit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.SplitContainer splitContainerDebit;
        private System.Windows.Forms.ListView lwDebit;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDebit;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCreateDebit;
        private System.Windows.Forms.ColumnHeader chAmount;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chDebit;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ErrorProvider errorProviderDebit;
    }
}
namespace NeuroInventory
{
    partial class MeasurementEditor
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
            this.nudOKEI = new System.Windows.Forms.NumericUpDown();
            this.lblName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.splitContainerMeasurement = new System.Windows.Forms.SplitContainer();
            this.lvMeasurement = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOKEIcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSymbol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblPlaces = new System.Windows.Forms.Label();
            this.nudPlaces = new System.Windows.Forms.NumericUpDown();
            this.tbSymbol = new System.Windows.Forms.TextBox();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.contextMenuStripMeasurement = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.errorProviderMeasurement = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudOKEI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMeasurement)).BeginInit();
            this.splitContainerMeasurement.Panel1.SuspendLayout();
            this.splitContainerMeasurement.Panel2.SuspendLayout();
            this.splitContainerMeasurement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPlaces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMeasurement)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.LightCyan;
            this.lblAmount.Location = new System.Drawing.Point(103, 33);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(76, 17);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "Код ОКЕИ";
            // 
            // nudOKEI
            // 
            this.nudOKEI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudOKEI.Location = new System.Drawing.Point(185, 31);
            this.nudOKEI.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudOKEI.Name = "nudOKEI";
            this.nudOKEI.Size = new System.Drawing.Size(175, 22);
            this.nudOKEI.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.LightCyan;
            this.lblName.Location = new System.Drawing.Point(107, 74);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(72, 17);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Название";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point(262, 269);
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
            this.btnAdd.Location = new System.Drawing.Point(14, 269);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 29);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // splitContainerMeasurement
            // 
            this.splitContainerMeasurement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMeasurement.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMeasurement.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerMeasurement.Name = "splitContainerMeasurement";
            // 
            // splitContainerMeasurement.Panel1
            // 
            this.splitContainerMeasurement.Panel1.Controls.Add(this.lvMeasurement);
            // 
            // splitContainerMeasurement.Panel2
            // 
            this.splitContainerMeasurement.Panel2.AutoScroll = true;
            this.splitContainerMeasurement.Panel2.BackColor = System.Drawing.Color.Silver;
            this.splitContainerMeasurement.Panel2.Controls.Add(this.lblPlaces);
            this.splitContainerMeasurement.Panel2.Controls.Add(this.nudPlaces);
            this.splitContainerMeasurement.Panel2.Controls.Add(this.tbSymbol);
            this.splitContainerMeasurement.Panel2.Controls.Add(this.lblSymbol);
            this.splitContainerMeasurement.Panel2.Controls.Add(this.tbName);
            this.splitContainerMeasurement.Panel2.Controls.Add(this.btnEdit);
            this.splitContainerMeasurement.Panel2.Controls.Add(this.btnDelete);
            this.splitContainerMeasurement.Panel2.Controls.Add(this.btnAdd);
            this.splitContainerMeasurement.Panel2.Controls.Add(this.lblAmount);
            this.splitContainerMeasurement.Panel2.Controls.Add(this.nudOKEI);
            this.splitContainerMeasurement.Panel2.Controls.Add(this.lblName);
            this.splitContainerMeasurement.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainerMeasurement.Size = new System.Drawing.Size(1062, 310);
            this.splitContainerMeasurement.SplitterDistance = 673;
            this.splitContainerMeasurement.TabIndex = 14;
            // 
            // lvMeasurement
            // 
            this.lvMeasurement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMeasurement.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chNumber,
            this.chOKEIcode,
            this.chName,
            this.chSymbol});
            this.lvMeasurement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMeasurement.FullRowSelect = true;
            this.lvMeasurement.GridLines = true;
            this.lvMeasurement.Location = new System.Drawing.Point(0, 0);
            this.lvMeasurement.Margin = new System.Windows.Forms.Padding(0);
            this.lvMeasurement.MultiSelect = false;
            this.lvMeasurement.Name = "lvMeasurement";
            this.lvMeasurement.Size = new System.Drawing.Size(673, 310);
            this.lvMeasurement.TabIndex = 0;
            this.lvMeasurement.UseCompatibleStateImageBehavior = false;
            this.lvMeasurement.View = System.Windows.Forms.View.Details;
            this.lvMeasurement.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.lvMeasurement_ColumnWidthChanged);
            // 
            // chId
            // 
            this.chId.Text = "id";
            // 
            // chNumber
            // 
            this.chNumber.Text = "№";
            // 
            // chOKEIcode
            // 
            this.chOKEIcode.Text = "код ОКЕИ";
            this.chOKEIcode.Width = 80;
            // 
            // chName
            // 
            this.chName.Text = "Наименование";
            this.chName.Width = 200;
            // 
            // chSymbol
            // 
            this.chSymbol.Text = "Условное обозначение";
            this.chSymbol.Width = 200;
            // 
            // lblPlaces
            // 
            this.lblPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlaces.AutoSize = true;
            this.lblPlaces.BackColor = System.Drawing.Color.LightCyan;
            this.lblPlaces.Location = new System.Drawing.Point(27, 159);
            this.lblPlaces.Name = "lblPlaces";
            this.lblPlaces.Size = new System.Drawing.Size(152, 17);
            this.lblPlaces.TabIndex = 12;
            this.lblPlaces.Text = "Десятичные разряды";
            // 
            // nudPlaces
            // 
            this.nudPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPlaces.Location = new System.Drawing.Point(185, 157);
            this.nudPlaces.Name = "nudPlaces";
            this.nudPlaces.Size = new System.Drawing.Size(175, 22);
            this.nudPlaces.TabIndex = 4;
            // 
            // tbSymbol
            // 
            this.tbSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSymbol.Location = new System.Drawing.Point(185, 113);
            this.tbSymbol.Name = "tbSymbol";
            this.tbSymbol.Size = new System.Drawing.Size(175, 22);
            this.tbSymbol.TabIndex = 3;
            this.tbSymbol.TextChanged += new System.EventHandler(this.tbSymbol_TextChanged);
            // 
            // lblSymbol
            // 
            this.lblSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.BackColor = System.Drawing.Color.LightCyan;
            this.lblSymbol.Location = new System.Drawing.Point(17, 116);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(162, 17);
            this.lblSymbol.TabIndex = 10;
            this.lblSymbol.Text = "Условное обозначение";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(185, 71);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(175, 22);
            this.tbName.TabIndex = 2;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Location = new System.Drawing.Point(140, 269);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 29);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // contextMenuStripMeasurement
            // 
            this.contextMenuStripMeasurement.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripMeasurement.Name = "contextMenuStripDemand";
            this.contextMenuStripMeasurement.Size = new System.Drawing.Size(61, 4);
            // 
            // errorProviderMeasurement
            // 
            this.errorProviderMeasurement.BlinkRate = 0;
            this.errorProviderMeasurement.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderMeasurement.ContainerControl = this;
            // 
            // MeasurementEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1062, 310);
            this.Controls.Add(this.splitContainerMeasurement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MeasurementEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор единиц измерения";
            ((System.ComponentModel.ISupportInitialize)(this.nudOKEI)).EndInit();
            this.splitContainerMeasurement.Panel1.ResumeLayout(false);
            this.splitContainerMeasurement.Panel2.ResumeLayout(false);
            this.splitContainerMeasurement.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMeasurement)).EndInit();
            this.splitContainerMeasurement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPlaces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMeasurement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown nudOKEI;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.SplitContainer splitContainerMeasurement;
        private System.Windows.Forms.ListView lvMeasurement;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMeasurement;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ColumnHeader chOKEIcode;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chSymbol;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblPlaces;
        private System.Windows.Forms.NumericUpDown nudPlaces;
        private System.Windows.Forms.TextBox tbSymbol;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.ErrorProvider errorProviderMeasurement;
    }
}
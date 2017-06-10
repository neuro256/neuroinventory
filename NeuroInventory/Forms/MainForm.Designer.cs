namespace NeuroInventory
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.единицыИзмеренияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tabProviders = new System.Windows.Forms.TabPage();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCreateBD = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenBD = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveBD = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDemandReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDebitReport = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabInventory.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.viewMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1262, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createBDToolStripMenuItem,
            this.openBDToolStripMenuItem,
            this.saveBDToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(57, 24);
            this.fileMenu.Text = "&Файл";
            // 
            // createBDToolStripMenuItem
            // 
            this.createBDToolStripMenuItem.Image = global::NeuroInventory.Properties.Resources.db_add_32;
            this.createBDToolStripMenuItem.Name = "createBDToolStripMenuItem";
            this.createBDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.createBDToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.createBDToolStripMenuItem.Text = "Создать БД";
            this.createBDToolStripMenuItem.Click += new System.EventHandler(this.createBDToolStripMenuItem_Click);
            // 
            // openBDToolStripMenuItem
            // 
            this.openBDToolStripMenuItem.Image = global::NeuroInventory.Properties.Resources.db_down_32;
            this.openBDToolStripMenuItem.Name = "openBDToolStripMenuItem";
            this.openBDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openBDToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.openBDToolStripMenuItem.Text = "Открыть";
            this.openBDToolStripMenuItem.Click += new System.EventHandler(this.openBDToolStripMenuItem_Click);
            // 
            // saveBDToolStripMenuItem
            // 
            this.saveBDToolStripMenuItem.Image = global::NeuroInventory.Properties.Resources.save_32;
            this.saveBDToolStripMenuItem.Name = "saveBDToolStripMenuItem";
            this.saveBDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveBDToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.saveBDToolStripMenuItem.Text = "Сохранить БД как...";
            this.saveBDToolStripMenuItem.Click += new System.EventHandler(this.saveBDToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::NeuroInventory.Properties.Resources.close_32;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.единицыИзмеренияToolStripMenuItem,
            this.настройкиПользователяToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(102, 24);
            this.viewMenu.Text = "&Параметры";
            // 
            // единицыИзмеренияToolStripMenuItem
            // 
            this.единицыИзмеренияToolStripMenuItem.Name = "единицыИзмеренияToolStripMenuItem";
            this.единицыИзмеренияToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.единицыИзмеренияToolStripMenuItem.Size = new System.Drawing.Size(311, 26);
            this.единицыИзмеренияToolStripMenuItem.Text = "Единицы измерения";
            this.единицыИзмеренияToolStripMenuItem.Click += new System.EventHandler(this.единицыИзмеренияToolStripMenuItem_Click);
            // 
            // настройкиПользователяToolStripMenuItem
            // 
            this.настройкиПользователяToolStripMenuItem.Image = global::NeuroInventory.Properties.Resources.user_add_32;
            this.настройкиПользователяToolStripMenuItem.Name = "настройкиПользователяToolStripMenuItem";
            this.настройкиПользователяToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.настройкиПользователяToolStripMenuItem.Size = new System.Drawing.Size(311, 26);
            this.настройкиПользователяToolStripMenuItem.Text = "Настройки пользователя";
            this.настройкиПользователяToolStripMenuItem.Click += new System.EventHandler(this.настройкиПользователяToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabInventory);
            this.tabControl.Controls.Add(this.tabProviders);
            this.tabControl.Controls.Add(this.tabEmployees);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.Location = new System.Drawing.Point(0, 55);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1262, 700);
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabInventory
            // 
            this.tabInventory.Controls.Add(this.lblInfo);
            this.tabInventory.Location = new System.Drawing.Point(4, 27);
            this.tabInventory.Margin = new System.Windows.Forms.Padding(0);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Size = new System.Drawing.Size(1254, 669);
            this.tabInventory.TabIndex = 0;
            this.tabInventory.Text = "ТМЦ";
            this.tabInventory.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lblInfo.Location = new System.Drawing.Point(311, 304);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(662, 29);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Для начала работы создайте или откройте базу данных";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabProviders
            // 
            this.tabProviders.Location = new System.Drawing.Point(4, 27);
            this.tabProviders.Margin = new System.Windows.Forms.Padding(0);
            this.tabProviders.Name = "tabProviders";
            this.tabProviders.Size = new System.Drawing.Size(1254, 669);
            this.tabProviders.TabIndex = 1;
            this.tabProviders.Text = "Поставщики";
            this.tabProviders.UseVisualStyleBackColor = true;
            // 
            // tabEmployees
            // 
            this.tabEmployees.Location = new System.Drawing.Point(4, 27);
            this.tabEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Size = new System.Drawing.Size(1254, 669);
            this.tabEmployees.TabIndex = 2;
            this.tabEmployees.Text = "Работники";
            this.tabEmployees.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCreateBD,
            this.toolStripButtonOpenBD,
            this.toolStripButtonSaveBD,
            this.toolStripSeparator1,
            this.toolStripButtonDebitReport,
            this.toolStripButtonDemandReport});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1262, 27);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripButtonCreateBD
            // 
            this.toolStripButtonCreateBD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCreateBD.Image = global::NeuroInventory.Properties.Resources.db_add_32;
            this.toolStripButtonCreateBD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCreateBD.Name = "toolStripButtonCreateBD";
            this.toolStripButtonCreateBD.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonCreateBD.Text = "toolStripButtonCreateBD";
            this.toolStripButtonCreateBD.Click += new System.EventHandler(this.toolStripButtonCreateBD_Click);
            // 
            // toolStripButtonOpenBD
            // 
            this.toolStripButtonOpenBD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenBD.Image = global::NeuroInventory.Properties.Resources.db_down_32;
            this.toolStripButtonOpenBD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenBD.Name = "toolStripButtonOpenBD";
            this.toolStripButtonOpenBD.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonOpenBD.Text = "toolStripButtonOpenBD";
            this.toolStripButtonOpenBD.Click += new System.EventHandler(this.toolStripButtonOpenBD_Click);
            // 
            // toolStripButtonSaveBD
            // 
            this.toolStripButtonSaveBD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveBD.Image = global::NeuroInventory.Properties.Resources.save_32;
            this.toolStripButtonSaveBD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveBD.Name = "toolStripButtonSaveBD";
            this.toolStripButtonSaveBD.Size = new System.Drawing.Size(24, 24);
            this.toolStripButtonSaveBD.Text = "toolStripButtonSaveBD";
            this.toolStripButtonSaveBD.Click += new System.EventHandler(this.toolStripButtonSaveBD_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonDemandReport
            // 
            this.toolStripButtonDemandReport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDemandReport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDemandReport.Image")));
            this.toolStripButtonDemandReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDemandReport.Name = "toolStripButtonDemandReport";
            this.toolStripButtonDemandReport.Size = new System.Drawing.Size(257, 24);
            this.toolStripButtonDemandReport.Text = "Создать требование-накладную";
            this.toolStripButtonDemandReport.Click += new System.EventHandler(this.toolStripButtonDemandReport_Click);
            // 
            // toolStripButtonDebitReport
            // 
            this.toolStripButtonDebitReport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDebitReport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDebitReport.Image")));
            this.toolStripButtonDebitReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDebitReport.Name = "toolStripButtonDebitReport";
            this.toolStripButtonDebitReport.Size = new System.Drawing.Size(158, 24);
            this.toolStripButtonDebitReport.Text = "Создать списание";
            this.toolStripButtonDebitReport.Click += new System.EventHandler(this.toolStripButtonDebitReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1262, 755);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Склад товарно-материальных ценностей";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabInventory.ResumeLayout(false);
            this.tabInventory.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem createBDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBDToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.TabPage tabProviders;
        private System.Windows.Forms.TabPage tabEmployees;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem openBDToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonCreateBD;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenBD;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveBD;
        private System.Windows.Forms.ToolStripMenuItem единицыИзмеренияToolStripMenuItem;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ToolStripMenuItem настройкиПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDemandReport;
        private System.Windows.Forms.ToolStripButton toolStripButtonDebitReport;
    }
}


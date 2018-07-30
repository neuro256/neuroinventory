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
            this.paramsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.единицыИзмеренияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаНумерацииДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.tabReleased = new System.Windows.Forms.TabPage();
            this.tabProviders = new System.Windows.Forms.TabPage();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDebitReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDemandReport = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.paramsMenu,
            this.справкаToolStripMenuItem});
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
            this.createBDToolStripMenuItem.Click += new System.EventHandler(this.CreateBDToolStripMenuItem_Click);
            // 
            // openBDToolStripMenuItem
            // 
            this.openBDToolStripMenuItem.Image = global::NeuroInventory.Properties.Resources.db_down_32;
            this.openBDToolStripMenuItem.Name = "openBDToolStripMenuItem";
            this.openBDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openBDToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.openBDToolStripMenuItem.Text = "Открыть";
            this.openBDToolStripMenuItem.Click += new System.EventHandler(this.OpenBDToolStripMenuItem_Click);
            // 
            // saveBDToolStripMenuItem
            // 
            this.saveBDToolStripMenuItem.Image = global::NeuroInventory.Properties.Resources.save_32;
            this.saveBDToolStripMenuItem.Name = "saveBDToolStripMenuItem";
            this.saveBDToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveBDToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.saveBDToolStripMenuItem.Text = "Сохранить БД как...";
            this.saveBDToolStripMenuItem.Click += new System.EventHandler(this.SaveBDToolStripMenuItem_Click);
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
            // paramsMenu
            // 
            this.paramsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.единицыИзмеренияToolStripMenuItem,
            this.настройкиПользователяToolStripMenuItem,
            this.настройкаНумерацииДокументовToolStripMenuItem});
            this.paramsMenu.Name = "paramsMenu";
            this.paramsMenu.Size = new System.Drawing.Size(102, 24);
            this.paramsMenu.Text = "&Параметры";
            // 
            // единицыИзмеренияToolStripMenuItem
            // 
            this.единицыИзмеренияToolStripMenuItem.Name = "единицыИзмеренияToolStripMenuItem";
            this.единицыИзмеренияToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.единицыИзмеренияToolStripMenuItem.Size = new System.Drawing.Size(327, 26);
            this.единицыИзмеренияToolStripMenuItem.Text = "Единицы измерения";
            this.единицыИзмеренияToolStripMenuItem.Click += new System.EventHandler(this.единицыИзмеренияToolStripMenuItem_Click);
            // 
            // настройкиПользователяToolStripMenuItem
            // 
            this.настройкиПользователяToolStripMenuItem.Image = global::NeuroInventory.Properties.Resources.user_add_32;
            this.настройкиПользователяToolStripMenuItem.Name = "настройкиПользователяToolStripMenuItem";
            this.настройкиПользователяToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.настройкиПользователяToolStripMenuItem.Size = new System.Drawing.Size(327, 26);
            this.настройкиПользователяToolStripMenuItem.Text = "Настройки пользователя";
            this.настройкиПользователяToolStripMenuItem.Click += new System.EventHandler(this.настройкиПользователяToolStripMenuItem_Click);
            // 
            // настройкаНумерацииДокументовToolStripMenuItem
            // 
            this.настройкаНумерацииДокументовToolStripMenuItem.Name = "настройкаНумерацииДокументовToolStripMenuItem";
            this.настройкаНумерацииДокументовToolStripMenuItem.Size = new System.Drawing.Size(327, 26);
            this.настройкаНумерацииДокументовToolStripMenuItem.Text = "Настройка нумерации документов";
            this.настройкаНумерацииДокументовToolStripMenuItem.Click += new System.EventHandler(this.SettingDocNumerationToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutBoxToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.справкаToolStripMenuItem.Text = "&Справка";
            // 
            // aboutBoxToolStripMenuItem
            // 
            this.aboutBoxToolStripMenuItem.Name = "aboutBoxToolStripMenuItem";
            this.aboutBoxToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.aboutBoxToolStripMenuItem.Text = "О программе";
            this.aboutBoxToolStripMenuItem.Click += new System.EventHandler(this.AboutBoxToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabInventory);
            this.tabControl.Controls.Add(this.tabReleased);
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
            this.tabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl_KeyDown);
            // 
            // tabInventory
            // 
            this.tabInventory.Location = new System.Drawing.Point(4, 27);
            this.tabInventory.Margin = new System.Windows.Forms.Padding(0);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Size = new System.Drawing.Size(1254, 669);
            this.tabInventory.TabIndex = 0;
            this.tabInventory.Text = "Склад ТМЦ";
            this.tabInventory.UseVisualStyleBackColor = true;
            // 
            // tabReleased
            // 
            this.tabReleased.Location = new System.Drawing.Point(4, 27);
            this.tabReleased.Name = "tabReleased";
            this.tabReleased.Size = new System.Drawing.Size(1254, 669);
            this.tabReleased.TabIndex = 3;
            this.tabReleased.Text = "Отпущенные ТМЦ";
            this.tabReleased.UseVisualStyleBackColor = true;
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
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripButtonDebitReport,
            this.toolStripButtonDemandReport});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1262, 27);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonDebitReport
            // 
            this.toolStripButtonDebitReport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDebitReport.Image = global::NeuroInventory.Properties.Resources.debit_32;
            this.toolStripButtonDebitReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDebitReport.Name = "toolStripButtonDebitReport";
            this.toolStripButtonDebitReport.Size = new System.Drawing.Size(163, 24);
            this.toolStripButtonDebitReport.Text = "История списаний";
            this.toolStripButtonDebitReport.Click += new System.EventHandler(this.toolStripButtonDebitReport_Click);
            // 
            // toolStripButtonDemandReport
            // 
            this.toolStripButtonDemandReport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonDemandReport.Image = global::NeuroInventory.Properties.Resources.employee_321;
            this.toolStripButtonDemandReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDemandReport.Name = "toolStripButtonDemandReport";
            this.toolStripButtonDemandReport.Size = new System.Drawing.Size(158, 24);
            this.toolStripButtonDemandReport.Text = "История отпусков";
            this.toolStripButtonDemandReport.Click += new System.EventHandler(this.toolStripButtonDemandReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1262, 755);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Склад товарно-материальных ценностей";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem paramsMenu;
        private System.Windows.Forms.ToolStripMenuItem openBDToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem единицыИзмеренияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonDemandReport;
        private System.Windows.Forms.ToolStripButton toolStripButtonDebitReport;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutBoxToolStripMenuItem;
        private System.Windows.Forms.TabPage tabReleased;
        private System.Windows.Forms.ToolStripMenuItem настройкаНумерацииДокументовToolStripMenuItem;
    }
}


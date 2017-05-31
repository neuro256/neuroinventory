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
            this.saceBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.единицыИзмеренияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInventory = new System.Windows.Forms.TabPage();
            this.tabProviders = new System.Windows.Forms.TabPage();
            this.tabEmployees = new System.Windows.Forms.TabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
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
            this.saceBDToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(57, 24);
            this.fileMenu.Text = "&Файл";
            // 
            // createBDToolStripMenuItem
            // 
            this.createBDToolStripMenuItem.Name = "createBDToolStripMenuItem";
            this.createBDToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.createBDToolStripMenuItem.Text = "Создать БД";
            this.createBDToolStripMenuItem.Click += new System.EventHandler(this.createBDToolStripMenuItem_Click);
            // 
            // openBDToolStripMenuItem
            // 
            this.openBDToolStripMenuItem.Name = "openBDToolStripMenuItem";
            this.openBDToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.openBDToolStripMenuItem.Text = "Открыть";
            this.openBDToolStripMenuItem.Click += new System.EventHandler(this.openBDToolStripMenuItem_Click);
            // 
            // saceBDToolStripMenuItem
            // 
            this.saceBDToolStripMenuItem.Name = "saceBDToolStripMenuItem";
            this.saceBDToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.saceBDToolStripMenuItem.Text = "Сохранить БД как...";
            this.saceBDToolStripMenuItem.Click += new System.EventHandler(this.saveBDToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.единицыИзмеренияToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(102, 24);
            this.viewMenu.Text = "&Параметры";
            // 
            // единицыИзмеренияToolStripMenuItem
            // 
            this.единицыИзмеренияToolStripMenuItem.Name = "единицыИзмеренияToolStripMenuItem";
            this.единицыИзмеренияToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.единицыИзмеренияToolStripMenuItem.Text = "Единицы измерения";
            this.единицыИзмеренияToolStripMenuItem.Click += new System.EventHandler(this.единицыИзмеренияToolStripMenuItem_Click);
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
            this.tabInventory.Location = new System.Drawing.Point(4, 27);
            this.tabInventory.Margin = new System.Windows.Forms.Padding(0);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Size = new System.Drawing.Size(1254, 669);
            this.tabInventory.TabIndex = 0;
            this.tabInventory.Text = "ТМЦ";
            this.tabInventory.UseVisualStyleBackColor = true;
            // 
            // tabProviders
            // 
            this.tabProviders.Location = new System.Drawing.Point(4, 27);
            this.tabProviders.Margin = new System.Windows.Forms.Padding(0);
            this.tabProviders.Name = "tabProviders";
            this.tabProviders.Size = new System.Drawing.Size(1305, 549);
            this.tabProviders.TabIndex = 1;
            this.tabProviders.Text = "Поставщики";
            this.tabProviders.UseVisualStyleBackColor = true;
            // 
            // tabEmployees
            // 
            this.tabEmployees.Location = new System.Drawing.Point(4, 27);
            this.tabEmployees.Margin = new System.Windows.Forms.Padding(0);
            this.tabEmployees.Name = "tabEmployees";
            this.tabEmployees.Size = new System.Drawing.Size(1305, 549);
            this.tabEmployees.TabIndex = 2;
            this.tabEmployees.Text = "Работники";
            this.tabEmployees.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1262, 27);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "toolStripButton3";
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
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Склад товарно-материальных ценностей";
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
        private System.Windows.Forms.ToolStripMenuItem saceBDToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabInventory;
        private System.Windows.Forms.TabPage tabProviders;
        private System.Windows.Forms.TabPage tabEmployees;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem openBDToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem единицыИзмеренияToolStripMenuItem;
    }
}


namespace NeuroInventory
{
    partial class TabRecent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabRecent));
            this.groupBoxRecent = new System.Windows.Forms.GroupBox();
            this.lvRecent = new System.Windows.Forms.ListView();
            this.imageListRecents = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxRecent.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRecent
            // 
            this.groupBoxRecent.BackColor = System.Drawing.Color.Azure;
            this.groupBoxRecent.Controls.Add(this.lvRecent);
            this.groupBoxRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRecent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxRecent.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRecent.Name = "groupBoxRecent";
            this.groupBoxRecent.Size = new System.Drawing.Size(1200, 650);
            this.groupBoxRecent.TabIndex = 0;
            this.groupBoxRecent.TabStop = false;
            this.groupBoxRecent.Text = "Последние открытые файлы баз данных";
            // 
            // lvRecent
            // 
            this.lvRecent.BackColor = System.Drawing.Color.LightCyan;
            this.lvRecent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRecent.LargeImageList = this.imageListRecents;
            this.lvRecent.Location = new System.Drawing.Point(3, 26);
            this.lvRecent.Name = "lvRecent";
            this.lvRecent.Size = new System.Drawing.Size(1194, 621);
            this.lvRecent.SmallImageList = this.imageListRecents;
            this.lvRecent.TabIndex = 0;
            this.lvRecent.UseCompatibleStateImageBehavior = false;
            this.lvRecent.View = System.Windows.Forms.View.List;
            this.lvRecent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvRecent_MouseDoubleClick);
            // 
            // imageListRecents
            // 
            this.imageListRecents.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListRecents.ImageStream")));
            this.imageListRecents.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListRecents.Images.SetKeyName(0, "db_64.png");
            // 
            // TabRecent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxRecent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabRecent";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "tabProviders";
            this.groupBoxRecent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRecent;
        private System.Windows.Forms.ListView lvRecent;
        private System.Windows.Forms.ImageList imageListRecents;
    }
}
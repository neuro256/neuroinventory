namespace NeuroInventory
{
    partial class ReportViewSelection
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
            this.btnReportList = new System.Windows.Forms.Button();
            this.btnReportEditor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReportList
            // 
            this.btnReportList.BackgroundImage = global::NeuroInventory.Properties.Resources.list_128;
            this.btnReportList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReportList.Location = new System.Drawing.Point(146, 12);
            this.btnReportList.Name = "btnReportList";
            this.btnReportList.Size = new System.Drawing.Size(128, 128);
            this.btnReportList.TabIndex = 1;
            this.btnReportList.Text = "Список";
            this.btnReportList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReportList.UseVisualStyleBackColor = true;
            this.btnReportList.Click += new System.EventHandler(this.btnReportList_Click);
            // 
            // btnReportEditor
            // 
            this.btnReportEditor.BackgroundImage = global::NeuroInventory.Properties.Resources.pen_128;
            this.btnReportEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReportEditor.Location = new System.Drawing.Point(12, 12);
            this.btnReportEditor.Name = "btnReportEditor";
            this.btnReportEditor.Size = new System.Drawing.Size(128, 128);
            this.btnReportEditor.TabIndex = 0;
            this.btnReportEditor.Text = "Редактор";
            this.btnReportEditor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportEditor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReportEditor.UseVisualStyleBackColor = true;
            this.btnReportEditor.Click += new System.EventHandler(this.btnReportEditor_Click);
            // 
            // ReportViewSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(291, 153);
            this.ControlBox = false;
            this.Controls.Add(this.btnReportList);
            this.Controls.Add(this.btnReportEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportViewSelection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выберите редактор";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReportEditor;
        private System.Windows.Forms.Button btnReportList;
    }
}
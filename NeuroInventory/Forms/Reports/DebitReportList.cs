using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DebitReportList : InventoryView
    {
        public DebitReportList()
        {
            InitializeComponent();
            SQLiteManager.GetInstance().DebitReport().SetCommandDataSet();
            InitForm();
            InitListView();
            InitContextMenuStrip();
            InitContextMenuStripValues();
            ShowTable();
            ListviewSelectedIndex = 0;
        }

        private void InitContextMenuStripValues()
        {
            Dictionary<string, bool> contextMenuStripValues = new Dictionary<string, bool>();
            contextMenuStripValues = new Dictionary<string, bool>();
            contextMenuStripValues.Add("addOnItem", false);
            contextMenuStripValues.Add("editOnItem", false);
            contextMenuStripValues.Add("removeOnItem", true);
            contextMenuStripValues.Add("addOnSpace", false);
            contextMenuStripValues.Add("editOnSpace", false);
            contextMenuStripValues.Add("removeOnSpace", false);

            ContextMenuStripValues = contextMenuStripValues;
        }

        protected override void InitForm()
        {
            this.Size = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.ControlBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            this.Name = "DebitReportList";
            this.Text = "Список списаний";
        }

        public override void InitListView()
        {
            base.InitListView();

            lvDebitReportList.Columns.Clear();

            List<ColumnSettings> lvDebitReportListSettings = UISettings.GetInstance().LvDebitReportListSettings.GetColumnSettingsList();

            foreach (var colSettings in lvDebitReportListSettings)
            {
                lvDebitReportList.Columns.Add(new ColHeader(colSettings.Text, colSettings.Width, colSettings.Align, colSettings.Ascending));
            }

            lvDebitReportList.DoubleBuffered(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        public override void RemoveRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().DebitReport().Remove(ListviewSelectedIndex);
                m_Listview.SelectedItems.Clear();
                SQLiteManager.GetInstance().DebitReport().SetCommandDataSet();
                RemoveFromListViewAt(ListviewSelectedIndex);
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        protected override ListView GetListView()
        {
            return lvDebitReportList;
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripDebitReportList;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().DebitReport().ReturnDataSet();
        }

        public override void ListViewItemMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                base.ListViewItemMouseUp(sender, e);

                if (e.Button == MouseButtons.Left)
                {
                    if (m_Listview.GetItemAt(e.X, e.Y)?.SubItems["document"]?.Bounds.Contains(e.X, e.Y) ?? false)
                    {
                        string l_FileName = m_Listview.GetItemAt(e.X, e.Y)?.SubItems["document"].Tag.ToString();
                        NeuroFile.OpenFileInExplorer(l_FileName);
                        m_Listview.SelectedItems.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ShowTable_ModifySubItem(ListViewItem.ListViewSubItem subItem)
        {
            base.ShowTable_ModifySubItem(subItem);

            if (subItem.Name == "document")
            {
                subItem.BackColor = Color.LightBlue;
                subItem.Tag = subItem.Text;
                subItem.Text = Path.GetFileName(subItem.Text);
            }
        }

        private void lvDebitReportList_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            List<ColumnSettings> lvNewSettings = UISettings.GetInstance().LvDebitReportListSettings.GetColumnSettingsList();

            if (lvNewSettings != null)
            {
                lvNewSettings[e.ColumnIndex].Width = lvDebitReportList.Columns[e.ColumnIndex].Width;

                UISettings.GetInstance().LvDebitReportListSettings.SetColumnSettingsList(lvNewSettings);
            }

            if (lvDebitReportList.Columns[e.ColumnIndex].Width < Definitions.MIN_COLUMN_WIDTH)
            {
                lvDebitReportList.Columns[e.ColumnIndex].Width = Definitions.MIN_COLUMN_WIDTH;
            }
        }
    }
}

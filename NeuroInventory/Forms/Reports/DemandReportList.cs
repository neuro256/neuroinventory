using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DemandReportList : InventoryView
    {
        public DemandReportList()
        {
            InitializeComponent();
            SQLiteManager.GetInstance().DemandReport().SetCommandDataSet();
            InitForm();
            InitListView();
            InitContextMenuStrip();
            InitContextMenuStripValues();
            ShowTable();
            ListviewSelectedIndex = 0;
            SelectedItemId = 0;
        }

        private void InitContextMenuStripValues()
        {
            ContextMenuStripValues = new Dictionary<string, bool>
            {
                { "addOnItem", false },
                { "editOnItem", false },
                { "removeOnItem", true },
                { "addOnSpace", false },
                { "editOnSpace", false },
                { "removeOnSpace", false }
            };
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

            this.Name = "DemandReportList";
            this.Text = "Список требований";
        }

        public override void InitListView()
        {
            base.InitListView();

            lvDemandReportList.Columns.Clear();

            List<ColumnSettings> lvDemandReportListSettings = UISettings.GetInstance().LvDemandReportListSettings.GetColumnSettingsList();

            foreach (var colSettings in lvDemandReportListSettings)
            {
                lvDemandReportList.Columns.Add(new ColHeader(colSettings.Text, colSettings.Width, colSettings.Align, colSettings.Ascending));
            }

            lvDemandReportList.DoubleBuffered(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        public override void RemoveRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().DemandReport().Remove(SelectedItemId);
                m_Listview.SelectedItems.Clear();
                SQLiteManager.GetInstance().DemandReport().SetCommandDataSet();
                RemoveFromListViewAt(ListviewSelectedIndex);
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        protected override ListView GetListView()
        {
            return lvDemandReportList;
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripDemandReportList;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().DemandReport().ReturnDataSet();
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

        private void lvDemandReportList_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            List<ColumnSettings> lvNewSettings = UISettings.GetInstance().LvDemandReportListSettings.GetColumnSettingsList();

            if (lvNewSettings != null)
            {
                lvNewSettings[e.ColumnIndex].Width = lvDemandReportList.Columns[e.ColumnIndex].Width;

                UISettings.GetInstance().LvDemandReportListSettings.SetColumnSettingsList(lvNewSettings);
            }

            if (lvDemandReportList.Columns[e.ColumnIndex].Width < Definitions.MIN_COLUMN_WIDTH)
            {
                lvDemandReportList.Columns[e.ColumnIndex].Width = Definitions.MIN_COLUMN_WIDTH;
            }
        }
    }
}

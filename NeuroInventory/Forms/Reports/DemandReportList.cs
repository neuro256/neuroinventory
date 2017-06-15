using System;
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
            ShowTable();
            m_ListviewSelectedIndex = 0;
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
            lvDemandReportList.Columns.Add(new ColHeader("ID", 50, HorizontalAlignment.Left, true));
            lvDemandReportList.Columns.Add(new ColHeader("№", 50, HorizontalAlignment.Left, true));
            lvDemandReportList.Columns.Add(new ColHeader("Сотрудник", 250, HorizontalAlignment.Left, true));
            lvDemandReportList.Columns.Add(new ColHeader("Дата", 100, HorizontalAlignment.Left, true));
            lvDemandReportList.Columns.Add(new ColHeader("Документ", 250, HorizontalAlignment.Left, true));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        public override void AddRecord()
        {
            DemandReport report = new DemandReport();
            report.StartPosition = FormStartPosition.CenterParent;
            if(report.ShowDialog() == DialogResult.OK)
            {
                SQLiteManager.GetInstance().DemandReport().SetCommandDataSet();
                ShowTable();
                m_Listview.EnsureVisible(m_Listview.Items.Count - 1);
            }
        }

        public override void RemoveRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().DemandReport().Remove(m_ListviewSelectedIndex);
                m_Listview.SelectedItems.Clear();
                SQLiteManager.GetInstance().DemandReport().SetCommandDataSet();
                ShowTable();
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
                if (e.Button == MouseButtons.Right)
                {
                    ListViewHitTestInfo info = m_Listview.HitTest(e.X, e.Y);
                    ListViewItem item = info.Item;

                    if (item != null)
                    {
                        m_ListviewSelectedIndex = item.Index;
                        m_ContextMenuStrip.Items["addToolStripMenuItem"].Visible = false;
                        m_ContextMenuStrip.Items["editToolStripMenuItem"].Visible = false;
                        m_ContextMenuStrip.Items["removeToolStripMenuItem"].Visible = true;
                    }
                    else
                    {
                        // No item is selected
                        this.m_Listview.SelectedItems.Clear();
                        m_ContextMenuStrip.Items["addToolStripMenuItem"].Visible = true;
                        m_ContextMenuStrip.Items["editToolStripMenuItem"].Visible = false;
                        m_ContextMenuStrip.Items["removeToolStripMenuItem"].Visible = false;
                    }
                }
                else if (e.Button == MouseButtons.Left)
                {
                    if (m_Listview.GetItemAt(e.X, e.Y)?.SubItems["document"]?.Bounds.Contains(e.X, e.Y) ?? false)
                    {
                        string l_FileName = m_Listview.GetItemAt(e.X, e.Y)?.SubItems["document"].Tag.ToString();
                        NeuroFile.GetInstance().OpenFileInExplorer(l_FileName);
                        m_Listview.SelectedItems.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ShowTable()
        {
            DataSet dataSet = ReturnDataSet();
            try
            {
                //Заполняем список
                m_Listview.BeginUpdate();
                m_Listview.Items.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    m_Listview.Items.Add(dataSet.Tables[0].Rows[i]["id"].ToString());
                    m_Listview.Items[i].SubItems.Add((i + 1).ToString());
                    for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
                        subitem.Text = dataSet.Tables[0].Rows[i][j].ToString();
                        subitem.Name = dataSet.Tables[0].Columns[j].ToString();
                        if(subitem.Name == "document")
                        {
                            subitem.BackColor = Color.LightBlue;
                            subitem.Tag = subitem.Text;
                            subitem.Text = Path.GetFileName(subitem.Text);
                        }
                        m_Listview.Items[i].SubItems.Add(subitem);
                    }
                    m_Listview.Items[i].UseItemStyleForSubItems = false;
                }
                m_Listview.EndUpdate();
            }
            catch (SQLiteException se)
            {
                MessageBox.Show(se.Message, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException se)
            {
                MessageBox.Show("Error!:", se.Message);
            }
            finally
            {
                dataSet.Dispose();
            }
        }
    }
}

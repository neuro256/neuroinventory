using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace NeuroInventory
{
    public partial class TabRecent : InventoryView
    {
        public delegate void LoadRecentFileEventHandler(string path);
        public static event LoadRecentFileEventHandler LoadRecentFile;

        public TabRecent()
        {
            InitializeComponent();
            InitForm();
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "TabRecent";
            this.Text = "TabRecent";
        }

        public override void Exit()
        {
            base.Exit();
        }

        protected override ListView GetListView()
        {
            return lwRecent;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteSettingsManager.GetInstance().Recents().ReturnDataSet();
        }

        public override void ShowTable()
        {
            DataSet dataSet = ReturnDataSet();
            try
            {
                //Заполняем список
                lwRecent.BeginUpdate();
                lwRecent.Items.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dataSet.Tables[0].Rows[i]["path"].ToString();
                    item.ImageIndex = 0;
                    item.Tag = dataSet.Tables[0].Rows[i]["id"].ToString();

                    lwRecent.Items.Add(item);
                }
                lwRecent.EndUpdate();
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

        private void lwRecent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewHitTestInfo info = lwRecent.HitTest(e.X, e.Y);
                ListViewItem item = info.Item;

                if (item != null && item.Selected)
                {
                    m_ListviewSelectedIndex = item.Index;
                    ListViewItem selectedItem = lwRecent.Items[m_ListviewSelectedIndex];
                    LoadRecentFile?.Invoke(selectedItem.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

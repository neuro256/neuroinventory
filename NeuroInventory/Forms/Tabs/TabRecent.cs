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
            return lvRecent;
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
                lvRecent.BeginUpdate();
                lvRecent.Items.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dataSet.Tables[0].Rows[i]["path"].ToString();
                    item.ImageIndex = 0;
                    item.Tag = dataSet.Tables[0].Rows[i]["id"].ToString();

                    lvRecent.Items.Add(item);
                }
                lvRecent.EndUpdate();
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

        private void lvRecent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewHitTestInfo info = lvRecent.HitTest(e.X, e.Y);
                ListViewItem item = info.Item;

                if (item != null && item.Selected)
                {
                    ListviewSelectedIndex = item.Index;
                    ListViewItem selectedItem = lvRecent.Items[ListviewSelectedIndex];
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

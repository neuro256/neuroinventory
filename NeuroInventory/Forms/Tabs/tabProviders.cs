using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;

namespace NeuroInventory
{
    public partial class TabProviders : InventoryView
    {
        private ProvidersFilter m_Filter;

        public ProvidersFilter Filter { get => m_Filter; set => m_Filter = value; }

        public TabProviders()
        {
            InitializeComponent();
            InitForm();
            InitListView();
            InitContextMenuStrip();
            m_ListviewSelectedIndex = 0;
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "tabEmployees";
            this.Text = "tabEmployees";

            ProvidersFilter.Filtration += ProvidersFilter_Filtration;
        }

        private void ProvidersFilter_Filtration()
        {
            ShowTable();
        }

        public override void InitListView()
        {
            base.InitListView();

            // Добавление столбцов
            // Необходимо добавлять столбцы именно так, иначе ColumnHeader не сможет преобразоваться в ColHeader (используется в методе сортировки)
            lwProviders.Columns.Clear();
            lwProviders.Columns.Add(new ColHeader("ID", 50, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("№", 50, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("Название", 200, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("адрес", 200, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("телефон", 200, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("e-mail", 200, HorizontalAlignment.Left, true));          
            lwProviders.Columns.Add(new ColHeader("Карточка предприятия", 200, HorizontalAlignment.Left, true));
            lwProviders.Columns.Add(new ColHeader("ИНН", 200, HorizontalAlignment.Left, true));
        }

        private void btnProviderAdd_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void btnProviderRemove_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        private void btnProviderEdit_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        /// <summary>
        /// Добавление записи в таблицу
        /// </summary>
        public override void AddRecord()
        {
            ProviderEditor editor = new ProviderEditor();
            editor.StartPosition = FormStartPosition.CenterParent;
            if(editor.ShowDialog() == DialogResult.OK)
            {
                ShowTable();
                if (m_Listview.Items.Count > 0)
                {
                    m_Listview.EnsureVisible(m_ListviewSelectedIndex);
                }
            }
            m_Listview.SelectedItems.Clear();
        }

        /// <summary>
        /// Удаление записи из таблицы
        /// </summary>
        public override void RemoveRecord()
        {
            if (m_Listview.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().Providers().Remove(m_ListviewSelectedIndex);
                RemoveFromListViewAt(m_ListviewSelectedIndex, 1);
                m_Listview.SelectedItems.Clear();
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        /// <summary>
        /// Редактирование записи из таблицы
        /// </summary>
        public override void UpdateRecord()
        {
            if (m_Listview.SelectedItems.Count > 0)
            {
                ProviderEditor editor = new ProviderEditor(m_ListviewSelectedIndex);
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                    lwProviders.EnsureVisible(m_ListviewSelectedIndex);
                }
                m_Listview.SelectedItems.Clear();
            }
            else
            {
                MessageBox.Show(Definitions.UPDATE_WARNING_STRING);
            }
        }

        protected override ListView GetListView()
        {
            return lwProviders;
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripProviders;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().Providers().ReturnDataSet();
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            Filter?.Close();
            base.Exit();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (Filter == null || !Filter.Created)
            {
                Filter = new ProvidersFilter();
                Filter.Dock = DockStyle.Top;
                Filter.TopLevel = false;
                Filter.MdiParent = MdiParent;
                Filter.Parent = Parent;
                Filter.Show();
            }
            else if (Filter != null && Filter.IsHandleCreated)
            {
                Filter.Close();
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
                        if (subitem.Name == "document")
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
                        m_ContextMenuStrip.Items["editToolStripMenuItem"].Visible = true;
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
                else if(e.Button == MouseButtons.Left)
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
    }
}

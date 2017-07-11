using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class DebitEditor : InventoryView
    {
        public delegate void DebitEventHandler();
        public static event DebitEventHandler CheckDebit;

        private int m_InventoryId;
        private object m_SelectedRecordId;
        private string m_InventoryName;

        public DebitEditor(string p_InventoryName, int p_InventoryId, int p_AmountDecimalPlaces)
        {
            InitializeComponent();
            SQLiteManager.GetInstance().Debit().SetCommandDataSet(p_InventoryId);
            InitForm();
            InitListView();
            InitContextMenuStrip();
            m_InventoryName = p_InventoryName;
            PopulateRedactorInfo();
            ShowTable();
            m_ListviewSelectedIndex = 0;
            m_InventoryId = p_InventoryId;
            nudAmount.DecimalPlaces = p_AmountDecimalPlaces;
        }

        protected override void InitForm()
        {
            this.Size = new Size(1200, 650);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.ControlBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            this.Name = "DebitEditor";
            this.Text = "Редактор списаний";
        }

        public override void InitListView()
        {
            base.InitListView();

            lwDebit.Columns.Clear();
            lwDebit.Columns.Add(new ColHeader("ID", 50, HorizontalAlignment.Left, true));
            lwDebit.Columns.Add(new ColHeader("№", 50, HorizontalAlignment.Left, true));
            lwDebit.Columns.Add(new ColHeader("Количество списанных тмц", 200, HorizontalAlignment.Left, true));
            lwDebit.Columns.Add(new ColHeader("Дата", 100, HorizontalAlignment.Left, true));
        }

        private void PopulateRedactorInfo()
        {
            tbName.Text = m_InventoryName;

            // Настройка селектора количества отпущенного тмц
            nudAmount.ThousandsSeparator = true;
            nudAmount.DecimalPlaces = 2;

            // Настройка селектора даты
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Value = DateTime.Today;
            dateTimePicker.ShowUpDown = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        public override void AddRecord()
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            if (!IsValidData())
                return;

            SQLiteManager.GetInstance().Debit().Insert(m_InventoryId, m_InventoryId, nudAmount.Value, dateTimePicker.Value);
            m_Listview.SelectedItems.Clear();
            ShowTable();
            if (m_Listview.Items.Count > 0)
            {
                m_Listview.EnsureVisible(m_Listview.Items.Count - 1);
            }
        }

        public override void RemoveRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().Debit().Remove(m_ListviewSelectedIndex);
                RemoveFromListViewAt(m_ListviewSelectedIndex);
                m_Listview.SelectedItems.Clear();
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        public override void UpdateRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                Dictionary<string, object> values = new Dictionary<string, object>();

                if (!IsValidData())
                    return;

                SQLiteManager.GetInstance().Debit().Update(m_SelectedRecordId, m_InventoryId, nudAmount.Value, dateTimePicker.Value);

                m_Listview.SelectedItems.Clear();
                ShowTable();
                m_Listview.EnsureVisible(m_ListviewSelectedIndex);
            }
            else
            {
                MessageBox.Show(Definitions.UPDATE_WARNING_STRING);
            }
        }

        private bool IsValidData()
        {
            errorProviderDebit.Clear();

            if (nudAmount.Value == 0)
            {
                errorProviderDebit.SetError(nudAmount, Definitions.VALIDATION_WARNING_STRING);
                nudAmount.Focus();
                return false;
            }
            return true;
        }

        protected override ListView GetListView()
        {
            return lwDebit;
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripDebit;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().Debit().ReturnDataSet();
        }

        public override void Clear()
        {
            base.Clear();
        }

        public override void ListViewItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                // При выборе строки событие ItemSelectionChanged возникает два раза:
                // первый раз, когда выделенная в данный момент строка теряут фокус,
                // второй - когда строка, в которой сделан щелчок, получает фокус.
                // Нас интересует строка, которая получает фокус.
                if (e.IsSelected)
                {
                    m_ListviewSelectedIndex = e.ItemIndex;
                    ShowInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowInfo()
        {
            DataSet dataSet = SQLiteManager.GetInstance().Debit().ReturnDataSet();
            m_SelectedRecordId = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["id"];
            nudAmount.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["amount"]);
            dateTimePicker.Value = Convert.ToDateTime(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["date"]);
        }

        private void btnCreateDebit_Click(object sender, EventArgs e)
        {
            DebitReport report = new DebitReport();
            report.StartPosition = FormStartPosition.CenterParent;
            report.ShowDialog();
        }

        private void nudAmount_ValueChanged(object sender, EventArgs e)
        {
            errorProviderDebit.Clear();
        }

        private void DebitEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckDebit?.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class MeasurementEditor : InventoryView
    {
        private object m_SelectedRecordId;

        public MeasurementEditor()
        {
            InitializeComponent();
            SQLiteInternalManager.GetInstance().databaseName = @"settings.db";
            InitForm();
            InitListView();
            InitContextMenuStrip();
            ShowTable();
            m_ListviewSelectedIndex = 0;
        }

        protected override void InitForm()
        {
            this.Size = new Size(1080, 350);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.ControlBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            this.Name = "MeasurementEditor";
            this.Text = "Редактор единиц измерения";
        }

        public override void InitListView()
        {
            base.InitListView();

            lwMeasurement.Columns.Clear();
            lwMeasurement.Columns.Add(new ColHeader("ID", 50, HorizontalAlignment.Left, true));
            lwMeasurement.Columns.Add(new ColHeader("№", 50, HorizontalAlignment.Left, true));
            lwMeasurement.Columns.Add(new ColHeader("Код ОКЕИ", 80, HorizontalAlignment.Left, true));
            lwMeasurement.Columns.Add(new ColHeader("Наименование", 200, HorizontalAlignment.Left, true));
            lwMeasurement.Columns.Add(new ColHeader("Условное обозначение", 200, HorizontalAlignment.Left, true));
            lwMeasurement.Columns.Add(new ColHeader("Количество десятичных разрядов", 250, HorizontalAlignment.Left, true));
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
            if (!CheckFields())
                return;
            SQLiteInternalManager.GetInstance().Measurement().Insert(nudOKEI.Value, tbName.Text, tbSymbol.Text, nudPlaces.Value);
            m_Listview.SelectedItems.Clear();
            ShowTable();
        }

        private bool CheckFields()
        {
            if (String.IsNullOrEmpty(tbName.Text) || String.IsNullOrEmpty(tbSymbol.Text))
            {
                MessageBox.Show("Введите обязательные значения");
                return false;
            }
            return true;
        }

        public override void RemoveRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                SQLiteInternalManager.GetInstance().Measurement().Remove(m_ListviewSelectedIndex);
            }

            m_Listview.SelectedItems.Clear();
            ShowTable();
        }

        public override void UpdateRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                SQLiteInternalManager.GetInstance().Measurement().Update(m_SelectedRecordId, nudOKEI.Value, tbName.Text, tbSymbol.Text, nudPlaces.Value);
            }
            m_Listview.SelectedItems.Clear();
            ShowTable();
        }

        protected override ListView GetListView()
        {
            return lwMeasurement;
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripMeasurement;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteInternalManager.GetInstance().Measurement().ReturnDataSet();
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

        private void ShowInfo()
        {
            DataSet dataSet = SQLiteInternalManager.GetInstance().Measurement().ReturnDataSet();
            m_SelectedRecordId = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["id"];
            nudOKEI.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["codeOKEI"]);
            tbName.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["name"].ToString();
            tbSymbol.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["symbol"].ToString();
            nudPlaces.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["decimalPlaces"]);
        }

        public override void ShowTable()
        {
            if (!SQLiteInternalManager.GetInstance().TestConnection())
                return;
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
                        m_Listview.Items[i].SubItems.Add(dataSet.Tables[0].Rows[i][j].ToString());
                    }
                    // Example coloring
                    //m_Listview.Items[i].SubItems[5].BackColor = System.Drawing.Color.GreenYellow;
                    //m_Listview.Items[i].UseItemStyleForSubItems = false;
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

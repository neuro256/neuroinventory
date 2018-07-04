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

            lvMeasurement.Columns.Clear();

            List<ColumnSettings> lvMeasurementSettings = UISettings.GetInstance().LvMeasurementSettings.GetColumnSettingsList();

            foreach (var colSettings in lvMeasurementSettings)
            {
                lvMeasurement.Columns.Add(new ColHeader(colSettings.Text, colSettings.Width, colSettings.Align, colSettings.Ascending));
            }

            lvMeasurement.DoubleBuffered(true);
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
            if (!IsValidData())
                return;
            SQLiteSettingsManager.GetInstance().Measurement().Insert(nudOKEI.Value, tbName.Text, tbSymbol.Text, nudPlaces.Value);
            m_Listview.SelectedItems.Clear();
            ShowTable();
            if (m_Listview.Items.Count > 0)
            {
                m_Listview.EnsureVisible(m_Listview.Items.Count - 1);
            }
        }

        private bool IsValidData()
        {
            bool isValid = true;
            errorProviderMeasurement.Clear();

            if (String.IsNullOrEmpty(tbName.Text))
            {
                errorProviderMeasurement.SetError(tbName, Definitions.VALIDATION_WARNING_STRING);
                isValid = false;
            }

            if(String.IsNullOrEmpty(tbSymbol.Text))
            {
                errorProviderMeasurement.SetError(tbSymbol, Definitions.VALIDATION_WARNING_STRING);
                isValid = false;
            }
            return isValid;
        }

        public override void RemoveRecord()
        {
            if(m_Listview.SelectedItems.Count > 0)
            {
                SQLiteSettingsManager.GetInstance().Measurement().Remove(m_ListviewSelectedIndex);
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
                SQLiteSettingsManager.GetInstance().Measurement().Update(m_SelectedRecordId, nudOKEI.Value, tbName.Text, tbSymbol.Text, nudPlaces.Value);
                ShowTable();
                m_Listview.EnsureVisible(m_ListviewSelectedIndex);
                m_Listview.SelectedItems.Clear();
            }
            else
            {
                MessageBox.Show(Definitions.UPDATE_WARNING_STRING);
            }
        }

        protected override ListView GetListView()
        {
            return lvMeasurement;
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripMeasurement;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteSettingsManager.GetInstance().Measurement().ReturnDataSet();
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
            DataSet dataSet = SQLiteSettingsManager.GetInstance().Measurement().ReturnDataSet();
            m_SelectedRecordId = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["id"];
            nudOKEI.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["codeOKEI"]);
            tbName.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["name"].ToString();
            tbSymbol.Text = dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["symbol"].ToString();
            nudPlaces.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[m_ListviewSelectedIndex]["decimalPlaces"]);
        }

        public override void ShowTable()
        {
            if (!SQLiteSettingsManager.GetInstance().TestConnection())
                return;
            DataSet dataSet = ReturnDataSet();
            try
            {
                //Заполняем список
                m_Listview.BeginUpdate();
                m_Listview.Items.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ListViewItem lvItem = new ListViewItem
                    {
                        Text = (i + 1).ToString(),
                        Tag = dataSet.Tables[0].Rows[i]["id"]
                    };

                    m_Listview.Items.Add(lvItem);

                    for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        m_Listview.Items[i].SubItems.Add(dataSet.Tables[0].Rows[i][j].ToString());
                    }
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

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            errorProviderMeasurement.Clear();
        }

        private void tbSymbol_TextChanged(object sender, EventArgs e)
        {
            errorProviderMeasurement.Clear();
        }

        private void lvMeasurement_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            List<ColumnSettings> lvNewSettings = UISettings.GetInstance().LvMeasurementSettings.GetColumnSettingsList();

            if (lvNewSettings != null)
            {
                lvNewSettings[e.ColumnIndex].Width = lvMeasurement.Columns[e.ColumnIndex].Width;

                UISettings.GetInstance().LvMeasurementSettings.SetColumnSettingsList(lvNewSettings);
            }

            if (lvMeasurement.Columns[e.ColumnIndex].Width < Definitions.MIN_COLUMN_WIDTH)
            {
                lvMeasurement.Columns[e.ColumnIndex].Width = Definitions.MIN_COLUMN_WIDTH;
            }
        }
    }
}

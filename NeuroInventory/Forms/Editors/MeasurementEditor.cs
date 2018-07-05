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
            ListviewSelectedIndex = 0;
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
                SQLiteSettingsManager.GetInstance().Measurement().Remove(ListviewSelectedIndex);
                RemoveFromListViewAt(ListviewSelectedIndex);
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
                m_Listview.EnsureVisible(ListviewSelectedIndex);
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
            base.ListViewItemSelectionChanged(sender, e);

            try
            {
                if(e.IsSelected)
                {
                    ShowInfo();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowInfo()
        {
            DataSet dataSet = SQLiteSettingsManager.GetInstance().Measurement().ReturnDataSet();
            m_SelectedRecordId = dataSet.Tables[0].Rows[ListviewSelectedIndex]["id"];
            nudOKEI.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[ListviewSelectedIndex]["codeOKEI"]);
            tbName.Text = dataSet.Tables[0].Rows[ListviewSelectedIndex]["name"].ToString();
            tbSymbol.Text = dataSet.Tables[0].Rows[ListviewSelectedIndex]["symbol"].ToString();
            nudPlaces.Value = Convert.ToDecimal(dataSet.Tables[0].Rows[ListviewSelectedIndex]["decimalPlaces"]);
        }

        public override void ShowTable()
        {
            if (!SQLiteSettingsManager.GetInstance().TestConnection())
                return;
            base.ShowTable();
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

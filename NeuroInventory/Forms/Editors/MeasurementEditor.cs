using BrightIdeasSoftware;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class MeasurementEditor : InventoryView
    {
        BindingSource bindingSource = null;

        public MeasurementEditor()
        {
            InitializeComponent();
            InitForm();
            InitListView();
            InitCtxMenuStrip();
            RestoreState();
        }

        private void InitCtxMenuStrip()
        {
            // Создаем элементы меню и добавляем их
            ToolStripMenuItem addMenuItem = new ToolStripMenuItem("Добавить");
            addMenuItem.Name = "addToolStripMenuItem";
            addMenuItem.Click += addToolStripMenuItem_Click;
            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Редактировать");
            editMenuItem.Name = "editToolStripMenuItem";
            editMenuItem.Click += editToolStripMenuItem_Click;
            ToolStripMenuItem removeMenuItem = new ToolStripMenuItem("Удалить");
            removeMenuItem.Name = "removeToolStripMenuItem";
            removeMenuItem.Click += removeToolStripMenuItem_Click;
            contextMenuStripMeasurement.Items.Clear();
            contextMenuStripMeasurement.Items.AddRange(new[] { addMenuItem, editMenuItem, removeMenuItem });
            // Ассоциируем контекстное меню со списком
            dlvMeasurement.ContextMenuStrip = contextMenuStripMeasurement;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        public override void InitListView()
        {
            base.InitListView();
            bindingSource = new BindingSource(ReturnDataSet(), "measurement");
            dlvMeasurement.DataSource = bindingSource;
            dlvMeasurement.PrimarySortColumn = columnName;
            dlvMeasurement.PrimarySortOrder = SortOrder.Ascending;
            dlvMeasurement.Sort();
            dlvMeasurement.RebuildColumns();
        }

        private void RefreshList()
        {
            bindingSource.DataSource = ReturnDataSet();
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
            RefreshList();
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
            if (dlvMeasurement.SelectedObjects?.Count > 0)
            {
                foreach (var selectedObject in dlvMeasurement.SelectedObjects)
                {
                    DataRowView dataRowView = selectedObject as DataRowView;
                    SQLiteSettingsManager.GetInstance().Measurement().Remove(Convert.ToInt32(dataRowView["id"]));
                }
                RefreshList();
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        public override void UpdateRecord()
        {
            if (dlvMeasurement.SelectedObject != null)
            {
                DataRowView dataRowView = dlvMeasurement.SelectedObject as DataRowView;
                SQLiteSettingsManager.GetInstance().Measurement().Update(Convert.ToInt32(dataRowView["id"]), nudOKEI.Value, tbName.Text, tbSymbol.Text, nudPlaces.Value);
                RefreshList();
            }
            else
            {
                MessageBox.Show(Definitions.UPDATE_WARNING_STRING);
            }
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteSettingsManager.GetInstance().Measurement().ReturnDataSet();
        }

        public override void Clear()
        {
            base.Clear();
        }

        private void ShowInfo()
        {
            DataRowView dataRowView = dlvMeasurement.SelectedObject as DataRowView;
            if (dataRowView != null)
            {
                nudOKEI.Value = Convert.ToDecimal(dataRowView["codeOKEI"]);
                tbName.Text = dataRowView["name"].ToString();
                tbSymbol.Text = dataRowView["symbol"].ToString();
                nudPlaces.Value = Convert.ToDecimal(dataRowView["decimalPlaces"]);
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

        private void dlvMeasurement_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (e.IsSelected)
                {
                    ShowInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void SaveState()
        {
            byte[] columnSettings = dlvMeasurement.SaveState();
            ColumnSettings.GetInstance().LvMeasurementSettings = columnSettings;
        }

        public override void RestoreState()
        {
            byte[] columnSettings = ColumnSettings.GetInstance().LvMeasurementSettings;
            if (columnSettings != null && columnSettings.Length > 0)
            {
                dlvMeasurement.RestoreState(columnSettings);
            }
        }

        private void MeasurementEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveState();
        }

        protected override FastDataListView GetListView()
        {
            return dlvMeasurement;
        }
    }
}

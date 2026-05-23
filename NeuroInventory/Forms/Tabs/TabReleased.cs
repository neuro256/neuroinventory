using BrightIdeasSoftware;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabReleased : InventoryView
    {
        enum BalanceType
        {
            ERROR_DEBIT, 
            NOT_DEBIT, 
            PARTIALLY_DEBIT, 
            DEBIT
        }

        class BalanceInfo
        {
            public object Balance { get; set; } 
            public BalanceType balanceType { get; set; }
            public Color Color { get; set; } 
            public string BalanceTypeText { get; set; }

            public BalanceInfo(object balance, BalanceType balanceType)
            {
                this.Balance = balance;
                this.balanceType = balanceType;
            }

            public static BalanceInfo GetBalanceInfo(object balance, object amount)
            {
                BalanceInfo balanceInfo = new BalanceInfo(balance, BalanceType.NOT_DEBIT);
                if (Equals(balance, DBNull.Value))
                {
                    balanceInfo.Color = Definitions.COLOR_BALANCEINFO_NOT_DEBIT_NULL_COLOR;//Color.DarkOrange;
                    balanceInfo.BalanceTypeText = Definitions.NOT_DEBIT_STRING;
                    balanceInfo.balanceType = BalanceType.NOT_DEBIT;
                }
                else if (Convert.ToDecimal(balance) > 0 && Equals(balance, amount))
                {
                    balanceInfo.Color = Definitions.COLOR_BALANCEINFO_NOT_DEBIT_COLOR;//Color.Coral;
                    balanceInfo.BalanceTypeText = Definitions.NOT_DEBIT_STRING;
                    balanceInfo.balanceType = BalanceType.NOT_DEBIT;
                }
                else if (Convert.ToDecimal(balance) > 0 && !Equals(balance, amount))
                {
                    balanceInfo.Color = Definitions.COLOR_BALANCEINFO_PART_DEBIT_COLOR;//Color.LightGreen;
                    balanceInfo.BalanceTypeText = $"{Definitions.PARTIALLY_DEBIT} ({balance})";
                    balanceInfo.balanceType = BalanceType.PARTIALLY_DEBIT;
                }
                else if (Convert.ToDecimal(balance) < 0)
                {
                    balanceInfo.Color = Definitions.COLOR_BALANCEINFO_ERROR_DEBIT_COLOR;//Color.Red;
                    balanceInfo.BalanceTypeText = $"{Definitions.ERROR_DEBIT_STRING} ({balance})";
                    balanceInfo.balanceType = BalanceType.ERROR_DEBIT;
                }
                else
                {
                    balanceInfo.Color = Definitions.COLOR_BALANCEINFO_DEBIT_COLOR;//Color.LightGreen;
                    balanceInfo.BalanceTypeText = Definitions.DEBIT_STRING;
                    balanceInfo.balanceType = BalanceType.DEBIT;
                }

                return balanceInfo;
            }
        }

        BindingSource bindingSource = null;

        public TabReleased()
        {
            InitializeComponent();
            InitForm();
            InitControls();
        }

        private void InitControls()
        {
            InitListView();
            InitCtxMenuStrip();
            SQLiteManager.GetInstance().Released().SetCommandSet();
            RestoreState();
            TimedFilter(dlvReleased, Definitions.DEFAULT_FILTER_TEXT, 0);
        }

        public override void RebuildList()
        {
            RefreshList();
        }

        private void InitCtxMenuStrip()
        {
            // Создаем элементы меню и добавляем их
            ToolStripMenuItem debitMenuItem = new ToolStripMenuItem("Списать");
            debitMenuItem.Name = "debitToolStripMenuItem";
            debitMenuItem.Click += debitToolStripMenuItem_Click;
            ToolStripMenuItem cancelDebitMenuItem = new ToolStripMenuItem("Отменить списание");
            cancelDebitMenuItem.Name = "cancelDebitToolStripMenuItem";
            cancelDebitMenuItem.Click += cancelDebitToolStripMenuItem_Click;
            ToolStripMenuItem cancelDemandMenuItem = new ToolStripMenuItem("Отменить отпуск");
            cancelDemandMenuItem.Name = "cancelDemandToolStripMenuItem";
            cancelDemandMenuItem.Click += cancelDemandToolStripMenuItem_Click;
            contextMenuStripReleased.Items.Clear();
            contextMenuStripReleased.Items.AddRange(new[] { debitMenuItem, cancelDebitMenuItem, cancelDemandMenuItem });
            // Ассоциируем контекстное меню со списком
            dlvReleased.ContextMenuStrip = contextMenuStripReleased;
        }

        private void cancelDemandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelDemand();
        }

        private void cancelDebitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CancelDebit();
        }

        private void debitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debit();
        }

        public override void InitListView()
        {
            base.InitListView();

            dlvReleased.CheckBoxes = true;
            dlvReleased.PersistentCheckBoxes = true;
            bindingSource = new BindingSource(ReturnDataSet(), "demand");
            dlvReleased.DataSource = bindingSource;

            this.dlvReleased.FormatCell += delegate (object cender, FormatCellEventArgs args)
            {
                if (args.Column?.AspectName == "document")
                {
                    args.SubItem.BackColor = Definitions.COLOR_SUBITEM_DOCUMENT_BACK_COLOR;
                    args.SubItem.Text = Path.GetFileName(args.SubItem.Text);
                }
                else if (args.Column?.AspectName == "amount" && args.Model != null)
                {
                    DataRowView dataRowView = args.Model as DataRowView;
                    int l_DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(dataRowView["measurement"].ToString());
                    args.SubItem.Text = String.Format($"{{0:n{l_DecimalPlaces}}}", args.SubItem.Text);
                }
                else if (args.Column?.AspectName == "balance" && args.Model != null)
                {
                    DataRowView dataRowView = args.Model as DataRowView;
                    BalanceInfo balanceInfo = BalanceInfo.GetBalanceInfo(dataRowView["balance"], dataRowView["amount"]);

                    //args.SubItem.BackColor = balanceInfo.Color;
                    args.SubItem.Text = balanceInfo.BalanceTypeText;
                }
            };

            this.dlvReleased.FormatRow += delegate (object cender, FormatRowEventArgs args)
            {
                DataRowView dataRowView = args.Model as DataRowView;
                if (dataRowView == null)
                    return;
                BalanceInfo balanceInfo = BalanceInfo.GetBalanceInfo(dataRowView["balance"], dataRowView["amount"]);
                if (balanceInfo.balanceType == BalanceType.DEBIT)
                {
                    args.Item.BackColor = Definitions.COLOR_ROW_BALANCE_DEBIT_COLOR;//Color.LightGreen;
                }
                else if (balanceInfo.balanceType == BalanceType.ERROR_DEBIT)
                {
                    args.Item.BackColor = Definitions.COLOR_ROW_BALANCE_ERROR_DEBIT_COLOR;//Color.LightPink;
                }
            };

            columnPrice.AspectToStringConverter = delegate (object obj)
            {
                return string.Format(new CultureInfo("ru-RU"),
                      "{0:C}",
                      Convert.ToDecimal(obj, CultureInfo.InvariantCulture));
            };

            columnSum.AspectToStringConverter = delegate (object obj)
            {
                return string.Format(new CultureInfo("ru-RU"),
                      "{0:C}",
                      Convert.ToDecimal(obj, CultureInfo.InvariantCulture));
            };

            dlvReleased.PrimarySortOrder = SortOrder.Ascending;
            dlvReleased.Sort();

            dlvReleased.RebuildColumns();
        }

        protected override FastDataListView GetListView()
        {
            return dlvReleased;
        }

        private void RefreshList()
        {
            bindingSource.DataSource = ReturnDataSet();
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "tabReleased";
            this.Text = "tabReleased";
        }

        private void btnReleasedRemove_Click(object sender, EventArgs e)
        {
            CancelDemand();
        }

        /// <summary>
        /// Отмена отпуска
        /// </summary>
        private void CancelDemand()
        {
            if (dlvReleased.SelectedObjects?.Count > 0)
            {
                dlvReleased.Freeze();
                foreach (var selectedObject in dlvReleased.SelectedObjects)
                {
                    DataRowView dataRowView = selectedObject as DataRowView;
                    SQLiteManager.GetInstance().Released().CancelDemand(Convert.ToInt32(dataRowView["demandId"]));
                }
                dlvReleased.Unfreeze();
                RefreshList();
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        private void btnDebitCancel_Click(object sender, EventArgs e)
        {
            CancelDebit();
        }

        private void CancelDebit()
        {
            if (dlvReleased.SelectedObjects?.Count > 0)
            {
                dlvReleased.Freeze();
                foreach (var selectedObject in dlvReleased.SelectedObjects)
                {
                    DataRowView dataRowView = selectedObject as DataRowView;
                    SQLiteManager.GetInstance().Released().CancelDebit(Convert.ToInt32(dataRowView["demandId"]));
                }
                dlvReleased.Unfreeze();
                RefreshList();
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().Released().ReturnDataSet();
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        public override void Exit()
        {
            base.Exit();
        }

        /// <summary>
        /// Списать выбранные тмц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDebitReport_Click(object sender, EventArgs e)
        {
            Debit();
        }

        private void Debit()
        {
            if (dlvReleased.CheckedObjects?.Count > 0)
            {
                DebitEditor editor = new DebitEditor(GetDebitDataSet());
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                }
            }
        }

        private DataSet GetDebitDataSet()
        {
            DataTable debitTable = new DataTable("DebitReport");
            debitTable.Columns.Add("id");
            debitTable.Columns.Add("demandId");
            debitTable.Columns.Add("date");
            debitTable.Columns.Add("invoice_code");
            debitTable.Columns.Add("invoiceDate");
            debitTable.Columns.Add("name");
            debitTable.Columns.Add("OKEIcode");
            debitTable.Columns.Add("measurement");
            debitTable.Columns.Add("price");
            debitTable.Columns.Add("balance");
            debitTable.Columns.Add("debit_amount");
            debitTable.Columns.Add("sum");

            foreach(var obj in dlvReleased.CheckedObjects)
            {
                DataRow newRow = debitTable.NewRow();
                DataRowView dataRowView = obj as DataRowView;

                newRow["id"] = dataRowView["id"];
                newRow["demandId"] = dataRowView["demandId"];
                newRow["date"] = dataRowView["ordate"];
                newRow["invoice_code"] = dataRowView["invoiceCodeStr"];
                newRow["invoiceDate"] = dataRowView["invoiceDate"];
                newRow["name"] = dataRowView["name"];
                newRow["OKEIcode"] = dataRowView["OKEIcode"];
                newRow["measurement"] = dataRowView["measurement"];
                newRow["price"] = dataRowView["price"];
                newRow["balance"] = CalculateBalance(dataRowView);
                newRow["debit_amount"] = CalculateBalance(dataRowView);
                // ToString(CultureInfo.GetCultureInfo("en-US")) использовано т.к. локальная культура ru-RU использует в качестве разделителя целой и дробной части запятую, 
                // и эта запятая автоматически записывается в newRow. То есть, в newRow хранится не decimal, а строковое значение sum с учетом культуры
                newRow["sum"] = MoneyConverter.Multiply(CalculateBalance(dataRowView), dataRowView["price"]).ToString(CultureInfo.GetCultureInfo("en-US"));

                debitTable.Rows.Add(newRow);
            }

            DataSet debitDataSet = new DataSet("Report");
            debitDataSet.Tables.Add(debitTable);

            return debitDataSet;
        }

        private static object CalculateBalance(DataRowView dataRowView)
        {
            object balance = dataRowView["balance"];
            object balanceValue = null;
            if (balance != null && !Equals(balance, DBNull.Value))
            {
                balanceValue = balance;
            }
            else
            {
                balanceValue = dataRowView["amount"];
            }

            return balanceValue;
        }

        private void dlvReleased_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Column?.AspectName == "document")
            {
                DataRowView dataRowView = e.Model as DataRowView;
                NeuroFile.OpenFileInExplorer(dataRowView["document"].ToString());
            }
        }

        private void dlvReleased_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            OLVListItem item = e.Item as OLVListItem;
            DataRowView dataRowView = item.RowObject as DataRowView;

            object l_Balance = dataRowView["balance"];
            if (!Equals(l_Balance, DBNull.Value))
            {
                decimal l_BalanceValue = Convert.ToDecimal(l_Balance);

                if (l_BalanceValue <= 0 && e.Item.Checked == true)
                {
                    MessageBox.Show(Definitions.ALREADY_DEBIT_WARNING);
                }
            }
        }

        private void dlvReleased_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (e.Model != null)
            {
                contextMenuStripReleased.Items["debitToolStripMenuItem"].Visible = true;
                contextMenuStripReleased.Items["cancelDebitToolStripMenuItem"].Visible = true;
                contextMenuStripReleased.Items["cancelDemandToolStripMenuItem"].Visible = true;
            }
            else
            {
                contextMenuStripReleased.Items["debitToolStripMenuItem"].Visible = true;
                contextMenuStripReleased.Items["cancelDebitToolStripMenuItem"].Visible = false;
                contextMenuStripReleased.Items["cancelDemandToolStripMenuItem"].Visible = false;
            }
            e.MenuStrip = contextMenuStripReleased;
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxShowAll.Checked)
            {
                TimedFilter(dlvReleased, ((TextBox)sender).Text, 0);
            }
            else
            {
                if (((TextBox)sender).Text.Length > 2)
                    TimedFilter(dlvReleased, ((TextBox)sender).Text, 0);
                else
                    TimedFilter(dlvReleased, Definitions.DEFAULT_FILTER_TEXT, 0);
            }
        }

        public override void SaveState()
        {
            byte[] columnSettings = dlvReleased.SaveState();
            ColumnSettings.GetInstance().LvReleasedSettings = columnSettings;
        }

        public override void RestoreState()
        {
            byte[] columnSettings = ColumnSettings.GetInstance().LvReleasedSettings;
            if (columnSettings != null && columnSettings.Length > 0)
            {
                dlvReleased.RestoreState(columnSettings);
            }
        }

        public override void FocusFilter()
        {
            tbFilter.Clear();
            tbFilter.Focus();
        }

        private void checkBoxShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShowAll.Checked)
            {
                TimedFilter(dlvReleased, String.Empty, 0);
                tbFilter.Clear();
            }   
            else
            {
                if(String.Equals(tbFilter.Text, String.Empty))
                    TimedFilter(dlvReleased, Definitions.DEFAULT_FILTER_TEXT, 0);
                else
                    TimedFilter(dlvReleased, tbFilter.Text, 0);
            }
                
        }
    }
}

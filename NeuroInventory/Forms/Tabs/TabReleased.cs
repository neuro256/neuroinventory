using BrightIdeasSoftware;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Diagnostics;
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

                decimal balanceValue = MoneyConverter.GetDecimalValue(balance);
                decimal amountValue = MoneyConverter.GetDecimalValue(amount);

                if (Equals(balance, DBNull.Value))
                {
                    balanceInfo.Color = Definitions.COLOR_BALANCEINFO_NOT_DEBIT_NULL_COLOR;//Color.DarkOrange;
                    balanceInfo.BalanceTypeText = Definitions.NOT_DEBIT_STRING;
                    balanceInfo.balanceType = BalanceType.NOT_DEBIT;
                }
                else if (balanceValue > 0 && balanceValue == amountValue)
                {
                    balanceInfo.Color = Definitions.COLOR_BALANCEINFO_NOT_DEBIT_COLOR;//Color.Coral;
                    balanceInfo.BalanceTypeText = Definitions.NOT_DEBIT_STRING;
                    balanceInfo.balanceType = BalanceType.NOT_DEBIT;
                }
                else if (balanceValue > 0 && balanceValue != amountValue)
                {
                    balanceInfo.Color = Definitions.COLOR_BALANCEINFO_PART_DEBIT_COLOR;//Color.LightGreen;
                    balanceInfo.BalanceTypeText = $"{Definitions.PARTIALLY_DEBIT} ({balance})";
                    balanceInfo.balanceType = BalanceType.PARTIALLY_DEBIT;
                }
                else if (balanceValue < 0)
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

            columnDate1.AspectGetter = rowObject =>
            {
                if (!(rowObject is DataRowView row))
                    return null;

                object value = row["ordate"];

                if (value == null || value == DBNull.Value)
                    return null;

                if (value is DateTime dt)
                    return dt;

                return DateTime.TryParse(value.ToString(), out dt)
                    ? (DateTime?)dt
                    : null;
            };

            columnDate2.AspectGetter = rowObject =>
            {
                if (!(rowObject is DataRowView row))
                    return null;

                object value = row["mydate"];

                if (value == null || value == DBNull.Value)
                    return null;

                if (value is DateTime dt)
                    return dt;

                return DateTime.TryParse(value.ToString(), out dt)
                    ? (DateTime?)dt
                    : null;
            };

            columnDate3.AspectGetter = rowObject =>
            {
                if (!(rowObject is DataRowView row))
                    return null;

                object value = row["invoiceDate"];

                if (value == null || value == DBNull.Value)
                    return null;

                if (value is DateTime dt)
                    return dt;

                return DateTime.TryParse(value.ToString(), out dt)
                    ? (DateTime?)dt
                    : null;
            };

            this.dlvReleased.FormatCell += delegate (object cender, FormatCellEventArgs args)
            {
                if (args.Column?.AspectName == "document")
                {
                    args.SubItem.BackColor = Definitions.COLOR_SUBITEM_DOCUMENT_BACK_COLOR;
                    args.SubItem.Text = Path.GetFileName(args.SubItem.Text);
                }
                else if (args.Column?.AspectName == "amount" && args.Model != null)
                {
                    if (!(args.Model is DataRowView dataRowView))
                        return;

                    int l_DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(dataRowView["measurement"]?.ToString() ?? string.Empty);
                    args.SubItem.Text = String.Format($"{{0:n{l_DecimalPlaces}}}", args.SubItem.Text);
                }
                else if (args.Column?.AspectName == "balance" && args.Model != null)
                {
                    if (!(args.Model is DataRowView dataRowView))
                        return;

                    BalanceInfo balanceInfo = BalanceInfo.GetBalanceInfo(dataRowView["balance"], dataRowView["amount"]);

                    //args.SubItem.BackColor = balanceInfo.Color;
                    args.SubItem.Text = balanceInfo.BalanceTypeText;
                }
            };

            this.dlvReleased.FormatRow += delegate (object cender, FormatRowEventArgs args)
            {
                if (!(args.Model is DataRowView dataRowView))
                    return;

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

            columnDate1.AspectToStringConverter = value =>
            {
                if (value is DateTime dt)
                    return dt.ToString("dd.MM.yyyy");

                return string.Empty;
            };

            columnDate2.AspectToStringConverter = value =>
            {
                if (value is DateTime dt)
                    return dt.ToString("dd.MM.yyyy");

                return string.Empty;
            };

            columnDate3.AspectToStringConverter = value =>
            {
                if (value is DateTime dt)
                    return dt.ToString("dd.MM.yyyy");

                return string.Empty;
            };

            columnPrice.AspectToStringConverter = value =>
            {
                if (value == null || value == DBNull.Value)
                    return string.Empty;

                decimal price = MoneyConverter.ToCurrency(value);

                return MoneyConverter.FormatCurrency(price);
            };

            columnSum.AspectToStringConverter = value =>
            {
                if (value == null || value == DBNull.Value)
                    return string.Empty;

                decimal sum = MoneyConverter.ToCurrency(value);

                return MoneyConverter.FormatCurrency(sum);
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
                    if (!(selectedObject is DataRowView dataRowView))
                        return;

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
                    if (!(selectedObject is DataRowView dataRowView))
                        return;

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
            debitTable.Columns.Add("price", typeof(decimal));
            debitTable.Columns.Add("balance", typeof(decimal));
            debitTable.Columns.Add("debit_amount", typeof(decimal));
            debitTable.Columns.Add("sum", typeof(decimal));

            foreach (var obj in dlvReleased.CheckedObjects)
            {
                if (!(obj is DataRowView dataRowView))
                    continue;

                decimal amount = CalculateBalance(dataRowView);
                decimal price = MoneyConverter.ToCurrency(dataRowView["price"]);

                DataRow newRow = debitTable.NewRow();

                newRow["id"] = dataRowView["id"];
                newRow["demandId"] = dataRowView["demandId"];
                newRow["date"] = dataRowView["ordate"];
                newRow["invoice_code"] = dataRowView["invoiceCodeStr"];
                newRow["invoiceDate"] = dataRowView["invoiceDate"];
                newRow["name"] = dataRowView["name"];
                newRow["OKEIcode"] = dataRowView["OKEIcode"];
                newRow["measurement"] = dataRowView["measurement"];
                
                newRow["price"] = MoneyConverter.RoundCurrency(price);
                newRow["balance"] = amount;
                newRow["debit_amount"] = amount;
                newRow["sum"] = MoneyConverter.RoundCurrency(amount * price);

                debitTable.Rows.Add(newRow);
            }

            DataSet debitDataSet = new DataSet("Report");
            debitDataSet.Tables.Add(debitTable);

            return debitDataSet;
        }

        private static decimal CalculateBalance(DataRowView dataRowView)
        {
            object balance = dataRowView["balance"];

            if (balance != null && balance != DBNull.Value)
                return MoneyConverter.GetDecimalValue(balance);

            return MoneyConverter.GetDecimalValue(dataRowView["amount"]);
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

            if (!(item.RowObject is DataRowView dataRowView))
                return;

            object l_Balance = dataRowView["balance"];
            if (!Equals(l_Balance, DBNull.Value))
            {
                decimal balanceValue = MoneyConverter.GetDecimalValue(l_Balance);

                if (balanceValue <= 0 && e.Item.Checked == true)
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

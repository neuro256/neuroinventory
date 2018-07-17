using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class TabReleased : InventoryView
    {
        public class ReleasedIds
        {
            public int inventoryId;
            public int demandId;
        }

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
                    balanceInfo.Color = Color.DarkOrange;
                    balanceInfo.BalanceTypeText = Definitions.NOT_DEBIT_STRING;
                }
                else if (Convert.ToDecimal(balance) > 0 && Equals(balance, amount))
                {
                    balanceInfo.Color = Color.Coral;
                    balanceInfo.BalanceTypeText = Definitions.NOT_DEBIT_STRING;
                }
                else if (Convert.ToDecimal(balance) > 0 && !Equals(balance, amount))
                {
                    balanceInfo.Color = Color.LightGreen;
                    balanceInfo.BalanceTypeText = $"{Definitions.PARTIALLY_DEBIT} ({balance})";
                }
                else if (Convert.ToDecimal(balance) < 0)
                {
                    balanceInfo.Color = Color.Red;
                    balanceInfo.BalanceTypeText = $"{Definitions.ERROR_DEBIT_STRING} ({balance})";
                }
                else
                {
                    balanceInfo.Color = Color.LightGreen;
                    balanceInfo.BalanceTypeText = Definitions.DEBIT_STRING;
                }

                return balanceInfo;
            }
        }

        private ReleasedFilter m_Filter;

        private ReleasedFilter Filter { get => m_Filter; set => m_Filter = value; }

        public TabReleased()
        {
            InitializeComponent();
            InitForm();
            InitListView();
            InitContextMenuStrip();
            InitContextMenuStripValues();
            ListviewSelectedIndex = 0;
            SelectedItemId = 0;
            SQLiteManager.GetInstance().Released().SetCommandSet();
            UseCheckox = true;
        }

        private void InitContextMenuStripValues()
        {
            Dictionary<string, bool> contextMenuStripValues = new Dictionary<string, bool>();
            contextMenuStripValues = new Dictionary<string, bool>
            {
                { "addOnItem", false },
                { "editOnItem", false },
                { "removeOnItem", true },
                { "addOnSpace", false },
                { "editOnSpace", false },
                { "removeOnSpace", false }
            };

            ContextMenuStripValues = contextMenuStripValues;
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "TabDemand";
            this.Text = "TabDemand";

            ReleasedFilter.Filtration += ReleasedFiltration;
        }

        public override void InitListView()
        {
            base.InitListView();

            lvReleased.View = View.Details;
            lvReleased.FullRowSelect = true;
            lvReleased.Scrollable = true;
            lvReleased.GridLines = true;
            lvReleased.CheckBoxes = true;
            lvReleased.OwnerDraw = true;
            lvReleased.HeaderStyle = ColumnHeaderStyle.Clickable;
            lvReleased.DoubleBuffered(true);
            // Добавление столбцов
            // Необходимо добавлять столбцы именно так, иначе ColumnHeader не сможет преобразоваться в ColHeader (используется в методе сортировки)
            lvReleased.Columns.Clear();

            List<ColumnSettings> lvReleasedSettings = UISettings.GetInstance().LvReleasedSettings.GetColumnSettingsList();

            foreach (var colSettings in lvReleasedSettings)
            {
                lvReleased.Columns.Add(new ColHeader(colSettings.Text, colSettings.Width, colSettings.Align, colSettings.Ascending));
            }
        }

        private void btnReleasedRemove_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        /// <summary>
        /// Удаление записи из таблицы
        /// </summary>
        public override void RemoveRecord()
        {
            if (m_Listview.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().Released().CancelDemand(SelectedItemId);
                RemoveFromListViewAt(ListviewSelectedIndex);
                UpdateTable();        
                m_Listview.SelectedItems.Clear();
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
            if (m_Listview.SelectedItems.Count > 0)
            {
                SQLiteManager.GetInstance().Released().CancelDebit(SelectedItemId);
                ShowTable();
            }
            else
            {
                MessageBox.Show(Definitions.REMOVE_WARNING_STRING);
            }
        }

        protected override ListView GetListView()
        {
            return lvReleased;
        }

        protected override ContextMenuStrip GetContextMenuStrip()
        {
            return contextMenuStripReleased;
        }

        public override DataSet ReturnDataSet()
        {
            return SQLiteManager.GetInstance().Released().ReturnDataSet();
        }

        private void UpdateTable()
        {
            DataSet dataSet = ReturnDataSet();
            try
            {
                m_Listview.BeginUpdate();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem
                        {
                            Text = dataSet.Tables[0].Rows[i][j].ToString(),
                            Name = dataSet.Tables[0].Columns[j].ToString()
                        };
                        if (subitem.Name == "document")
                        {
                            lvReleased.Items[i].SubItems["document"].Tag = subitem.Text;
                            lvReleased.Items[i].SubItems["document"].Text = Path.GetFileName(subitem.Text);
                        }
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
            catch (Exception ex)
            {
                MessageBox.Show("Exception", ex.Message);
            }
            finally
            {
                dataSet.Dispose();
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
                m_Listview.Columns[0].Tag = false;

                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    ListViewItem newItem = new ListViewItem
                    {
                        Text = (i + 1).ToString(),
                        Name = dataSet.Tables[0].Rows[i]["demandId"].ToString()
                    };
                    newItem.Tag = new ReleasedIds
                    {
                        inventoryId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["id"]),
                        demandId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["demandId"])
                    };
                    m_Listview.Items.Add(newItem);

                    for (int j = 1; j < dataSet.Tables[0].Columns.Count; j++)
                    {
                        ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem
                        {
                            Text = dataSet.Tables[0].Rows[i][j].ToString(),
                            Name = dataSet.Tables[0].Columns[j].ToString()
                        };
                        // Костыль для правильного отображения количества тмц (десятичные знаки после запятой)
                        if (subitem.Name == "amount")
                        {
                            int l_DecimalPlaces = SQLiteSettingsManager.GetInstance().Measurement().GetDecimalPlacesByName(dataSet.Tables[0].Rows[i]["measurement"].ToString());
                            subitem.Text = String.Format($"{{0:n{l_DecimalPlaces}}}", dataSet.Tables[0].Rows[i][j]);
                        }
                        else if (subitem.Name == "price" || subitem.Name == "sum")
                        {
                            subitem.Text = Convert.ToDecimal(subitem.Text, CultureInfo.InvariantCulture).ToString("C");
                        }

                        if (subitem.Name == "document")
                        {
                            subitem.BackColor = Color.LightBlue;
                            subitem.Tag = subitem.Text;
                            subitem.Text = Path.GetFileName(subitem.Text);
                        }

                        if (subitem.Name == "balance")
                        {
                            object balance = dataSet.Tables[0].Rows[i]["balance"];
                            object amount = dataSet.Tables[0].Rows[i]["amount"];
                            BalanceInfo balanceInfo = BalanceInfo.GetBalanceInfo(balance, amount);

                            subitem.Tag = balanceInfo;
                            subitem.BackColor = balanceInfo.Color;
                            subitem.Text = balanceInfo.BalanceTypeText;
                        }

                        if (subitem.Name != "demandId")
                        {
                            m_Listview.Items[i].SubItems.Add(subitem);
                        }
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
                Filter = new ReleasedFilter();
                Filter.Dock = DockStyle.Top;
                Filter.TopLevel = false;
                Filter.MdiParent = MdiParent;
                Filter.Parent = Parent;
                Filter.Show();
            }
            else if (Filter.IsHandleCreated)
            {
                Filter.Close();
            }
        }

        private void ReleasedFiltration()
        {
            ShowTable();
        }

        #region DRAW CHECKBOXES

        private void lvReleased_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                    new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void lvReleased_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvReleased_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        #endregion

        public override void ListViewItemMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                base.ListViewItemMouseUp(sender, e);

                if (e.Button == MouseButtons.Left)
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

        /// <summary>
        /// Списать выбранные тмц
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDebitReport_Click(object sender, EventArgs e)
        {
            if (lvReleased.CheckedItems.Count > 0)
            {
                DebitEditor editor = new DebitEditor(GetDebitDataSet());
                editor.StartPosition = FormStartPosition.CenterParent;
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    ShowTable();
                }
            }
            else
            {
                MessageBox.Show(Definitions.DEBIT_SELECTION_WARNING_STRING);
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

            foreach (ListViewItem item in lvReleased.CheckedItems)
            {
                DataRow newRow = debitTable.NewRow();

                newRow["id"] = (item.Tag as ReleasedIds).inventoryId;
                newRow["demandId"] = (item.Tag as ReleasedIds).demandId;
                newRow["date"] = item.SubItems["ordate"].Text;
                newRow["invoice_code"] = item.SubItems["invoiceCodeStr"].Text;
                newRow["invoiceDate"] = item.SubItems["invoiceDate"].Text;
                newRow["name"] = item.SubItems["name"].Text;
                newRow["OKEIcode"] = item.SubItems["OKEIcode"].Text;
                newRow["measurement"] = item.SubItems["measurement"].Text;
                newRow["price"] = item.SubItems["price"].Text;
                newRow["balance"] = CalculateBalance(item);
                newRow["debit_amount"] = 0;
                newRow["sum"] = item.SubItems["sum"].Text;

                debitTable.Rows.Add(newRow);
            }

            DataSet debitDataSet = new DataSet("Report");
            debitDataSet.Tables.Add(debitTable);

            return debitDataSet;
        }

        private static object CalculateBalance(ListViewItem item)
        {
            object balance = (item.SubItems["balance"].Tag as BalanceInfo).Balance;
            object balanceValue = null;
            if (balance != null && !Equals(balance, DBNull.Value))
            {
                balanceValue = balance;
            }
            else
            {
                balanceValue = item.SubItems["amount"].Text;
            }

            return balanceValue;
        }

        private void lvReleased_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            DataSet dataSet = SQLiteManager.GetInstance().Released().ReturnDataSet();

            object l_Balance = dataSet.Tables[0].Rows[e.Index]["balance"];
            if (!Equals(l_Balance, DBNull.Value))
            {
                decimal l_BalanceValue = Convert.ToDecimal(l_Balance);

                if (l_BalanceValue <= 0 && e.CurrentValue == CheckState.Unchecked)
                {
                    MessageBox.Show(Definitions.ALREADY_DEBIT_WARNING);
                }
            }
        }

        private void lvReleased_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            List<ColumnSettings> lvNewSettings = UISettings.GetInstance().LvReleasedSettings.GetColumnSettingsList();

            if (lvNewSettings != null)
            {
                lvNewSettings[e.ColumnIndex].Width = lvReleased.Columns[e.ColumnIndex].Width;

                UISettings.GetInstance().LvReleasedSettings.SetColumnSettingsList(lvNewSettings);
            }

            if (lvReleased.Columns[e.ColumnIndex].Width < Definitions.MIN_COLUMN_WIDTH)
            {
                lvReleased.Columns[e.ColumnIndex].Width = Definitions.MIN_COLUMN_WIDTH;
            }
        }
    }
}

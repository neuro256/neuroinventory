using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class MainForm : Form
    {
        Dictionary<string, IInventoryView> inventoryTabs;

        public MainForm()
        {
            InitializeComponent();
            inventoryTabs = new Dictionary<string, IInventoryView>();
            InitEmptyTabs();
        }

        private void InitEmptyTabs()
        {
            TabEmpty tabMain = new TabEmpty();
            tabMain.MdiParent = this;
            tabMain.Parent = tabControl.TabPages[0];
            tabMain.Dock = DockStyle.Fill;
            tabMain.Show();
            inventoryTabs["tabEmpty1"] = tabMain;

            TabEmpty tabProviders = new TabEmpty();
            tabProviders.MdiParent = this;
            tabProviders.Parent = tabControl.TabPages[1];
            tabProviders.Dock = DockStyle.Fill;
            tabProviders.Show();
            inventoryTabs["tabEmpty2"] = tabProviders;

            TabEmpty tabEmployees = new TabEmpty();
            tabEmployees.MdiParent = this;
            tabEmployees.Parent = tabControl.TabPages[2];
            tabEmployees.Dock = DockStyle.Fill;
            tabEmployees.Show();
            inventoryTabs["tabEmpty3"] = tabEmployees;
        }

        private void InitTabs()
        {
            // Закрытие открытых вкладок
            if (inventoryTabs != null && inventoryTabs.Values.Count > 0)
            {
                foreach (IInventoryView tab in inventoryTabs.Values)
                {
                    tab.Exit();
                }
                inventoryTabs.Clear();
            }

            TabMain tabMain = new TabMain();
            tabMain.MdiParent = this;
            tabMain.Parent = tabControl.TabPages[0];
            tabMain.Dock = DockStyle.Fill;
            tabMain.OnSelectedInventory += TabMain_OnSelectedInventory;
            tabMain.Show();
            inventoryTabs["tabInventory"] = tabMain;

            TabProviders tabProviders = new TabProviders();
            tabProviders.MdiParent = this;
            tabProviders.Parent = tabControl.TabPages[1];
            tabProviders.Dock = DockStyle.Fill;
            tabProviders.Show();
            inventoryTabs["tabProviders"] = tabProviders;

            TabEmployees tabEmployees = new TabEmployees();
            tabEmployees.MdiParent = this;
            tabEmployees.Parent = tabControl.TabPages[2];
            tabEmployees.Dock = DockStyle.Fill;
            tabEmployees.Show();
            inventoryTabs["tabEmployees"] = tabEmployees;
        }

        private void TabMain_OnSelectedInventory(string name)
        {
            tabControl.SuspendLayout();
            tabControl.TabPages["tabInventory"].Text = $"ТМЦ : {name}";
            tabControl.ResumeLayout();
        }

        private void createBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Базы данных SQLite (*.db)|*.db";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateBase(saveFileDialog.FileName);
            }
        }

        private void CreateBase(string p_FileName)
        {
            SQLiteManager.GetInstance().CreateDatabase(p_FileName);
            SQLiteManager.GetInstance().CreateTables();
            InitTabs();
        }

        private void openBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Базы данных SQLite (*.db)|*.db";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadBase(openFileDialog.FileName);
            }
        }

        private void LoadBase(string p_DatabaseName)
        {
            SQLiteManager.GetInstance().databaseName = p_DatabaseName;
            if (SQLiteManager.GetInstance().TestConnection())
            {
                InitTabs();
                if (inventoryTabs.ContainsKey(tabControl.SelectedTab.Name))
                    inventoryTabs[tabControl.SelectedTab.Name].ShowTable();
                SQLiteManager.GetInstance().IsOpened = true;
            }
            else
            {
                SQLiteManager.GetInstance().databaseName = String.Empty;
                MessageBox.Show(Definitions.DB_INCORRECT);
            }
        }

        private void saveBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SQLiteManager.GetInstance().IsCreated && !SQLiteManager.GetInstance().IsOpened)
            {
                MessageBox.Show(Definitions.BD_NOT_CREATED_OR_OPENED);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Базы данных SQLite (*.db)|*.db";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveBase(saveFileDialog.FileName);
            }
        }

        private void SaveBase(string p_FileName)
        {
            try
            {
                if(String.IsNullOrEmpty(NeuroFile.GetInstance().CopyDataBase(SQLiteManager.GetInstance().databaseName, p_FileName)))
                {
                    MessageBox.Show(Definitions.DB_SUCCESSFULLY_SAVED);
                }
            }
            catch { }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inventoryTabs != null && inventoryTabs.ContainsKey(tabControl.SelectedTab.Name))
                inventoryTabs[tabControl.SelectedTab.Name].ShowTable();
        }

        private void единицыИзмеренияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeasurementEditor editor = new MeasurementEditor();
            editor.StartPosition = FormStartPosition.CenterParent;
            editor.ShowDialog();
        }

        private void настройкиПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthenticationEditor authEditor = new AuthenticationEditor();
            authEditor.StartPosition = FormStartPosition.CenterParent;
            authEditor.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Definitions.APPLICATION_CLOSE_QUESTION, Definitions.APPLICATION_CLOSE_DIALOG_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void toolStripButtonCreateBD_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Базы данных SQLite (*.db)|*.db";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                CreateBase(saveFileDialog.FileName);
            }
        }

        private void toolStripButtonOpenBD_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Базы данных SQLite (*.db)|*.db";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadBase(openFileDialog.FileName);
            }
        }

        private void toolStripButtonSaveBD_Click(object sender, EventArgs e)
        {
            if (!SQLiteManager.GetInstance().IsCreated && !SQLiteManager.GetInstance().IsOpened)
            {
                MessageBox.Show(Definitions.BD_NOT_CREATED_OR_OPENED);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Базы данных SQLite (*.db)|*.db";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveBase(saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// Создание отчета требование-накладная 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonDemandReport_Click(object sender, EventArgs e)
        {
            DemandReportViewSelector();
        }

        /// <summary>
        /// Создание отчета списание
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonDebitReport_Click(object sender, EventArgs e)
        {
            DebitReportViewSelector();
        }

        private void DemandReportViewSelector()
        {
            if (!SQLiteManager.GetInstance().IsCreated && !SQLiteManager.GetInstance().IsOpened)
            {
                MessageBox.Show(Definitions.BD_NOT_CREATED_OR_OPENED);
                return;
            }

            ReportViewSelection viewSelection = new ReportViewSelection();
            viewSelection.StartPosition = FormStartPosition.CenterParent;
            if (viewSelection.ShowDialog() == DialogResult.OK)
            {
                OpenDemandReport();
            }
            else
            {
                OpenDemandReportList();
            }
        }

        private void DebitReportViewSelector()
        {
            if (!SQLiteManager.GetInstance().IsCreated && !SQLiteManager.GetInstance().IsOpened)
            {
                MessageBox.Show(Definitions.BD_NOT_CREATED_OR_OPENED);
                return;
            }

            ReportViewSelection viewSelection = new ReportViewSelection();
            viewSelection.StartPosition = FormStartPosition.CenterParent;
            if (viewSelection.ShowDialog() == DialogResult.OK)
            {
                OpenDebitReport();
            }
            else
            {
                OpenDebitReportList();
            }
        }

        private void OpenDemandReport()
        {
            if (!SQLiteManager.GetInstance().IsCreated && !SQLiteManager.GetInstance().IsOpened)
            {
                MessageBox.Show(Definitions.BD_NOT_CREATED_OR_OPENED);
                return;
            }

            DemandReport report = new DemandReport();
            report.StartPosition = FormStartPosition.CenterParent;
            report.ShowDialog();
        }

        private void OpenDebitReport()
        {
            if (!SQLiteManager.GetInstance().IsCreated && !SQLiteManager.GetInstance().IsOpened)
            {
                MessageBox.Show(Definitions.BD_NOT_CREATED_OR_OPENED);
                return;
            }

            DebitReport report = new DebitReport();
            report.StartPosition = FormStartPosition.CenterParent;
            report.ShowDialog();
        }

        private void OpenDemandReportList()
        {
            if (!SQLiteManager.GetInstance().IsCreated && !SQLiteManager.GetInstance().IsOpened)
            {
                MessageBox.Show(Definitions.BD_NOT_CREATED_OR_OPENED);
                return;
            }

            DemandReportList reportList = new DemandReportList();
            reportList.StartPosition = FormStartPosition.CenterParent;
            reportList.ShowDialog();
        }

        private void OpenDebitReportList()
        {
            if (!SQLiteManager.GetInstance().IsCreated && !SQLiteManager.GetInstance().IsOpened)
            {
                MessageBox.Show(Definitions.BD_NOT_CREATED_OR_OPENED);
                return;
            }

            DebitReportList reportList = new DebitReportList();
            reportList.StartPosition = FormStartPosition.CenterParent;
            reportList.ShowDialog();
        }

        private void demandReportEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDemandReport();
        }

        private void demandReportListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDemandReportList();
        }

        private void debitReportEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDebitReport();
        }

        private void debitReportListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDebitReportList();
        }

        private void aboutBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.StartPosition = FormStartPosition.CenterParent;
            aboutBox.ShowDialog();
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class MainForm : Form
    {
        Dictionary<string, IInventoryView> inventoryTabs;
        private readonly object counts = 25;

        public object Counts => counts;

        public MainForm()
        {
            InitializeComponent();
            inventoryTabs = new Dictionary<string, IInventoryView>();
            InitEmptyTabs();
            TabRecent.LoadRecentFile += TabRecent_LoadRecentFile;
            Numeration.GetInstance().ParseDocNumeration();
            UISettings.GetInstance().ParseSettings();
            //CheckDemo();
        }

        private void TabRecent_LoadRecentFile(string path)
        {
            LoadBase(path);
        }

        #region DEMO

        private void CheckDemo()
        {
            Demo();
            RegistryKey reg = Registry.CurrentUser;
            reg = reg.OpenSubKey(@"Software\NeuroInventory", true);
            int count = Convert.ToInt32(reg.GetValue("StartsCount"));
            if (count != 0)
            {
                MessageBox.Show("Осталось пробных открытий:" + count);
            }
            if (count == 0)
            {
                MessageBox.Show("Пробные открытия закончились:" + count);
                Environment.Exit(0);
            }
        }

        private void Demo()
        {
            RegistryKey regedit = Registry.CurrentUser;
            regedit = regedit.OpenSubKey("Software", true);
            if (Registry.CurrentUser.OpenSubKey(@"Software\NeuroInventory") == null)
            {
                regedit = regedit.CreateSubKey("NeuroInventory", true);//ProgramName - Название программы в реестре
                regedit.SetValue("StartsCount", Counts);//MyFirtsProgram - Название значение программы/Opencount - колчество пробных открытий
            }
            else
            {
                RegistryKey reg = Registry.CurrentUser;
                reg = reg.OpenSubKey(@"Software\NeuroInventory", true);
                int count = Convert.ToInt32(reg.GetValue("StartsCount"));
                if (count > 0)
                {
                    count--;
                }
                reg.SetValue("StartsCount", count);
            }
        }

        #endregion

        private void InitEmptyTabs()
        {
            if (SQLiteSettingsManager.GetInstance().Recents().ReturnCount() > 0)
            {
                TabRecent tabMain = new TabRecent();
                tabMain.MdiParent = this;
                tabMain.Parent = tabControl.TabPages[0];
                tabMain.Dock = DockStyle.Fill;
                tabMain.Show();
                inventoryTabs["tabInventory"] = tabMain;

                TabRecent tabReleased = new TabRecent();
                tabReleased.MdiParent = this;
                tabReleased.Parent = tabControl.TabPages[1];
                tabReleased.Dock = DockStyle.Fill;
                tabReleased.Show();
                inventoryTabs["tabReleased"] = tabReleased;

                TabRecent tabProviders = new TabRecent();
                tabProviders.MdiParent = this;
                tabProviders.Parent = tabControl.TabPages[2];
                tabProviders.Dock = DockStyle.Fill;
                tabProviders.Show();
                inventoryTabs["tabProviders"] = tabProviders;

                TabRecent tabEmployees = new TabRecent();
                tabEmployees.MdiParent = this;
                tabEmployees.Parent = tabControl.TabPages[3];
                tabEmployees.Dock = DockStyle.Fill;
                tabEmployees.Show();
                inventoryTabs["tabEmployees"] = tabEmployees;

                if (inventoryTabs.ContainsKey(tabControl.SelectedTab.Name))
                    inventoryTabs[tabControl.SelectedTab.Name].ShowTable();
            }
            else
            {
                for(int i = 0; i < tabControl.TabPages.Count; i++)
                {
                    TabEmpty tabEmpty = new TabEmpty();
                    tabEmpty.MdiParent = this;
                    tabEmpty.Parent = tabControl.TabPages[i];
                    tabEmpty.Dock = DockStyle.Fill;
                    tabEmpty.Show();
                    inventoryTabs[$"tabEmpty{i+1}"] = tabEmpty;
                }
            }
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
            tabMain.Show();
            inventoryTabs["tabInventory"] = tabMain;

            TabReleased tabReleased = new TabReleased();
            tabReleased.MdiParent = this;
            tabReleased.Parent = tabControl.TabPages[1];
            tabReleased.Dock = DockStyle.Fill;
            tabReleased.Show();
            inventoryTabs["tabReleased"] = tabReleased;

            TabProviders tabProviders = new TabProviders();
            tabProviders.MdiParent = this;
            tabProviders.Parent = tabControl.TabPages[2];
            tabProviders.Dock = DockStyle.Fill;
            tabProviders.Show();
            inventoryTabs["tabProviders"] = tabProviders;

            TabEmployees tabEmployees = new TabEmployees();
            tabEmployees.MdiParent = this;
            tabEmployees.Parent = tabControl.TabPages[3];
            tabEmployees.Dock = DockStyle.Fill;
            tabEmployees.Show();
            inventoryTabs["tabEmployees"] = tabEmployees;
        }

        private void CreateBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogName dialogName = new DialogName();
            dialogName.StartPosition = FormStartPosition.CenterParent;
            if(dialogName.ShowDialog() == DialogResult.OK)
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Учет ТМЦ", dialogName.name);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string extStr = ".db";
                string fileName = Path.Combine(path, dialogName.name + extStr);
                CreateBase(fileName);
            }
        }

        private void CreateBase(string p_FileName)
        {
            SQLiteManager.GetInstance().CreateDatabase(p_FileName);
            SQLiteManager.GetInstance().CreateTables();
            InitTabs();
            SQLiteSettingsManager.GetInstance().Recents().Insert(p_FileName);
        }

        private void OpenBDToolStripMenuItem_Click(object sender, EventArgs e)
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
                SQLiteManager.GetInstance().UpdateDatabase();
                InitTabs();
                if (inventoryTabs.ContainsKey(tabControl.SelectedTab.Name))
                    inventoryTabs[tabControl.SelectedTab.Name].ShowTable();
                SQLiteManager.GetInstance().IsOpened = true;
                SQLiteSettingsManager.GetInstance().Recents().Insert(p_DatabaseName);
            }
            else
            {
                SQLiteManager.GetInstance().databaseName = String.Empty;
                MessageBox.Show(Definitions.DB_INCORRECT);
            }
        }

        private void SaveBDToolStripMenuItem_Click(object sender, EventArgs e)
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
                if(String.IsNullOrEmpty(NeuroFile.CopyDataBase(SQLiteManager.GetInstance().databaseName, p_FileName)))
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
            UISettings.GetInstance().WriteSettings();
            Numeration.GetInstance().WriteDocNumeration();
        } 

        /// <summary>
        /// Создание отчета требование-накладная 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonDemandReport_Click(object sender, EventArgs e)
        {
            //DemandReportViewSelector();
            OpenDemandReportList();
        }

        /// <summary>
        /// Создание отчета списание
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonDebitReport_Click(object sender, EventArgs e)
        {
            //DebitReportViewSelector();
            OpenDebitReportList();
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

        private void AboutBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.StartPosition = FormStartPosition.CenterParent;
            aboutBox.ShowDialog();
        }

        private void SettingDocNumerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingDocumentNumeration docNum = new SettingDocumentNumeration();
            docNum.StartPosition = FormStartPosition.CenterParent;
            docNum.ShowDialog();
        }
    }
}

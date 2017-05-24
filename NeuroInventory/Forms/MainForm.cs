using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class MainForm : Form
    {
        Dictionary<string, IInventoryView> inventoryTabs;

        public MainForm()
        {
            InitializeComponent();        }

        private void InitTabs()
        {
            inventoryTabs = new Dictionary<string, IInventoryView>();

            TabMain tabMain = new TabMain();
            tabMain.MdiParent = this;
            tabMain.Parent = tabControl.TabPages[0];
            tabMain.Dock = DockStyle.Fill;
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
            SQLiteManager.GetInstance().databaseName = p_FileName;
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
                if(inventoryTabs.ContainsKey(tabControl.SelectedTab.Name))
                    inventoryTabs[tabControl.SelectedTab.Name].ShowTable();
            }
        }

        private void saceBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Базы данных SQLite (*.db)|*.db";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveBase(saveFileDialog.FileName);
            }
        }

        private void SaveBase(string p_FileName)
        {
            SQLiteManager.GetInstance().databaseName = p_FileName;
            if (SQLiteManager.GetInstance().TestConnection())
                MessageBox.Show("База данных успешно сохранена");
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
    }
}

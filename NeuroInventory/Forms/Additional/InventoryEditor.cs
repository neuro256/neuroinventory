using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class InventoryEditor : Form
    {
        private EditorMode m_EditorMode;
        private int m_ListviewSelectedIndex;
        private object m_SelectedRecordId;

        public InventoryEditor()
        {
            InitializeComponent();
            m_EditorMode = EditorMode.INSERT;
            cbProviders.Focus();
        }

        public InventoryEditor(int p_Id)
        {
            InitializeComponent();
            m_EditorMode = EditorMode.UPDATE;
            m_ListviewSelectedIndex = p_Id;
            ShowInfo();
            cbProviders.Focus();
        }

        // TODO
        private void ShowInfo()
        {
            DataSet dataSet = SQLiteManager.GetInstance().Inventory().ReturnDataSet();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();

            // TODO
            if(m_EditorMode == EditorMode.UPDATE)
            {

            }
            else
            {

            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

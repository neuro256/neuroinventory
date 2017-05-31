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
    public partial class DialogName : Form
    {
        public string name { get; private set; }
        public DialogName()
        {
            InitializeComponent();
            tbName.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!IsValidData())
                return;
            name = tbName.Text.Trim();
            DialogResult = DialogResult.OK;
        }

        private bool IsValidData()
        {
            errorProviderName.Clear();

            if (String.IsNullOrEmpty(tbName.Text))
            {
                errorProviderName.SetError(tbName, Definitions.BLANK_NAME_WARNING_STRING);
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.Cancel;
        }

        private void tbName_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnOK.Focus();
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            errorProviderName.Clear();
        }
    }
}

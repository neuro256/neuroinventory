using System;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class ReportViewSelection : Form
    {
        public ReportViewSelection()
        {
            InitializeComponent();
        }

        private void btnReportEditor_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnReportList_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}

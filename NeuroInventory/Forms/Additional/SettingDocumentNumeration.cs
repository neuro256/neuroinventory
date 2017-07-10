using System;
using System.Windows.Forms;

namespace NeuroInventory
{
    public partial class SettingDocumentNumeration : Form
    {
        public SettingDocumentNumeration()
        {
            InitializeComponent();
        }

        private void SettingDocumentNumeration_Load(object sender, EventArgs e)
        {
            NeuroFile.GetInstance().ParseDocNumeration();

            nudDemandNumeration.Value = NeuroFile.GetInstance().DemandNumeration.DocCurrentNumber;
            tbDemandPrefix.Text = NeuroFile.GetInstance().DemandNumeration.DocPrefix;
            cbDemandDate.Checked = NeuroFile.GetInstance().DemandNumeration.IncludeDate;

            nudDebitNumeration.Value = NeuroFile.GetInstance().DebitNumeration.DocCurrentNumber;
            tbDebitPrefix.Text = NeuroFile.GetInstance().DebitNumeration.DocPrefix;
            cbDebitDate.Checked = NeuroFile.GetInstance().DebitNumeration.IncludeDate;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DocumentNumeration demandNum = new DocumentNumeration((int)nudDemandNumeration.Value, tbDemandPrefix.Text, cbDemandDate.Checked);
            DocumentNumeration debitNum = new DocumentNumeration((int)nudDebitNumeration.Value, tbDebitPrefix.Text, cbDebitDate.Checked);

            NeuroFile.GetInstance().WriteDocNumeration(new DocumentNumeration[] { demandNum, debitNum });

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

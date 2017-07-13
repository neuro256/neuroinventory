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
            Numeration.GetInstance().ParseDocNumeration();

            nudDemandNumeration.Value = Numeration.GetInstance().DemandNumeration.DocCurrentNumber;
            tbDemandPrefix.Text = Numeration.GetInstance().DemandNumeration.DocPrefix;
            cbDemandDate.Checked = Numeration.GetInstance().DemandNumeration.IncludeDate;

            nudDebitNumeration.Value = Numeration.GetInstance().DebitNumeration.DocCurrentNumber;
            tbDebitPrefix.Text = Numeration.GetInstance().DebitNumeration.DocPrefix;
            cbDebitDate.Checked = Numeration.GetInstance().DebitNumeration.IncludeDate;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DocumentNumeration demandNum = new DocumentNumeration((int)nudDemandNumeration.Value, tbDemandPrefix.Text, cbDemandDate.Checked);
            DocumentNumeration debitNum = new DocumentNumeration((int)nudDebitNumeration.Value, tbDebitPrefix.Text, cbDebitDate.Checked);

            Numeration.GetInstance().WriteDocNumeration(new DocumentNumeration[] { demandNum, debitNum });

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

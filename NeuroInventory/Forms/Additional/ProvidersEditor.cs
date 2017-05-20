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
    public partial class ProvidersEditor : Form
    {
        public ProvidersEditor()
        {
            InitializeComponent();
        }

        private void tbLink_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "Файлы документов (*.doc, *jpeg, *jpg, *png)|*.doc, *jpeg, *jpg, *png";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                tbLink.Text = openFileDialog.FileName;
            }
        }
    }
}

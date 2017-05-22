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
        private int m_ListviewSelectedIndex;

        public InventoryEditor()
        {
            InitializeComponent();
        }

        public InventoryEditor(int m_ListviewSelectedIndex)
        {
            this.m_ListviewSelectedIndex = m_ListviewSelectedIndex;
        }
    }
}

using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;

namespace NeuroInventory
{
    public partial class TabEmpty : InventoryView
    {
        public TabEmpty()
        {
            InitializeComponent();
        }

        protected override void InitForm()
        {
            base.InitForm();

            this.Name = "tabEmpty";
            this.Text = "tabEmpty";
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

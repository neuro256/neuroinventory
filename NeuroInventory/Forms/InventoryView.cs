using BrightIdeasSoftware;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class InventoryView : Form, IInventoryView
    {
        private int listviewSelectedIndex;
        protected DataListView mDataListView = null;
        protected ContextMenuStrip m_ContextMenuStrip = null;
        private HighlightTextRenderer highlightTextRenderer1;
        private bool isRebuilded = false;

        protected int ListviewSelectedIndex { get => listviewSelectedIndex; set => listviewSelectedIndex = value; }
        public bool IsRebuilded { get => isRebuilded; set => isRebuilded = value; }

        protected virtual void InitForm()
        {
            this.Size = new System.Drawing.Size(1200, 650);
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
        }

        public virtual void InitListView()
        {
            mDataListView = GetListView();
            mDataListView.AutoGenerateColumns = false;
            mDataListView.FullRowSelect = true;
            mDataListView.GridLines = true;
            mDataListView.HideSelection = false;
            mDataListView.ShowGroups = false;
            mDataListView.SelectColumnsOnRightClickBehaviour = ObjectListView.ColumnSelectBehaviour.Submenu;
            mDataListView.ShowCommandMenuOnRightClick = true;
            mDataListView.ShowItemToolTips = true;
            mDataListView.UseCellFormatEvents = true;
            mDataListView.UseFilterIndicator = true;
            mDataListView.UseFiltering = true;
            mDataListView.SelectedBackColor = Color.LightBlue;
            mDataListView.SelectedForeColor = Color.MidnightBlue;
            mDataListView.RowHeight = Definitions.ROW_HEIGHT;
            mDataListView.DoubleBuffered(true);
            mDataListView.FormatRow += delegate (object sender, FormatRowEventArgs args)
            {
                args.Item.Text = (args.RowIndex + 1).ToString();
            };
            mDataListView.SelectedObject = null;
            mDataListView.SelectedObjects = null;
            // highlightrenderer
            highlightTextRenderer1 = new HighlightTextRenderer();
            highlightTextRenderer1.CornerRoundness = 0.0f;
            highlightTextRenderer1.FramePen = new Pen(Color.MidnightBlue);
            highlightTextRenderer1.FillBrush = new SolidBrush(Color.LightBlue);
            mDataListView.DefaultRenderer = highlightTextRenderer1;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveRecord();
        }

        public virtual void RebuildList() { }
        public virtual DataSet ReturnDataSet() { return null; }
        public virtual void AddRecord() { }
        public virtual void RemoveRecord() { }
        public virtual void UpdateRecord() { }
        public virtual void Clear() { }
        protected virtual DataListView GetListView() { return null; }
        public virtual void SaveState() { }
        public virtual void RestoreState() { }

        public virtual void Exit()
        {
            Close();
        }

        public void TimedFilter(ObjectListView olv, string txt, int matchKind)
        {
            TextMatchFilter filter = null;
            if (!String.IsNullOrEmpty(txt))
            {
                switch (matchKind)
                {
                    case 0:
                    default:
                        filter = TextMatchFilter.Contains(olv, txt);
                        break;
                    case 1:
                        filter = TextMatchFilter.Prefix(olv, txt);
                        break;
                    case 2:
                        filter = TextMatchFilter.Regex(olv, txt);
                        break;
                }
            }

            // Text highlighting requires at least a default renderer
            if (olv.DefaultRenderer == null)
                olv.DefaultRenderer = new HighlightTextRenderer(filter);

            olv.AdditionalFilter = filter;
        }

        private void InitializeComponent()
        {
            this.highlightTextRenderer1 = new BrightIdeasSoftware.HighlightTextRenderer();
            this.SuspendLayout();
            // 
            // InventoryView
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "InventoryView";
            this.ResumeLayout(false);

        }
    }
}

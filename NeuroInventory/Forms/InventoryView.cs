using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class InventoryView : Form, IInventoryView
    {
        private int listviewSelectedIndex;
        private int selectedItemId;
        protected ContextMenuStrip m_ContextMenuStrip = null;
        private bool useCheckox = false;
        private Dictionary<string, bool> contextMenuStripValues = null;

        protected bool UseCheckox { get => useCheckox; set => useCheckox = value; }
        protected int ListviewSelectedIndex { get => listviewSelectedIndex; set => listviewSelectedIndex = value; }
        protected int SelectedItemId { get => selectedItemId; set => selectedItemId = value; }
        protected Dictionary<string, bool> ContextMenuStripValues { get => contextMenuStripValues; set => contextMenuStripValues = value; }

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
            //m_Listview = GetListView();
            //m_Listview.View = View.Details;
            //m_Listview.FullRowSelect = true;
            //m_Listview.MultiSelect = false;
            //m_Listview.BorderStyle = BorderStyle.None;
            //m_Listview.Scrollable = true;
            //m_Listview.GridLines = true;
            //m_Listview.ShowItemToolTips = true;
            //m_Listview.MinimumSize = new System.Drawing.Size(0, 0);
            //m_Listview.ItemSelectionChanged += ListViewItemSelectionChanged;
            //m_Listview.ColumnClick += ListViewColumnClick;
            //m_Listview.MouseDoubleClick += ListViewItemDoubleClick;
            //m_Listview.MouseUp += ListViewItemMouseUp;
        }

        public void InitContextMenuStrip()
        {
            m_ContextMenuStrip = GetContextMenuStrip();
            // Создаем элементы меню и добавляем их
            ToolStripMenuItem addMenuItem = new ToolStripMenuItem("Добавить");
            addMenuItem.Name = "addToolStripMenuItem";
            addMenuItem.Click += addToolStripMenuItem_Click;
            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Редактировать");
            editMenuItem.Name = "editToolStripMenuItem";
            editMenuItem.Click += editToolStripMenuItem_Click;
            ToolStripMenuItem removeMenuItem = new ToolStripMenuItem("Удалить");
            removeMenuItem.Name = "removeToolStripMenuItem";
            removeMenuItem.Click += removeToolStripMenuItem_Click;
            m_ContextMenuStrip.Items.Clear();
            m_ContextMenuStrip.Items.AddRange(new[] { addMenuItem, editMenuItem, removeMenuItem });
            // Значения contextMenuStrip в различных ситациях по умолчанию 
            contextMenuStripValues = new Dictionary<string, bool>();
            contextMenuStripValues.Add("addOnItem", false);
            contextMenuStripValues.Add("editOnItem", true);
            contextMenuStripValues.Add("removeOnItem", true);
            contextMenuStripValues.Add("addOnSpace", true);
            contextMenuStripValues.Add("editOnSpace", false);
            contextMenuStripValues.Add("removeOnSpace", false);
            // Ассоциируем контекстное меню со списком
            //m_Listview.ContextMenuStrip = m_ContextMenuStrip;
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

        public virtual DataSet ReturnDataSet() { return null; }
        public virtual void AddRecord() { }
        public virtual void RemoveRecord() { }
        public virtual void UpdateRecord() { }
        public virtual void Clear() { }
        //protected virtual ListView GetListView() { return null; }
        protected virtual ContextMenuStrip GetContextMenuStrip() { return null; }
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
    }
}

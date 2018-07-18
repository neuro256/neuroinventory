using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    interface IInventoryView
    {
        void InitListView();
        void InitContextMenuStrip();
        void ShowTable();
        void AddRecord();
        void RemoveRecord();
        void UpdateRecord();
        void ListViewItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e);
        void ListViewColumnClick(object sender, ColumnClickEventArgs e);
        void ListViewItemDoubleClick(object sender, MouseEventArgs e);
        void ListViewItemMouseUp(object sender, MouseEventArgs e);
        void SaveState();
        void RestoreState();
        void Clear();
        void Exit();
    }
}

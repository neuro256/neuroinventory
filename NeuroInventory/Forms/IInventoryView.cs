using System.Data;
using System.Windows.Forms;

namespace NeuroInventory
{
    interface IInventoryView
    {
        void InitListView();
        void InitContextMenuStrip();
        void AddRecord();
        void RemoveRecord();
        void UpdateRecord();
        void SaveState();
        void RestoreState();
        void Clear();
        void Exit();
    }
}

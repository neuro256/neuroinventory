namespace NeuroInventory
{
    interface IInventoryView
    {
        void RebuildList();
        void InitListView();
        void AddRecord();
        void RemoveRecord();
        void UpdateRecord();
        void SaveState();
        void RestoreState();
        void FocusFilter();
        void Clear();
        void Exit();
    }
}

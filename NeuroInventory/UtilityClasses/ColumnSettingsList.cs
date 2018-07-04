using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NeuroInventory
{
    [DataContract]
    public class ColumnSettingsList
    {
        [DataMember(Name = "list")]
        private List<ColumnSettings> columnSettingsList;

        public List<ColumnSettings> GetColumnSettingsList()
        {
            return columnSettingsList;
        }

        public void SetColumnSettingsList(List<ColumnSettings> value)
        {
            columnSettingsList = value;
        }

        public ColumnSettingsList(List<ColumnSettings> list)
        {
            columnSettingsList = list;
        }
    }
}

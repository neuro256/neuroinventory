using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroInventory
{
    public class ProvidersSql : TableSql<ProvidersSql>
    {
        public ProvidersSql()
        {
            _commandDataSet = "SELECT * FROM providers";
            _tableName = "providers";
        }

        public void Insert()
        {

        }

        public void Update()
        {

        }

        public void Remove()
        {

        }

        internal void Remove(int m_ListviewSelectedIndex)
        {
            throw new NotImplementedException();
        }
    }
}

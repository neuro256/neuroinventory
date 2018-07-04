using System.Windows.Forms;

namespace NeuroInventory
{
    public class ColHeader : ColumnHeader
    {
        public bool ascending;
        //Класс для работы со столбцами
        public ColHeader(string text, int width, HorizontalAlignment align, bool asc)
        {
            this.Name = text;
            this.Text = text;
            this.Width = width;
            this.TextAlign = align;
            this.ascending = asc;
        }
    }
}

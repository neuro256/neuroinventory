using System.Runtime.Serialization;
using System.Windows.Forms;

namespace NeuroInventory
{
    [DataContract]
    public class ColumnSettings
    {
        [DataMember]
        private string name;
        [DataMember]
        private string text;
        [DataMember]
        private int width;
        [DataMember]
        private HorizontalAlignment align;
        [DataMember]
        private bool ascending;

        public ColumnSettings(string text, int width, HorizontalAlignment align, bool asc)
        {
            this.Name = text;
            this.Text = text;
            this.Width = width;
            this.Align = align;
            this.Ascending = asc;
        }

        public string Name { get => name; set => name = value; }
        public string Text { get => text; set => text = value; }
        public int Width { get => width; set => width = value; }
        public HorizontalAlignment Align { get => align; set => align = value; }
        public bool Ascending { get => ascending; set => ascending = value; }
    }
}

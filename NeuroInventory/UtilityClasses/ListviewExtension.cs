using System.Windows.Forms;

namespace NeuroInventory
{
    public static class ListviewExtension
    {
        public static void DoubleBuffered(this Control control, bool enabled)
        {
            var property = control.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            property.SetValue(control, enabled, null);
        }
    }
}

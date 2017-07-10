using System;

namespace NeuroInventory
{
    [Serializable]
    public class DocumentNumeration
    {
        private int m_DocCurrentNumber;
        private string m_DocPrefix;
        private bool m_IncludeDate;

        public int DocCurrentNumber { get => m_DocCurrentNumber; set => m_DocCurrentNumber = value; }
        public string DocPrefix { get => m_DocPrefix; set => m_DocPrefix = value; }
        public bool IncludeDate { get => m_IncludeDate; set => m_IncludeDate = value; }

        public DocumentNumeration(int p_DocCurNumber, string p_DocPrefix, bool p_IncludeDate)
        {
            DocCurrentNumber = p_DocCurNumber;
            DocPrefix = p_DocPrefix;
            IncludeDate = p_IncludeDate;
        }

        public int IncrementNumber()
        {
            return ++DocCurrentNumber;
        }
    }
}

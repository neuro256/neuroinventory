using System;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class Numeration
    {
        private static readonly Numeration instance = new Numeration();

        public static Numeration GetInstance()
        {
            return instance;
        }

        private DocumentNumeration m_DemandNumeration;
        private DocumentNumeration m_DebitNumeration;
        private string m_DocNumerationPath = "numeration.json";

        public DocumentNumeration DemandNumeration { get => m_DemandNumeration; set => m_DemandNumeration = value; }
        public DocumentNumeration DebitNumeration { get => m_DebitNumeration; set => m_DebitNumeration = value; }
        public string DocNumerationPath { get => m_DocNumerationPath; set => m_DocNumerationPath = value; }

        public void ParseDocNumeration()
        {
            try
            {
                JSonSerialization<DocumentNumeration> js = new JSonSerialization<DocumentNumeration>();

                if (!File.Exists(DocNumerationPath))
                {
                    js.Serialize(new DocumentNumeration[] { new DocumentNumeration(1, "", false), new DocumentNumeration(1, "", false) }, DocNumerationPath);
                }

                DocumentNumeration[] docsNumeration = js.DeserializeMulti(DocNumerationPath);
                if (docsNumeration != null)
                {
                    DemandNumeration = docsNumeration[0];
                    DebitNumeration = docsNumeration[1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void WriteDocNumeration()
        {
            try
            {
                JSonSerialization<DocumentNumeration> js = new JSonSerialization<DocumentNumeration>();
                js.Serialize(new DocumentNumeration[] { DemandNumeration, DebitNumeration }, DocNumerationPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void WriteDocNumeration(DocumentNumeration[] docsNumeration)
        {
            try
            {
                JSonSerialization<DocumentNumeration> js = new JSonSerialization<DocumentNumeration>();
                js.Serialize(docsNumeration, DocNumerationPath);
                if (docsNumeration != null)
                {
                    DemandNumeration = docsNumeration[0];
                    DebitNumeration = docsNumeration[1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private string m_DocNumerationPath = Definitions.APPLICATION_SETTINGS_PATH + "numeration.json";

        public DocumentNumeration DemandNumeration { get => m_DemandNumeration; set => m_DemandNumeration = value; }
        public DocumentNumeration DebitNumeration { get => m_DebitNumeration; set => m_DebitNumeration = value; }
        public string DocNumerationPath { get => m_DocNumerationPath; set => m_DocNumerationPath = value; }

        public void ParseDocNumeration()
        {
            try
            {
                if (!File.Exists(DocNumerationPath))
                {
                    File.WriteAllText(m_DocNumerationPath, JsonConvert.SerializeObject(new List<DocumentNumeration>()
                    {
                        new DocumentNumeration(1, "", false),
                        new DocumentNumeration(1, "", false)
                    }));
                }

                List<DocumentNumeration> documentNumerations = JsonConvert.DeserializeObject<List<DocumentNumeration>>(File.ReadAllText(m_DocNumerationPath));

                if (documentNumerations != null)
                {
                    DemandNumeration = documentNumerations[0];
                    DebitNumeration = documentNumerations[1];
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
                File.WriteAllText(m_DocNumerationPath, JsonConvert.SerializeObject(new List<DocumentNumeration>()
                    {
                        DemandNumeration,
                        DebitNumeration
                    }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void WriteDocNumeration(List<DocumentNumeration> docsNumeration)
        {
            try
            {
                File.WriteAllText(m_DocNumerationPath, JsonConvert.SerializeObject(docsNumeration));

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

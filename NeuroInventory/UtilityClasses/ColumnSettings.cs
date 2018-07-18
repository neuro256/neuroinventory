using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class ColumnSettings
    {
        private static readonly ColumnSettings instance = new ColumnSettings();

        public static ColumnSettings GetInstance()
        {
            return instance;
        }

        private string ColumnSettingsPath = "ColumnSettings.json";

        private byte[] lvInventorySettings;
        private byte[] lvReleasedSettings;
        private byte[] lvProvidersSettings;
        private byte[] lvEmployeesSettings;
        private byte[] lvDemandReportListSettings;
        private byte[] lvDebitReportListSettings;
        private byte[] lvMeasurementSettings;
        private byte[] lvDemandDataSettings;
        private byte[] lvDebitDataSettings;

        public byte[] LvInventorySettings { get => lvInventorySettings; set => lvInventorySettings = value; }
        public byte[] LvReleasedSettings { get => lvReleasedSettings; set => lvReleasedSettings = value; }
        public byte[] LvProvidersSettings { get => lvProvidersSettings; set => lvProvidersSettings = value; }
        public byte[] LvEmployeesSettings { get => lvEmployeesSettings; set => lvEmployeesSettings = value; }
        public byte[] LvDemandReportListSettings { get => lvDemandReportListSettings; set => lvDemandReportListSettings = value; }
        public byte[] LvDebitReportListSettings { get => lvDebitReportListSettings; set => lvDebitReportListSettings = value; }
        public byte[] LvMeasurementSettings { get => lvMeasurementSettings; set => lvMeasurementSettings = value; }
        public byte[] LvDemandDataSettings { get => lvDemandDataSettings; set => lvDemandDataSettings = value; }
        public byte[] LvDebitDataSettings { get => lvDebitDataSettings; set => lvDebitDataSettings = value; }

        public void ParseSettings()
        {
            try
            {
                if (!File.Exists(ColumnSettingsPath))
                {
                    string inventorySettingsStr = LvInventorySettings !=null ? Convert.ToBase64String(LvInventorySettings) : String.Empty;
                    string releasedSettingsStr = LvReleasedSettings != null ? Convert.ToBase64String(LvReleasedSettings) : String.Empty;
                    string providersSettingsStr = LvProvidersSettings != null ? Convert.ToBase64String(LvProvidersSettings) : String.Empty;
                    string employeeSettingsStr = LvEmployeesSettings != null ? Convert.ToBase64String(LvEmployeesSettings) : String.Empty;
                    string demandReportListSettingsStr = LvDemandReportListSettings != null ? Convert.ToBase64String(LvDemandReportListSettings) : String.Empty;
                    string debitReportListSettingsStr = LvDebitReportListSettings != null ? Convert.ToBase64String(LvDebitReportListSettings) : String.Empty;
                    string measurementSettingsStr = LvMeasurementSettings != null ? Convert.ToBase64String(LvMeasurementSettings) : String.Empty;
                    string demandDataSettingsStr = LvDemandDataSettings != null ? Convert.ToBase64String(LvDemandDataSettings) : String.Empty;
                    string debitDataSetttingsStr = LvDebitDataSettings != null ? Convert.ToBase64String(LvDebitDataSettings) : String.Empty;

                    // serialize JSON to a string and then write string to a file
                    File.WriteAllText(ColumnSettingsPath, JsonConvert.SerializeObject(new List<string>()
                    {
                        inventorySettingsStr,
                        releasedSettingsStr,
                        providersSettingsStr,
                        employeeSettingsStr,
                        demandReportListSettingsStr,
                        debitReportListSettingsStr,
                        measurementSettingsStr,
                        demandDataSettingsStr,
                        debitDataSetttingsStr
                    }));
                }

                // read file into a string and deserialize JSON to a type
                List<string> lvSettings = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(ColumnSettingsPath));

                if (lvSettings != null)
                {
                    lvInventorySettings = Convert.FromBase64String(lvSettings[0]);
                    lvReleasedSettings = Convert.FromBase64String(lvSettings[1]);
                    lvProvidersSettings = Convert.FromBase64String(lvSettings[2]);
                    lvEmployeesSettings = Convert.FromBase64String(lvSettings[3]);
                    lvDemandReportListSettings = Convert.FromBase64String(lvSettings[4]);
                    lvDebitReportListSettings = Convert.FromBase64String(lvSettings[5]);
                    lvMeasurementSettings = Convert.FromBase64String(lvSettings[6]);
                    lvDemandDataSettings = Convert.FromBase64String(lvSettings[7]);
                    lvDebitDataSettings = Convert.FromBase64String(lvSettings[8]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void WriteSettings()
        {
            try
            {
                string inventorySettingsStr = LvInventorySettings != null ? Convert.ToBase64String(LvInventorySettings) : String.Empty;
                string releasedSettingsStr = LvReleasedSettings != null ? Convert.ToBase64String(LvReleasedSettings) : String.Empty;
                string providersSettingsStr = LvProvidersSettings != null ? Convert.ToBase64String(LvProvidersSettings) : String.Empty;
                string employeeSettingsStr = LvEmployeesSettings != null ? Convert.ToBase64String(LvEmployeesSettings) : String.Empty;
                string demandReportListSettingsStr = LvDemandReportListSettings != null ? Convert.ToBase64String(LvDemandReportListSettings) : String.Empty;
                string debitReportListSettingsStr = LvDebitReportListSettings != null ? Convert.ToBase64String(LvDebitReportListSettings) : String.Empty;
                string measurementSettingsStr = LvMeasurementSettings != null ? Convert.ToBase64String(LvMeasurementSettings) : String.Empty;
                string demandDataSettingsStr = LvDemandDataSettings != null ? Convert.ToBase64String(LvDemandDataSettings) : String.Empty;
                string debitDataSetttingsStr = LvDebitDataSettings != null ? Convert.ToBase64String(LvDebitDataSettings) : String.Empty;

                // serialize JSON to a string and then write string to a file
                File.WriteAllText(ColumnSettingsPath, JsonConvert.SerializeObject(new List<string>()
                    {
                        inventorySettingsStr,
                        releasedSettingsStr,
                        providersSettingsStr,
                        employeeSettingsStr,
                        demandReportListSettingsStr,
                        debitReportListSettingsStr,
                        measurementSettingsStr,
                        demandDataSettingsStr,
                        debitDataSetttingsStr
                    }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

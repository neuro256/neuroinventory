using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NeuroInventory
{
    public class UISettings
    {
        private static readonly UISettings instance = new UISettings();

        public static UISettings GetInstance()
        {
            return instance;
        }

        private string UISettingsPath = "UIsettings.json";

        private ColumnSettingsList lvInventorySettings;
        private ColumnSettingsList lvReleasedSettings;
        private ColumnSettingsList lvProvidersSettings;
        private ColumnSettingsList lvEmployeesSettings;
        private ColumnSettingsList lvDemandReportListSettings;
        private ColumnSettingsList lvDebitReportListSettings;
        private ColumnSettingsList lvMeasurementSettings;
        private ColumnSettingsList lvDemandDataSettings;
        private ColumnSettingsList lvDebitDataSettings;

        public ColumnSettingsList LvInventorySettings { get => lvInventorySettings; set => lvInventorySettings = value; }
        public ColumnSettingsList LvReleasedSettings { get => lvReleasedSettings; set => lvReleasedSettings = value; }
        public ColumnSettingsList LvProvidersSettings { get => lvProvidersSettings; set => lvProvidersSettings = value; }
        public ColumnSettingsList LvEmployeesSettings { get => lvEmployeesSettings; set => lvEmployeesSettings = value; }
        public ColumnSettingsList LvDemandReportListSettings { get => lvDemandReportListSettings; set => lvDemandReportListSettings = value; }
        public ColumnSettingsList LvDebitReportListSettings { get => lvDebitReportListSettings; set => lvDebitReportListSettings = value; }
        public ColumnSettingsList LvMeasurementSettings { get => lvMeasurementSettings; set => lvMeasurementSettings = value; }
        public ColumnSettingsList LvDemandDataSettings { get => lvDemandDataSettings; set => lvDemandDataSettings = value; }
        public ColumnSettingsList LvDebitDataSettings { get => lvDebitDataSettings; set => lvDebitDataSettings = value; }

        public void ParseSettings()
        {
            try
            {
                if (!File.Exists(UISettingsPath))
                {
                    lvInventorySettings = new ColumnSettingsList(new List<ColumnSettings>()
                    {
                        new ColumnSettings("№", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("Поставщик", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("Дата поступления", 140, HorizontalAlignment.Left, true),
                        new ColumnSettings("Накладная", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Номер накладной", 150, HorizontalAlignment.Left, true),
                        new ColumnSettings("Дата накладной", 140, HorizontalAlignment.Left, true),
                        new ColumnSettings("Наименование", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("Код ОКЕИ", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Единица измерения", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Количество", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Цена", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Сумма", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Остаток", 100, HorizontalAlignment.Left, true)
                    });

                    lvReleasedSettings = new ColumnSettingsList(new List<ColumnSettings>()
                    {
                        new ColumnSettings("№", 60, HorizontalAlignment.Left, true),
                        new ColumnSettings("Дата поступления", 120, HorizontalAlignment.Left, true),
                        new ColumnSettings("Дата отпуска", 120, HorizontalAlignment.Left, true),
                        new ColumnSettings("Номер накладной", 120, HorizontalAlignment.Left, true),
                        new ColumnSettings("Дата накладной", 120, HorizontalAlignment.Left, true),
                        new ColumnSettings("Наименование", 350, HorizontalAlignment.Left, true),
                        new ColumnSettings("Код ОКЕИ", 80, HorizontalAlignment.Left, true),
                        new ColumnSettings("Единица измерения", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Кому отпущено", 250, HorizontalAlignment.Left, true),
                        new ColumnSettings("Количество", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Цена", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Сумма", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Документ", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("Состояние списания", 250, HorizontalAlignment.Left, true)
                    });

                    lvProvidersSettings = new ColumnSettingsList(new List<ColumnSettings>()
                    {
                        //new ColumnSettings("ID", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("№", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("Название", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("адрес", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("телефон", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("e-mail", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("ИНН", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("Карточка предприятия", 200, HorizontalAlignment.Left, true)
                    });

                    lvEmployeesSettings = new ColumnSettingsList(new List<ColumnSettings>()
                    {
                        //new ColumnSettings("ID", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("№", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("Фамилия", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("Имя", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("Отчество", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("Должность", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("Отдел", 200, HorizontalAlignment.Left, true)
                    });

                    lvDemandReportListSettings = new ColumnSettingsList(new List<ColumnSettings>()
                    {
                        //new ColumnSettings("ID", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("№", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("Сотрудник", 250, HorizontalAlignment.Left, true),
                        new ColumnSettings("Дата", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Документ", 250, HorizontalAlignment.Left, true)
                    });

                    lvDebitReportListSettings = new ColumnSettingsList(new List<ColumnSettings>()
                    {
                        //new ColumnSettings("ID", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("№", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("Дата", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Документ", 250, HorizontalAlignment.Left, true)
                    });

                    lvMeasurementSettings = new ColumnSettingsList(new List<ColumnSettings>()
                    {
                        //new ColumnSettings("ID", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("№", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("Код ОКЕИ", 80, HorizontalAlignment.Left, true),
                        new ColumnSettings("Наименование", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("Условное обозначение", 200, HorizontalAlignment.Left, true),
                        new ColumnSettings("Количество десятичных разрядов", 250, HorizontalAlignment.Left, true)
                    });

                    lvDemandDataSettings = new ColumnSettingsList(new List<ColumnSettings>()
                    {
                        new ColumnSettings("№", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("Название", 250, HorizontalAlignment.Left, true),
                        new ColumnSettings("Код ОКЕИ", 90, HorizontalAlignment.Left, true),
                        new ColumnSettings("Номер накладной", 140, HorizontalAlignment.Left, true),
                        new ColumnSettings("Единица измерения", 150, HorizontalAlignment.Left, true),
                        new ColumnSettings("Цена", 250, HorizontalAlignment.Left, true),
                        new ColumnSettings("Количество", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Сумма", 100, HorizontalAlignment.Left, true)
                    });

                    lvDebitDataSettings = new ColumnSettingsList(new List<ColumnSettings>()
                    {
                        new ColumnSettings("№", 50, HorizontalAlignment.Left, true),
                        new ColumnSettings("Название", 250, HorizontalAlignment.Left, true),
                        new ColumnSettings("Код ОКЕИ", 90, HorizontalAlignment.Left, true),
                        new ColumnSettings("Номер накладной", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Единица измерения", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Цена", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Остаток", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Списать", 100, HorizontalAlignment.Left, true),
                        new ColumnSettings("Сумма", 100, HorizontalAlignment.Left, true)
                    });

                    // serialize JSON to a string and then write string to a file
                    File.WriteAllText(UISettingsPath, JsonConvert.SerializeObject(new List<ColumnSettingsList>()
                    {
                        lvInventorySettings,
                        lvReleasedSettings,
                        lvProvidersSettings,
                        lvEmployeesSettings,
                        lvDemandReportListSettings,
                        lvDebitReportListSettings,
                        lvMeasurementSettings,
                        lvDemandDataSettings,
                        lvDebitDataSettings
                    }));
                }

                // read file into a string and deserialize JSON to a type
                List<ColumnSettingsList> lvSettings = JsonConvert.DeserializeObject<List<ColumnSettingsList>>(File.ReadAllText(UISettingsPath));

                if (lvSettings != null)
                {
                    lvInventorySettings = lvSettings[0];
                    lvReleasedSettings = lvSettings[1];
                    lvProvidersSettings = lvSettings[2];
                    lvEmployeesSettings = lvSettings[3];
                    lvDemandReportListSettings = lvSettings[4];
                    lvDebitReportListSettings = lvSettings[5];
                    lvMeasurementSettings = lvSettings[6];
                    lvDemandDataSettings = lvSettings[7];
                    lvDebitDataSettings = lvSettings[8];
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
                // serialize JSON to a string and then write string to a file
                File.WriteAllText(UISettingsPath, JsonConvert.SerializeObject(new List<ColumnSettingsList>()
                    {
                        lvInventorySettings,
                        lvReleasedSettings,
                        lvProvidersSettings,
                        lvEmployeesSettings,
                        lvDemandReportListSettings,
                        lvDebitReportListSettings,
                        lvMeasurementSettings,
                        lvDemandDataSettings,
                        lvDebitDataSettings
                    }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

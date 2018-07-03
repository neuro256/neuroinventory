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

        private List<ColHeader> lvInventorySettings;
        private List<ColHeader> lvReleasedSettings;
        private List<ColHeader> lvProvidersSettings;
        private List<ColHeader> lvEmployeesSettings;
        private List<ColHeader> lvDemandReportListSettings;
        private List<ColHeader> lvDebitReportListSettings;
        private List<ColHeader> lvMeasurementSettings;
        private List<ColHeader> lvDemandDataSettings;
        private List<ColHeader> lvDebitDataSettings;

        public List<ColHeader> LvInventorySettings { get => lvInventorySettings; set => lvInventorySettings = value; }
        public List<ColHeader> LvReleasedSettings { get => lvReleasedSettings; set => lvReleasedSettings = value; }
        public List<ColHeader> LvProvidersSettings { get => lvProvidersSettings; set => lvProvidersSettings = value; }
        public List<ColHeader> LvEmployeesSettings { get => lvEmployeesSettings; set => lvEmployeesSettings = value; }
        public List<ColHeader> LvDemandReportListSettings { get => lvDemandReportListSettings; set => lvDemandReportListSettings = value; }
        public List<ColHeader> LvDebitReportListSettings { get => lvDebitReportListSettings; set => lvDebitReportListSettings = value; }
        public List<ColHeader> LvMeasurementSettings { get => lvMeasurementSettings; set => lvMeasurementSettings = value; }
        public List<ColHeader> LvDemandDataSettings { get => lvDemandDataSettings; set => lvDemandDataSettings = value; }
        public List<ColHeader> LvDebitDataSettings { get => lvDebitDataSettings; set => lvDebitDataSettings = value; }

        public void ParseSettings()
        {
            try
            {
                JSonSerialization<List<List<ColHeader>>> js = new JSonSerialization<List<List<ColHeader>>>();

                if (!File.Exists(UISettingsPath))
                {
                    lvInventorySettings = new List<ColHeader>()
                    {
                        new ColHeader("№", 50, HorizontalAlignment.Left, true),
                        new ColHeader("Поставщик", 200, HorizontalAlignment.Left, true),
                        new ColHeader("Дата поступления", 140, HorizontalAlignment.Left, true),
                        new ColHeader("Накладная", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Номер накладной", 150, HorizontalAlignment.Left, true),
                        new ColHeader("Дата накладной", 140, HorizontalAlignment.Left, true),
                        new ColHeader("Наименование", 200, HorizontalAlignment.Left, true),
                        new ColHeader("Код ОКЕИ", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Единица измерения", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Количество", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Цена", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Сумма", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Остаток", 100, HorizontalAlignment.Left, true)
                    };

                    lvReleasedSettings = new List<ColHeader>()
                    {
                        new ColHeader("№", 60, HorizontalAlignment.Left, true),
                        new ColHeader("Дата поступления", 120, HorizontalAlignment.Left, true),
                        new ColHeader("Дата отпуска", 120, HorizontalAlignment.Left, true),
                        new ColHeader("Номер накладной", 120, HorizontalAlignment.Left, true),
                        new ColHeader("Дата накладной", 120, HorizontalAlignment.Left, true),
                        new ColHeader("Наименование", 350, HorizontalAlignment.Left, true),
                        new ColHeader("Код ОКЕИ", 80, HorizontalAlignment.Left, true),
                        new ColHeader("Единица измерения", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Кому отпущено", 250, HorizontalAlignment.Left, true),
                        new ColHeader("Количество", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Цена", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Сумма", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Документ", 200, HorizontalAlignment.Left, true),
                        new ColHeader("Состояние списания", 250, HorizontalAlignment.Left, true)
                    };

                    lvProvidersSettings = new List<ColHeader>()
                    {
                        new ColHeader("ID", 50, HorizontalAlignment.Left, true),
                        new ColHeader("№", 50, HorizontalAlignment.Left, true),
                        new ColHeader("Название", 200, HorizontalAlignment.Left, true),
                        new ColHeader("адрес", 200, HorizontalAlignment.Left, true),
                        new ColHeader("телефон", 200, HorizontalAlignment.Left, true),
                        new ColHeader("e-mail", 200, HorizontalAlignment.Left, true),
                        new ColHeader("ИНН", 200, HorizontalAlignment.Left, true),
                        new ColHeader("Карточка предприятия", 200, HorizontalAlignment.Left, true)
                    };

                    lvEmployeesSettings = new List<ColHeader>()
                    {
                        new ColHeader("ID", 50, HorizontalAlignment.Left, true),
                        new ColHeader("№", 50, HorizontalAlignment.Left, true),
                        new ColHeader("Фамилия", 200, HorizontalAlignment.Left, true),
                        new ColHeader("Имя", 200, HorizontalAlignment.Left, true),
                        new ColHeader("Отчество", 200, HorizontalAlignment.Left, true),
                        new ColHeader("Должность", 200, HorizontalAlignment.Left, true),
                        new ColHeader("Отдел", 200, HorizontalAlignment.Left, true)
                    };

                    lvDemandReportListSettings = new List<ColHeader>()
                    {
                        new ColHeader("ID", 50, HorizontalAlignment.Left, true),
                        new ColHeader("№", 50, HorizontalAlignment.Left, true),
                        new ColHeader("Сотрудник", 250, HorizontalAlignment.Left, true),
                        new ColHeader("Дата", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Документ", 250, HorizontalAlignment.Left, true)
                    };

                    lvDebitReportListSettings = new List<ColHeader>()
                    {
                        new ColHeader("ID", 50, HorizontalAlignment.Left, true),
                        new ColHeader("№", 50, HorizontalAlignment.Left, true),
                        new ColHeader("Дата", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Документ", 250, HorizontalAlignment.Left, true)
                    };

                    lvMeasurementSettings = new List<ColHeader>()
                    {
                        new ColHeader("ID", 50, HorizontalAlignment.Left, true),
                        new ColHeader("№", 50, HorizontalAlignment.Left, true),
                        new ColHeader("Код ОКЕИ", 80, HorizontalAlignment.Left, true),
                        new ColHeader("Наименование", 200, HorizontalAlignment.Left, true),
                        new ColHeader("Условное обозначение", 200, HorizontalAlignment.Left, true),
                        new ColHeader("Количество десятичных разрядов", 250, HorizontalAlignment.Left, true)
                    };

                    lvDemandDataSettings = new List<ColHeader>()
                    {
                        new ColHeader("№", 50, HorizontalAlignment.Left, true),
                        new ColHeader("Название", 250, HorizontalAlignment.Left, true),
                        new ColHeader("Код ОКЕИ", 90, HorizontalAlignment.Left, true),
                        new ColHeader("Номер накладной", 140, HorizontalAlignment.Left, true),
                        new ColHeader("Единица измерения", 150, HorizontalAlignment.Left, true),
                        new ColHeader("Цена", 250, HorizontalAlignment.Left, true),
                        new ColHeader("Количество", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Сумма", 100, HorizontalAlignment.Left, true)
                    };

                    lvDebitDataSettings = new List<ColHeader>()
                    {
                        new ColHeader("№", 50, HorizontalAlignment.Left, true),
                        new ColHeader("Название", 250, HorizontalAlignment.Left, true),
                        new ColHeader("Код ОКЕИ", 90, HorizontalAlignment.Left, true),
                        new ColHeader("Номер накладной", 120, HorizontalAlignment.Left, true),
                        new ColHeader("Единица измерения", 150, HorizontalAlignment.Left, true),
                        new ColHeader("Цена", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Остаток", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Списать", 100, HorizontalAlignment.Left, true),
                        new ColHeader("Сумма", 100, HorizontalAlignment.Left, true)
                    };

                    js.Serialize(new List<List<ColHeader>>()
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
                    },
                    UISettingsPath);
                }

                List<List<ColHeader>> lvSettings = js.Deserialize(UISettingsPath);

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
                JSonSerialization<List<List<ColHeader>>> js = new JSonSerialization<List<List<ColHeader>>>();
                js.Serialize(new List<List<ColHeader>>()
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
                },
                UISettingsPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

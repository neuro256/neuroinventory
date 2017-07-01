namespace NeuroInventory
{
    class Definitions
    {
        public static string REMOVE_WARNING_STRING = "Сначала выберите запись которую хотите удалить";
        public static string UPDATE_WARNING_STRING = "Сначала выберите запись которую хотите изменить";
        public static string VALIDATION_WARNING_STRING = "Сначала заполните обязательные поля";
        public static string BLANK_NAME_WARNING_STRING = "Имя не должно быть пустым";
        public static string INVALID_LOGIN_OR_PASSWORD = "Логин и/или пароль введены неверно";
        public static string APPLICATION_CLOSE_QUESTION = "Вы действительно хотите выйти?";
        public static string APPLICATION_CLOSE_DIALOG_CAPTION = "Выход из программы";
        public static string DB_SUCCESSFULLY_SAVED = "База данных успешно сохранена";
        public static string BD_NOT_CREATED_OR_OPENED = "Для начала создайте или откройте базу данных";
        public static string DB_ROOT_CATALOG = "Корневой каталог";
        public static string SELECT_RECORDS = "Отчет должен включать хотя бы одну запись из таблицы. Пожалуйста, выберите интересующие записи и отметьте их галочками.";
        public static string DB_INCORRECT = "Похоже, Вы попытались открыть некорректную базу данных.";
        public static string INSERT_WARNING_STRING = "Неоднозначность целевого каталога. Пожалуйста, сначала выберите ЕДИНСТВЕННЫЙ список тмц, куда хотите добавить тмц.";
        public static string DEMAND_SELECTION_WARNING_STRING = "Чтобы отпустить тмц, сначала выберите и отметьте галочками нужные тмц в таблице";
        public static string DEBIT_SELECTION_WARNING_STRING = "Чтобы списать тмц, сначала выберите и отметьте галочками нужные тмц в таблице";
        public static string CREATE_REPORT_FAILED = "Попытка создать отчет провалилась";
        public static string ZERO_AMOUNT = "Количество тмц не должно иметь нулевое значение";
        public static string RELEASED_STR = "Списано";
        public static string NONRELEASED_STR = "Не списано";
        public static string TOO_MANY_SELECTED_NODES = "Перемещение записей невозможно если выбрано несколько списков тмц. Сначала выберите один список тмц";
    }
}

using System.Windows.Input;

namespace Lab8
{
    public static class CustomCommands
    {
        #region Команды для пользователя
        public static readonly RoutedUICommand GetUserImage = new("Получение фотографии профиля", "GetUserImage", typeof(CustomCommands));

        public static readonly RoutedUICommand DeleteUser = new("Удаление пользователя из БД", "DeleteUser", typeof(CustomCommands));

        public static readonly RoutedUICommand AddUser = new("Добавление пользователя в БД", "AddUser", typeof(CustomCommands));

        public static readonly RoutedUICommand ChangeUser = new("Изменение существующего пользователя", "ChangeUser", typeof(CustomCommands));

        public static readonly RoutedUICommand ClearUserFields = new("Очистка всех полей формы таблицы Users", "ClearUserFields", typeof(CustomCommands));
        #endregion

        #region Команды для оружия

        public static readonly RoutedUICommand GetHouseImage = new("Получение фотографии профиля", "GetHouseImage", typeof(CustomCommands));

        public static readonly RoutedUICommand ClearHouseFields = new("Очистка всех полей формы таблицы Houses", "ClearHouseFields", typeof(CustomCommands));

        public static readonly RoutedUICommand AddHouse = new("Добавить дом в БД", "AddHouse", typeof(CustomCommands));

        public static readonly RoutedUICommand ChangeHouse = new("Изменить описание домав БД", "ChangeHouse", typeof(CustomCommands));

        public static readonly RoutedUICommand DeleteHouse = new("Изменить описание домав БД", "DeleteHouse", typeof(CustomCommands));

        #endregion


    }
}

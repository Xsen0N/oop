using Microsoft.Data.Sqlite;
using Microsoft.Win32;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Lab8
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnect"].ConnectionString;
            OtherFunctions.CreateDatabaseIfNotExists("../../../database.db");

            LoadUsersData();
            LoadHousesData();
        }

        #region Инструкции таблицы Users
        private void LoadProfileImage(object sender, RoutedEventArgs e) // функция загрузки изображения
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Фото профиля (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp" // фильтр
            };

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage image = new();

                image.BeginInit();
                image.UriSource = new Uri(openFileDialog.FileName);
                image.EndInit();
                byte[] imageData = System.IO.File.ReadAllBytes(openFileDialog.FileName);

                newUserPhoto.Content = imageData;
            }
        }
        public void DeleteUser(object sender, RoutedEventArgs e) // удаление пользователя из БД
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnect"].ConnectionString;
            using SqliteConnection connection = new(connectionString);
            connection.Open();
            using SqliteTransaction transaction = connection.BeginTransaction();
            try
            {
                using (SqliteCommand command = new())
                {
                    _ = int.TryParse(deletedUserIdInput.Text, out int userID);
                    command.Transaction = transaction;
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Houses WHERE owner = @userId";
                    _ = command.Parameters.AddWithValue("@userId", userID);
                    _ = command.ExecuteNonQuery();
                }
                using (SqliteCommand command = new())
                {
                    _ = int.TryParse(deletedUserIdInput.Text, out int userID);
                    command.Transaction = transaction;
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Users WHERE id = @userId";
                    _ = command.Parameters.AddWithValue("@userId", userID);
                    _ = command.ExecuteNonQuery();
                }


                transaction.Commit();
                LoadUsersData();
                LoadHousesData();
                deletedUserIdInput.Clear();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Ошибка удаления пользователя из БД!");
            }

        }

        public void CreateNewUser(object sender, RoutedEventArgs e)
        {
            if (!OtherFunctions.UserFieldsChecker(
                newUserFirstName.Text,
                newUserLastName.Text,
                newUserPassword.Text,
                newUserMail.Text,
                newUserCash.Text)
                )
            {
                return;
            }
            if(String.Equals(newUserPhoto.Content, "Загрузить изображение"))
            {
                MessageBox.Show("Отсутвует изображение профиля!");
                return;
            }
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnect"].ConnectionString;
            using SqliteConnection connection = new(connectionString);
            connection.Open();
            using SqliteTransaction transaction = connection.BeginTransaction();
            try
            {
                using (SqliteCommand command = new())
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = "INSERT INTO Users (firstName, lastName, password, email, cash, ProfilePhoto) VALUES (@firstName, @lastName, @password, @email, @cash, @photo)";
                    _ = command.Parameters.AddWithValue("@firstName", newUserFirstName.Text);
                    _ = command.Parameters.AddWithValue("@lastName", newUserLastName.Text);
                    _ = command.Parameters.AddWithValue("@password", newUserPassword.Text);
                    _ = command.Parameters.AddWithValue("@email", newUserMail.Text);
                    _ = command.Parameters.AddWithValue("@cash", newUserCash.Text);
                    _ = command.Parameters.AddWithValue("@photo", newUserPhoto.Content);
                    _ = command.ExecuteNonQuery();
                }
                transaction.Commit();
                connection.Close();

                newUserFirstName.Clear();
                newUserLastName.Clear();
                newUserPassword.Clear();
                newUserMail.Clear();
                newUserCash.Clear();
                newUserPhoto.Content = "Добавить";
                LoadUsersData();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }

        }
        public void LoadUsersData() // получение данных из таблицы Users
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnect"].ConnectionString;
            using SqliteConnection connection = new(connectionString);
            connection.Open();
            using SqliteCommand dataCommand = new("SELECT * FROM Users ORDER BY cash DESC", connection);
            using SqliteDataReader dataReader = dataCommand.ExecuteReader();

            DataTable dataTable = new();
            dataTable.Load(dataReader);

            UsersTable.ItemsSource = null;
            UsersTable.ItemsSource = dataTable.AsDataView();

        }



        private void UsersTableSelectionChanged(object sender, SelectionChangedEventArgs e) // закидывает выделенный товар в поля формы для изменения
        {
            if (UsersTable.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)UsersTable.SelectedItem;

                // Получение данных из выбранной строки и заполнение полей формы
                newUserFirstName.Text = dataRow["firstName"].ToString();
                newUserLastName.Text = dataRow["lastName"].ToString();
                newUserPassword.Text = dataRow["password"].ToString();
                newUserMail.Text = dataRow["email"].ToString();
                newUserCash.Text = dataRow["cash"].ToString();

                newUserPhoto.Content = dataRow["profilePhoto"];
                AddUserButton.Content = "Изменить пользователя";
                AddUserButton.Command = CustomCommands.ChangeUser;
            }
        }

        public void UpdateUser(object sender, RoutedEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnect"].ConnectionString;
            if (!OtherFunctions.UserFieldsChecker(
    newUserFirstName.Text,
    newUserLastName.Text,
    newUserPassword.Text,
    newUserMail.Text,
    newUserCash.Text)
    )
            {
                return;
            }
            string updateQuery = @"UPDATE Users 
                           SET FirstName = @FirstName, 
                               LastName = @LastName, 
                               Email = @Email, 
                               Cash = @Cash,
                               Password = @Password,
                               ProfilePhoto = @ProfilePhoto
                           WHERE Id = @UserId;";

            using (SqliteConnection connection = new(connectionString))
            {
                connection.Open();
                using SqliteTransaction transaction = connection.BeginTransaction();
                using (SqliteCommand command = new(updateQuery, connection, transaction))
                {
                    _ = command.Parameters.AddWithValue("@FirstName", newUserFirstName.Text);
                    _ = command.Parameters.AddWithValue("@LastName", newUserLastName.Text);
                    _ = command.Parameters.AddWithValue("@Email", newUserMail.Text);
                    _ = command.Parameters.AddWithValue("@Cash", newUserCash.Text);
                    _ = command.Parameters.AddWithValue("@Password", newUserPassword.Text);

                    _ = command.Parameters.AddWithValue("@ProfilePhoto", newUserPhoto.Content);

                    DataRowView? selectedItem = UsersTable.SelectedItem as DataRowView;
                    _ = command.Parameters.AddWithValue("@UserId", selectedItem.Row[0]);

                    _ = command.ExecuteNonQuery();

                }

                transaction.Commit();
            }
            newUserFirstName.Clear();
            newUserLastName.Clear();
            newUserPassword.Clear();
            newUserMail.Clear();
            newUserCash.Clear();
            newUserPhoto.Content = "Загрузить изображение";
            AddUserButton.Content = "Добавить пользователя";
            AddUserButton.Command = CustomCommands.AddUser;
            LoadUsersData();
        }

        private void ClearUserForm(object sender, RoutedEventArgs e) // очищает форму
        {

            newUserFirstName.Clear();
            newUserLastName.Clear();
            newUserCash.Clear();
            newUserMail.Clear();
            newUserPassword.Clear();
            newUserPhoto.Content = "Загрузить изображение";
            AddUserButton.Command = CustomCommands.AddUser;
            AddUserButton.Content = "Добавить пользователя";
            _ = MessageBox.Show("Форма очищена!");

        }

        #endregion

        #region Инструкции таблицы Houses

        public bool IsOwnerInDB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnect"].ConnectionString;
            string owner = newHouseOwner.Text; // Получаем значение внешнего ключа "owner" из текстового поля

            // Проверяем наличие записи в таблице "Users" по значению внешнего ключа "owner"
            using (SqliteConnection connection = new(connectionString))
            {
                connection.Open();
                using SqliteCommand command = new("SELECT COUNT(*) FROM Users WHERE Id = @ownerId", connection);
                _ = command.Parameters.AddWithValue("@ownerId", owner);
                Int64 count = (Int64)command.ExecuteScalar();

                if (count == 0)
                {
                    _ = MessageBox.Show("Пользователь с указанным идентификатором отсутствует!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
         
        }
        public void LoadHousesData() // получение данных из таблицы Houses
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnect"].ConnectionString;
            using (SqliteConnection connection = new(connectionString))
            {
                connection.Open();
                using SqliteCommand dataCommand = new("SELECT * FROM Houses ORDER BY owner DESC", connection);
                using SqliteDataReader dataReader = dataCommand.ExecuteReader();

                DataTable dataTable = new();
                dataTable.Load(dataReader);

                HousesTable.ItemsSource = null;
                HousesTable.ItemsSource = dataTable.AsDataView();
            }
        }

        private void HousesTableSelectionChanged(object sender, SelectionChangedEventArgs e) // закидывает выделенный товар в поля формы для изменения
        {
            if (HousesTable.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)HousesTable.SelectedItem;

                // Получение данных из выбранной строки и заполнение полей формы
                newHouseName.Text = dataRow["name"].ToString();
                newHouseAmount.Text = dataRow["amount"].ToString();
                newHousePrice.Text = dataRow["price"].ToString();
                newHouseOwner.Text = dataRow["owner"].ToString();

                newHousePhoto.Content = dataRow["Photo"];
                AddHouseButton.Content = "Изменить дом";
                AddHouseButton.Command = CustomCommands.ChangeHouse;
            }
        }

        private void ClearHouseForm(object sender, RoutedEventArgs e) // очищает форму
        {

            newHouseName.Text = null;
            newHouseAmount.Text = null;
            newHousePrice.Text = null;
            newHouseOwner.Text = null;

            newHousePhoto.Content = "Загрузить изображение";
            AddHouseButton.Command = CustomCommands.AddHouse;
            AddHouseButton.Content = "Добавить дом";
            _ = MessageBox.Show("Форма очищена!");

        }

        private void LoadHouseImage(object sender, RoutedEventArgs e) // функция загрузки изображения
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Фото дома(*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp" // фильтр
            };

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage image = new();

                image.BeginInit();
                image.UriSource = new Uri(openFileDialog.FileName);
                image.EndInit();
                byte[] imageData = System.IO.File.ReadAllBytes(openFileDialog.FileName);

                newHousePhoto.Content = imageData;
            }
        }
        public void DeleteHouse(object sender, RoutedEventArgs e) // удаление пользователя из БД
        {
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnect"].ConnectionString;
            using(SqliteConnection connection = new(connectionString))
            {
                connection.Open();

                using SqliteTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (SqliteCommand command = new())
                    {
                        _ = int.TryParse(deletedHouseIdInput.Text, out int houseID);
                        command.Transaction = transaction;
                        command.Connection = connection;
                        command.CommandText = "DELETE FROM Houses WHERE id = @houseID";
                        _ = command.Parameters.AddWithValue("@houseID", houseID);
                        _ = command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    connection.Close();
                    LoadHousesData();
                    deletedHouseIdInput.Clear();
                }
                catch
                {
                    transaction.Rollback();
                    _ = MessageBox.Show("Ошибка удаления домаиз БД!");
                }
            }

        }

        public void CreateNewHouse(object sender, RoutedEventArgs e)
        {
            if (!IsOwnerInDB())
            {
                return;
            }
            if (!OtherFunctions.HouseFieldsChecker(
                newHouseName.Text,
                newHouseAmount.Text,
                newHousePrice.Text,
                newHouseOwner.Text
                ))
            {
                return;
            }
            if (String.Equals(newHousePhoto.Content, "Загрузить изображение"))
            {
                MessageBox.Show("Отсутвует изображение оружия!");
                return;
            }
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnect"].ConnectionString;
            using (SqliteConnection connection = new(connectionString))
            {
                connection.Open();
                using SqliteTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (SqliteCommand command = new())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;
                        command.CommandText = "INSERT INTO Houses (type, metrage, price, owner, Photo) VALUES (@type, @metrage, @price, @owner, @Photo)";
                        _ = command.Parameters.AddWithValue("@type", newHouseName.Text);
                        _ = command.Parameters.AddWithValue("@metrage", newHouseAmount.Text);
                        _ = command.Parameters.AddWithValue("@price", newHousePrice.Text);
                        _ = command.Parameters.AddWithValue("@owner", newHouseOwner.Text);
                        _ = command.Parameters.AddWithValue("@Photo", newHousePhoto.Content);
                        _ = command.ExecuteNonQuery();

                    }
                    transaction.Commit();
                    connection.Close();

                    newHouseName.Clear();
                    newHouseAmount.Clear();
                    newHousePrice.Clear();
                    newHouseOwner.Clear();

                    newHousePhoto.Content = "Загрузить изображение";
                    AddHouseButton.Command = CustomCommands.AddHouse;
                    AddHouseButton.Content = "Добавить дом";
                    LoadHousesData();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }

        public void UpdateHouse(object sender, RoutedEventArgs e)
        {
            if (!IsOwnerInDB())
            {
                return;
            }
            if (!OtherFunctions.HouseFieldsChecker(
                newHouseName.Text,
                newHouseAmount.Text,
                newHousePrice.Text,
                newHouseOwner.Text
                ))
            {
                return;
            }
            string connectionString = ConfigurationManager.ConnectionStrings["databaseConnect"].ConnectionString;
            string updateQuery = @"UPDATE Houses 
                       SET type = @type, 
                           metrage = @metrage, 
                           Price = @Price, 
                           Photo = @Photo,
                           owner = @owner
                       WHERE Id = @HouseId;";

            using (SqliteConnection connection = new(connectionString))
            {
                connection.Open();
                using SqliteTransaction transaction = connection.BeginTransaction();
                using (SqliteCommand command = new(updateQuery, connection, transaction))
                {
                    _ = command.Parameters.AddWithValue("@type", newHouseName.Text);
                    _ = command.Parameters.AddWithValue("@metrage", newHouseAmount.Text);
                    _ = command.Parameters.AddWithValue("@Price", newHousePrice.Text);
                    _ = command.Parameters.AddWithValue("@HousePhoto", newHousePhoto.Content);
                    _ = command.Parameters.AddWithValue("@owner", newHouseOwner.Text);

                    DataRowView? selectedItem = HousesTable.SelectedItem as DataRowView;
                    _ = command.Parameters.AddWithValue("@HouseId", selectedItem.Row[0]);

                    _ = command.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();

                }
            }
            newHouseName.Clear();
            newHouseAmount.Clear();
            newHousePrice.Clear();
            newHouseOwner.Clear();

            newHousePhoto.Content = "Загрузить изображение";
            AddHouseButton.Command = CustomCommands.AddHouse;
            AddHouseButton.Content = "Добавить дом";
            LoadHousesData();
        }

        #endregion

        #region Кнопки вперед и назад
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика обработки нажатия кнопки "Назад" для переключения на предыдущую вкладку
            int selectedIndex = mainTabs.SelectedIndex;
            if (selectedIndex > 0)
            {
                mainTabs.SelectedIndex = selectedIndex - 1;
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика обработки нажатия кнопки "Вперед" для переключения на следующую вкладку
            int selectedIndex = mainTabs.SelectedIndex;
            if (selectedIndex < mainTabs.Items.Count - 1)
            {
                mainTabs.SelectedIndex = selectedIndex + 1;
            }
        }
        #endregion
    }
}

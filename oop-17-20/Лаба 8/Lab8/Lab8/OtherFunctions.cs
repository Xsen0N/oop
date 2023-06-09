using Microsoft.Data.Sqlite;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace Lab8
{
    internal static class OtherFunctions
    {
        #region Создание новой БД, если она отсутствует
        public static void CreateDatabaseIfNotExists(string databasePath) // создает БД, если нет по указанному пути
        {
            if (!File.Exists(databasePath))
            {
                var fileStream = File.Create(databasePath);
                fileStream.Close();

                using (var connection = new SqliteConnection($"Data Source={databasePath};Version=3;"))
                {
                    connection.Open();

                    var createUsersTableQuery = @"CREATE TABLE Users (
                                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            firstName TEXT,
                                            lastName TEXT,
                                            password TEXT,
                                            email TEXT,
                                            cash INTEGER,
                                            profilePhoto BLOB 
                                        )";
                    var createUserTableCommand = new SqliteCommand(createUsersTableQuery, connection);
                    _ = createUserTableCommand.ExecuteNonQuery();

                    var createHousesTableQuery = @"CREATE TABLE Houses (
                                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                name TEXT,
                                                amount INTEGER,
                                                price INTEGER
                                            )";
                    var createHousesTableCommand = new SqliteCommand(createHousesTableQuery, connection);
                    _ = createHousesTableCommand.ExecuteNonQuery();
                }
                using (var connection = new SqliteConnection($"Data Source={databasePath};Version=3;"))
                {
                    connection.Open();
                    using (var command = new SqliteCommand("INSERT INTO Users (FirstName, LastName, Email, Password, Cash) VALUES (@FirstName, @LastName, @Email, @Password, @Cash)", connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", "Илья");
                        command.Parameters.AddWithValue("@LastName", "Старовойтов");
                        command.Parameters.AddWithValue("@Email", "workplaceilstar@gmail.com");
                        command.Parameters.AddWithValue("@Password", "123a@");
                        command.Parameters.AddWithValue("@Cash", 2000);

                        command.ExecuteNonQuery();
                    }
                }
                using (var connection = new SqliteConnection($"Data Source={databasePath};Version=3;"))
                {
                    connection.Open();
                    using (var command = new SqliteCommand("INSERT INTO Houses (Name, Amount, Price, OwnerId) VALUES (@Name, @Amount, @Price, @OwnerId)", connection))
                    {
                        command.Parameters.AddWithValue("@Name", "Сайга-9");
                        command.Parameters.AddWithValue("@Amount", 5);
                        command.Parameters.AddWithValue("@Price", 2500);
                        command.Parameters.AddWithValue("@OwnerId", 1);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion

        #region Проверка полей User на заполняемость
        public static bool UserFieldsChecker(string firstName, string lastName, string password, string email, string cash)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(cash))
            {
                MessageBox.Show("Пожалуйста, запоните все поля!");
                return false;
            }

            // Проверяем формат email-адреса
            string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Формат почты неверный!");
                return false;
            }

            // Проверяем, что cash - положительное число
            if (!double.TryParse(cash, out double cashValue) || cashValue < 0)
            {
                MessageBox.Show("Количество денег должно быть больше 0!");
                return false;
            }

            // Проверяем сложность пароля
            bool hasDigit = false, hasLetter = false, hasSpecial = false;
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                else if (char.IsLetter(c))
                {
                    hasLetter = true;
                }
                else if (!char.IsWhiteSpace(c))
                {
                    hasSpecial = true;
                }
            }

            if (!(hasDigit && hasLetter && hasSpecial))
            {
                MessageBox.Show("Пароль должен содержать как минимум одну цифру, одну букву и один спец. символ!");
                return false;
            }

            // Если все проверки пройдены успешно, возвращаем true
            return true;
        }
        #endregion

        #region Проверка полей House на заполняемость
        public static bool HouseFieldsChecker(string newHouseName, string newHouseAmount, string newHousePrice, string newHouseOwner)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrEmpty(newHouseName) || string.IsNullOrEmpty(newHouseAmount)
                || string.IsNullOrEmpty(newHousePrice) || string.IsNullOrEmpty(newHouseOwner))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return false;
            }

            // Проверяем, что newHouseAmount - положительное число
            if (!int.TryParse(newHouseAmount, out int amountValue) || amountValue < 0)
            {
                MessageBox.Show("Количество домадолжно быть больше 0!");
                return false;
            }

            // Проверяем, что newHousePrice - положительное число
            if (!double.TryParse(newHousePrice, out double priceValue) || priceValue < 0)
            {
                MessageBox.Show("Цена домадолжна быть больше 0!");
                return false;
            }

            // Проверяем, что newHouseOwner - положительное число
            if (!double.TryParse(newHouseOwner, out double owner) || owner < 0)
            {
                MessageBox.Show("Неверно задан ID владельца оружия!");
                return false;
            }

            // Если все проверки пройдены успешно, возвращаем true
            return true;
        }

        #endregion

    }
}

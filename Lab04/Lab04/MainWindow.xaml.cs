using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Windows.Interactivity;
using System.Windows.Resources;
using GuiLabs.Undo;

namespace Lab04
{

    public partial class MainWindow : Window
    {
        public List<House> GlobalItemsList = new List<House>();
        StreamResourceInfo sri = System.Windows.Application.GetResourceStream(new Uri("Resources/arrow.cur", UriKind.Relative));
        private readonly ActionManager actionManager = new();
        private readonly ResourceDictionary enDict = new ResourceDictionary() { Source = new Uri("Resources/langEN.xaml", UriKind.Relative) };
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        private readonly ResourceDictionary lightTheme = new ResourceDictionary() { Source = new Uri("Resources/lightTheme.xaml", UriKind.Relative) };
        private readonly ResourceDictionary darkTheme = new ResourceDictionary() { Source = new Uri("Resources/darkTheme.xaml", UriKind.Relative) };
        private readonly Stack<List<House>> UndoAction = new();
        private readonly Stack<List<House>> RedoAction = new();
        public string messageBoxText = ""; // сообщение при добавлении\изменении предмета
        private readonly string itemsDB = "../../../items.json";
        public MainWindow()
        {
            Cursor arrow = new Cursor(sri.Stream);
            InitializeComponent();
            MainShopGrid.Cursor = arrow; // добавление курсора
            GlobalItemsList = JsonConvert.DeserializeObject<List<House>>(File.ReadAllText(itemsDB));
            ItemsList.ItemsSource = GlobalItemsList;
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
            Resources.MergedDictionaries.Add(lightTheme); // светлая тема
            BubbleButton.Click += BubbleButton_Click;
            DirectButton.Click += DirectButton_Click;
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            GlobalItemsList = JsonConvert.DeserializeObject<List<House>>(File.ReadAllText(itemsDB));
            ItemsList.ItemsSource = GlobalItemsList;
            Database.ItemsSource = GlobalItemsList;
        }
        

        #region Функции смены языка

        private void Ru_Selected(object sender, RoutedEventArgs e) // смена языка на русский путем добавления-удаления словарей
        {
            Resources.MergedDictionaries.Remove(enDict);
            Resources.MergedDictionaries.Add(ruDict);           
        }
        private void Eng_Selected(object sender, RoutedEventArgs e) // смена языка на английский путем добавления-удаления словарей
        {
            Resources.MergedDictionaries.Remove(ruDict);
            Resources.MergedDictionaries.Add(enDict);     
        }
        #endregion
        #region функции загрузки и удаления данных из формы
        private void SaveDataToFile(object sender, RoutedEventArgs e) // сохранить в файл по пути переменной itemsDB
        {
            File.WriteAllText(itemsDB, JsonConvert.SerializeObject(GlobalItemsList));
            MessageBox.Show("Данные сохранены в файл!");

        }


        private void LoadDataFromFile(object sender, RoutedEventArgs e)
        {
            GlobalItemsList = JsonConvert.DeserializeObject<List<House>>(File.ReadAllText(itemsDB)); // десереализация
            ItemsList.ItemsSource = GlobalItemsList; // загрузка данных в список на 1 вкладке
            Database.ItemsSource = GlobalItemsList; // загрузка данных в таблицу на 2 вкладке
            MessageBox.Show("Данные загружены из файла!");
        }
        #endregion

        #region Функции смены стилей приложения
        private void DarkTheme_Selected(object sender, RoutedEventArgs e)
        {
            Resources.MergedDictionaries.Remove(lightTheme);

            Resources.MergedDictionaries.Add(darkTheme);
        }
        private void LightTheme_Selected(object sender, RoutedEventArgs e)
        {
            Resources.MergedDictionaries.Remove(darkTheme);

            Resources.MergedDictionaries.Add(lightTheme);
        }
        #endregion

        private void IDTextChanged(object sender, TextChangedEventArgs e) // функция для определения текста кнопки добавления\изменения товара
        {
            int.TryParse(newItemID.Text, out int newItemId);
            if (GlobalItemsList.FindIndex(x => x.ID == newItemId) != -1)
            {
                AddItemButton.Content = "Изменить товар";
            }
            else
            {
                AddItemButton.Content = "Добавить товар";
            }
        }
        private void DatabaseSelectionChanged(object sender, SelectionChangedEventArgs e) // закидывает выделенный товар в поля формы для изменения
        {
            if (Database.SelectedItem != null)
            {
                House selectedModel = (House)Database.SelectedItem;

                newItemID.Text = selectedModel.ID.ToString();
                newItemCity.Text = selectedModel.city;
                newItemMetr.Text = selectedModel.metrage.ToString();
                newItemBeds.Text = selectedModel.beds.ToString();
                newItemDesc.Text = selectedModel.Description;
                newItemPrice.Text = selectedModel.cost.ToString();
                AddImageButton.Content = selectedModel.ImagePath;

                AddItemButton.Content = "Изменить товар";
            }
        }
        #region Класс House
        
        public class House
        {
            [ImgAttribute(ErrorMessage = "Ошибка в чтении пути изображения!")]
            public string? ImagePath { get; set; }

            [NumericAttribute(ErrorMessage = "Ошибка в указании количества спален!")]
            public int? beds { get; set; }

            [NumericAttribute(ErrorMessage = "Ошибка в заполнении поля цены!")]
            public double? cost { get; set; }

            [StringAttribute(ErrorMessage = "Ошибка в заполнении поля названия города!")]
            public string? city { get; set; }

            [NumericAttribute(ErrorMessage = "Ошибка в заполнении поля метража!")]
            public double? metrage { get; set; }

            [NumericAttribute(ErrorMessage = "Ошибка в заполнении поля ID!")]
            public int? ID { get; set; }
            [DiscrAttribute(ErrorMessage = "Ошибка в заполнении поля описания!")]
            public string? Description { get; set; }
        }
#endregion
        private void searchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchField.Text != "")
            {

                var SearchResult = GlobalItemsList.FindAll(p =>
                p.ID.ToString().Contains(searchField.Text) ||
                p.city.Contains(searchField.Text) ||
                p.metrage.ToString().Contains(searchField.Text) ||
                p.beds.ToString().Contains(searchField.Text) ||         
                p.Description.Contains(searchField.Text) ||
                p.ImagePath.Contains(searchField.Text) ||
                p.cost.ToString().Contains(searchField.Text)
);
                ItemsList.ItemsSource = SearchResult;
                Database.ItemsSource = SearchResult;
            }
            else
            {
                ItemsList.ItemsSource = GlobalItemsList;
                Database.ItemsSource = GlobalItemsList;
            }
        }
        public void UpdateItemInList(List<House> myList, House newItem)
        {
            // Проверяем, существует ли элемент с заданным ID в списке
            House? currentItem = myList.FirstOrDefault(m => m.ID == newItem.ID);

            if (currentItem != null)
            {
                // Обновляем поля существующего элемента
                currentItem.ID = newItem.ID;
                currentItem.city = newItem.city;
                currentItem.metrage = newItem.metrage;
                currentItem.beds = newItem.beds;
                currentItem.Description = newItem.Description;
                currentItem.cost = newItem.cost;
                currentItem.ImagePath = newItem.ImagePath;
            }
            else
            {
                // Если элемент не найден, добавляем его в список
                myList.Add(newItem);
            }
        }
        private void DeleteItem(object sender, RoutedEventArgs e) // удаляет предмет
        {
            List<House> newList = new(GlobalItemsList);
            UndoAction.Push(newList);
            RedoAction.Clear();

            string id = deletedItemIdInput.Text;
            int a = GlobalItemsList.FindIndex(t => t.ID.ToString() == id);
            try
            {
                GlobalItemsList.RemoveAt(a);
                Database.ItemsSource = null;
                Database.ItemsSource = GlobalItemsList;
                ItemsList.ItemsSource = null;
                ItemsList.ItemsSource = GlobalItemsList;

                deletedItemIdInput.Clear();
                _ = MessageBox.Show("Предмет удален из таблицы!");
            }
            catch (Exception)
            {
                _ = MessageBox.Show("Ошибка удаления товара! Проверьте указанные данные!");
            }
        }

        private void LoadImageFile(object sender, RoutedEventArgs e) // функция загрузки изображения
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"; // фильтр

            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();

                image.BeginInit();
                image.UriSource = new Uri(openFileDialog.FileName);
                image.EndInit();

                AddImageButton.Content = "./" + image.UriSource.Segments[image.UriSource.Segments.Length - 2] + image.UriSource.Segments[image.UriSource.Segments.Length - 1]; // обрезка пути, использование только нужной
            }

        }
        private void ClearForm(object sender, RoutedEventArgs e) // очищает форму
        {

            newItemID.Clear();
            newItemCity.Clear();
            newItemMetr.Clear();
            newItemBeds.Clear();
            newItemPrice.Clear();
            newItemDesc.Clear();


            AddImageButton.Content = "";
            AddItemButton.Content = "Добавить товар";
            MessageBox.Show("Форма очищена!");

        }
        private void AddItem(object sender, RoutedEventArgs e)
        {

            _ = int.TryParse(newItemID.Text, out int newItemId); // попытка превратить в числовые значения
            _ = int.TryParse(newItemMetr.Text, out int newItemmetr);
            _ = int.TryParse(newItemPrice.Text, out int newItemprice);
            _ = int.TryParse(newItemBeds.Text, out int newItembeds);

            var newItem = new House() // создание нового товара
            {
                ID = newItemId,
                city = newItemCity.Text,
                cost = newItemprice,
                beds = newItembeds,               
                metrage = newItemmetr,
                ImagePath = AddImageButton.Content.ToString(),
                Description = newItemDesc.Text,
            };
            ValidationContext validationContext = new(newItem); // контекст валидации объекта, включая объект, который необходимо проверить, и дополнительную информацию о проверке.
            List<System.ComponentModel.DataAnnotations.ValidationResult> validationResults = new(); // результат проверки на соответствие некоторым правилам валидации, которые были заданы с использованием атрибутов валидации. 

            Validator.TryValidateObject(newItem, validationContext, validationResults, true); // валидация

            if (!Validator.TryValidateObject(newItem, validationContext, validationResults, true) ||// валидация
    validationResults.Count > 0)
            {
                foreach (System.ComponentModel.DataAnnotations.ValidationResult validationResult in validationResults)
                {
                    _ = MessageBox.Show(validationResult.ErrorMessage);
                }
                return;
            }
            if (string.IsNullOrEmpty(newItemID.Text) ||
                string.IsNullOrEmpty(newItemCity.Text) ||
                string.IsNullOrEmpty(newItemMetr.Text) ||
                string.IsNullOrEmpty(newItemBeds.Text) ||
                string.IsNullOrEmpty(newItemPrice.Text) ||
                AddImageButton.Content.ToString() == "Load image" ||
                AddImageButton.Content.ToString() == "Загрузить изображение" ||
                 string.IsNullOrEmpty(newItemDesc.Text))

            {
                _ = MessageBox.Show("Ошибка заполнения полей! Проверьте указанные значения!");
                return;
            }
            UpdateItemInList(GlobalItemsList, newItem);
            Database.ItemsSource = null;
            Database.ItemsSource = GlobalItemsList;
            ItemsList.ItemsSource = null;
            ItemsList.ItemsSource = GlobalItemsList;
            AddItemButton.Content = "Добавить товар";
            _ = MessageBox.Show(messageBoxText);
        }
        #region Undo Redo функции
        private void Undo(object sender, RoutedEventArgs e)
        {
            if (UndoAction.Count < 1)
            {
                return;
            }

            List<House> newList = new(GlobalItemsList);
            RedoAction.Push(newList);

            GlobalItemsList = UndoAction.Pop();
            Database.ItemsSource = null;
            Database.ItemsSource = GlobalItemsList;
            ItemsList.ItemsSource = null;
            ItemsList.ItemsSource = GlobalItemsList;
        }

        private void Redo(object sender, RoutedEventArgs e)
        {
            if (RedoAction.Count == 0)
            {
                return;
            }

            List<House> newList = new(GlobalItemsList);

            UndoAction.Push(newList);
            GlobalItemsList = RedoAction.Pop();

            Database.ItemsSource = null;
            Database.ItemsSource = GlobalItemsList;
            ItemsList.ItemsSource = null;
            ItemsList.ItemsSource = GlobalItemsList;
        }
        #endregion
        #region Разные события
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void RedoButton_Click(object sender, RoutedEventArgs e)
        {
            actionManager.Redo();
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            actionManager.Undo();
        }
        private void InfoCommand_Executed(object sender, RoutedEventArgs e)
        {
            _ = MessageBox.Show("Инфомация о разработчике: \nЖук Ксения \nФИТ 4-2");
        }
        private void BubbleButton_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("sender: " + "Lab4.BubbleButton" + "\n source: " + "Lab4.BubbleButton" + "\n");
            MessageBox.Show("sender: " + "System.Windows.Controls.StackPanel" + "\n source: " + "Lab4.BubbleButton" + "\n");
        }
        private void DirectButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("sender: " + "Lab4.DirectButton" + "\n source: " + "Lab4.DirectButton" + "\n");
        }
        private void TunnelButton_Click(object sender, RoutedEventArgs e)
        {
            _ = MessageBox.Show("Нажатие на Tunnel кнопку!");
        }
        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void newItemPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GreenButton_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("sender: " + sender.ToString() + "\n source: " + e.Source.ToString() + "\n");
        }
    }

}

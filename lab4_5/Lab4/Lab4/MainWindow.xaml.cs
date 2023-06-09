using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Resources;
using System.Windows.Shapes;
using System.IO;

namespace Lab4
{

    public partial class MainWindow : Window
    {
  
        public List<House> GlobalItemsList = new List<House>();
        //StreamResourceInfo sri = System.Windows.Application.GetResourceStream(new Uri("Resources/customCursor.cur", UriKind.Relative));
        private readonly ResourceDictionary lightTheme = new ResourceDictionary() { Source = new Uri("Resources/lightTheme.xaml", UriKind.Relative) };
        private readonly ResourceDictionary darkTheme = new ResourceDictionary() { Source = new Uri("Resources/darkTheme.xaml", UriKind.Relative) };
        private readonly ResourceDictionary mintTheme = new ResourceDictionary() { Source = new Uri("Resources/mintTheme.xaml", UriKind.Relative) };
        private readonly ResourceDictionary enDict = new ResourceDictionary() { Source = new Uri("Resources/langEN.xaml", UriKind.Relative) };
        private readonly ResourceDictionary ruDict = new ResourceDictionary() { Source = new Uri("Resources/langRU.xaml", UriKind.Relative) };
        private readonly Stack<List<House>> UndoAction = new Stack<List<House>>();
        private readonly Stack<List<House>> RedoAction = new Stack<List<House>>();
        private readonly string itemsDB = "../../../items.json";


        //#region Функции инициализации окна
        public MainWindow()
        {
          //  Cursor customCursor = new Cursor(sri.Stream); // свой курсор
            InitializeComponent(); // инициализация XAML
         //   MainShopGrid.Cursor = customCursor; // добавление курсора
            Resources.MergedDictionaries.Add(ruDict); // словарь русских слов
            Resources.MergedDictionaries.Add(lightTheme); // светлая тема
        }
        private void searchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchField.Text != "")
            {

                var SearchResult = GlobalItemsList.FindAll(p =>
                p.ID.ToString().Contains(searchField.Text) ||
                p.city.Contains(searchField.Text) ||
                p.metrage.ToString().Contains(searchField.Text) ||
                p.beds.ToString().Contains(searchField.Text) ||
                p.baths.ToString().Contains(searchField.Text) ||
                p.Description.Contains(searchField.Text) ||
                p.ImagePath.Contains(searchField.Text) ||
                p.cost.ToString().Contains(searchField.Text)
);
                ItemsList.ItemsSource = SearchResult;
             //   Database.ItemsSource = SearchResult;
            }
            //else
            //{
            //    ItemsList.ItemsSource = GlobalItemsList;
            //    Database.ItemsSource = GlobalItemsList;
            //}
        }

        //private void Window_Initialized(object sender, EventArgs e)
        //{
        //    GlobalItemsList = JsonConvert.DeserializeObject<List<House>>(File.ReadAllText(itemsDB));
        //    //ItemsList.ItemsSource = GlobalItemsList;
        //   // Database.ItemsSource = GlobalItemsList;
        //}
        // #endregion

        //        private void searchField_TextChanged(object sender, TextChangedEventArgs e)
        //        {
        //            if (searchField.Text != "")
        //            {

        //                var SearchResult = GlobalItemsList.FindAll(p =>
        //                p.ID.ToString().Contains(searchField.Text) ||
        //                p.city.Contains(searchField.Text) ||
        //                p.metrage.Contains(searchField.Text) ||
        //                p.beds.ToString().Contains(searchField.Text) ||
        //                p.baths.ToString().Contains(searchField.Text) ||
        //                p.Description.Contains(searchField.Text) ||
        //                p.ImagePath.Contains(searchField.Text) ||
        //                p.Price.ToString().Contains(searchField.Text)
        //);
        //                ItemsList.ItemsSource = SearchResult;
        //                Database.ItemsSource = SearchResult;
        //            }
        //            else
        //            {
        //                ItemsList.ItemsSource = GlobalItemsList;
        //               // Database.ItemsSource = GlobalItemsList;
        //            }
        //        }
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
          //  Database.ItemsSource = GlobalItemsList; // загрузка данных в таблицу на 2 вкладке
            MessageBox.Show("Данные загружены из файла!");
        }
        #endregion









    }

    public class MainViewModel
    {
        public List<House> Houses { get; set; }

        public MainViewModel()
        {
            Houses = new List<House>() {
            new House { ImagePath="../img/img1.jpg", cost = 2099000, beds = 3, baths = 2, metrage = 1871, city = "Los Angeles", ID = "90066" },
            new House { ImagePath="../img/img2.jpg",cost = 4699999, beds = 6, baths = 7, metrage = 4794, city = "San Diego", ID = "90048" },
            new House { ImagePath="../img/img3.jpg",cost = 2995000, beds = 5, baths = 4, metrage = 3407, city = "Los Angeles", ID = "90067" },
            new House { ImagePath="../img/img4.jpg",cost = 2495000, beds = 5, baths = 4, metrage = 2323, city = "Los Angeles", ID = "90078" },
            new House {ImagePath="../ img/img5.jpg", cost = 2700000, beds = 3, baths = 2, metrage = 1758, city = "San Francisco ", ID = "90147" },
            new House { ImagePath="../img/img6.jpg",cost = 3595000, beds = 3, baths = 4, metrage = 2614, city = "San Francisco ", ID = "90078" }
           };
        }
    }
}
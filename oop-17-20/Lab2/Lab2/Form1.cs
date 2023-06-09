using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;

namespace Lab2
{
    public partial class Form1 : Form
    {

        Timer timer;
        ToolStripLabel infolabel;
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        public List<Flat> flats = new List<Flat>();
        public List<Flat> resultflats = new List<Flat>();
        Flat flat = new Flat();
        public int counter = 0;
        public int item = 0;
        public int price = 0;
        public Form1()
        {
            InitializeComponent();
;           infolabel = new ToolStripLabel();
            this.BackgroundImage = Image.FromFile("D:\\additional\\photoes\\Imgg.jpg");
            trackBar1.Scroll += trackBar1_Scroll;
            floor.Validating += floor_Validating;
            textBox2.Validating += textBox2_Validating;
            comboBox1.Validating += comboBox1_Validating;
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            info.Items.Add(infolabel);
            info.Items.Add(dateLabel);
            info.Items.Add(timeLabel);
            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
            string path = "flat1.json";
            File.WriteAllText(path, "");

        }
        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void floor_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (String.IsNullOrEmpty(floor.Text))
            {
                errorProvider1.SetError(floor, "Введите значение");
            }
            if (!Int32.TryParse(floor.Text, out num) || num < 1 || num > 20)
            {
                errorProvider1.SetError(floor, "Некорретный ввод!");
            }
        }


        private void floor_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            toolStripStatusLabel3.Text = "Последнее выполненное действие: выбор этажа";
            textBox3.Text = price.ToString();
            try { price = price + Convert.ToInt32(floor.Text) * 100;}
            catch { }
            
            textBox3.Text = price.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            result.Text = $"Значение: {trackBar1.Value}";
            toolStripStatusLabel3.Text = "Последнее выполненное действие: изменение метража";
            price = price + 10 * trackBar1.Value;
            textBox3.Text = price.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее выполненное действие: открытие 2 формы";
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Введите значение");
            }
            if (!Int32.TryParse(textBox2.Text, out num) || num < 1960 || num > 2023)
            {
                errorProvider1.SetError(textBox2, "Некорретный ввод!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (String.IsNullOrEmpty(comboBox1.Text) || String.IsNullOrEmpty((options.Text))
                    || String.IsNullOrEmpty((textBox2.Text))
                    || String.IsNullOrEmpty((floor.Text))
                   || String.IsNullOrEmpty((iD.Text)))
                { MessageBox.Show("Не все поля заполнены или заполнены не верно"); }
                else {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Flat>));             
                    using (FileStream fs = new FileStream("flat1.json", FileMode.OpenOrCreate))
                    {
                        jsonFormatter.WriteObject(fs, flats);
                        MessageBox.Show("Данные сохранены");
                    }
                }
            }catch(Exception ex) {
                MessageBox.Show("Что-то пошло не так(((");
            }
            toolStripStatusLabel3.Text = "Последнее выполненное действие: сохранение данных";
            price = 0;
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                errorProvider2.SetError(comboBox1, "Введите значение");
            }
            if (!Int32.TryParse(comboBox1.Text, out num) || num < 1 || num > 5)
            {
                errorProvider2.SetError(comboBox1, "Некорретный ввод!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            errorProvider2.Clear();
            toolStripStatusLabel3.Text = "Последнее выполненное действие: выбор года посторойки";
            if (Convert.ToInt32(textBox2.Text) < 2000) price += 150;
            textBox3.Text = price.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            try
            {
                var jsonListFormatter = new DataContractJsonSerializer(typeof(List<Flat>));
                using (var file = new FileStream("flat1.json", FileMode.Open))
                {
                 flats = (List<Flat>)jsonListFormatter.ReadObject(file);
                    foreach (Flat flat in flats) {
                        textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так(((1");
            }
            toolStripStatusLabel3.Text = "Последнее выполненное действие: вывод данных";
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider2.Clear();
        }

        private void prog_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 2.0!!!Разработчик: Жук Ксения Михайловна");
            toolStripStatusLabel3.Text = "Последнее выполненное действие: вывод данных о программе";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее выполненное действие: запись данных";
            Flat flat = new Flat();

            try
            {
                using (var file = new FileStream("flat.json", FileMode.Open))
                {
                    var jsonListFormatter = new DataContractJsonSerializer(typeof(Flat));
                     flat = (Flat)jsonListFormatter.ReadObject(file);
                }

            Random random = new Random();
            flat.meterage = trackBar1.Value;
            flat.rooms = Convert.ToInt32(comboBox1.Text);
            flat.year =textBox2.Text;
            flat.option = options.Text;
            flat.floor = Convert.ToInt32(floor.Text);
            flat.cost = price;
                flat.ID = iD.Text;
                Flat.CreateID(flat.ID);
            flats.Add(flat);
                counter =  counter + 1;
                toolStripStatusLabel2.Text = $"Кол-во объектов: {counter}";
                
            }
            catch { MessageBox.Show("Что-то пошло не так((("); }
        }
 
        private void square_Click(object sender, EventArgs e)
        {
            var listofsquare = flats.OrderBy(x => x.meterage);
            textBox1.Clear();
            foreach (Flat flat in listofsquare)
            {
                textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";
                resultflats.Add(flat);
            }
            toolStripStatusLabel3.Text = "Последнее выполненное действие: Сортировка по площади\"";
            
        }

        private void количествуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listofsquare = flats.OrderBy(x => x.rooms);
            textBox1.Clear();
            foreach (Flat flat in listofsquare)
            {
                textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";
                resultflats.Add(flat);
            }
            toolStripStatusLabel3.Text = "Последнее выполненное действие: Сортировка по кол-ву комнат";
        }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее выполненное действие: сохраниние результатов";
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Flat>));
            using (FileStream fs = new FileStream("result.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, resultflats);
                MessageBox.Show("Данные сохранены в файл result.json");
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее выполненное действие: поиск ";
            try
            {
                Regex regex = new Regex(@"^\d+$");
                MatchCollection matches = regex.Matches(resultBox.Text);
                if (matches.Count > 0)
                {
                    textBox1.Clear();
                    MessageBox.Show("Совпадения найдены");

                    foreach (Match match in matches)
                    {
                        textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";
                        resultflats.Add(flat);
                    }

                }
                else
                {
                    MessageBox.Show("Совпадений не найдено");
                }

                var listofsquare = from i in flats
                                   where i.rooms == Convert.ToInt32( resultBox.Text)
                                   select i;
                foreach (Flat flat in listofsquare)
                {
                    textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";
                    resultflats.Add(flat);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные!!!");
            }
        }
        private void ragionFind_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            toolStripStatusLabel3.Text = "Последнее выполненное действие: поиск по району";
            try
            {
                Regex regex = new Regex(@"^[А-яа-я\s]+(?:[\-\'][А-яа-я\s]+)*$");
                MatchCollection matches = regex.Matches(resultBox.Text);
                if (matches.Count > 0)
                {
                   
                    MessageBox.Show("Совпадения найдены");
                   
                 //  foreach (Match match in matches) {
                 //      textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";
                 //      resultflats.Add(flat);
                 //  }
                        
                }
                else
                {
                    MessageBox.Show("Совпадений не найдено");
                }
                var listofsquare = from i in flats
                                   where i.street == resultBox.Text
                                   select i;
                textBox1.Clear();
                foreach (Flat flat in listofsquare)
                {
                    textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";
                    resultflats.Add(flat);
                }
            }
            catch (Exception) {
                MessageBox.Show("Неверные данные!!!");
            }

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее выполненное действие: поиск по городу";
            try
            {
                Regex regex = new Regex(@"^[А-яа-я\s]+(?:[\-\'][А-яа-я\s]+)*$");
                MatchCollection matches = regex.Matches(resultBox.Text);
                if (matches.Count > 0)
                {
                    
                    MessageBox.Show("Совпадения найдены");
                 // foreach (Match match in matches)
                 // {
                 //     textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";
                 //     resultflats.Add(flat);
                 // }
                }
                else
                {
                    MessageBox.Show("Совпадений не найдено");
                }
                var listofsquare = from i in flats
                                   where i.street == resultBox.Text
                                   select i;
                textBox1.Clear();
                foreach (Flat flat in listofsquare)
                {
                    textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";
                    resultflats.Add(flat);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные!!!");
            }

        }


        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Visible)
            {
                menuStrip1.Hide();
                toolStripStatusLabel3.Text = "Последнее выполненое действие: скрытие панели инструментов.";

            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text += $"{counter}";
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }
        
        private void costToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            toolStripStatusLabel3.Text = "Последнее выполненное действие: Сортировка по цене";
            var listofsquare =  flats.OrderBy(x => x.cost);
            textBox1.Clear();
            foreach (Flat flat in listofsquare)
            {
                textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";
                resultflats.Add(flat);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее выполненное действие: выбор числа конмат";
            switch (Convert.ToInt32(comboBox1.Text))
            {
                case 1:
                    price += 1500;
                    break;
                case 2:
                    price += 1400;
                    break;
                case 3:
                    price += 1700;
                    break;
                case 4:
                    price += 1900;
                    break;
                case 5:
                    price += 2200;
                    break;
                default:
                    break;
            }
            textBox3.Text = price.ToString();
        }

        private void options_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее выполненное действие: выбор опции";
            switch (options.Text)
            {
                case "подвал":
                    price += 500;
                    break;
                case "балкон":
                    price += 900;
                    break;
                case "столовая":
                    price += 1500;
                    break;
                case "гардеробная":
                    price += 1700;
                    break;
                case "кладовая":
                    price += 300;
                    break;
                default:
                    break;
            }
            textBox3.Text = price.ToString();

        }

        private void resultBox_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Последнее выполненное действие: выбор данных для поиска";
        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
            menuStrip1.Show();
        }


        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            flats.Clear();
            string path = "flat1.json";
            File.WriteAllText(path, "");
            MessageBox.Show("Все элементы удалены!");
        }

        private void FlRoom_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            try
            {
                Regex regex = new Regex(@"[1-5]");
                MatchCollection matches = regex.Matches(resultBox.Text);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        Console.WriteLine(match.Value);
                }
                else
                {
                    MessageBox.Show("Совпадений не найдено");
                }
                var listofsquare = from i in flats
                                   where i.rooms == Convert.ToInt32(resultBox.Text)
                                   select i;
                textBox1.Clear();
                foreach (Flat flat in listofsquare)
                {
                    textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";
                    resultflats.Add(flat);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные!!!");
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            try
            {
                if (flats.Count < item)
                {
                    MessageBox.Show("Больше элементов нет");
                }
                else
                {
                    item++;
                    Flat flat = flats[item];
                    textBox1.Clear();
                    textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";

                }
            }
            catch (Exception ex) {
                MessageBox.Show("Больше элементов нет");
            }
        }

        private void previous_Click(object sender, EventArgs e)
        {
            try { 
            if (flats.Count < item)
            {
                MessageBox.Show("Больше элементов нет");
            }
            else
            {
                    if (item != 0) { 
                item--;}
                Flat flat = flats[item];
                    textBox1.Clear();
                    textBox1.Text = textBox1.Text + $"\r\nId - {flat.ID}, Метраж - {flat.meterage}\n, Число комнат- {flat.rooms}\n, Этаж - {flat.floor}\n, Год постройки- {flat.year}\n , Опция - {flat.option}\n, Страна - {flat.country}\n, Город- {flat.city}\n, Район - {flat.street}\n, Дом- {flat.house}\n , Номер квартиры - {flat.flat_num}\n , Цена {flat.cost} \n";


                }
            }
            catch(Exception ex) {
                MessageBox.Show("Больше элементов нет");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = price.ToString();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

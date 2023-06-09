using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Drawing;

namespace Lab2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            city.Validating += city_Validating;
            city.TextChanged += city_TextChanged;
            street.TextChanged += street_TextChanged;
            street.Validating += street_Validating;
            house.Validating += house_Validating;
            house.TextChanged += house_TextChanged;
            //flat_num.Validating += flat_num_Validating;
            flat_num.TextChanged += flat_num_TextChanged;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text) {
                case "Италия":
                    errorProvider1.Clear();
                    city.Text = "Рим";
                    street.Text = "Виа Джулия";
                    house.Text = "4";
                    flat_num.Text = "15";
                    break;
                case "США":
                    errorProvider1.Clear();
                    city.Text = "Нью-Йорк";
                    street.Text = "Уолл-стрит";
                    house.Text = "1";
                    flat_num.Text = "1";
                    break ;
                case "Франция":
                    errorProvider1.Clear();
                    city.Text = "Париж";
                    street.Text = "Розье";
                    house.Text = "12";
                    flat_num.Text = "21";
                    break;
                default:
                    errorProvider1.SetError(comboBox1, "Выберете одно из значений");
                    break;
            }

        }

        private void city_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(city.Text))
            {
                errorProvider1.SetError(city, "Введите значение");
            }
            if ((comboBox1.Text == "Италия" && (city.Text != "Рим" && city.Text != "Милан" && city.Text != "Венеция"))) {
                errorProvider1.SetError(city, "Неверно");
                MessageBox.Show("Доступно: Рим, Милан, Венеция ");
            }
            if ((comboBox1.Text == "США" && (city.Text != "Нью-Йорк" && city.Text != "Сан-Франциско" && city.Text != "Техас")))
            {
                errorProvider1.SetError(city, "Неверно");
                MessageBox.Show("Доступно: Нью-Йорк, Сан-Франциско, Техас ");
            }
            if ((comboBox1.Text == "Франция" && (city.Text != "Париж" && city.Text != "Лион" && city.Text != "Ницца")))
            {
                errorProvider1.SetError(city, "Неверно");
                MessageBox.Show("Доступно: Париж, Лион, Ницца ");
            }


        }

        private void street_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(street.Text))
            {
                errorProvider1.SetError(street, "Введите значение");
            }
            if ((comboBox1.Text == "Италия" && (street.Text != " Виа Рома" && street.Text != "Данте" && street.Text != "Виа Джулия")))
            {
                errorProvider1.SetError(street, "Неверно");
                MessageBox.Show("Доступно: Виа Рома, Данте, Виа Джулия ");
            }
            if ((comboBox1.Text == "США" && (street.Text != "Нью-Йорк" && street.Text != "Уолл-стрит" && street.Text != "Черч")))
            {
                errorProvider1.SetError(street, "Неверно");
                MessageBox.Show("Доступно: Нью-Йорк, Уолл-стрит, Черч");
            }
            if ((comboBox1.Text == "Франция" && (street.Text != "Розье" && street.Text != "Верье" && street.Text != "Бонопарта")))
            {
                errorProvider1.SetError(street, "Неверно");
                MessageBox.Show("Доступно: Розье, Верье, Бонопарта ");
            }

        }

        private void house_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (String.IsNullOrEmpty(house.Text))
            {
                errorProvider1.SetError(house, "Введите значение");
            }
            if (!Int32.TryParse(house.Text, out num) || num < 1 || num > 100)
            {
                errorProvider1.SetError(house, "Некорретный ввод!");
            }

        }

        private void flat_num_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (String.IsNullOrEmpty(flat_num.Text))
            {
                errorProvider1.SetError(flat_num, "Введите значение");
            }
            if (!Int32.TryParse(flat_num.Text, out num) || num < 1 || num > 100)
            {
                errorProvider1.SetError(flat_num, "Некорретный ввод!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(city.Text) || String.IsNullOrEmpty((house.Text).ToString())
                    || String.IsNullOrEmpty((street.Text))
                    || String.IsNullOrEmpty((flat_num.Text).ToString()))
                { MessageBox.Show("Не все поля заполнены или заполнены не верно"); }
                else {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Flat));
                    Flat flat = new Flat(comboBox1.Text, city.Text, street.Text, Convert.ToInt32(house.Text), Convert.ToInt32(flat_num.Text));
                    using (FileStream fs = new FileStream("flat.json", FileMode.Create))
                    {
                        jsonFormatter.WriteObject(fs, flat);
                        MessageBox.Show("Данные сохранены");
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void city_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void street_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void house_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void flat_num_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}

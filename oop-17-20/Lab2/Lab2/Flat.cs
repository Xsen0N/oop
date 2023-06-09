using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    [Serializable]

    public class Flat
    {
        [Validation.UDKValidation(ErrorMessage = "Неправильный ID!")]
        [RegularExpression(@"[0-9]{1,5}")]
        [Required(ErrorMessage = "Не указан ID")]
        public string ID { get; set; }
        [Required]
        public float meterage { get; set; }

        public int rooms { get; set; }
        public string option { get; set; }
        [RegularExpression(@"^\+[1-9]\d{3}-\d{3}-\d{4}$")]
        public string year { get; set; }
        public int floor { get; set; }
        
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int house { get; set; }
        public int flat_num { get; set; }
        public int cost { get; set; }
        public Flat(float meterage, int rooms, string option, string year, int floor) { 
        this.meterage = meterage;
        this.rooms = rooms;
        this.option = option;
        this.year = year;
        this.floor = floor;
        }
        public Flat(float meterage, int rooms, string option, string year
            , int floor
            , string country, string city, string street
            , int house, int flat_num)
        {
            this.meterage = meterage;
            this.rooms = rooms;
            this.option = option;
            this.year = year;
            this.floor = floor;
            this.country = country;
            this.city = city;
            this.street = street;
            this.house = house;
            this.flat_num = flat_num;
        }
        public Flat( string country, string city, string street
    , int house, int flat_num)
        {
            this.country = country;
            this.city = city;
            this.street = street;
            this.house = house;
            this.flat_num = flat_num;
        }
        public Flat() { }
        public Flat(string ID) { 
            this.ID = ID;
        }

        public static void CreateID(string id)
    {
        Flat fl = new Flat(id);
        var results = new List<ValidationResult>();
        var context = new ValidationContext(fl);
        if (Validator.TryValidateObject(fl, context, results, true))
            MessageBox.Show("Проходит валидацию!");
        else
            MessageBox.Show("Неверный ID!");
    }
    }
}

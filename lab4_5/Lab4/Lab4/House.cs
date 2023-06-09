using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Lab4
{
    public class House
    {
        [StringAttribute(ErrorMessage = "Ошибка в чтении пути изображения!")]
        public string? ImagePath { get; set; }

        [NumericAttribute(ErrorMessage = "Ошибка в указании количества спален!")]
        public int? beds { get; set; }

        [NumericAttribute(ErrorMessage = "Ошибка в указании количества ванных!")]
        public int? baths { get; set; }

        [NumericAttribute(ErrorMessage = "Ошибка в заполнении поля цены!")]
        public long? cost { get; set; }

        [StringAttribute(ErrorMessage = "Ошибка в заполнении поля названия города!")]
        public string? city { get; set; }

        [NumericAttribute(ErrorMessage = "Ошибка в заполнении поля метража!")]
        public int? metrage { get; set; }

        [NumericAttribute(ErrorMessage = "Ошибка в заполнении поля ID!")]
        public string? ID { get; set; }
        [StringAttribute(ErrorMessage = "Ошибка в заполнении поля описания!")]
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"{cost}\n {beds} beds • {baths} baths • {metrage}sqft\n {city},{ID} ";
        }
  
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    public partial class  Phone
    {
        public override string ToString()
        {
            return "Person: " + "ID: " + ID + " " + "Имя: " + name + " Фамилия: "  + surname + " Отчество:  " + patronymic
                + " Адрес: " + addres + " Номер карты:*" + cardnum.Substring(12, 4) +
                " Время междугородных разговоров: " + timeoftalk + "мин Время  городских разговоров: " + timeoftalkcity + "мин Кредит " + kredit + " Дебет " + debit;
        }
        public override bool Equals(object obj)
        {
            // если параметр метода представляет тип Phone
            // то возвращаем true, если фамилии совпадают
            if (obj is Phone phone) return surname == phone.surname;
            return false;
        }
        // вместе с методом Equals следует реализовать метод GetHashCode
        public override int GetHashCode() => surname.GetHashCode();
    }
}

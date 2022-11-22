using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_11
{
    public class Phone : ICanCall
    {
        public List<Phone> phoneList;
        public string surname { get; set; }
        public long timeoftalk { get; set; }
        public long debit { get; set; }
        public Phone(string surname, long timeoftalk, long debit)
        {
            this.surname = surname;
            this.timeoftalk = timeoftalk;
            this.debit = debit;
        }
        public string Show()
        {
            return $"Person:  Фамилия:  {surname}" +
                " Время междугородных разговоров: " + timeoftalk
                + " мин "
                + " Дебет " + debit;
        }
        public void callYou() {
            Console.WriteLine("I can call!");
        }
    }
}

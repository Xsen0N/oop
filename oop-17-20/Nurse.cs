using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public class Nurse : Сure, INurse
    {
        string Name = "Dr. Proper";
        public void RresGrugs()
        {
            Console.WriteLine("Ваши лекартсва");
        }
        public string Analis { get; set; }
        //-----------------------------
        public void HelpToTreat() {
            Console.WriteLine("Я на замене врача и умею лечить");
        }
    }
}

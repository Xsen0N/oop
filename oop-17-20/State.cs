using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{

    public class Сhamber 
    {
        public IChamberState State { get; set; }
        public Сhamber(IChamberState ws)
        {
            State = ws;
        }
        public void Simple()
        {
            State.Simple(this);
        }
        public void VIP()
        {
            State.VIP(this);
        }
    }
     public interface IChamberState
    {
        void Simple(Сhamber chamber);
        void VIP(Сhamber chamber);
    }
    public class FirstLvl : IChamberState
    {
        public void Simple(Сhamber chamber)
        {
            Console.WriteLine("Уборка поверхностная");
            chamber.State = new SecLvl();
        }

        public void VIP(Сhamber chamber)
        {
            Console.WriteLine("Просто уборка");
        }
    }
    public class SecLvl : IChamberState
    {
        public void Simple(Сhamber chamber)
        {
            Console.WriteLine("Закинем грязь под кровать");
            chamber.State = new ThrLvl();
        }

        public void VIP(Сhamber chamber)
        {
            Console.WriteLine("Протрем пыль");
            chamber.State = new FirstLvl();
        }
    }
    public class ThrLvl : IChamberState
    {
        public void Simple(Сhamber chamber)
        {
            Console.WriteLine("Сделаем вид, что число");
        }

        public void VIP(Сhamber chamber)
        {
            Console.WriteLine("Сделаем, чтобы блестело");
            chamber.State = new ThrLvl();
        }
    }

}

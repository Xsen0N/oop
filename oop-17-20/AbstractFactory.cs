using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public class Sick
    {
        private Time time;
        private Dosage dosage;
        public Sick(SickFactory factory)
        {
            time = factory.When();
            dosage = factory.HowMuch();
        }
        public void Put()
        {
            dosage.Put();
        }
        public void Drink()
        {
            time.Drink();
        }
    }
    public abstract class Time
    {
        public abstract void Drink();
    }
    public abstract class Dosage
    {
        public abstract void Put();
    }
   public class Tablets : Time
    {
        public override void Drink()
        {
            Console.WriteLine("Глотать 2 раза в день после еды");
        }
    }
    public class Syrup : Time
    {
        public override void Drink()
        {
            Console.WriteLine("Пить 3 раза в день");
        }
    }
    public class TabletsInstr : Dosage
    {
        public override void Put()
        {
            Console.WriteLine("Пол таблетки за раз");
        }
    }
    public  class SyrupInstr : Dosage
    {
        public override void Put()
        {
            Console.WriteLine("3мл");
        }
    }
    public abstract class SickFactory
    {
        public abstract Dosage HowMuch();
        public abstract Time When();
    }
    public  class HomeSickFactory : SickFactory
    {
        public override Dosage HowMuch()
        {
            return new SyrupInstr();
        }

        public override Time When()
        {
            return new Syrup();
        }
    }
    public class HospitalSickFactory : SickFactory
    {
        public override Dosage HowMuch()
        {
            return new TabletsInstr();
        }

        public override Time When()
        {
            return new Tablets();
        }
    }

}

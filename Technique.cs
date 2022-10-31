using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace oop_4
{
    public abstract class Technique
    {
        int ID;
        public string name;
        public int lifespan;
        public double cost;
        public string category
        {
            get => "Техника";
            set => category = value;
        }
        public abstract void Power();
        public abstract void Quality();
        public abstract string Areas_of_use { get;  }
        public string Name { get; }
        // конструктор абстрактного класса Technique
        public Technique(string name, double cost, int lifespan)
        {
            Name = name;
            this.cost = cost;
            this.lifespan = lifespan;
            ID = GetHashCode();
        }
    }
    public class MyPrinter : Technique, IProduct
    {
        int ID;
        protected const string power = "50 W/hr.";
        protected string quality = "Low % of defects";
        public int lifespan { get; set; }
        public MyPrinter(string name, double cost, int lifespan) : base(name, cost, lifespan) {
            ID = GetHashCode();
        }
        public override void Power()
        {
            Console.WriteLine(power);
        }
        public override void Quality()
        {
            Console.WriteLine("Free of defects");
        }
        void IProduct.Quality()
        {
            Console.WriteLine("No free of defects");
        }
        public override string Areas_of_use
        {
            get => "physical document processors";
        }
        double IProduct.ProductCost(double cost)
        {
            if (cost > 1000)
                cost = cost - cost * 0.1;
            else cost = +10;
            return cost;
        }
        public void ProductId()
        {
            ID = GetHashCode();
            Console.WriteLine(ID);
        }
       new public string category
        {
            get => "Принтер";
            set => category = value;
        }
        public override string ToString() => $"Type is {GetType}; Id: {ID}; Category:{category};Areas_of_use: {Areas_of_use}; Quality :{quality}; Power {power}";
        public class Scanner : IProduct
        {
            int ID;
            public string name;
            public int Lifespan;
            public int lifespan {
                get { return Lifespan; }
                set
                {
                    if (Lifespan >= 100)
                        throw new Lies("Это ложь");
                    else Lifespan = value;
                }
            }
            public double cost { get; set; }
            protected string quality = "Free of defects";
            public Scanner(string name, double cost, int lifespan)
            {
                this.name = name;
                this.cost = cost;
                this.lifespan = lifespan;
                ID = GetHashCode();
            }

            public void Quality()
            {
                Console.WriteLine("Free of defects");
            }
            public string category
            {
                get => "Сканер";
                set => category = value;
            }
            public string Name {
                get => name;
                set
                {
                    if (value == null)
                        throw new NullElemNameExceptoin("Не указано название техники!!!");
                    else if(Name.Length == 0 || Name == "Принтер")
                    {
                        throw new NameExceptoin("НЕ ВЕРНОЕ ИМЯ111!", Name);
                    }
                }
            }

            public void ProductId()
            {
                ID = GetHashCode();
                Console.WriteLine(ID);
            }
             double IProduct.ProductCost(double cost)
            {
                if (cost < 500)
                    cost = cost + cost * 0.2;
                if (cost <= 0) {
                    throw new CostExceptoin("К сожалению, цена не может быть отрицательной и 0 :(", cost);
                }
                else cost = -100;
                return cost;
            }
            public override string ToString()
            {
                return $"Type is {GetType};Name: {Name}; ID :{ID}; Category:{category};Quality: {quality}; ";
            }
        }
        public class Computer : Technique
        {
            int ID;
            protected const string power = "2000 W/hr.";
            string calculate = "I can count";
            string quality = "Low % of defects";
            public Computer(string name, double cost, int lifespan) : base(name, cost, lifespan) {
                ID = GetHashCode();
            }
            public override void Power()
            {
                Console.WriteLine(power);
            }
            virtual public void Calculate()
            {
                Console.WriteLine(calculate);
            }
            public override void Quality()
            {
                Console.WriteLine(quality);
            }

           new public string category
            {
                get => "Компьютер";
            }
            public override string Areas_of_use
            {
                get => "physical document processors";
            }
            virtual public void id()
            {
                Console.WriteLine($"Computer ID: {ID}");
            }
            public override string ToString()
            {
                return $"Type is {GetType}; Id: {ID}; Category:{calculate};Quality: {quality};Power {power}; Areas_of_use: {Areas_of_use} ";
            }
        }
        public class Workstation : Computer
        {
            int ID;
            string calculate = "I can count too";
            public Workstation(string name, double cost, int lifespan) : base(name, cost, lifespan)
            {
                ID = GetHashCode();
            }
            override public void Calculate()
            {
                Console.WriteLine(calculate);
            }
            override public void id()
            {
                int ID = GetHashCode();
                Console.WriteLine($"Workstation ID: {ID}");
            }
            new public string category
            {
                get => "Рабочая станция";
            }
            public override string ToString()
            {
                return $"Type is {GetType}; Id: {ID}; Category:{calculate}; Power {power}; Areas_of_use: {Areas_of_use}";
            }
        }
        sealed partial class Tablet : Computer
        {
            int ID;
            new  string name { get; set; }
            new int lifespan { get; set; }
            double Cost;
            public double CostEl
            {
                get { return Cost; }

                set {
                    if (value > 10000) throw new CostExceptoin("И СТОЛЬКО стоит планшет!!! Сбить цену!", cost);
                    Cost = value;
                }
            }
            string calculate = "And I can calculate";
            new public string category
            {
                get => "Планшет";
            }
            override public void id()
            {
                int ID = GetHashCode();
                Console.WriteLine($"Tablet ID: {ID}");
            }
            public Tablet(string name, double cost, int lifespan) : base(name, cost, lifespan)
            {
                ID = GetHashCode();
            }
            override public void Calculate()
            {
                Console.WriteLine(calculate);
            }
            public override string ToString()
            {
                return $"Type is {GetType}; Id: {ID}; Category:{calculate}; Power {power}; Areas_of_use: {Areas_of_use}"; 
            }
        }
        public struct Iron {
             string Model;
            double cost;
            public double CostEl
            {
                get { return cost; }

                set
                {
                    if (value > 10000) throw new CostExceptoin("И СТОЛЬКО стоит Iron!!! Сбить цену!", cost);
                    cost = value;
                }
            }
            public string model {
                get { return Model; }
                set {
                   
                    Debug.Assert(value == "Samsuni");
                    try
                    {              
                        throw new Lies("Такой модели нет");
                    }
                    catch (Lies e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Model = value;
                    
                     }
            }
        public double power { get; set; }
            public void instruction() {
                Console.WriteLine("Everybody know how to use an iron");
            }

        }
    }
}

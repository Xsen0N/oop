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
        public abstract void Power();
        public abstract void Quality();
        public abstract string Areas_of_use { get;  }
        public string Name { get; }
        // конструктор абстрактного класса Technique
        public Technique(string name)
        {
            Name = name;
            ID = GetHashCode();
        }
    }
    public class MyPrinter : Technique, IProduct
    {
        int ID;
        protected const string power = "50 W/hr.";
        protected string quality = "Low % of defects";
        public MyPrinter(string name) : base(name) {
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
        public string category
        {
            get => "Сканер";
            set => category = value;
        }
        public override string ToString() => $"Type is {GetType}; Id: {ID}; Category:{category};Areas_of_use: {Areas_of_use}; Quality :{quality}; Power {power}";
        public class Scanner : IProduct
        {
            int ID;
            protected string quality = "Free of defects";
            public void Quality()
            {
                Console.WriteLine("Free of defects");
            }
            public string category
            {
                get => "Сканер";
                set => category = value;
            }
            public string Name => "Scanner";

            public void ProductId()
            {
                ID = GetHashCode();
                Console.WriteLine(ID);
            }
            double IProduct.ProductCost(double cost)
            {
                if (cost < 500)
                    cost = cost + cost * 0.2;
                else cost = -100;
                return cost;
            }
            public override string ToString()
            {
                return $"Type is {GetType};Name: {Name}; ID :{ProductId}; Category:{category};Quality: {quality}; ";
            }
        }
        public class Computer : Technique
        {
            int ID;
            protected const string power = "2000 W/hr.";
            string calculate = "I can count";
            string quality = "Low % of defects";
            public Computer(string name) : base(name) {
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
            public Workstation(string name) : base(name) {
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
            public override string ToString()
            {
                return $"Type is {GetType}; Id: {ID}; Category:{calculate}; Power {power}; Areas_of_use: {Areas_of_use}";
            }
        }
        sealed class Tablet : Computer
        {
            int ID;
            string calculate = "And I can calculate";

            override public void id()
            {
                int ID = GetHashCode();
                Console.WriteLine($"Tablet ID: {ID}");
            }
            public Tablet(string name) : base(name) {
                ID = GetHashCode();
            }
            override public void Calculate()
            {
                Console.WriteLine(calculate);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode()+1000;
            }
            public override bool Equals(object? obj)
            {
                if (obj is Computer computer) return true;
                return false;
            }
            public override string ToString()
            {
                return $"Type is {GetType}; Id: {ID}; Category:{calculate}; Power {power}; Areas_of_use: {Areas_of_use}"; 
            }
        }
    }
}

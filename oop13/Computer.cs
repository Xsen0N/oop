using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    [Serializable]
    public class Computer 
    {
        int ID;
        public string name;
        public int cost;
        [NonSerialized]
        public int power;
        public Computer() { }
        public Computer(string name, int cost, int power)
        {
            this.name = name;
            this.cost = cost;
            this.power = power;
            ID = GetHashCode();
        }
        public Computer( int cost, int power)
        {
            this.cost = cost;
            this.power = power;
        }
        public void Power()
        {
            Console.WriteLine(power);
        }
         public string category
        {
            get => "Компьютер";
        }
        virtual public void id()
        {
            Console.WriteLine($"Computer ID: {ID}");
        }
        public override string ToString()
        {
            return $"Type is {name}. Cost: {cost}; Power: {this.power}";
        }
    }
    [Serializable]
    public class Workstation : Computer
    {
        new public string? name;
        new  public int cost;
        readonly int ID;
        public Workstation() { }
        public Workstation(string name, int cost, int power) : base(name, cost, power)
        {
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
            return $"Type is {name}. Cost: {cost}; Power: {this.power}";
        }
    }
}

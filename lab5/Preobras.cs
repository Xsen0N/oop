using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract
{
    public class Animal
    {
        public string name { get; set; }
        public int age { get; set; }
        public double size { get; set; }
        public Animal(string n, int a, double d) {
            name = n;
            age = a;
            size = d;
        }
        public Animal(string n, int a) : this(n, a, 0) {
            name = n;
            age = a;
        }
        public Animal(string name) : this(name, 0) {
        
            this.name = name;
        }
        public virtual void speak() {
            Console.WriteLine("lublu tebia");
        }

    }
    public class Cat : Animal
    {
        public int age { get; }
        string name;
        public override void speak()
        {
            Console.WriteLine("Mmmmrrrrrrr");
        }
        public Cat(string name, int age) : base(name) {
            this.age = age;
        }
    }
    public abstract class Mleco {
        public abstract void feed();

    }
    public class Rate : Mleco {
        public override void feed() {
            Console.WriteLine();
        }
    }
    public interface Feedable {
        void breath();
        abstract void feed();

    }
    public class Dolfin : Feedable {
        public void breath() { }
        public void feed() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace pract
{
    public class Person {
        public string Name { get; set; }

        public Person(string name) => Name = name;
        int age;
        public int Age {
            get => age;
            set { if (value < 0) throw new AgeExep("- number", value);
                else age = value; 
            }
        }
        //-----переопределение 
        public override string ToString()
        {
            return "This is a nice person";
        }
        public override bool Equals(object obj)
        {
            if (obj is Person phone) return Name == phone.Name;
            return false;
        }
        public override int GetHashCode() => Name.GetHashCode();
    }
    public class Company
    {
        Person[] personal;
        public Company(Person[] personal)
        {
            this.personal = personal;
        }
        public Person this[int index] { 
        get => personal[index];
        set => personal[index] = value;
        }
    }
    public struct Dog { 
    public int age = 10;
        public Dog(int age) { 
        this.age = age;
        }

    }    
}

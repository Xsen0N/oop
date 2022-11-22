using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_11
{
    public class Student
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int course { get; set; }
        private int id;

        public Student(string name, string surname, int course)
        {
            this.name = name;
            this.surname = surname;
            this.course = course;
        }
        public Student()
        {
            name = "asdfg";
            surname = "qwerty";
            course = 1;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public override string ToString()
        {
            return $"Name:  {name}, Surname: {surname}, Course: {course}";
        }
        public void Study(string name, int course)
        {
            Console.WriteLine($"Этот студент {name} является учащимся {course} курса");
        }
    }
}

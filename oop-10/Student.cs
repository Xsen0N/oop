using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace oop_09
{
    public class Student : IEnumerable
    {
        public string Name { get; set; }
        public int grate { get; set; }
        readonly long ID;
        public Student[] _students;
        public Student(Student[] studAar) {
            _students = new Student[studAar.Length];
            for (int i = 0; i < studAar.Length; i++) {
                _students[i] = studAar[i];
            }

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            // возвращаем перечислитель по коллекции
            return _students.GetEnumerator();
        }
        public Queue<Student> studentQueue = new();
        public Student(string name, int grate)
        {
            Name = name;
            ID = GetHashCode();
        }
    }
}

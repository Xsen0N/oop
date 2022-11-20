using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace oop_09
{
    public class Program
    {
        private static void Date_CollectionChanged(object item, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Student? newstudent = e.NewItems[0] as Student;
                    Console.WriteLine($"Добавлен элемент {newstudent.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    try
                    {
                        Student? prevstudent = e.NewItems[0] as Student;
                        Console.WriteLine($"Удален элемент{prevstudent.Name}");
                    }
                    catch (NullReferenceException) {
                        Console.Write("НЕ найдено");
                    }
                    break;
                case NotifyCollectionChangedAction.Replace: 
                    if ((e.NewItems?[0] is Student replacingPerson) &&
                        (e.OldItems?[0] is Student replacedPerson))
                        Console.WriteLine($"Объект {replacedPerson.Name} заменен объектом {replacingPerson.Name}");
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Student? prevstudent1 = e.NewItems[0] as Student;
                    Console.WriteLine("Вся коллекция очищена");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Student Anton = new Student("Anton", 1);
            Student Anna = new Student("Anna", 2);
            Student Mary = new Student("Mary", 1);
            Student Alex = new Student("Alex", 3);
            List<Student> studentList = new List<Student>();
            studentList.Add(Anton);
            studentList.Add(Anna);
            studentList.Add(Mary);
            studentList.Add(Alex);
            studentList[2] = new Student("Lis", 4);
            studentList.RemoveAt(1);
            studentList.RemoveAll(person => person.Name == "Rose");
            var speshpers = studentList.Exists(p => p.grate == 4);
            var speshpers2 = studentList.FindLast (p => p.grate == 1);
            List<Student> first3 = studentList.FindAll(per => per.Name == "Alex");
            for (int i = 0; i < studentList.Count; i++)
            {
                Console.WriteLine(studentList[i].Name);
            }
            List<int> elems = new List<int> { 1, 2, 8, 3, 78 };
            Queue<int> studentQueue = new Queue<int>(elems);
            foreach (var person in studentQueue) Console.WriteLine(person);
            Console.WriteLine("введите n");
            int n = Convert.ToInt32(Console.ReadLine());
            while (n > studentQueue.Count) {
                Console.WriteLine("введите n меньшей длины");
                n = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                studentQueue.Dequeue();
            }
            Console.WriteLine("Осталось:");
            foreach (var person in studentQueue) Console.WriteLine(person);
            studentQueue.Enqueue(56);
            ConcurrentDictionary< string, int > _myConcuDict = new ConcurrentDictionary<string, int>();
            try
            {
                _myConcuDict.TryAdd("A", studentQueue.Dequeue());
                _myConcuDict.TryAdd("B", studentQueue.Dequeue());
                _myConcuDict.TryAdd("C", studentQueue.Dequeue());
                _myConcuDict.TryAdd("D", studentQueue.Dequeue());
                _myConcuDict.TryAdd("E", studentQueue.Dequeue());
                _myConcuDict.TryAdd("F", studentQueue.Dequeue());
            }
            catch (InvalidOperationException) {
                Console.WriteLine("В очереди нет больше элементов,все удалено");
            }
            Console.WriteLine("Исходная коллекция");
            foreach (var item in _myConcuDict)
            {
                Console.WriteLine(item.Key + "-" + item.Value);
            }
            Console.WriteLine("Введите значение A-F ");
            string? lett = Console.ReadLine();
            bool r1 = _myConcuDict.ContainsKey(lett.ToUpper());
            if (r1) Console.WriteLine(_myConcuDict.Values);
            var people = new ObservableCollection<Student>(new Student[] { Anton, Anna, Alex, Mary });
            people.CollectionChanged += Date_CollectionChanged;
            Student Kate = new Student("Kate", 2);
            people.Add(Kate);
            people.Clear();
        }
    
    }
}
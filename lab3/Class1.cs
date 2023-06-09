using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace oop
{
    public partial class Set
    {
        public List<int> List;
        public Set(List<int> List) => this.List = List;

        //удалить элемент из множества
        public static Set operator >>(Set set, int item)
        {
            set.List.Remove(item);
            return set;
        }

        //проверка на подмножество
        public static bool operator *(Set set1, Set subset)
        {
            int countSubset = subset.List.Count;
            int counter = 0;
            foreach (var item in set1.List)
            {
                if (subset.List.Contains(item)) { counter++; }

            }
            if (counter == countSubset) { return true; }

            else { return false; }
        }
        //проверка множеств на неравенство
        public static bool operator !=(Set set1, Set set2)
        {
            int amount1 = set1.List.Count;
            int amount2 = set2.List.Count;
            if (!set1.List.Count.Equals(set2.List.Count) )
            {
                return true;
            }
            else { return false; }   
        }
        public static bool operator ==(Set set1, Set set2)
        {
            if (set1.List.Count.Equals(set2.List.Count))
            {
                return true;
            }else { return false; }
        }

        //пересечение множеств
        public static Set operator %(Set set1, Set set2)
        {
            var concatSet = new Set(new List<int>());
            foreach (var item in set1.List)
            {
                if (set2.List.Contains(item))
                {
                    concatSet.List.Add(item);
                }
            }
            return concatSet;
        }

        //добавление элемента в множество
        public static Set operator <<(Set set1, int item)
        {
            set1.List.Add(item);
            return set1;
        }

        public static void SetTest()
        {
            var set1 = new Set(new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var set2 = new Set(new List<int>() { 1, 3, 5, 7, 9 });
            var subset = new Set(new List<int>() { 1, 4, 3 });

            Console.Write($"Первое множество: ");
            foreach (var i in set1.List)
            {
                Console.Write(i + " ");

            }
            Console.WriteLine();
            Console.Write($"Второе множество: ");
            foreach (var i in set2.List)
            {
                Console.Write(i + " ");

            }
            Console.WriteLine();
            Console.Write($"Подмножество: ");
            foreach (var i in subset.List)
            {
                Console.Write(i + " ");

            }
            Console.Write($"\nУдаляем из первого множества 9: ");
            var deletedSet = set1 >> 9;
            foreach (var i in deletedSet.List)
            {
                Console.Write(i + " ");
            }         

            Console.WriteLine($"\nПроверка множество set1 на подмножество subset: {set1 * subset}");

            Console.WriteLine($"Проверка множеств set1 и set2 на неравенство: {set1 != set2}");

            Console.Write($"Добавляем ко второму множеству 10: ");
            var addSet = set2 << 10;
            foreach (var i in addSet.List)
            {
                Console.Write(i + " ");
            }   
           
            Console.Write($"\nПересечение множеств set1 и set2: ");
            var concatSet = set1 % set2;
            foreach (var i in concatSet.List)
            {
                Console.Write(i + " ");

            }
            Console.WriteLine();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract
{
    public interface Figure {
    void Print();
    }

    public class Rectangle : Figure {
        double x = 5, y = 1, h, l;
        string color;
        public void Print() {
            Console.WriteLine($"Имя: {x}  Возраст: {y}  Рост: {h}м  Длина: {l}");
        }

        public static int[] operator + (Rectangle r1, int val){
            int[] data = new int[2];
            data[0] = (int)r1.x  + val;
            data[1] = (int)r1.y + val;
            return data;}
        
    }
    public class Class1{

    }
}

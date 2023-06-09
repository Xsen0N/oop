using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract
{
    public class Class2
    {
        public enum WDay { M, T, W};
        public WDay wDay { get; }
        public Class2(WDay wDay)
        {
            this.wDay = wDay;
        }
        public static bool operator ==(Class2 w1, Class2 w2) { 
        if(w1.wDay==w2.wDay)return true;
        return false;
        }
        public static bool operator !=(Class2 w1, Class2 w2)
        {
            if (w1 == w2) return false;
            return true;
        }
        
    }
    public class Qwert : Qwe, Iqwert
    {
        void Iqwert.Go()
        {
            Console.WriteLine("nkknk");
        }
        public override void Go()
        {
            Console.WriteLine("1111111");
        }

    }
    public interface Iqwert
    {
        void Go();

    }
    public abstract class Qwe
    {
        public abstract void Go();
    }

}

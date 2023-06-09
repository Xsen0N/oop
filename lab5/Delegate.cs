using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract
{
    // класс-источник события
    public delegate void SomeDelegate();
    public class Mind
    {
        public event SomeDelegate Go;
        public void CommanGo() {
            Console.WriteLine("Gooo");
            if(Go != null)
                Go();
        }
    }
    public class Leg {
        public void ObGo() { 
        Console.WriteLine("Идуууу");
        }
    }
    public class Eye 
    {
        public void ObGo()
        {
            Console.WriteLine("Смотрю, что идет");
        }
    }
    //----------------------
    public class CallMen {
        public event EventHandler Tr;
        public void Call() { 
        Console.WriteLine("ttttttttrrr");
            if (Tr != null)
                Tr(this, null);
        }    
    }
    public class Men {
        public void Answer(object sender, EventArgs e) { 
        Console.WriteLine("Allo?");
        }
    }


}

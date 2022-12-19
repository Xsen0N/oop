using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab17
{
    public class Doctor : Сure, IDoctor
    {
        public string Name { get; set; }
        public void Analyze(int pain_lvl) {
            if (pain_lvl < 5) Console.WriteLine("Вы не больны");
            if (pain_lvl > 5 && pain_lvl < 10) Console.WriteLine("Сейчас посмотрим");
            if (pain_lvl > 10) Console.WriteLine("Кладите его!!!!");
        }
        public void RresGrugs()
        {
            Console.WriteLine("Ваши лекартсва");
        }
        // Builder 
        public Disease Find(Symptoms syms)
        {
            syms.FindDis();
            syms.Symp1();
            syms.Symp2();
            return syms.Disease;
        }
        //--------------------
        public void Treat() {
            Console.WriteLine("Я вас лечу");
        }
    }
    public abstract class Symptoms
    {
        public Disease Disease { get; private set; }
        public void FindDis()
        {
            Disease = new Disease();
        }
        public abstract void Symp1();
        public abstract void Symp2();
    }
}

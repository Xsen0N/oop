using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public class NursingStaff
    {
        private int patients = 15; // кол-во ппациентов в день в среднем
        private int patience = 10; // уровень стресса

        public void Visit()
        {
            if (patients > 0)
            {
                patience--;
                Console.WriteLine($"Приход больных. Осталось {--patients} еще пациентов");
            }
            else
                Console.WriteLine("Надо отдохнуть Срочно!!!!");
        }
        // сохранение состояния
        public NurseMemento SaveState()
        {
            Console.WriteLine("Запомним. Еще: {0} пациентов, {1} - уровень спокойствия", patients, patience);
            return new NurseMemento(patients, patience);
        }

        // восстановление состояния
        public void RestoreState(NurseMemento memento)
        {
            this.patients = memento.Patients;
            this.patience = memento.Patience;
            Console.WriteLine("Вспомним и подумаем, может иначе. Еще: {0} пациентов, {1} - уровень спокойствия", patients, patience);
        }

    }// Memento
    public class NurseMemento
    {
        public int Patients { get; private set; }
        public int Patience { get; private set; }

        public NurseMemento(int patients, int patience)
        {
            this.Patients = patients;
            this.Patience = patience;
        }
    }
    class DayHistory
    {
        public Stack<NurseMemento> History { get; private set; }
        public DayHistory()
        {
            History = new Stack<NurseMemento>();
        }
    }
}

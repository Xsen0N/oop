using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public class NurseToDoctor : IDoctor
    {
        Nurse Nurse;
        public NurseToDoctor(Nurse nurse) { 
        Nurse = nurse;
        }
        public void Treat() { 
        Nurse.HelpToTreat();
        }
    }
}

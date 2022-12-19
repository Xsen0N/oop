using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public abstract class Diagnosis
    {
        public Diagnosis(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetPain();
    }
    class Cough : Diagnosis
    {
        public Cough() : base("Сильный кашель")
        { }
        public override int GetPain()
        {
            return 5;
        }
    }
    class Nausea : Diagnosis
    {
        public Nausea() : base("Тошнота")
        { }
        public override int GetPain()
        {
            return 4;
        }
    }
    abstract class DiagnosisDecorator : Diagnosis
    {
        protected Diagnosis diagnosis;
        public DiagnosisDecorator(string n, Diagnosis diagnosis) : base(n)
        {
            this.diagnosis = diagnosis;
        }
    }
    class StrongNausea : DiagnosisDecorator
    {
        public StrongNausea(Diagnosis p)
            : base(p.Name + ", сильное обезвоживание", p)
        { }

        public override int GetPain()
        {
            return diagnosis.GetPain() + 3;
        }
    }
    class HeadAche : DiagnosisDecorator
    {
        public HeadAche(Diagnosis p)
            : base(p.Name + ", головная боль", p)
        { }

        public override int GetPain()
        {
            return diagnosis.GetPain() + 10;
        }
    }
}

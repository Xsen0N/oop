using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17
{
    public class Hospital
    {
        string Name = "Sacred Heart";
        public void ShowDocs(Doctor item) {
            Console.WriteLine($"The best doc is {item.Name}");
        }
        public string Deag { get; set; }
    }
}

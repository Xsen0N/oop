using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_4
{
    public class Laboratory
    {
        public List<object> List;
        public Laboratory(List<object> List) => this.List = List;
        public int quantity { get; set; }
        public object Delete (Laboratory laboratory, object item)
        {
            laboratory.List.Remove(item);
            return laboratory;
        }
        public object AddEl(Laboratory laboratory, object item)
        {
            laboratory.List.Add(item);
            return laboratory;
        }
        public void Show(Laboratory laboratory)
        {
            foreach (var i in laboratory.List)
            {
                Console.Write(i + " ");
            }
        }

    }
}

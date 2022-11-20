using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_4
{
     interface IProduct
    {
        string Name { get { return "Product"; } }
        public int lifespan { get; set; }
        string category { get; set ;}
        double ProductCost(double cost);
        void ProductId();
        void Quality() {
            Console.WriteLine("Quality is good");
        }
    }
}

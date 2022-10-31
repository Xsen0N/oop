using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop07
{
     interface IGenIntr<T> where  T : new()
    {
        void Add(T i);
        void Remove(T i);
        void Show();
    }
}

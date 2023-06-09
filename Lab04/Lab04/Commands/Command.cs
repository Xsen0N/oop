using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Lab04.Commands
{
    public abstract class Command
    {
        protected readonly Canvas canvas;
        protected readonly UIElement element;
        protected readonly Point position;

        public Command(Canvas canvas, UIElement element, Point position)
        {
            this.canvas = canvas;
            this.element = element;
            this.position = position;
        }

        public abstract void Execute();

        public abstract void Unexecute();
    }
}

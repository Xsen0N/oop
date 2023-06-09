using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Lab04.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(Canvas canvas, UIElement element, Point position)
            : base(canvas, element, position) { }

        public override void Execute()
        {
            canvas.Children.Add(element);
            Canvas.SetLeft(element, position.X);
            Canvas.SetTop(element, position.Y);
        }

        public override void Unexecute()
        {
            canvas.Children.Remove(element);
        }
    }

    public class RemoveCommand : Command
    {
        public RemoveCommand(Canvas canvas, UIElement element, Point position)
            : base(canvas, element, position) { }

        public override void Execute()
        {
            canvas.Children.Remove(element);
        }

        public override void Unexecute()
        {
            canvas.Children.Add(element);
            Canvas.SetLeft(element, position.X);
            Canvas.SetTop(element, position.Y);
        }
    }
}

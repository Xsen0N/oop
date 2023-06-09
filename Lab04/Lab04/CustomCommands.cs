using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab04
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand InfoCommand = new RoutedUICommand(
            "Info command",
            "InfoCommand",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
            new KeyGesture(Key.K, ModifierKeys.Control)
            }
        );
    }
}

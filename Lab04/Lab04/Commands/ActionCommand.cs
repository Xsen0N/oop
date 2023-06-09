using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab04.Commands
{
    public class ActionCommand<T> : ICommand // конструктор для команд, которые используются в XAML (см ссылки этого класса). Есть и встроенный, но без указания типа <>
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public ActionCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute((T)parameter);

        public void Execute(object parameter) => _execute((T)parameter);

        public event EventHandler CanExecuteChanged;
    }

}

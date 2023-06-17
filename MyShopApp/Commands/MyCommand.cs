using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyShopApp.Commands
{

    public class MyCommand : ICommand
    {
        private readonly Action action;
        private readonly Func<bool> predicate;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public MyCommand(Action action, Func<bool> predicate)
        {
            this.action = action;
            this.predicate = predicate;
        }

        public bool CanExecute(object? parameter)
        {
            return predicate.Invoke();
        }

        public void Execute(object? parameter)
        {
            action.Invoke();
        }
    }
}

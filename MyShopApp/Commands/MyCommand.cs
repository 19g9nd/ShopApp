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

        public event EventHandler? CanExecuteChanged;

        public MyCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action.Invoke();
        }
    }
}

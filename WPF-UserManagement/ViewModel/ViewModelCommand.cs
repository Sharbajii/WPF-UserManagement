using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_UserManagement.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        //Fileds
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecutePredicate;

        //Constructors
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecutePredicate = null;
        }

        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecutePredicate)
        {
            _executeAction = executeAction;
            _canExecutePredicate = canExecutePredicate;
        }

        //Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Methods
        public bool CanExecute(object parameter)
        {
            // return _canExecutePredicate == null ? true : _canExecutePredicate(parameter);

            if (_canExecutePredicate == null)
            {
                return true;
            }
            else
            {
                return _canExecutePredicate(parameter);
            }
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }




    }
}

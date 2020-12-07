using System;
using System.Windows.Input;

namespace PatientDetails.Commands
{
    public class RelayCommand : ICommand
    {
        #region fields
        Action myDelegate;
        #endregion

        #region methods
        public RelayCommand(Action action)
        {
            myDelegate = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            myDelegate();
        }
        #endregion
    }
}

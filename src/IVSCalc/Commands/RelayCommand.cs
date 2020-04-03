/*******************************************************************
 * Project: IVSCalc DreamTeamIVS
 * File: RelayCommand.cs
 * Date: 25.3.2020
 * Author: Peter Dragun (xdragu01stud.fit.vutbr.cz)
 *
 * Description: Replay command
 *
 *******************************************************************/

using System;
using System.Windows.Input;

namespace IVSCalc.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> executeAction;
        private readonly Func<object, bool> canExecuteAction;
        private Action<string> numberPressed;

        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecuteAction = null)
        {
            this.executeAction = executeAction;
            this.canExecuteAction = canExecuteAction;
        }

        public RelayCommand(Action executeAction, Func<bool> canExecuteAction = null)
            : this(p => executeAction(), p => canExecuteAction?.Invoke() ?? true)
        {
        }

        public RelayCommand(Action<string> numberPressed)
        {
            this.numberPressed = numberPressed;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteAction?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            executeAction?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is T typedParameter)
            {
                return canExecute?.Invoke(typedParameter) ?? true;
            }
            else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            if (parameter is T typedParameter)
            {
                execute?.Invoke(typedParameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
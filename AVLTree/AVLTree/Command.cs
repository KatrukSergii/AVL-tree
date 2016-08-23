using System;
using System.Windows.Input;

namespace AVLTree
{
    public class Command : ICommand
    {
        private readonly Func<object, bool> canExec;

        private readonly Action execAction;

        private readonly Action<object> execParamAction;
        public bool CanExecute(object parameter)
        {
            return this.canExec?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            this.execAction?.Invoke();
            this.execParamAction?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;

        private Command(Func<object, bool> canExecFunc)
        {
            this.canExec = canExecFunc;
        }

        public Command(Action execAction, Func<object, bool> canExecFunc = null)
            : this(canExecFunc)
        {
            this.execAction = execAction;
        }

        public Command(Action<object> execParamAction, Func<object, bool> canExecFunc)
            : this(canExecFunc)
        {
            this.execParamAction = execParamAction;
        }
    }
}
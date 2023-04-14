using System.Windows.Input;

namespace ViewModelNS
{
    public class Commands : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public event EventHandler? CanExecuteChanged;
        public Commands(Action execute) : this(execute, null) { }

        private Commands(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            if (parameter == null)
                return _canExecute();
            return _canExecute();
        }
        public virtual void Execute(object parameter)
        {
            _execute();
        }
    }
}

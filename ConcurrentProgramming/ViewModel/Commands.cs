using System.Windows.Input;

namespace ViewModelNS
{
    public class Commands : ICommand
    {
        private readonly Action _execute;
        
        public event EventHandler? CanExecuteChanged;


        public Commands(Action execute)
        {
            _execute = execute ?? throw new ArgumentNullException();
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public virtual void Execute(object parameter)
        {
            _execute();
        }
    }
}

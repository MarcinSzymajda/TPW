using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ModelNS;
using LogicNS;

namespace ViewModelNS
{
    public class ViewModel : INotifyPropertyChanged
    {
        public int WindowHeight { get; }
        public int WindowWidth { get; }

        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        

        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }

        private Model model { get; set; }


        public ObservableCollection<ModelNS.Ball> Balls
        {
            get { return model.Balls; }
        }

        public ViewModel()
        {
            model = new Model();
            WindowWidth = model.canvasWidth;
            WindowHeight = model.canvasHeight;
            StartCommand = new Commands(Start);
            StopCommand = new Commands(Stop);
        }
        
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }
        private void Start()
        {
            Balls.Clear();
            model.GetStartingCirclePositions(Count);

        }
        private void Stop()
        {
            model.StopAnimation();
            
        }
    }
}


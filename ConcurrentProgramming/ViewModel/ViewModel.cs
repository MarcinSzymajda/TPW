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

        private ObservableCollection<Ball> balls;
        public ObservableCollection<Ball> Balls
        {
            get => balls;
            set
            {
                balls = value;
                OnPropertyChanged();
            }
        }
        public ViewModel()
        {
            balls = new();
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
        private async void Start()
        {
            Balls = model.GetStartingCirclePositions(Count);
            while (model.IsAnimating)
            {
                await Task.Delay(10);
                Balls = model.MoveCircle(balls);
            }
        }
        private void Stop()
        {
            model.IsAnimating = false;
        }
    }
}


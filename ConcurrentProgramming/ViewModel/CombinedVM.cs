using System.Collections.ObjectModel;
using System.Windows.Input;
using ModelNS;
using LogicNS;

namespace ViewModelNS
{
    public class CombinedVM : ViewModel
    {
        public int WindowHeight { get; }
        public int WindowWidth { get; }

        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }

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
        public CombinedVM()
        {
            balls = new();
            WindowHeight = 600;
            WindowWidth = 720;
            model = new Model(WindowWidth, WindowHeight);
            StartCommand = new Commands(Start);
            StopCommand = new Commands(Stop);
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


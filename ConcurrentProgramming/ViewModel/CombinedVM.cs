using System.Collections.ObjectModel;
using System.Windows.Input;
using ModelNS;
using Logic;

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
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public Model model { get; set; }

        private ObservableCollection<Ball> balls;
        public ObservableCollection<Ball> Balls
        {
            get => balls;
            set
            {
                balls = value;
                OnPropertyChanged(nameof(Balls));
            }
        }

    

        public CombinedVM()
        {
            balls = new();
            WindowHeight = 640;
            WindowWidth = 1230;
            model = new Model(WindowWidth, WindowHeight);
           
            StartCommand = new Commands(() => Start());
            StopCommand = new Commands(() => Stop());
        }
      

        private async void Start()
        {
            
            Balls = model.GetStartingCirclePositions(Count);
            while (model.Animating)
            {
                await Task.Delay(15);
                Balls = model.MoveCircle(balls);
            }
        }

        private void Stop()
        {
            model.Animating = false;
        }

       
        
    }
}


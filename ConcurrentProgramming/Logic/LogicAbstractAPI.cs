using System.Collections.ObjectModel;
using DataNS;

namespace LogicNS
{
    public abstract class LogicAbstractAPI
    {
        public int canvasWidth;
        public int canvasHeight;
        public bool Animating { get; set; }
       public static LogicAbstractAPI CreateAPI(DataAbstractAPI? dataAPI = default)
        {
            return new LogicAPI(dataAPI ?? DataAbstractAPI.CreateApi());
        }
       public abstract ObservableCollection<Ball> CreateBalls( int amountOfBalls);
        public abstract ObservableCollection<Ball> UpdateBalls( ObservableCollection<Ball> balls);

    
    }
}

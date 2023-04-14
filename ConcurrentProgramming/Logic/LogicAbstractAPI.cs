using System.Collections.ObjectModel;
using DataNS;

namespace LogicNS
{
    public abstract class LogicAbstractAPI
    {
       public static LogicAbstractAPI CreateAPI(DataAbstractAPI? dataAPI = default)
        {
            return new LogicAPI(dataAPI ?? DataAbstractAPI.CreateApi());
        }
       public abstract ObservableCollection<Ball> CreateBalls(int canvasWidth, int canvasHeight, int amountOfBalls);
        public abstract ObservableCollection<Ball> UpdateBalls(int canvasWidth, int canvasHeight, ObservableCollection<Ball> balls);

    
    }
}

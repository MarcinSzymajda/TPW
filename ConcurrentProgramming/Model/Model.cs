using LogicNS;
using System.Collections.ObjectModel;

namespace ModelNS
{
    public class Model
    {
        private readonly int canvasWidth;
        private readonly int canvasHeight;
        private readonly LogicAbstractAPI logicAbstractAPI;
        public bool IsAnimating { get; set; }

        public Model(int canvasWidth, int canvasHeight,LogicAbstractAPI? logicAbstractAPI = null) {
            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
            this.logicAbstractAPI = logicAbstractAPI?? LogicAbstractAPI.CreateAPI();
        }

        public ObservableCollection<Ball> GetStartingCirclePositions(int amountOfBalls)
        {
            IsAnimating = true;
            return logicAbstractAPI.CreateBalls(canvasWidth, canvasHeight, amountOfBalls);
        }

        public ObservableCollection<Ball> MoveCircle(ObservableCollection<Ball> balls)
        {
            return logicAbstractAPI.UpdateBalls(canvasWidth, canvasHeight, balls);
        }
        
    }
}
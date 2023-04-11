using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    public class Model
    {
        private readonly int canvasWidth;
        private readonly int canvasHeight;
        private readonly LogicAbstractAPI logicAbstractAPI;
        public bool Animating { get; set; }

        public Model(int canvasWidth, int canvasHeight,LogicAbstractAPI logicAbstractAPI) {
            this.canvasWidth = canvasWidth;
            this.canvasHeight = canvasHeight;
            this.logicAbstractAPI = logicAbstractAPI;
        }

        public ObservableCollection<Ball> GetStartingCirclePositions(int amountOfBalls)
        {
            Animating = true;
            return logicAbstractAPI.createBalls(canvasWidth, canvasHeight, amountOfBalls);
        }

        public ObservableCollection<Ball> MoveCircle(ObservableCollection<Ball> balls)
        {
            return logicAbstractAPI.updateBalls(canvasWidth, canvasHeight, balls);
        }
        
    }
}
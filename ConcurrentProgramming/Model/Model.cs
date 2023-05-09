using LogicNS;
using System.Collections.ObjectModel;

namespace ModelNS
{
    public class Model
    {
        public readonly int canvasWidth;
        public readonly int canvasHeight;
        private readonly LogicAbstractAPI logicAbstractAPI;
        public bool IsAnimating { get; set; }

        public Model(LogicAbstractAPI? logicAbstractAPI = null) {
            this.logicAbstractAPI = logicAbstractAPI?? LogicAbstractAPI.CreateAPI();
            this.canvasWidth = this.logicAbstractAPI.canvasWidth;
            this.canvasHeight = this.logicAbstractAPI.canvasHeight;
        }

        public ObservableCollection<Ball> GetStartingCirclePositions(int amountOfBalls)
        {
            logicAbstractAPI.Animating = true;
            IsAnimating = true;
            return logicAbstractAPI.CreateBalls( amountOfBalls);
        }

        public ObservableCollection<Ball> MoveCircle(ObservableCollection<Ball> balls)
        {
            return logicAbstractAPI.UpdateBalls( balls);
        }

        public void StopAnimation()
        {
            logicAbstractAPI.Animating = false;
            IsAnimating = false;
        }
        
    }
}
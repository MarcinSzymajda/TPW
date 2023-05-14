using LogicNS;
using System.Collections.ObjectModel;

namespace ModelNS
{
    public class Model
    {
        public readonly int canvasWidth;
        public readonly int canvasHeight;
        private readonly LogicAbstractAPI logicAbstractAPI;
        public  ObservableCollection<ModelNS.Ball> Balls = new ObservableCollection<Ball>();

        public Model(LogicAbstractAPI? logicAbstractAPI = null) {
            this.logicAbstractAPI = logicAbstractAPI?? LogicAbstractAPI.CreateAPI();
            this.canvasWidth = this.logicAbstractAPI.canvasWidth;
            this.canvasHeight = this.logicAbstractAPI.canvasHeight;
        }

        public void GetStartingCirclePositions(int amountOfBalls)
        {
            Balls.Clear();
            logicAbstractAPI.Start();
            logicAbstractAPI.CreateBalls(amountOfBalls);
            convert();
        }
        
        public void StopAnimation()
        {
            logicAbstractAPI.Stop();
        }

        public void convert()
        {
            foreach (var ball in logicAbstractAPI.generateBallsList())
            {
                Balls.Add(new Ball(ball));
            }
        }
    }
}
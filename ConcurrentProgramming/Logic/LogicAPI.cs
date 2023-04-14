using System.Collections.ObjectModel;
using DataNS;

namespace LogicNS;


    public class LogicAPI : LogicAbstractAPI
    {
        private readonly DataAbstractAPI? dataAPI;

        public LogicAPI(DataAbstractAPI dataAPI)
        {
            this.dataAPI = dataAPI;
        }

        public override ObservableCollection<Ball> CreateBalls(int canvasWidth, int canvasHeight, int amountOfBalls)
        {
            ObservableCollection<Ball> balls = new ();
            Random rnd = new Random();
            for(int i=0;i<amountOfBalls;i++) 
            {
                Ball ball = new(10,rnd.Next(10,canvasWidth-10),rnd.Next(10,canvasHeight-10),"#FF0000",10);
                balls.Add(ball);
            }
            return balls;
        }

        public override ObservableCollection<Ball> UpdateBalls(int canvasWidth, int canvasHeight, ObservableCollection<Ball> balls)
        {
            ObservableCollection<Ball> updatedBalls = new();
            foreach (var ball in balls)
            {
                if (ball.X + ball.Radius >= canvasWidth || ball.X - ball.Radius <= 0) ball.speedX *= -1;
                if (ball.Y + ball.Radius >= canvasHeight  || ball.Y - ball.Radius <= 0) ball.speedY *= -1;
                ball.X += ball.speedX;
                ball.Y += ball.speedY;
                updatedBalls.Add(ball);
            }
            return updatedBalls;
        }

    }

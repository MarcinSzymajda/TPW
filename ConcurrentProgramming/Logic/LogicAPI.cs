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
                int xPosDifference = ball.speedX;
                int yPosDifference = ball.speedY;
                if (ball.X + ball.Radius + ball.speedX >= canvasWidth)
                {
                    xPosDifference =  -1*(ball.speedX - 2*Math.Abs(canvasWidth - ball.X - ball.Radius));
                    ball.speedX *= -1;
                } else if (ball.X - ball.Radius + ball.speedX <= 0)
                {
                    xPosDifference =  -1*(ball.speedX + 2*Math.Abs(ball.X - ball.Radius));
                    ball.speedX *= -1;
                }
                if (ball.Y + ball.Radius + ball.speedY >= canvasHeight )
                {
                    yPosDifference =  -1*(ball.speedY - 2*Math.Abs(canvasHeight - ball.Y - ball.Radius));
                    ball.speedY *= -1;
                }
                else if(ball.Y - ball.Radius + ball.speedY <= 0)
                {
                    yPosDifference =  -1*(ball.speedY + 2*Math.Abs(ball.Y - ball.Radius));
                    ball.speedY *= -1;
                }
                ball.X += xPosDifference;
                ball.Y += yPosDifference;
                updatedBalls.Add(ball);
            }
            return updatedBalls;
        }

    }

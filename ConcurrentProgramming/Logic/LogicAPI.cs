using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using DataNS;

namespace LogicNS;


    public class LogicAPI : LogicAbstractAPI
    {
        private readonly DataAbstractAPI? dataAPI;
        

        public LogicAPI(DataAbstractAPI dataAPI)
        {
            this.dataAPI = dataAPI;
            canvasHeight = this.dataAPI.canvasheight;
            canvasWidth = this.dataAPI.canvaswidth;
        }

        public override ObservableCollection<Ball> CreateBalls(int amountOfBalls)
        {
            for(int i=0;i<amountOfBalls;i++) 
            {
                dataAPI.Balls.Add(dataAPI.createBall());
            }
            return dataAPI.Balls;
        }

        public override ObservableCollection<Ball> UpdateBalls(ObservableCollection<Ball> balls)
        {
            ObservableCollection<Ball> updatedBalls = new();
            foreach (var ball in balls)
            {
                int xPosDifference = ball.speedX;
                int yPosDifference = ball.speedY;
                if (ball.X + ball.Radius + ball.speedX >= dataAPI.canvaswidth)
                {
                    xPosDifference =  -1*(ball.speedX - 2*Math.Abs(dataAPI.canvaswidth - ball.X - ball.Radius));
                    ball.speedX *= -1;
                } else if (ball.X - ball.Radius + ball.speedX <= 0)
                {
                    xPosDifference =  -1*(ball.speedX + 2*Math.Abs(ball.X - ball.Radius));
                    ball.speedX *= -1;
                }
                if (ball.Y + ball.Radius + ball.speedY >= dataAPI.canvasheight )
                {
                    yPosDifference =  -1*(ball.speedY - 2*Math.Abs(dataAPI.canvasheight - ball.Y - ball.Radius));
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

            dataAPI.Balls = updatedBalls;
            return dataAPI.Balls;
        }
        
    }

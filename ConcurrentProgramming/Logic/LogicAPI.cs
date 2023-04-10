using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;


namespace Logic
{

    public abstract class LogicAbstractAPI
    {
       public static LogicAbstractAPI createAPI(DataAbstractAPI dataAPI)
        {
            return new LogicAPI(dataAPI);
        }

        public abstract ObservableCollection<Ball> createBalls(int canvasWidth, int canvasHeight, int amountOfBalls);
        public abstract ObservableCollection<Ball> updateBalls(int canvasWidth, int canvasHeight, ObservableCollection<Ball> balls);

    public class LogicAPI : LogicAbstractAPI
    {
        private readonly DataAbstractAPI? dataAPI;

        public LogicAPI(DataAbstractAPI dataAPI)
        {
            this.dataAPI = dataAPI;
        }

            public override ObservableCollection<Ball> createBalls(int canvasWidth, int canvasHeight, int amountOfBalls)
            {
                ObservableCollection<Ball> balls = new ();
                Random rnd = new Random();
                for(int i=0;i<amountOfBalls;i++) 
                {
                    Ball ball = new(rnd.Next(2,4),rnd.Next(10,canvasWidth-10),rnd.Next(10,canvasHeight-10));
                    balls.Add(ball);
                }
                return balls;
            }

            public override ObservableCollection<Ball> updateBalls(int canvasWidth, int canvasHeight, ObservableCollection<Ball> balls)
            {
                ObservableCollection<Ball> updatedBalls = new();
                foreach (Ball ball in balls)
                {
                    if (ball.X + ball.Radius + 1 > canvasWidth || ball.X - ball.Radius - 1 < 0) ball.speedX *= -1;
                    if (ball.Y + ball.Radius + 1 > canvasHeight  || ball.Y - ball.Radius - 1 < 0) ball.speedY *= -1;
                    ball.X += ball.speedX;
                    ball.Y += ball.speedY;
                    updatedBalls.Add(ball);
                }
                return updatedBalls;
            }

        }
    }
}

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

        public override void CreateBalls(int amountOfBalls)
        {
            for (int i = 0; i < amountOfBalls; i++)
            {
                dataAPI.Balls.Add(dataAPI.createBall());
            }
            

            foreach (var ball in dataAPI.Balls)
            {
                Task.Run(async () =>
                {
                    while (Animating)
                    {
                        int xPosDifference = ball.speedX;
                        int yPosDifference = ball.speedY;
                        if (ball.X + ball.Radius + ball.speedX >= dataAPI.canvaswidth)
                        {
                            xPosDifference = -1 * (ball.speedX - 2 * Math.Abs(dataAPI.canvaswidth - ball.X - ball.Radius));
                            ball.speedX *= -1;
                        }
                        else if (ball.X - ball.Radius + ball.speedX <= 0)
                        {
                            xPosDifference = -1 * (ball.speedX + 2 * Math.Abs(ball.X - ball.Radius));
                            ball.speedX *= -1;
                        }

                        if (ball.Y + ball.Radius + ball.speedY >= dataAPI.canvasheight)
                        {
                            yPosDifference =
                                -1 * (ball.speedY - 2 * Math.Abs(dataAPI.canvasheight - ball.Y - ball.Radius));
                            ball.speedY *= -1;
                        }
                        else if (ball.Y - ball.Radius + ball.speedY <= 0)
                        {
                            yPosDifference = -1 * (ball.speedY + 2 * Math.Abs(ball.Y - ball.Radius));
                            ball.speedY *= -1;
                        }

                        ball.X += xPosDifference;
                        ball.Y += yPosDifference;
                        await Task.Delay(10);
                    }
                });

            }
        }

        public override List<LogicNS.Ball> generateBallsList()
        {
            List<LogicNS.Ball> list = new List<Ball>();
            foreach (var ball in dataAPI.Balls)
            {
                Ball kula = new Ball(ball);
                list.Add(kula);
            }

            return list;
        }

        public override void Start()
        {
            Animating = true;
        }

        public override void Stop()
        {
            Animating = false;
        }
    }

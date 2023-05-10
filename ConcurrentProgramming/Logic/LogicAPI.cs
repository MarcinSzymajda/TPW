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
            DataNS.Ball.counter = 0;
            dataAPI.Balls.Clear();
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
                        int xPosDifference = (int) ball.speedX;
                        int yPosDifference = (int) ball.speedY;
                        if (ball.X + ball.Radius + ball.speedX >= dataAPI.canvaswidth)
                        {
                            xPosDifference = (int) (-1 * (ball.speedX - 2 * Math.Abs(dataAPI.canvaswidth - ball.X - ball.Radius)));
                            ball.speedX *= -1;
                        }
                        else if (ball.X - ball.Radius + ball.speedX <= 0)
                        {
                            xPosDifference = (int) (-1 * (ball.speedX + 2 * Math.Abs(ball.X - ball.Radius)));
                            ball.speedX *= -1;
                        }

                        if (ball.Y + ball.Radius + ball.speedY >= dataAPI.canvasheight)
                        {
                            yPosDifference =
                               (int) (-1 * (ball.speedY - 2 * Math.Abs(dataAPI.canvasheight - ball.Y - ball.Radius)));
                            ball.speedY *= -1;
                        }
                        else if (ball.Y - ball.Radius + ball.speedY <= 0)
                        {
                            yPosDifference = (int) (-1 * (ball.speedY + 2 * Math.Abs(ball.Y - ball.Radius)));
                            ball.speedY *= -1;
                        }

                        //sprawdzanie kolizji między kulami
                      
                        
                        ball.X += xPosDifference;
                        ball.Y += yPosDifference;
                        
                        detectCollision(ball);
                        
                        await Task.Delay(10);
                        
                    }
                });

            }
        }

        public override void detectCollision(DataNS.Ball ball)
        {
            for (int i = ball.id; i < dataAPI.Balls.Count; i++)
                {
                    
                        double xSubstraction = dataAPI.Balls[i].X - ball.X;
                        double ySubstraction = dataAPI.Balls[i].Y - ball.Y;
                        double radiusSum = ball.Radius + dataAPI.Balls[i].Radius;
                        double powSum = Math.Sqrt(Math.Pow(xSubstraction, 2) + Math.Pow(ySubstraction, 2));
                        
                        if (ball == dataAPI.Balls[i]) continue;
                        if (Math.Abs(xSubstraction) >= radiusSum) continue;
                        if (Math.Abs(ySubstraction) >= radiusSum) continue;
                        lock (ball)
                        {
                            lock (dataAPI.Balls[i])
                            {
                                if (powSum >= radiusSum)
                                    continue;

                                double nVectorX = xSubstraction / powSum;
                                double nVectorY = ySubstraction / powSum;

                                double tVectorX = -nVectorY;
                                double tVectorY = nVectorX;

                                double nVectorProduct1 = nVectorX * ball.speedX + nVectorY * ball.speedY;
                                double nVectorProduct2 = nVectorX * dataAPI.Balls[i].speedX + nVectorY * dataAPI.Balls[i].speedY;

                                double tVectorProduct1 = tVectorX * ball.speedX + tVectorY * ball.speedY;
                                double tVectorProduct2 = tVectorX * dataAPI.Balls[i].speedX + tVectorY * dataAPI.Balls[i].speedY;

                                double newSpeed1 = (nVectorProduct1 * (ball.Weight - dataAPI.Balls[i].Weight) + 2 * dataAPI.Balls[i].Weight * nVectorProduct2) / (ball.Weight + dataAPI.Balls[i].Weight);
                                double newSpeed2 = (nVectorProduct2 * (dataAPI.Balls[i].Weight - ball.Weight) + 2 * ball.Weight * nVectorProduct1) / (ball.Weight + dataAPI.Balls[i].Weight);

                                ball.speedX = newSpeed1 * nVectorX + tVectorProduct1 * tVectorX;
                                ball.speedY = newSpeed1 * nVectorY + tVectorProduct1 * tVectorY;

                                dataAPI.Balls[i].speedX = newSpeed2 * nVectorX + tVectorProduct2 * tVectorX;
                                dataAPI.Balls[i].speedY = newSpeed2 * nVectorY + tVectorProduct2 * tVectorY;
                                
                                double jump =  radiusSum - powSum;
                                
                                ball.X += jump * (ball.X - dataAPI.Balls[i].X) / powSum;
                                ball.Y += jump * (ball.Y - dataAPI.Balls[i].Y) / powSum;
                                
                                dataAPI.Balls[i].X -= jump * (ball.X - dataAPI.Balls[i].X) / powSum;
                                dataAPI.Balls[i].Y -= jump * (ball.Y - dataAPI.Balls[i].Y) / powSum;
                            }
                        }

                        return;
                        
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

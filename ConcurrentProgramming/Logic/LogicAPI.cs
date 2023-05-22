using System.Diagnostics;
using DataNS;
using System.Timers;

namespace LogicNS;


    public class LogicAPI : LogicAbstractAPI
    {
        private readonly DataAbstractAPI? dataAPI;
        private int roundCounter = 0;
        private static System.Timers.Timer aTimer;
        private Logger logger = Logger.createLogger();
        
        public LogicAPI(DataAbstractAPI dataAPI)
        {
            this.dataAPI = dataAPI;
            canvasHeight = this.dataAPI.canvasheight;
            canvasWidth = this.dataAPI.canvaswidth;
        }
        
        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(2);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            foreach (var ball in dataAPI.Balls)
            {
                logger.prepareDataToSave(ball.id, ball.X, ball.Y, ball.speedX, ball.speedY);
            }
        }


        public override void CreateBalls(int amountOfBalls)
        {
            
            roundCounter++;
            DataNS.Ball.counter = 0;
            dataAPI.Balls.Clear();
            for (int i = 0; i < amountOfBalls; i++)
            {
                dataAPI.Balls.Add(dataAPI.createBall());
            }
            
            
            foreach (var ball in dataAPI.Balls)
            {
                SetTimer();
                
                Task.Run(async () =>
                {
                    int round = roundCounter;
                    while (Animating && round == roundCounter)
                    {
                        lock (ball)
                        {
                            double xPosDifference = ball.speedX;
                            double yPosDifference = ball.speedY;
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

                                yPosDifference = -1 * (ball.speedY - 2 * Math.Abs(dataAPI.canvasheight - ball.Y - ball.Radius));
                                ball.speedY *= -1;
                            } else if (ball.Y - ball.Radius + ball.speedY <= 0)
                            {
                                yPosDifference = -1 * (ball.speedY + 2 * Math.Abs(ball.Y - ball.Radius));
                                ball.speedY *= -1;
                            }
                            ball.X += xPosDifference;
                            ball.Y += yPosDifference;
                            if (ball.X - ball.Radius < 0)
                            {
                                ball.X = ball.Radius;
                            } else if (ball.X + ball.Radius > dataAPI.canvaswidth)
                            {
                                ball.X = dataAPI.canvaswidth - ball.Radius;
                            }
                            if (ball.Y - ball.Radius < 0)
                            {
                                ball.Y = ball.Radius;
                            } else if (ball.Y + ball.Radius > dataAPI.canvasheight)
                            {
                                ball.Y = dataAPI.canvasheight - ball.Radius;
                            }
                        }
                        detectCollision(ball);
                        //logger.prepareDataToSave(ball.id,ball.X,ball.Y,ball.speedX,ball.speedY);
                        await Task.Delay(10);
                    }
                });
                
            }
        }

        private void detectCollision(DataNS.Ball ball)
        {
            for (int i = ball.id; i < dataAPI.Balls.Count; i++)
            {
                lock (ball)
                {
                    lock (dataAPI.Balls[i])
                    {
                        double xSubstraction = dataAPI.Balls[i].X - ball.X;
                        double ySubstraction = dataAPI.Balls[i].Y - ball.Y;
                        double radiusSum = ball.Radius + dataAPI.Balls[i].Radius;
                        double powSum = Math.Sqrt(Math.Pow(xSubstraction, 2) + Math.Pow(ySubstraction, 2));

                        if (ball == dataAPI.Balls[i]) continue;
                        if (Math.Abs(xSubstraction) >= radiusSum) continue;
                        if (Math.Abs(ySubstraction) >= radiusSum) continue;
                        if (powSum >= radiusSum) continue;
                        double nVectorX = xSubstraction / powSum;
                        double nVectorY = ySubstraction / powSum;
                        double tVectorX = -nVectorY;
                        double tVectorY = nVectorX;
                        double nVectorProduct1 = nVectorX * ball.speedX + nVectorY * ball.speedY;
                        double nVectorProduct2 = nVectorX * dataAPI.Balls[i].speedX + nVectorY * dataAPI.Balls[i].speedY;
                        double tVectorProduct1 = tVectorX * ball.speedX + tVectorY * ball.speedY;
                        double tVectorProduct2 = tVectorX * dataAPI.Balls[i].speedX + tVectorY * dataAPI.Balls[i].speedY;
                        double newSpeed1 = (nVectorProduct1 * (ball.Weight - dataAPI.Balls[i].Weight) +
                                            2 * dataAPI.Balls[i].Weight * nVectorProduct2) /
                                           (ball.Weight + dataAPI.Balls[i].Weight);
                        double newSpeed2 = (nVectorProduct2 * (dataAPI.Balls[i].Weight - ball.Weight) +
                                            2 * ball.Weight * nVectorProduct1) / (ball.Weight + dataAPI.Balls[i].Weight);
                        ball.speedX = newSpeed1 * nVectorX + tVectorProduct1 * tVectorX;
                        ball.speedY = newSpeed1 * nVectorY + tVectorProduct1 * tVectorY;
                        dataAPI.Balls[i].speedX = newSpeed2 * nVectorX + tVectorProduct2 * tVectorX;
                        dataAPI.Balls[i].speedY = newSpeed2 * nVectorY + tVectorProduct2 * tVectorY;
                        double jump = radiusSum - powSum;
                        ball.X += jump * (ball.X - dataAPI.Balls[i].X) / powSum; 
                        ball.Y += jump * (ball.Y - dataAPI.Balls[i].Y) / powSum;
                        dataAPI.Balls[i].X -= jump * (ball.X - dataAPI.Balls[i].X) / powSum;
                        dataAPI.Balls[i].Y -= jump * (ball.Y - dataAPI.Balls[i].Y) / powSum;
                    }
                }
                return;
            }
        }

        public override List<Ball> generateBallsList()
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
            logger.initFile();
        }

        public override void Stop()
        {
            Animating = false;
            aTimer.Stop();
        }
    }
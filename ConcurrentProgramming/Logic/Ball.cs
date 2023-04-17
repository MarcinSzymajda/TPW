using DataNS;

namespace LogicNS
{
    public class Ball
    {
        public int Radius { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
        public int speedX { get; set; }
        public int speedY { get; set; }
        public string Color { get; set; }

        public Ball(DataAbstractAPI dataAbstractApi)
        {
            Random random = new Random();
            Radius = dataAbstractApi.radius;
            X = random.Next(10, dataAbstractApi.canvaswidth - 10);
            Y = random.Next(10, dataAbstractApi.canvasheight - 10);
            Color = dataAbstractApi.color;
            do
            {
                speedX = random.Next(-dataAbstractApi.maxspeed, dataAbstractApi.maxspeed);
            } while (speedX == 0);
            do
            {
                speedY = random.Next(-dataAbstractApi.maxspeed, dataAbstractApi.maxspeed);
            } while (speedY == 0);
        }

  
    }
}
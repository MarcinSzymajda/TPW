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

        public Ball(int radius,int x,int y,string color,int maxSpeed)
        {
            Random random = new Random();
            Radius = radius;
            X = x;
            Y = y;
            Color = color;
            do
            {
                speedX = random.Next(-maxSpeed, maxSpeed);
            } while (speedX == 0);
            do
            {
                speedY = random.Next(-maxSpeed, maxSpeed);
            } while (speedY == 0);
        }

  
    }
}
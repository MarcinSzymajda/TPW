namespace Logic
{
    public class Ball
    {
        public int Radius { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
        public int speedX { get; set; }
        public int speedY { get; set; }

        public Ball(int radius,int x,int y)
        {
            Random rnd = new Random();
            this.Radius = radius;
            this.X = x;
            this.Y = y;
            this.speedX = rnd.next(-3, 3);
            this.speedY = rnd.next(-3, 3);
            do
            {
                this.speedX = rnd.next(-3, 3);
                this.speedY = rnd.next(-3, 3);
            } while (speedX == 0 && speedY == 0)

        }

  
    }
}
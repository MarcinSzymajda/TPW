namespace Logic
{
    public class Ball
    {
        public int Radius { get; set; }
        public int Y { get; set; }
        public int X { get; set; }
        public int speedX { get; set; }
        public int speedY { get; set; }
        public string Color { get; set; }

        public Ball(int radius,int x,int y)
        {
            Random rnd = new Random();
            this.Radius = radius;
            this.X = x;
            this.Y = y;
            this.speedX = rnd.Next(-3, 3);
            this.speedY = rnd.Next(-3, 3);
            this.Color = string.Format("#{0:X6}", rnd.Next(0x1000000)
);             Console.WriteLine("Kula");
            do
            {
                this.speedX = rnd.Next(-3, 3);
                this.speedY = rnd.Next(-3, 3);
            } while (speedX == 0 && speedY == 0);
            Console.WriteLine("Kula");
                }

  
    }
}
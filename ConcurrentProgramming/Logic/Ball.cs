namespace Logic
{
    internal class Ball
    {
        public int Radius { get; set; }
        public int Y { get; set; }
        public int X { get; set; }


        public Ball(int radius,int x,int y)
        {
            this.Radius = radius;
            this.X = x;
            this.Y = y;
        }

  
    }
}
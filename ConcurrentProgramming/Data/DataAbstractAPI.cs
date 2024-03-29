﻿namespace DataNS
{
    public abstract class DataAbstractAPI
    {
        public int radius;
        public int canvaswidth;
        public int canvasheight;
        public string color;
        public double maxspeed;
        public int maxWeight;
        public int minWeight;
        public List<Ball> Balls { get; set; }
        public static DataAbstractAPI CreateApi()
        {
            return new DataAPI();
        }
        public abstract Ball createBall();
    }
}

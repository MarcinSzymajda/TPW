namespace DataNS
{
    public abstract class DataAbstractAPI
    {
        public int radius;
        public int canvaswidth;
        public int canvasheight;
        public string color;
        public int maxspeed;
        public static DataAbstractAPI CreateApi()
        {
            return new DataAPI();
        }
    }
    
}

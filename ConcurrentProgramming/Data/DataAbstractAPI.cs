using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using LogicNS;

namespace DataNS
{
    public abstract class DataAbstractAPI
    {
        public int radius;
        public int canvaswidth;
        public int canvasheight;
        public string color;
        public int maxspeed;
        public int maxWeight;
        public int minWeight;
        public ObservableCollection<Ball> Balls { get; set; }
        public ConcurrentQueue<Ball> Queue { get; set; } 
        public static DataAbstractAPI CreateApi()
        {
            return new DataAPI();
        }

        public abstract Ball createBall();
    }
    
}

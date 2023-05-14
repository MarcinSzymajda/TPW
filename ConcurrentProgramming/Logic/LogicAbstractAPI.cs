using DataNS;

namespace LogicNS
{
    public abstract class LogicAbstractAPI
    {
        public int canvasWidth;
        public int canvasHeight;
        public bool Animating { get; set; }
       public static LogicAbstractAPI CreateAPI(DataAbstractAPI? dataAPI = default)
        {
            return new LogicAPI(dataAPI ?? DataAbstractAPI.CreateApi());
        }
       public abstract void CreateBalls( int amountOfBalls);
        
        public abstract List<LogicNS.Ball> generateBallsList();

        public abstract void Start();
        public abstract void Stop();
    }
}

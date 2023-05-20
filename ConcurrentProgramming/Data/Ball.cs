using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataNS
{
    public class Ball : INotifyPropertyChanged
    {
        public int Radius { get; }
        private double x;
        private double y;
        private double speedx;
        private double speedy;
        public int id { get; }
        public static int counter = 0;
        public double Y
        {
            get => y;
            set
            {
                y = value;
                OnPropertyChanged();
            }
        }

        public double X { 
            get => x;
            set
            {
                x = value;
                OnPropertyChanged();
            }}

        public double speedX
        { get ; set; }
        public double speedY { get; set ;}
        public string Color { get; }
        public double Weight { get; }
        

        public Ball(DataAbstractAPI dataAbstractApi)
        {
            id = counter;
            counter++;
            Random random = new Random();
            Radius = dataAbstractApi.radius;
            X = random.Next(10, dataAbstractApi.canvaswidth - 10);
            Y = random.Next(10, dataAbstractApi.canvasheight - 10);
            Color = dataAbstractApi.color;
            Weight = random.Next(dataAbstractApi.minWeight, dataAbstractApi.maxWeight);
            do
            {
                speedX = random.Next((int) -dataAbstractApi.maxspeed, (int) dataAbstractApi.maxspeed);
            } while (speedX == 0);
            do
            {
                speedY = random.Next((int) -dataAbstractApi.maxspeed,(int) dataAbstractApi.maxspeed);
            } while (speedY == 0);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
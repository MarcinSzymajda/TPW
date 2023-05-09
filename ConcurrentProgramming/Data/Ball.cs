using System.ComponentModel;
using System.Runtime.CompilerServices;
using DataNS;

namespace LogicNS
{
    public class Ball : INotifyPropertyChanged
    {
        public int Radius { get; set; }
        private int x;
        private int y;
        private int speedx;
        private int speedy;

        public int Y
        {
            get => y;
            set
            {
                y = value;
                OnPropertyChanged();
            }
        }

        public int X { 
            get => x;
            set
            {
                x = value;
                OnPropertyChanged();
            }}

        public int speedX
        {
            get => speedx;
            set
            {
                speedx = value;
                OnPropertyChanged();
            }
        }
        public int speedY {            
            get => speedy;
            set
            {
                speedy = value;
                OnPropertyChanged();
            }}
        public string Color { get; set; }
        public double Weight { get; set; }
        

        public Ball(DataAbstractAPI dataAbstractApi)
        {
            
            Random random = new Random();
            Radius = dataAbstractApi.radius;
            X = random.Next(10, dataAbstractApi.canvaswidth - 10);
            Y = random.Next(10, dataAbstractApi.canvasheight - 10);
            Color = dataAbstractApi.color;
            Weight = random.Next(dataAbstractApi.minWeight, dataAbstractApi.maxWeight);
            do
            {
                speedX = random.Next(-dataAbstractApi.maxspeed, dataAbstractApi.maxspeed);
            } while (speedX == 0);
            do
            {
                speedY = random.Next(-dataAbstractApi.maxspeed, dataAbstractApi.maxspeed);
            } while (speedY == 0);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LogicNS;

public class Ball : INotifyPropertyChanged
{
    public double X
    {
        get => x;
        set
        {
            x = value;
            OnPropertyChanged();
        }
    }

    public double Y
    {
        get => y;
        set
        {
            y = value;
            OnPropertyChanged();
        }
    }
    public string Color { get; set; }

    public int Radius { get; set; }
    private double x;
    private double y;
    public event PropertyChangedEventHandler? PropertyChanged;

    public Ball(DataNS.Ball ball)
    {
        this.X = ball.X;
        this.Y = ball.Y;
        Radius = ball.Radius;
        Color = ball.Color;
        ball.PropertyChanged += UpdateBall;
    }

    public void UpdateBall(object source, PropertyChangedEventArgs e)
    {
        DataNS.Ball t = (DataNS.Ball)source;
        if (e.PropertyName == "Y")
        {
            Y = t.Y;
        }
        if (e.PropertyName == "X")
        {
            X = t.X;
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
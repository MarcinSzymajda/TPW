using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ModelNS;

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

    public int Radius { get; set; }
    private double x;
    private double y;
    public string Color { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public Ball(LogicNS.Ball ball)
    {
        this.X = ball.X;
        this.Y = ball.Y;
        Radius = ball.Radius;
        Color = ball.Color;
        ball.PropertyChanged += UpdateBall;
    }

    private void UpdateBall(object source, PropertyChangedEventArgs e)
    {
        LogicNS.Ball t = (LogicNS.Ball) source;
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
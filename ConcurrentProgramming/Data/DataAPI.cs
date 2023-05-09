using System.Collections.Concurrent;
using System.Collections.ObjectModel;


namespace DataNS;

public class DataAPI : DataAbstractAPI
{
    public DataAPI()
    {
        Balls = new List<Ball>();
        minWeight = 1;
        maxWeight = 10;
        radius = 10;
        maxspeed = 10;
        canvaswidth = 600;
        canvasheight = 600;
        color = "#FF0000";
    }

    public override Ball createBall()
    {
        return new Ball(this);
    }
}
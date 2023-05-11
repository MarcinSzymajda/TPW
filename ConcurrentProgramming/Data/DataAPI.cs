namespace DataNS;

public class DataAPI : DataAbstractAPI
{
    public DataAPI()
    {
        Balls = new List<Ball>();
        minWeight = 5;
        maxWeight = 10;
        radius = 10;
        maxspeed = 5;
        canvaswidth = 720;
        canvasheight = 600;
        color = "#FF0000";
    }

    public override Ball createBall()
    {
        return new Ball(this);
    }
}
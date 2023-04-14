using LogicNS;
namespace Tests;

public class BallTest
{
    private Ball ball;
    
    [SetUp]
    public void Setup()
    {
        ball = new Ball(10, 20, 30, "#FF0000", 10);
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.AreEqual(ball.Radius,10);
        Assert.AreEqual(ball.X,20);
        Assert.AreEqual(ball.Y,30);
        Assert.AreEqual(ball.Color,"#FF0000");
        Assert.LessOrEqual(ball.speedX,10);
        Assert.GreaterOrEqual(ball.speedX,-10);
        Assert.AreNotEqual(ball.speedX,0);
        Assert.LessOrEqual(ball.speedY,10);
        Assert.GreaterOrEqual(ball.speedY,-10);
        Assert.AreNotEqual(ball.speedY,0);
    }
}
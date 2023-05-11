using DataNS;
using LogicNS;
namespace Tests;

public class BallTest
{
    private DataNS.Ball ball;
   
    [SetUp]
    public void Setup()
    {
        DataAbstractAPI dataAbstractApi = DataAbstractAPI.CreateApi();
        ball = new DataNS.Ball(dataAbstractApi);
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.AreEqual(ball.Radius,10);
        Assert.AreEqual(ball.Color,"#FF0000");
        Assert.LessOrEqual(ball.speedX,10);
        Assert.GreaterOrEqual(ball.speedX,-10);
        Assert.AreNotEqual(ball.speedX,0);
        Assert.LessOrEqual(ball.speedY,10);
        Assert.GreaterOrEqual(ball.speedY,-10);
        Assert.AreNotEqual(ball.speedY,0);
    }
}
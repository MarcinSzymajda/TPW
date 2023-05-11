using System.Collections.ObjectModel;
using DataNS;
using LogicNS;
using Ball = LogicNS.Ball;

namespace Tests;

public class LogicAbstractApiTest
{
    private LogicAbstractAPI logicAbstractApi;
    private DataAbstractAPI dataAbstractApi;
    
    [SetUp]
    public void Setup()
    {
        logicAbstractApi = LogicAbstractAPI.CreateAPI();
    }

    [Test]
    public void CreateApiTest()
    {
        Assert.IsInstanceOf(typeof(LogicAbstractAPI), LogicAbstractAPI.CreateAPI());
    }

    [Test]
    public void CreateBallsTest()
    {
        
        Assert.AreEqual(0,logicAbstractApi.generateBallsList().Count);
    }

    [Test]
    public void StartAndStopAnimatingTest()
    {
        logicAbstractApi.Start();
        Assert.AreEqual(true,logicAbstractApi.Animating);
        logicAbstractApi.Stop();
        Assert.AreEqual(false,logicAbstractApi.Animating);
    }
    
}
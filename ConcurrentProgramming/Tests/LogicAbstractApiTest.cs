using System.Collections.ObjectModel;
using DataNS;
using LogicNS;

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
        Assert.AreEqual(5,logicAbstractApi.CreateBalls(5).Count);
    }

    [Test]
    public void UpdateBallsTest()
    {
        Assert.AreEqual(logicAbstractApi.CreateBalls(3).Count,
            logicAbstractApi.UpdateBalls(logicAbstractApi.CreateBalls(3)).Count);
    }
    
}
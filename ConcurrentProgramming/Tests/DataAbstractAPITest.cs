using DataNS;

namespace Tests;

public class DataAbstractAPITest
{
    [Test]
    public void CreateApiTest()
    {
        Assert.IsInstanceOf(typeof(DataAbstractAPI),DataAbstractAPI.CreateApi());
    }
}
using HelloClassNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace mainTestNS {

    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void consoleWrite()
        {
            HelloClass temp = new HelloClass();
            Assert.AreEqual(temp.consoleWrite("Hello"), "Hello");
        }
}

}
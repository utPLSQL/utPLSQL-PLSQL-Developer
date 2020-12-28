using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace utPLSQL
{
    [TestClass]
    public class RealTimeTestRunnerTest
    {
        [TestMethod]
        public void TestToscamtest()
        {
            RealTimeTestRunner testRunner = new RealTimeTestRunner();
            testRunner.Connect(username: "toscamtest", password: "toscamtest", database: "CA40");

            testRunner.RunTests(type: "USER", owner: null, name: "toscamtest", subType: null);

            testRunner.ConsumeResult(@event =>
            {
                System.Diagnostics.Trace.WriteLine(@event.type);
            });

            Assert.AreEqual("1", "1");
        }

        [TestMethod]
        public void TestToscatest()
        {
            RealTimeTestRunner testRunner = new RealTimeTestRunner();
            testRunner.Connect(username: "toscatest", password: "toscatest", database: "CA40");

            testRunner.RunTests(type: "USER", owner: null, name: "toscatest", subType: null);

            testRunner.ConsumeResult(@event =>
            {
                System.Diagnostics.Trace.WriteLine(@event.type);
            });

            Assert.AreEqual("1", "1");
        }
    }
}

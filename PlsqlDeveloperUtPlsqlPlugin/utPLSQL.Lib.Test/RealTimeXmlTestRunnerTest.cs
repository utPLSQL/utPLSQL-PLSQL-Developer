using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace utPLSQL
{
    [TestClass]
    public class RealTimeXmlTestRunnerTest
    {
        [TestMethod]
        public void TestToscamtest()
        {
            RealTimeXmlTestRunner testRunner = new RealTimeXmlTestRunner();
            testRunner.Connect(username: "toscatest", password: "toscatest", database: "CA40");

            testRunner.RunTests(type: "_ALL", owner: "toscatest", name: null, subType: null);

            List<string> events = new List<string>();
            testRunner.ConsumeResult(xml =>
            {
                System.Diagnostics.Trace.WriteLine(xml);
            });
        }
    }
}

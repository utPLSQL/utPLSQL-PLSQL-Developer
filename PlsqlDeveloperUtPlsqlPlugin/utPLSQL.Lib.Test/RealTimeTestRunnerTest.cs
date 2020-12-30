using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace utPLSQL
{
    [TestClass]
    public class RealTimeTestRunnerTest
    {
        [TestMethod]
        public void TestToscamtest()
        {
            var testRunner = new RealTimeTestRunner();
            testRunner.Connect(username: "toscamtest", password: "toscamtest", database: "CA40");

            testRunner.RunTestsWithCoverage(type: "USER", owner: null, name: "toscamtest", procedure: null, coverageSchemas: "'toscam'", "'pa_m720','pa_m770'", null);

            List<@event> events = new List<@event>();
            testRunner.ConsumeResult(@event =>
            {
                events.Add(@event);
            });

            Assert.AreEqual("pre-run", events[0].type);
            Assert.AreEqual("post-run", events.Last().type);

            var report = testRunner.GetCoverageReport();

            System.Diagnostics.Trace.WriteLine(report);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oracle.ManagedDataAccess.Client;
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

            var events = new List<@event>();
            testRunner.ConsumeResult(@event =>
            {
                events.Add(@event);
            });

            Assert.AreEqual("pre-run", events[0].type);
            Assert.AreEqual("post-run", events.Last().type);

            var report = testRunner.GetCoverageReport();

            System.Diagnostics.Trace.WriteLine(report);
        }

        [TestMethod]
        public void TestGetVersion()
        {
            var testRunner = new RealTimeTestRunner();
            testRunner.Connect(username: "toscamtest", password: "toscamtest", database: "CA40");

            string version = testRunner.GetVersion();

            Assert.AreEqual("v3.1.7.3096", version);
        }

        [TestMethod]
        public void TestGetVersionWhenNotInstalled()
        {
            var testRunner = new RealTimeTestRunner();
            testRunner.Connect(username: "c##sakila", password: "sakila", database: "ORCLCDB");

            try
            {
                string version = testRunner.GetVersion();
                Assert.Fail();
            }
            catch (OracleException e)
            {
                Assert.AreEqual("ORA-00904: \"UT\".\"VERSION\": ungültige ID", e.Message);
            }
        }
    }
}

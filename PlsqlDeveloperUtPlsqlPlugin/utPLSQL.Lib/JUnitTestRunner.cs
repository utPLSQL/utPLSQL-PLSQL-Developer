using Oracle.ManagedDataAccess.Client;
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace utPLSQL
{
    public class JUnitTestRunner : TestRunner<string>
    {
        private OracleDataReader dataReader;

        public override void RunTests(string type, string owner, string name, string subType)
        {
            string testsToRun = null;

            if (type.Equals("USER"))
            {
                testsToRun = name;
            }
            else if (type.Equals("PACKAGE"))
            {
                testsToRun = $"{owner}.{name}";
            }
            else if (type.Equals("_ALL"))
            {
                testsToRun = owner;
            }

            if (testsToRun != null)
            {
                OracleCommand cmd = new OracleCommand($"select * from table(ut.run('{testsToRun}', ut_junit_reporter()))", produceConnection);
                dataReader = cmd.ExecuteReader();
            }
        }

        public override void ConsumeResult(Action<String> action)
        {
        }

        public testsuites GetJUnitResult()
        {
            var sb = new StringBuilder();

            while (dataReader.Read())
            {
                var value = dataReader.GetString(0);

                sb.Append(value).Append("\r\n");
            }

            dataReader.Close();

            var result = sb.ToString();

            var serializer = new XmlSerializer(typeof(testsuites));
            var testsuites = (testsuites)serializer.Deserialize(new StringReader(result));

            return testsuites;
        }
    }

}

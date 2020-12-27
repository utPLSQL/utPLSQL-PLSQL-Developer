using Oracle.ManagedDataAccess.Client;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    class JUnitTestRunner : TestRunner
    {
        private OracleDataReader dataReader;

        protected override void RunTests(string type, string owner, string name, string subType)
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
                try
                {
                    OracleCommand cmd = new OracleCommand($"select * from table(ut.run('{testsToRun}', ut_junit_reporter()))", PlsqlDeveloperUtPlsqlPlugin.produceConnection);
                    dataReader = cmd.ExecuteReader();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Execute: " + e.Message);
                }
            }
        }

        internal testsuites GetJUnitResult()
        {
            var sb = new StringBuilder();
            try
            {
                while (dataReader.Read())
                {
                    var value = dataReader.GetString(0);

                    sb.Append(value).Append("\r\n");
                }

                dataReader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("READ: " + e.Message);
            }

            try
            {
                var result = sb.ToString();

                var serializer = new XmlSerializer(typeof(testsuites));
                var testsuites = (testsuites)serializer.Deserialize(new StringReader(result));

                return testsuites;
            }
            catch (Exception e)
            {
                MessageBox.Show("SERIALIZE: " + e.Message);
            }

            return null;
        }
    }

}

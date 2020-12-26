using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    class TestRunner
    {
        bool running;

        internal void Run(string type, string owner, string name, string subType)
        {
            if (running)
            {
                throw new TestsAlreadyRunningException();
            }
            else
            {
                running = true;

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
                    ExecuteSql($"select * from table(ut.run('{name}', ut_junit_reporter()))");
                }
            }
        }

        internal JUnitTestSuites GetJUnitResult()
        {
            var sb = new StringBuilder();
            while (!PlsqlDeveloperUtPlsqlPlugin.sqlEof())
            {
                var value = PlsqlDeveloperUtPlsqlPlugin.sqlField(0);

                var converteredValue = Marshal.PtrToStringAnsi(value);
                sb.Append(converteredValue).Append("\r\n");

                PlsqlDeveloperUtPlsqlPlugin.sqlNext();
            }
            var result = sb.ToString();

            var serializer = new XmlSerializer(typeof(JUnitTestSuites));
            var testSuites = (JUnitTestSuites)serializer.Deserialize(new StringReader(result));

            running = false;

            return testSuites;
        }

        private void ExecuteSql(string sql)
        {
            var code = PlsqlDeveloperUtPlsqlPlugin.sqlExecute(sql);
            if (code != 0)
            {
                var message = PlsqlDeveloperUtPlsqlPlugin.sqlErrorMessage();
                MessageBox.Show(Marshal.PtrToStringAnsi(message));
            }
        }

    }

    [System.Serializable]
    internal class TestsAlreadyRunningException : System.Exception
    {
    }
}

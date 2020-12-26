using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    class JUnitTestRunner : TestRunner
    {
        internal testsuites GetJUnitResult()
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

            var serializer = new XmlSerializer(typeof(testsuites));
            var testsuites = (testsuites)serializer.Deserialize(new StringReader(result));

            running = false;

            return testsuites;
        }
    }

    [System.Serializable]
    internal class TestsAlreadyRunningException : System.Exception
    {
    }
}

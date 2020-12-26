using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    internal abstract class TestRunner
    {
        internal bool running;

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
                    ExecuteSql($"select * from table(ut.run('{testsToRun}', ut_junit_reporter()))");
                }
            }
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
}
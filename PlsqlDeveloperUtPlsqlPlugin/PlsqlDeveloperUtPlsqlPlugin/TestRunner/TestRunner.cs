using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    internal abstract class TestRunner
    {
        internal void Run(string type, string owner, string name, string subType)
        {
            RunTests(type, owner, name, subType);
        }

        protected abstract void RunTests(string type, string owner, string name, string subType);
    }

}
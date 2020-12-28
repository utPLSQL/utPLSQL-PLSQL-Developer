using System.Drawing;

namespace PlsqlDeveloperUtPlsqlPlugin
{
    class TestResult
    {
        internal string Id { get; set; }
        internal string Result { get; set; }
        public Bitmap Icon { get; set; }
        public string Name { get; set; }
        public decimal Time { get; set; }
        public string Error { get; set; }
    }
}

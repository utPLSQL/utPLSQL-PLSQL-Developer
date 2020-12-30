using System.Windows.Forms;

namespace utPLSQL
{
    public partial class CodeCoverateReportDialog : Form
    {
        public CodeCoverateReportDialog(string path)
        {
            InitializeComponent();

            txtPaths.Text = path;
        }

        public string GetSchemas()
        {
            return txtSchemas.Text;
        }

        public string GetIncludes()
        {
            return txtIncludes.Text;
        }

        public string GetExcludes()
        {
            return txtExluces.Text;
        }
    }
}

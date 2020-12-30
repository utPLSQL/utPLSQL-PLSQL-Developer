using System.Windows.Forms;

namespace utPLSQL
{
    public partial class CodeCoverageReportDialog : Form
    {
        public CodeCoverageReportDialog(string path)
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

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRun.PerformClick();
            }
        }
    }
}

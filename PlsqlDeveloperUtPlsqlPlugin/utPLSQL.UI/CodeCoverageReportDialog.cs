using System.Collections.Generic;
using System.Windows.Forms;

namespace utPLSQL
{
    public partial class CodeCoverageReportDialog : Form
    {
        public CodeCoverageReportDialog(List<string> paths)
        {
            InitializeComponent();

            txtPaths.Text = paths[0];
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

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRun.PerformClick();
            }
        }
    }
}

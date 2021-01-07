using System.Windows.Forms;

namespace utPLSQL
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            lblVersion.Text = $"Version {fileVersionInfo.FileVersion}";
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/utPLSQL/utPLSQL-PLSQL-Developer");
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}

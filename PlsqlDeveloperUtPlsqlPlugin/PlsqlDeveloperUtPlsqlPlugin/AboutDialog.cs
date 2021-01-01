using System.Windows.Forms;

namespace utPLSQL
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
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

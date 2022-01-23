using System.Diagnostics;

namespace SteamFamilySharingBypass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Disable Steam internet access
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;

            p.StartInfo = info;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine(" netsh advfirewall firewall add rule name=\"SteamFamilySharingBypass\" dir=in action=block profile=any program=\"C:\\Program Files (x86)\\Steam\\steam.exe\" ");
                    sw.WriteLine(" netsh advfirewall firewall add rule name=\"SteamFamilySharingBypass\" dir=out action=block profile=any program=\"C:\\Program Files (x86)\\Steam\\steam.exe\" ");
                    sw.WriteLine(" netsh advfirewall firewall add rule name=\"SteamFamilySharingBypass\" dir=in action=block profile=any program=\"C:\\Program Files (x86)\\Steam\\bin\\cef\\cef.win7x64\\steamwebhelper.exe\" ");
                    sw.WriteLine(" netsh advfirewall firewall add rule name=\"SteamFamilySharingBypass\" dir=out action=block profile=any program=\"C:\\Program Files (x86)\\Steam\\bin\\cef\\cef.win7x64\\steamwebhelper.exe\" ");
                    sw.WriteLine(" pause ");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Enable Steam internet access
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;
            info.Verb = "runas";

            p.StartInfo = info;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine(" netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files (x86)\\Steam\\steam.exe\" ");
                    sw.WriteLine(" netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files (x86)\\Steam\\bin\\cef\\cef.win7x64\\steamwebhelper.exe\" ");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // open github page
            Process.Start(new ProcessStartInfo
                {
                FileName = "https://github.com/TheGloriousDuck/SteamFamilySharingBypass",
                UseShellExecute = true
                }
            );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // open youtube page
            Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.youtube.com/channel/UCbE9CmwlzQML1qbfNjcIlGw",
                    UseShellExecute = true
                }
            );
        }
    }
}
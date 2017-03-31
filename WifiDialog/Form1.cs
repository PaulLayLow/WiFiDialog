using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Wifi DLL - https://github.com/DigiExam/simplewifi 
using SimpleWifi;

namespace WifiDialog
{
    public partial class WifiForm : Form
    {
        // Create WiFi object
        private static Wifi wifi;

        public WifiForm()
        {
            InitializeComponent();
        }

        private void WifiForm_Load(object sender, EventArgs e)
        {
            wifi = new Wifi();

            List<AccessPoint> aps = wifi.GetAccessPoints();

            foreach (AccessPoint ap in aps)
            {
                ListViewItem lvap = new ListViewItem(ap.Name);

                // Grab signal strength
                lvap.SubItems.Add(ap.SignalStrength + "%");

                // Check if secured or open
                if (ap.IsSecure)
                {
                    lvap.SubItems.Add("\u221A");
                }

                // Add name
                lvap.Tag = ap;

                lvAccessPoints.Items.Add(lvap);
            }

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (wifi.ConnectionStatus == WifiStatus.Connected)
            {
                wifi.Disconnect();
                lblConnStatus.Text = "OFFLINE";
                lblConnStatus.ForeColor = Color.Red;
                MessageBox.Show("You have been disconnected.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lvAccessPoints.Items.Clear();
            WifiForm_Load(sender, e);
        }

        private void lvAccessPoints_Click(object sender, EventArgs e)
        {
            Form2 passwordDlg = new Form2();
            passwordDlg.f1 = this;
            passwordDlg.Show();
        }
    }
}

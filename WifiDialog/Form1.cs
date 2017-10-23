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

        // On Load, get all avialable WiFi within the vicinity
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
                else
                {
                    lvap.SubItems.Add("");
                }

                // Add name
                lvap.Tag = ap;

                lvAccessPoints.Items.Add(lvap);
            }

            if (wifi.ConnectionStatus == WifiStatus.Connected)
            {
                lblConnStatus.Text = "ONLINE";
                lblConnStatus.ForeColor = Color.Green;
                btnDisconnect.Visible = true;
                btnConnect.Visible = false;
            }
            else
            {
                lblConnStatus.Text = "OFFLINE";
                lblConnStatus.ForeColor = Color.Red;
                btnDisconnect.Visible = false;
                btnConnect.Visible = true;
            }

        }

        // Disconnect current connection
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (wifi.ConnectionStatus == WifiStatus.Connected)
            {
                wifi.Disconnect();
                lblConnStatus.Text = "OFFLINE";
                lblConnStatus.ForeColor = Color.Red;
                MessageBox.Show("You have been disconnected.", "Disconnected From WiFi");
            }
            btnConnect.Visible = true;
            btnDisconnect.Visible = false;
        }

        // Refresh Access Points
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lvAccessPoints.Items.Clear();
            WifiForm_Load(sender, e);
        }

        // If user double-clicks on the list
        private void lvAccessPoints_Click(object sender, EventArgs e)
        {
            // If connection is unsecured, just connect without asking for password
            ListViewItem selectedItem = lvAccessPoints.SelectedItems[0];
            if (selectedItem.SubItems[2].Text == "")
            {
                ListViewItem selectedAP = lvAccessPoints.SelectedItems[0];
                AccessPoint ap = (AccessPoint)selectedAP.Tag;

                if (connectToPublicWiFi(ap))
                {
                    lblConnStatus.Text = "ONLINE";
                    lblConnStatus.ForeColor = Color.Green;
                    btnDisconnect.Visible = true;
                    btnConnect.Visible = false;
                }
                else
                {
                    MessageBox.Show("Having difficulty connecting to " + ap.Name + " \nPlease check signal strength and try again.");
                }
            }
            else
            {
                Form2 passwordDlg = new Form2();
                passwordDlg.f1 = this;
                passwordDlg.ShowDialog();
            }
        }

        // Physical button to connect
        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Make sure an access point is selected
            if (lvAccessPoints.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select an access point to connect to.");
            }
            else
            {
                // If connection is unsecured, just connect without asking for password
                ListViewItem selectedItem = lvAccessPoints.SelectedItems[0];
                if (selectedItem.SubItems[2].Text == "")
                {
                    ListViewItem selectedAP = lvAccessPoints.SelectedItems[0];
                    AccessPoint ap = (AccessPoint)selectedAP.Tag;

                    if (connectToPublicWiFi(ap))
                    {
                        lblConnStatus.Text = "ONLINE";
                        lblConnStatus.ForeColor = Color.Green;
                        btnDisconnect.Visible = true;
                        btnConnect.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Having difficulty connecting to " + ap.Name + " \nPlease check signal strength and try again.");
                    }
                }
                else
                {
                    Form2 passwordDlg = new Form2();
                    passwordDlg.f1 = this;
                    passwordDlg.ShowDialog();
                }
            }
        }

        // Connect to WiFi
        private bool connectToPublicWiFi(AccessPoint ap)
        {
            AuthRequest request = new AuthRequest(ap);
            request.Password = "";
            return ap.Connect(request);
        }
    }
}

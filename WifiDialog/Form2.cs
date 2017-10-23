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
    public partial class Form2 : Form
    {
        public string selectedAP;
        public WifiForm f1;

        public Form2()
        {
            InitializeComponent();
            lblNote.Text = "Note: For previously connected networks,\nyou do not need to re - enter the password.";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (f1.lvAccessPoints.SelectedItems.Count > 0)
            {
                ListViewItem selectedAP = f1.lvAccessPoints.SelectedItems[0];
                AccessPoint ap = (AccessPoint)selectedAP.Tag;

                if (connectToWifi(ap, txtPassword.Text))
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Successfully connected to \n" + ap.Name;
                    f1.lblConnStatus.Text = "ONLINE";
                    f1.lblConnStatus.ForeColor = Color.Green;
                    f1.btnDisconnect.Visible = true;
                    f1.btnConnect.Visible = false;
                    this.Close();
                }
                else
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Having difficulty connecting to " + ap.Name + " \nPlease check password and try again.";
                }
            }

            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "This is a secured network, \na valid password is required.";
                lblStatus.Visible = true;
            }
        }

        // This is where credentials are sent
        private bool connectToWifi(AccessPoint ap, string password)
        {
            lblStatus.Visible = true;
            AuthRequest request = new AuthRequest(ap);
            request.Password = password;
            lblStatus.Visible = true;
            lblStatus.Text = "Connecting... \nPlease Wait...";
            return ap.Connect(request);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

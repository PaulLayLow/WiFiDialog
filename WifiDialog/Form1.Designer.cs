namespace WifiDialog
{
    partial class WifiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WifiForm));
            this.lvAccessPoints = new System.Windows.Forms.ListView();
            this.clmAP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSignal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSecure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblConnStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvAccessPoints
            // 
            this.lvAccessPoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmAP,
            this.clmSignal,
            this.clmSecure});
            this.lvAccessPoints.FullRowSelect = true;
            this.lvAccessPoints.HideSelection = false;
            this.lvAccessPoints.Location = new System.Drawing.Point(9, 10);
            this.lvAccessPoints.Name = "lvAccessPoints";
            this.lvAccessPoints.Size = new System.Drawing.Size(336, 238);
            this.lvAccessPoints.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvAccessPoints.TabIndex = 0;
            this.lvAccessPoints.UseCompatibleStateImageBehavior = false;
            this.lvAccessPoints.View = System.Windows.Forms.View.Details;
            this.lvAccessPoints.DoubleClick += new System.EventHandler(this.lvAccessPoints_Click);
            // 
            // clmAP
            // 
            this.clmAP.Text = "Access Point";
            this.clmAP.Width = 154;
            // 
            // clmSignal
            // 
            this.clmSignal.Text = "Signal Strength";
            this.clmSignal.Width = 102;
            // 
            // clmSecure
            // 
            this.clmSecure.Text = "Secure";
            this.clmSecure.Width = 56;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(196, 254);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(149, 27);
            this.btnDisconnect.TabIndex = 2;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::WifiDialog.Properties.Resources.restart;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(9, 254);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblConnStatus
            // 
            this.lblConnStatus.AutoSize = true;
            this.lblConnStatus.ForeColor = System.Drawing.Color.Red;
            this.lblConnStatus.Location = new System.Drawing.Point(87, 261);
            this.lblConnStatus.Name = "lblConnStatus";
            this.lblConnStatus.Size = new System.Drawing.Size(51, 13);
            this.lblConnStatus.TabIndex = 7;
            this.lblConnStatus.Text = "OFFLINE";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(196, 254);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(149, 27);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Visible = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // WifiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 287);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblConnStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.lvAccessPoints);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WifiForm";
            this.Text = "Connect to WiFi";
            this.Load += new System.EventHandler(this.WifiForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader clmAP;
        private System.Windows.Forms.ColumnHeader clmSignal;
        private System.Windows.Forms.ColumnHeader clmSecure;
        private System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.ListView lvAccessPoints;
        public System.Windows.Forms.Label lblConnStatus;
        public System.Windows.Forms.Button btnDisconnect;
        public System.Windows.Forms.Button btnConnect;
    }
}


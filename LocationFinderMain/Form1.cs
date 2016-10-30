using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;
using System.Diagnostics;
using System.Security;

namespace LocationFinderMain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

           // // The coordinate watcher.
        private GeoCoordinateWatcher Watcher = null;
        // Create and start the watcher.
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            // Create the watcher.
            Watcher = new GeoCoordinateWatcher();
            // Catch the StatusChanged event.
            Watcher.StatusChanged += Watcher_StatusChanged;
            // Start the watcher.
            Watcher.Start();



           
           


        }

        private SecureString ConvertToSecureString(string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");

            var securePassword = new SecureString();

            foreach (char c in password)
                securePassword.AppendChar(c);

            securePassword.MakeReadOnly();
            return securePassword;
        }

        // The watcher's status has change. See if it is ready.
        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            this.Hide();
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.
                if (Watcher.Position.Location.IsUnknown)
                {
                    txtLat.Text = "Cannot find location data";
                }
                else
                {
                    txtLat.Text = Watcher.Position.Location.Latitude.ToString();
                    txtLong.Text = Watcher.Position.Location.Longitude.ToString();

                    gmap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                    GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
                    // gmap.SetPositionByKeywords("Maputu,Mozambique");
                    gmap.Position = new GMap.NET.PointLatLng(Convert.ToDouble(txtLat.Text), Convert.ToDouble(txtLong.Text));
                    


                }

                if (txtLat.Text.Substring(0, 5) == "23.74" && txtLong.Text.Substring(0, 5) == "90.38")
                {
                    //this.Hide();
                    MessageBox.Show("Home");



                    ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe");

                    startInfo.WorkingDirectory = "c:/";
                    startInfo.UserName = "Administrator";
                    startInfo.Password = ConvertToSecureString("erp");
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;

                    ///// Wifi Ip

                    // startInfo.Arguments = "/c " + @"netsh interface ip set address ""Wi-Fi"" static 10.168.12.161 255.255.255.192 10.168.12.129";


                    //// wifi dhcp

                    startInfo.Arguments = "/c " + @"netsh interface ip set address ""Wi-Fi"" dhcp";


                    Process.Start(startInfo);

                    startInfo.Arguments = "";

                      startInfo.Arguments = "/c " + @" netsh interface ip set dns ""Wi-Fi"" dhcp";


                     Process.Start(startInfo);
                    this.Close();



                }
                else if (txtLat.Text.Substring(0, 5) == "23.80" && txtLong.Text.Substring(0, 5) == "90.41")
                {

                    //this.Hide();
                    MessageBox.Show("Office");
                    
                    ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe");
                                        
                    startInfo.WorkingDirectory = "c:/";
                    startInfo.UserName = "Administrator";
                    startInfo.Password = ConvertToSecureString("erp");
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;

                    ///// Wifi Ip

                    startInfo.Arguments = "/c " + @"netsh interface ip set address ""Wi-Fi"" static 10.168.12.161 255.255.255.192 10.168.12.129";
                    

                    //// wifi dhcp
                    
                    //startInfo.Arguments = "/c " + @"netsh interface ip set address ""Wi-Fi"" dhcp";

                    
                    Process.Start(startInfo);
                    startInfo.Arguments = "";
                    startInfo.Arguments = "/c " + @"netsh interface ip set dns ""Wi-Fi"" static 10.168.2.5 primary";
                    Process.Start(startInfo);

                   this.Close();

                }

            }





        }

      


    }
    }

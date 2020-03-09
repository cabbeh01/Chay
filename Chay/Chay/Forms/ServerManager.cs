using MongoDBLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chay.Forms
{
    public partial class ServerManager : Form
    {
        MongoCRUD db = new MongoCRUD("dbChay");
        public Point mouseLocation;
        public User us;
        public ServerManager(User u)
        {
            InitializeComponent();

            //Defining Logged in user
            us = u;

            RetrieveServers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                this.Location = mousePose;
            }
        }

        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void AddServer()
        {
            if (!String.IsNullOrEmpty(tbxServername.Text))
            {
                try
                {
                    IPAddress ip = IPAddress.Parse(tbxIp.Text);
                    try
                    {
                        if(int.Parse(tbxPort.Text) > 0 && int.Parse(tbxPort.Text) < 65536) 
                        {
                            if(us._servers == null)
                            {
                                us._servers = new List<Server>();
                            }
                            us._servers.Add(new Server(tbxServername.Text, ip, int.Parse(tbxPort.Text)));
                            lbxOut.Items.Add(new Server(tbxServername.Text, ip, int.Parse(tbxPort.Text)));
                            Updatestruct();
                            MessageBox.Show("Server tillagd");
                        }
                        else
                        {
                            MessageBox.Show("Ett portnummer ska vara mellan 1-65535");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Vänligen mata in ett korrekt portnummer");
                    }


                }
                catch
                {
                    MessageBox.Show("Vänligen mata in en korrekt ipaddress");
                }
            }
            else
            {
                MessageBox.Show("Vänligen mata in ett namn");
            }
        }
        private void Updatestruct()
        {
            db.UpdateOne<User>("Users", us.Id, us);
        }
        private void RetrieveServers()
        {
            try
            {
                lbxOut.Items.Clear();
                us = db.FindById<User>("Users", us.Id);
                foreach (Server a in us._servers)
                {
                    lbxOut.Items.Add(a);
                }
            }
            catch
            {

            }
        }
        private void RemoveServer(Server s)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            AddServer();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}

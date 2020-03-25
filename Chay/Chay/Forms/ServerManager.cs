﻿using MongoDBLogin;
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

        private async void btnClose_Click(object sender, EventArgs e)
        {
            await UpdateStruct();
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

        private async void AddServer()
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
                            await UpdateStruct();
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

        private async Task UpdateStruct()
        {
            await Task.Run(() => {
                db.UpdateOne<User>("Users", us.Id, us);
            });
        }
        private void RetrieveServers()
        {
            try
            {
                lbxOut.Items.Clear();
                try
                {
                    us = db.FindById<User>("Users", us.Id);
                }
                catch
                {
                    MessageBox.Show("Kan inte nå serven");
                }
                foreach (Server a in us._servers)
                {
                    lbxOut.Items.Add(a);
                }
                lbxOut.SelectedIndex = 0;
                LoadPickedServer();
            }
            catch
            {
                
            }
        }
        private async void RemoveServer(Server s)
        {
            try
            {
                lbxOut.Items.Remove(s);
                us._servers.Remove(s);
                await UpdateStruct();
                if (lbxOut.Items.Count == 0)
                {
                    btnRemove.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Det går inte att ta bort servern");
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            AddServer();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lbxOut.Items.Add(new Server("new1",IPAddress.Parse("127.0.0.1"),2000));
            btnRemove.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveServer((Server)lbxOut.SelectedItem);
            tbxIp.Clear();
            tbxServername.Clear();
            tbxPort.Clear();
        }

        private void lbxOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPickedServer();
        }

        private void LoadPickedServer()
        {
            if(!(lbxOut.SelectedItem == null))
            {
                try
                {
                    gbxPickServer.Enabled = true;
                    Server a = (Server)lbxOut.SelectedItem;

                    tbxServername.Text = a._name;
                    tbxIp.Text = a._ip.ToString();
                    tbxPort.Text = a._port.ToString();
                }
                catch
                {

                }
            }
            else
            {
                gbxPickServer.Enabled = false;
            }

        }
    }
}

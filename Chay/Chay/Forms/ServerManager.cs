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
        //private MongoCRUD _db;
        private Point _mouseLocation;
        private Server _def = new Server("new1", IPAddress.Parse("127.0.0.1"), 2000);

        internal User _us;
        internal MongoCRUD _db;

        public ServerManager()
        {
            InitializeComponent();
            GraphicalComponents();
        }

        public void GraphicalComponents()
        {
            try
            {
                //lblRegister.Font = new Font(Login.pfc.Families[0], 24, FontStyle.Regular);
                Font text = new Font(Login.pfc.Families[0], 15.75f, FontStyle.Regular);
                Font gbxtext = new Font(Login.pfc.Families[0], 26.25f, FontStyle.Regular);
                gbxServerlist.Font = gbxtext;
                gbxPickServer.Font = gbxtext;
                lblServerhanterare.Font = new Font(Login.pfc.Families[0], 25.25f, FontStyle.Regular);
                lblIP.Font = text;
                lblPort.Font = text;
                lblServer.Font = text;
            }
            catch
            {
                MessageBox.Show("Typsnitten kunde ej laddas in");

            }
        }

        private async void btnClose_Click(object sender, EventArgs e)
        {
            await UpdateStruct();
            
            this.Hide();
        }

        public List<Server> GetServers()
        {
            return _us.Servers;
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(_mouseLocation.X, _mouseLocation.Y);
                this.Location = mousePose;
            }
        }

        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(-e.X, -e.Y);
        }

        private async void UpdateServer()
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
                            if(_us.Servers == null)
                            {
                                _us.Servers = new List<Server>();
                            }
                            Server temp = new Server(tbxServername.Text, ip, int.Parse(tbxPort.Text));
                            temp.Id = _db.GenID();
                            lbxOut.Items.Insert(lbxOut.SelectedIndex,temp);
                            lbxOut.Items.RemoveAt(lbxOut.SelectedIndex);
                            await UpdateStruct();
                            ClearTextboxes();
                            MessageBox.Show("Server uppdaterad");
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
                _us.Servers = lbxOut.Items.Cast<Server>().ToList();
                _db.UpdateOne<User>("Users", _us.Id, _us);
            });
        }
        public void RetrieveServers()
        {
            try
            {
                lbxOut.Items.Clear();
                try
                {
                    _us = _db.FindById<User>("Users", _us.Id);
                }
                catch
                {
                    MessageBox.Show("Kan inte nå serven");
                }
                foreach (Server a in _us.Servers)
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
            UpdateServer();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lbxOut.Items.Add(_def);
            btnRemove.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveServer((Server)lbxOut.SelectedItem);
            ClearTextboxes();
        }

        private void ClearTextboxes()
        {
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

                    tbxServername.Text = a.Name;
                    tbxIp.Text = a.Ip.ToString();
                    tbxPort.Text = a.Port.ToString();
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

        private void btnServerUp_Click(object sender, EventArgs e)
        {
            try
            {
                // only if the first item isn't the current one
                if (lbxOut.SelectedIndex > 0)
                {
                    // add a duplicate item up in the listbox
                    lbxOut.Items.Insert(lbxOut.SelectedIndex - 1, lbxOut.SelectedItem);
                    // make it the current item
                    lbxOut.SelectedIndex = (lbxOut.SelectedIndex - 2);
                    // delete the old occurrence of this item
                    lbxOut.Items.RemoveAt(lbxOut.SelectedIndex + 2);
                }
            }
            catch
            {
                MessageBox.Show("Går inte att flytta objektet");
            }
            
        }

        private void btnServerDown_Click(object sender, EventArgs e)
        {
            try
            {
                // only if the last item isn't the current one
                if ((lbxOut.SelectedIndex != -1) && (lbxOut.SelectedIndex < lbxOut.Items.Count - 1))
                {
                    // add a duplicate item down in the listbox
                    lbxOut.Items.Insert(lbxOut.SelectedIndex + 2, lbxOut.SelectedItem);
                    // make it the current item
                    lbxOut.SelectedIndex = lbxOut.SelectedIndex + 2;
                    // delete the old occurrence of this item
                    lbxOut.Items.RemoveAt(lbxOut.SelectedIndex - 2);
                }
            }
            catch
            {
                MessageBox.Show("Går inte att flytta objektet");
            }
            
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            
        }
    }
}

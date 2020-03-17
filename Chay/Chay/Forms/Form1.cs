using Chay.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chay
{
    public partial class Form1 : Form
    {
        //Forms
        User us;
        Settings s = null;
        ServerManager sm = null;


        public Point mouseLocation;
        bool isMaxi = false;

        public Form1(User user)
        {
            InitializeComponent();
            GraphicalComponents();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            us = user;

            //Setting up Client
            us._client = new TcpClient();
            us._client.NoDelay = true;


            //retriveServerList();
            this.lblUser.Text = user._username;
            LogicalComponents();
        }


        //Resizeable windows form without border

        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToScreen(pos);

                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)3;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }

                if (pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)15;
                    return;
                }
            }

            base.WndProc(ref m);
        }

        //Moveable header
        private void PHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                this.Location = mousePose;
            }
        }


        
        public void GraphicalComponents()
        {
            //Logo
            Logo.Font = new Font("Ranchers", 20, FontStyle.Regular);
            Logo.ForeColor = Color.White;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaxi_Click(object sender, EventArgs e)
        {
            if (!isMaxi)
            {
                this.WindowState = FormWindowState.Maximized;
                isMaxi = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                isMaxi = false;
            }
            
        }

        private void BtnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login a = new Login();
            a.Show();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            if(s == null)
            {
                s = new Settings();
                s.FormClosed += S_FormClosed;
                s.Show();
            }
            else
            {
                s.BringToFront();
            }
        }

        private void S_FormClosed(object sender, FormClosedEventArgs e)
        {
            s = null;
        }

        private async void Sm_FormClosed(object sender, FormClosedEventArgs e)
        {
            us._servers = sm.us._servers;
            await RetriveServerList();
            sm = null;
        }

        private void BtnServermanager_Click(object sender, EventArgs e)
        {
            if (sm == null)
            {
                sm = new ServerManager(us);
                sm.FormClosed += Sm_FormClosed;
                sm.Show();
            }
            else
            {
                sm.BringToFront();
            }
        }

        private async void LogicalComponents()
        {
            await this.RetriveServerList();
        }
        
        private async Task RetriveServerList()
        {
            
            await Task.Run(() => {
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        try
                        {
                            twServers.Nodes.Clear();
                            foreach (Server s in us._servers)
                            {
                                twServers.Nodes.Add(s._name);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Serverna kan inte hämtas");
                        }
                    }));
                }
                else
                {
                    try
                    {
                        twServers.Nodes.Clear();
                        foreach (Server s in us._servers)
                        {
                            twServers.Nodes.Add(s._name);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Serverna kan inte hämtas");
                    }
                }
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (us._client.Connected)
                {
                    StartCommunication(tbxSend.Text);
                    //us._client.Close();
                }
                else
                {
                    MessageBox.Show("Du måste vara uppkopplad mot någon server");
                }
            }
            catch
            {
                MessageBox.Show("Det går inte skicka meddelandet");
            }
        }

        private void twServers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(twServers.SelectedNode.Text);
                foreach (Server s in us._servers)
                {
                    if (twServers.SelectedNode.Text == s._name)
                    {
                        if (!us._client.Connected)
                        {
                            StartHandshake(s._ip, s._port);
                            MessageBox.Show($"Du connectar till {s._name}");
                        }
                        //us._client.Connect(s._ip, s._port);
                        
                    }
                }
            }
            catch
            {
                MessageBox.Show("Kan inte ansluta till servern");
            }
        }

        public async void StartHandshake(IPAddress address, int port)
        {
            try
            {
                await us._client.ConnectAsync(address, port);
            }
            catch
            {
                MessageBox.Show("Går inte uppräta en anslutning");
            }
        }

        public async void StartCommunication(string message)
        {
            byte[] outData = Encoding.Unicode.GetBytes(message); // Detta ska bytas ut om en klass som man ska skicka
            try
            {
                await us._client.GetStream().WriteAsync(outData, 0, outData.Length);
            }
            catch
            {
                MessageBox.Show("Det går inte skicka meddelandet");
            }
        }
    }
}

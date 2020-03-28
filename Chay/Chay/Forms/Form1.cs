﻿using Chay.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
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
        Settings setting            = null;
        ServerManager servermang    = null;
        Profile profile             = null;

        //Settings
        Settings.ChatColor S_cColor     = Settings.ChatColor.Blå;
        Settings.TimeFormat S_tFormat   = Settings.TimeFormat.HHmm;


        public Point mouseLocation;
        bool isMaxi = false;

        public Form1(User user)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            us = user;

            //Setting up Client
            us._client = new TcpClient();
            us._client.NoDelay = true;

            //retriveServerList();
            this.lblUser.Text = user._username;
            GraphicalComponents();
            RetriveSettings();
            LogicalComponents();
        }


        //Resizeable windows form without border

        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref System.Windows.Forms.Message m)
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
            // -----    Logo    -----

            //      Includes font
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Application.StartupPath + "\\Font\\Ranchers-Regular.ttf");
            Logo.Font = new Font(pfc.Families[0], 20, FontStyle.Regular);
            Logo.ForeColor = Color.White;

            lblUser.Location = new Point(639 - (us._username.Length * 7) ,0);
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
            if(setting == null)
            {
                setting = new Settings(ref S_cColor, ref S_tFormat);
                setting.FormClosed += S_FormClosed;
                setting.Show();
            }
            else
            {
                setting.BringToFront();
            }
        }

        private void S_FormClosed(object sender, FormClosedEventArgs e)
        {
            setting = null;
            RetriveSettings();
            conversationCtrl.Rebind();
        }

        private async void Sm_FormClosed(object sender, FormClosedEventArgs e)
        {
            us._servers = servermang.us._servers;
            await RetriveServerList();
            servermang = null;
        }

        private void BtnServermanager_Click(object sender, EventArgs e)
        {
            if (servermang == null)
            {
                servermang = new ServerManager(us);
                servermang.FormClosed += Sm_FormClosed;
                servermang.Show();
            }
            else
            {
                servermang.BringToFront();
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
                            if(us._servers != null)
                            {
                                foreach (Server s in us._servers)
                                {
                                    twServers.Nodes.Add(s._name);
                                }
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
                        if (us._servers != null)
                        {
                            foreach (Server s in us._servers)
                            {
                                twServers.Nodes.Add(s._name);
                            }
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
                /*
                if (us._client.Connected)
                {
                    StartCommunication(tbxSend.Text);
                    //us._client.Close();

                    
                }
                else
                {
                    MessageBox.Show("Du måste vara uppkopplad mot någon server");
                }*/

                dSChatt.ConversationMessagesDataTable table = new dSChatt.ConversationMessagesDataTable();
                dSChatt.ConversationMessagesRow newRow = table.NewConversationMessagesRow();

                newRow.time = DateTime.Now;
                newRow.text = "Hejsan";
                newRow.incoming = true;
                table.AddConversationMessagesRow(newRow);

                newRow = table.NewConversationMessagesRow();
                newRow.time = DateTime.Now;
                newRow.text = "Tjena =)";
                newRow.incoming = false;
                table.AddConversationMessagesRow(newRow);

                newRow = table.NewConversationMessagesRow();
                newRow.time = DateTime.Now;
                newRow.text = "Hur mår du? hdsfajkdlhaskjdh ksahdkasj hdkajshd jkashd jkashkjdhas jkhd asjkhdjk ashdjkas ";
                newRow.incoming = true;
                table.AddConversationMessagesRow(newRow);

                conversationCtrl.DataSource = table;
                conversationCtrl.MessageColumnName = table.textColumn.ColumnName;
                conversationCtrl.IdColumnName = table.idColumn.ColumnName;
                conversationCtrl.DateColumnName = table.timeColumn.ColumnName;
                conversationCtrl.IsIncomingColumnName = table.incomingColumn.ColumnName;

                conversationCtrl.Rebind();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {

            if (profile == null)
            {
                profile = new Profile(us);
                profile.FormClosed += Profile_FormClosed;
                profile.Show();
            }
            else
            {
                profile.BringToFront();
            }
        }

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            profile = null;
        }



        //Connection when choosing a connection to join
        private void twServers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //us._client.Close();
                //MessageBox.Show(twServers.SelectedNode.Text);
                foreach (Server s in us._servers)
                {
                    if (twServers.SelectedNode.Text == s._name)
                    {
                        if (us._client.Connected)
                        {
                            us._client.Client.Close();
                            cDConnected.UpdateStatus(true);
                            StartHandshake(s._ip, s._port);
                            MessageBox.Show($"Du connectar till {s._name}");
                        }
                        else
                        {
                            cDConnected.UpdateStatus(true);
                            lblNameServer.Text = twServers.SelectedNode.Text;
                            StartHandshake(s._ip, s._port);
                            MessageBox.Show($"Du connectar till {s._name}");
                        }
                        
                        //us._client.Connect(s._ip, s._port);

                    }
                }
            }
            catch
            {
                cDConnected.UpdateStatus(false);
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
                us._client.Dispose();
                cDConnected.UpdateStatus(false);
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

        private void RetriveSettings()
        {

            try
            {
                if(Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ "\\Chay\\"))
                {
                    FileStream stream = new FileStream(Settings.fileName, FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(stream);

                   
                    string colorMessage = reader.ReadLine();
                    string timeFormat = reader.ReadLine();
                    if(String.IsNullOrEmpty(colorMessage) && String.IsNullOrEmpty(timeFormat))
                    {
                        throw new System.ArgumentException("Värdena är ogiltliga", "Ogiltliga värden");
                    }

                    reader.Dispose();

                    switch (colorMessage)
                    {
                        case "Blå":
                            conversationCtrl.BalloonBackColor = Color.SteelBlue;
                            S_cColor = Settings.ChatColor.Blå;
                            break;
                        case "Grön":
                            conversationCtrl.BalloonBackColor = Color.ForestGreen;
                            S_cColor = Settings.ChatColor.Grön;
                            break;
                        case "Orange":
                            conversationCtrl.BalloonBackColor = Color.Orange;
                            S_cColor = Settings.ChatColor.Orange;
                            break;
                        case "Röd":
                            conversationCtrl.BalloonBackColor = Color.Firebrick;
                            S_cColor = Settings.ChatColor.Röd;
                            break;

                        case "Lila":
                            conversationCtrl.BalloonBackColor = Color.DarkOrchid;
                            S_cColor = Settings.ChatColor.Lila;
                            break;
                    }


                    switch (timeFormat)
                    {
                        case "Hmm":
                            
                            S_tFormat = Settings.TimeFormat.Hmm;
                            break;
                        case "HHmmss":
                            S_tFormat = Settings.TimeFormat.HHmmss;
                            break;

                        case "HHmm":
                            S_tFormat = Settings.TimeFormat.HHmm;
                            break;
                    }
                }

            }
            catch
            {
                
            }
        }
    }
}

using Chay.Forms;
using MongoDBLogin;
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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Chay
{
    public partial class Form1 : Form
    {
        //Forms
        private User us;
        private Settings setting            = null;
        private ServerManager servermang;
        private Profile profile;

        private MongoCRUD _db = new MongoCRUD("dbChay");

        public static PrivateFontCollection pfc = new PrivateFontCollection();
        //Settings
        Settings.ChatColor S_cColor     = Settings.ChatColor.Blå;
        Settings.TimeFormat S_tFormat   = Settings.TimeFormat.HHmm;

        dSChatt.ConversationMessagesDataTable table = new dSChatt.ConversationMessagesDataTable();
        dSChatt.ConversationMessagesRow newRow = null;

        private Point _mouseLocation;
        private bool _isMaxi = false;

        public Form1(User user)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            us = user;
            servermang = new ServerManager();
            profile = new Profile();
            //Setting up Client
            us.Client = new TcpClient();
            
            us.Client.NoDelay = true;

            //retriveServerList();
            this.lblUser.Text = user.Username;
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
            _mouseLocation = new Point(-e.X, -e.Y);
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(_mouseLocation.X, _mouseLocation.Y);
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

            lblUser.Location = new Point(639 - (us.Username.Length * 7) ,0);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaxi_Click(object sender, EventArgs e)
        {
            if (!_isMaxi)
            {
                this.WindowState = FormWindowState.Maximized;
                _isMaxi = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                _isMaxi = false;
            }
            
        }

        private void BtnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
            //GC.Collect();
        }
       

        private void BtnServermanager_Click(object sender, EventArgs e)
        {
            if (!servermang.Visible)
            {
                servermang._us = us;
                servermang._db = _db;
                
                servermang.VisibleChanged += Servermang_VisibleChanged;
                servermang.RetrieveServers();
                servermang.Show();
            }
            else
            {
                servermang.BringToFront();
            }
        }

        private async void Servermang_VisibleChanged(object sender, EventArgs e)
        {
            if (!servermang.Visible)
            {
                us.Servers = servermang.GetServers();
                await RetriveServerList();
                servermang.VisibleChanged -= Servermang_VisibleChanged;
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            
            if (!servermang.Visible)
            {
                profile._us = us;
                profile._db = _db;

                profile.RetrieveData();
                profile.Show();
            }
            else
            {
                profile.BringToFront();
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
                            if(us.Servers != null)
                            {
                                foreach (Server s in us.Servers)
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
                        if (us.Servers != null)
                        {
                            foreach (Server s in us.Servers)
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
                
                
                if (us.Client.Connected)
                {
                    StartCommunication(new Message(us,tbxSend.Text,DateTime.Now));
                    //us._client.Close();


                    newRow.time = DateTime.Now;
                    newRow.text = tbxSend.Text;
                    newRow.incoming = true;

                    newRow = table.NewConversationMessagesRow();
                    newRow.time = DateTime.Now;
                    newRow.text = tbxSend.Text;
                    newRow.incoming = true;
                    table.AddConversationMessagesRow(newRow);


                    conversationCtrl.Rebind();
                }
                else
                {
                    MessageBox.Show("Du måste vara uppkopplad mot någon server");
                }


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

        



        //Connection when choosing a connection to join
        private void twServers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //us._client.Close();
                //MessageBox.Show(twServers.SelectedNode.Text);
                foreach (Server s in us.Servers)
                {
                    if (twServers.SelectedNode.Text == s._name)
                    {
                        if (us.Client.Connected)
                        {
                            RemoveHandshake();
                        }
                        
                        StartHandshake(s._ip, s._port);
                        MessageBox.Show($"Du connectar till {s._name}");

                        newRow = table.NewConversationMessagesRow();
                        cDConnected.UpdateStatus(true);
                        lblNameServer.Text = twServers.SelectedNode.Text;

                        //us.Client.Close();
                        //us._client.Connect(s._ip, s._port);

                    }
                }
            }
            catch(Exception ex)
            {
                cDConnected.UpdateStatus(false);
                MessageBox.Show("Kan inte ansluta till servern" + "\n" + ex.ToString());
            }
        }

        public async void StartHandshake(IPAddress address, int port)
        {
            try
            {
                await us.Client.ConnectAsync(address, port);
                StartReading();
            }
            catch
            {
                
                cDConnected.UpdateStatus(false);
                MessageBox.Show("Går inte uppräta en anslutning");
            }
        }

        public void RemoveHandshake()
        {
            try
            {
                us.Client.Client.Close();
                cDConnected.UpdateStatus(false);
            }
            catch
            {
                cDConnected.UpdateStatus(false);
                MessageBox.Show("Ett fel uppstod kontakta utvecklaren");
            }
        }

        public void StartCommunication(Message msg)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream str = us.Client.GetStream();
            formatter.Serialize(str,msg);
            
            //us.Client.GetStream().
            /*
            byte[] outData = Encoding.Unicode.GetBytes(msg); // Detta ska bytas ut om en klass som man ska skicka
            try
            {
                await us.Client.GetStream().WriteAsync(outData, 0, outData.Length);
            }
            catch
            {
                MessageBox.Show("Det går inte skicka meddelandet");
            }*/
        }
        public async void StartReading()
        {
            try
            {
                if (us.Client.Connected)
                {
                    byte[] buffert = new byte[1024];

                    int n = 0;
                    try
                    {
                        n = await us.Client.GetStream().ReadAsync(buffert, 0, buffert.Length);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    //Sending data on server screen
                    //SendMessage($"User 1> {Encoding.Unicode.GetString(buffert, 0, n)}");
                    MessageBox.Show("Jag fick detta");
                    StartReading();
                }
            }
            catch
            {
                MessageBox.Show("Anslutningen upphörde");
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

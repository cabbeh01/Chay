using Chay.Forms;
using MongoDBLogin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChayPackages;
using Message = ChayPackages.Message;
using MongoDB.Bson;

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
        private bool _readId = false;
        private Server pickedServer = null;

        public Form1(User user)
        {
            try
            {
                InitializeComponent();

                this.SetStyle(ControlStyles.ResizeRedraw, true);
                this.FormBorderStyle = FormBorderStyle.None;
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
            catch
            {
                MessageBox.Show("Krash");
            }
            
        }


        //Resizeable windows form without border

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 1;
            const int HTCAPTION = 2;
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    if(m.Result == (IntPtr)HTCLIENT)
                    {
                        m.Result = (IntPtr)HTCAPTION;
                    }
                    break;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = (cp.Style | 262144);
                return cp;
            }
        }

        //Moveable header
        private void PHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(-e.X, -e.Y);
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
                                    twServers.Nodes.Add(s.Name);
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
                                twServers.Nodes.Add(s.Name);
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
                    if (!String.IsNullOrEmpty(tbxSend.Text))
                    {
                        StartSending(new Message(new Userpack(us.Id, us.Name, us.Image, us.Username), tbxSend.Text, DateTime.Now));
                        tbxSend.Clear();
                    }
                    UpdateMessagesDB();
                    
                }
                else
                {
                    UpdateMessagesDB();
                    //MessageBox.Show("Du måste vara uppkopplad mot någon server");
                }


                UpdateMessboard();
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
                    if (twServers.SelectedNode.Text == s.Name)
                    {
                        
                        pickedServer = s;
                        if (us.Client.Connected)
                        {
                            RemoveHandshake();
                        }
                        
                        StartHandshake(s.Ip, s.Port,s.Name);
                        
                        newRow = table.NewConversationMessagesRow();
                        
                        lblNameServer.Text = twServers.SelectedNode.Text;
                        
                        UpdateMessagesDB();
                        UpdateMessboard();

                        twServers.SelectedNode.Nodes.Clear();
                        foreach(User u in pickedServer.Users)
                        {
                            twServers.SelectedNode.Nodes.Add(u.Name);
                        }
                        twServers.ExpandAll();
                        //us.Client.Close();
                        //us._client.Connect(s._ip, s._port);

                    }
                }
            }
            catch
            {
                cDConnected.UpdateStatus(false);
                //MessageBox.Show("Kan inte ansluta till servern" + "\n" + ex);
            }
        }

        public async void StartHandshake(IPAddress address, int port, string name)
        {
            try
            {
                us.Client = new TcpClient();
                await us.Client.ConnectAsync(address, port);
                StartSending(new Message(new Userpack(us.Id, us.Name, us.Image,us.Username), "connected", DateTime.Now, true));
                StartReading();
                MessageBox.Show($"Du connectar till {name}");
                UpdateMessagesDB();
                UpdateMessboard();
                cDConnected.UpdateStatus(true);
            }
            catch
            {
                cDConnected.UpdateStatus(false);
                MessageBox.Show("Kan inte ansluta till servern");
            }
        }

        public void UpdateMessboard()
        {
            conversationCtrl.DataSource = table;
            conversationCtrl.MessageColumnName = table.textColumn.ColumnName;
            conversationCtrl.IdColumnName = table.idColumn.ColumnName;
            conversationCtrl.DateColumnName = table.timeColumn.ColumnName;
            conversationCtrl.IsIncomingColumnName = table.incomingColumn.ColumnName;

            conversationCtrl.Rebind();
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

        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        Object ByteArrayToObject(byte[] arrBytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter binForm = new BinaryFormatter();
                    ms.Write(arrBytes, 0, arrBytes.Length);
                    ms.Seek(0, SeekOrigin.Begin);
                    Object obj = (Object)binForm.Deserialize(ms);
                    return obj;
                }

            }
            catch
            {
                return null;
            }
        }

        public void StartSending(Message msg)
        {
            
            //us.Client.GetStream().
            //byte[] outData = Encoding.Unicode.GetBytes(msg); // Detta ska bytas ut om en klass som man ska 
            try
            {
                byte[] meta = new byte[8];

                byte[] outData = ObjectToByteArray(msg);
                meta = Encoding.ASCII.GetBytes(outData.Length.ToString());
                //MessageBox.Show(outData.Length.ToString());
                us.Client.GetStream().Write(meta, 0, meta.Length);

                //MessageBox.Show(outData.ToString());

                us.Client.GetStream().Write(outData, 0, outData.Length);


                //Message test = (Message)ByteArrayToObject(outData, outData.Length);

                //Serializa och deserializa fungerar. Problemet är att skicka datan från client till server.
                //MessageBox.Show($"{test.Auther.Name}: {test.Text}"); 
                //MessageBox.Show("Meddelandet har nu skickats" + "\n" + outData.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Det går inte skicka meddelandet" + "\n "+ ex);
            }
        }



        // ------------------   Påbörjar läsning   -------------------
        public async void StartReading()
        {
            try
            {
                if (us.Client.Connected)
                {
                    if (!_readId)
                    {
                        byte[] buffId = new byte[254];

                        int n = 0;
                        try
                        {
                            n = await us.Client.GetStream().ReadAsync(buffId, 0, buffId.Length);
                        }
                        catch
                        {
                            //MessageBox.Show("Fel i överföringen" + ex);
                            
                        }
                       
                        
                        string id = Encoding.Unicode.GetString(buffId, 0, n);
                        //MessageBox.Show(id);
                        pickedServer.Id = ObjectId.Parse(id.ToString());
                        _readId = true;
                        UpdateMessagesDB();
                        cDConnected.UpdateStatus(true);

                    }

                    byte[] buffert = new byte[64];

                    int bRead = 0;
                    try
                    {
                        bRead = await us.Client.GetStream().ReadAsync(buffert, 0, buffert.Length);
                    }
                    catch
                    {
                        //MessageBox.Show(""+ex);
                        
                    }
                    

                    string mess = Encoding.Unicode.GetString(buffert, 0, bRead);
                    //MessageBox.Show(mess);
                    if (mess == "newmess")
                    {
                        UpdateMessagesDB();
                        UpdateMessboard();
                    }
                    cDConnected.UpdateStatus(true);
                    StartReading();
                }
                else
                {
                    //us.Client = new TcpClient();
                    cDConnected.UpdateStatus(false);
                }
            }
            catch(Exception ex)
            {
                /*if (us.Client.Connected)
                {
                    us.Client.GetStream().Close();
                }*/
                cDConnected.UpdateStatus(false);
                MessageBox.Show("Startreading \n"+ex);
            }
        }

        private void UpdateMessagesDB()
        {
            try
            {
                table.Clear();
                List<Server> allServ = _db.GetAll<Server>("Servers");
                newRow = table.NewConversationMessagesRow();
                foreach (Server sv in allServ)
                {
                    //pickedServer.Id == sv.Id
                    //ObjectId.Parse("5e91d70759e6fd33103b1d46")
                    if (pickedServer.Id == sv.Id)
                    {
                        pickedServer = sv;
                    }
                }

                if(pickedServer.Messages != null)
                {
                    foreach (Message msg in pickedServer.Messages)
                    {
                        if (msg.Auther.Id == us.Id)
                        {
                            if (table.Count < 0)
                            {
                                newRow.time = msg.DelivaryTime;
                                newRow.text = msg.Text;
                                newRow.incoming = true;
                            }
                            else
                            {
                                newRow = table.NewConversationMessagesRow();
                                newRow.time = msg.DelivaryTime;
                                newRow.text = msg.Text;
                                newRow.incoming = true;
                            }

                            table.AddConversationMessagesRow(newRow);
                        }
                        else
                        {
                            if (table.Count < 0)
                            {
                                newRow.time = msg.DelivaryTime;
                                newRow.text = msg.Text;
                                newRow.incoming = false;
                            }
                            else
                            {
                                newRow = table.NewConversationMessagesRow();
                                newRow.time = msg.DelivaryTime;
                                newRow.text = msg.Text;
                                newRow.incoming = false;
                            }
                            table.AddConversationMessagesRow(newRow);
                        }
                    }
                }
                
                UpdateMessboard();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                        case "HHmmss":
                            conversationCtrl.LongTimeSett = true;
                            S_tFormat = Settings.TimeFormat.HHmmss;
                            break;

                        case "HHmm":
                            conversationCtrl.LongTimeSett = false;
                            S_tFormat = Settings.TimeFormat.HHmm;
                            break;
                    }
                }

            }
            catch
            {
                
            }
        }

        

        private void btnMaxMize_Click(object sender, EventArgs e)
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

        private void btnMiniMize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tbxSend_TextChanged(object sender, EventArgs e)
        {
            lblRemainingWords.Text = (512 - (int)tbxSend.Text.Count<Char>()).ToString();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

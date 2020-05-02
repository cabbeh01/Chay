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
        //---------    Fönster     ----------

        /// <summary>Inställningsformen</summary>
        private Settings setting = null;

        /// <summary>Serverhanteringsformen</summary>
        private ServerManager servermang;

        /// <summary>Profilformen</summary>
        private Profile profile;




        // --------   Andra deklarationer   --------

        /// <summary>Databasen</summary>
        private MongoCRUD _db = new MongoCRUD("dbChay");

        /// <summary>Användaren</summary>
        private User us;

        /// <summary>Privata font kollektionen som inne håller två stycken fonter</summary>
        public static PrivateFontCollection pfc = new PrivateFontCollection();




        //----------  StandardInställningar   ---------

        /// <summary>Chattfärgen</summary>
        private Settings.ChatColor S_cColor     = Settings.ChatColor.Blå;

        /// <summary>Tidsformatet</summary>
        private Settings.TimeFormat S_tFormat   = Settings.TimeFormat.HHmm;



        //----------  Andra deklarationer   ---------

        /// <summary>Skapar en dataTable</summary>
        private dSChatt.ConversationMessagesDataTable table = new dSChatt.ConversationMessagesDataTable();

        /// <summary>Skapar en meddelande rad</summary>
        private dSChatt.ConversationMessagesRow newRow = null;

        /// <summary>Muspekarens position</summary>
        private Point _mouseLocation;

        /// <summary>Status om fönstret är maximerat</summary>
        private bool _isMaxi = false;

        /// <summary>Läst ett id på den uppkopplade servern</summary>
        private bool _readId = false;

        /// <summary>Valda servern</summary>
        private Server pickedServer = null;


        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        /// <param name="user">Inloggad användare</param>
        public Form1(User user)
        {
            try
            {
                InitializeComponent();
                
                this.SetStyle(ControlStyles.ResizeRedraw, true);
                this.FormBorderStyle = FormBorderStyle.None;
                
                //Sätter användaren till den användaren som matades in vid inloggningen
                us = user;
                
                //Skapar objekten på de fönsterna
                servermang = new ServerManager();
                profile = new Profile();

                //Sätter upp klienten
                us.Client = new TcpClient();
                us.Client.NoDelay = true;

                //Läser in och kör viktiga funktioner
                this.lblUser.Text = user.Username;
                GraphicalComponents();
                RetriveSettings();
                LogicalComponents();
            }
            catch
            {
                MessageBox.Show("Ett fel har uppstått kontakta utvecklaren");
            }
            
        }


        //Fungerar inte riktigt som jag hoppats men tillräckligt för att ta sig runt i programmet
        /// <summary>
        /// Omskalningsbart fönster utan boarder
        /// </summary>
        /// <param name="m">Windows Form special meddelande</param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            //Skickats till ett fönster för att bestämma vilken del av fönstret som motsvarar en viss skärmkoordinat
            const int WM_NCHITTEST = 0x84;

            //I klient vyn
            const int HTCLIENT = 1;

            //I title baren
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

        /// <summary>
        /// Skapar förutsättningen och layouten med specifika parametrar som är inbyggt i Windowsform
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                
                //Stilen på parametern vid en viss parameter
                cp.Style = (cp.Style | 262144);
                return cp;
            }
        }

        /// <summary>
        /// Musposition lagras när användaren klickar med musknappen
        /// </summary>
        private void PHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(-e.X, -e.Y);
        }

        /// <summary>
        /// Flyttar fönstret till den position som musen rör sig till
        /// </summary>
        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(_mouseLocation.X, _mouseLocation.Y);
                this.Location = mousePose;
            }
        }


        /// <summary>
        /// Läser in grafiska komponenter som etc. typsnitt
        /// </summary>
        public void GraphicalComponents()
        {
            try
            {

                // -----    Logo    -----

                //      Includes font
                pfc.AddFontFile(Application.StartupPath + "\\Font\\Ranchers-Regular.ttf");
                Logo.Font = new Font(pfc.Families[0], 20, FontStyle.Regular);
                Logo.ForeColor = Color.White;

                lblUser.Location = new Point(639 - (us.Username.Length * 7), 0);
            }
            catch
            {
                Logo.Font = DefaultFont;
            }
            
        }

        /// <summary>
        /// Inställningsknappen klickas på
        /// </summary>
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            //Om instansen inte finns
            if(setting == null)
            {
                //Skapa en ny instans
                setting = new Settings(ref S_cColor, ref S_tFormat);

                //Skapa en händelse
                setting.FormClosed += S_FormClosed;

                //Visa fönstret
                setting.Show();
            }
            else
            {
                //Annars lägg fönstret överst
                setting.BringToFront();
            }
        }

        /// <summary>
        /// Inställningsfönstret stängs
        /// </summary>
        private void S_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Sätter fönstret till null
            setting = null;

            //Hämtar inställningarna
            RetriveSettings();

            //Uppdaterar meddelande rutan
            conversationCtrl.Rebind();
        }

        /// <summary>
        /// Serverhanterarknappen klickas på
        /// </summary>
        private void BtnServermanager_Click(object sender, EventArgs e)
        {
            try
            {
                //Om den inte visas
                if (!servermang.Visible)
                {
                    //Visa fönstret och ladda serverar
                    servermang._us = us;
                    servermang._db = _db;

                    servermang.VisibleChanged += Servermang_VisibleChanged;
                    servermang.RetrieveServers();
                    servermang.Show();
                }
                else
                {
                    //Annars lägg fönstret överst
                    servermang.BringToFront();
                }
            }
            catch
            {
                servermang = new ServerManager();
            }
            
        }

        /// <summary>
        /// Serverhanterar visningen ändras
        /// </summary>
        private async void Servermang_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                //Är den inte synlig
                if (!servermang.Visible)
                {
                    //Hämta serverna
                    us.Servers = servermang.GetServers();
                    await RetriveServerList();

                    //Ta bort händelse
                    servermang.VisibleChanged -= Servermang_VisibleChanged;
                }
            }
            catch
            {

            }
            
        }

        /// <summary>
        /// Profilknappen klickas på
        /// </summary>
        private void btnProfile_Click(object sender, EventArgs e)
        {
            try
            {
                //Om den inte visas
                if (!profile.Visible)
                {
                    //Visa den
                    profile._us = us;
                    profile._db = _db;

                    profile.RetrieveData();
                    profile.Show();
                }
                else
                {
                    //Annars lägg fönstret överst
                    profile.BringToFront();
                }
            }
            catch
            {
                profile = new Profile();
            }
            
        }

        /// <summary>
        /// Logiska komponenter läses in
        /// </summary>
        private async void LogicalComponents()
        {
            try
            {
                //Läser in serverlistan
                await this.RetriveServerList();
            }
            catch
            {

            }
        }
        
        /// <summary>
        /// Hämtar serverlistan
        /// </summary>
        private async Task RetriveServerList()
        {
            
            await Task.Run(() => {
                //Körs en process mellan två trådar
                if (InvokeRequired)
                {
                    //Gör så att jag kan styra en annan tråd via denna klassen
                    this.Invoke(new MethodInvoker(delegate
                    {
                        UpdateTreeViewServer();
                    }));
                }
                else
                {
                    UpdateTreeViewServer();
                }
            });
        }

        /// <summary>
        /// Uppdaterar Treeview listan på serverar
        /// </summary>
        private void UpdateTreeViewServer()
        {
            try
            {
                //Rensar servrarna på treeviewn
                twServers.Nodes.Clear();

                //Om det finns serverar lägg till dem i treeviewn
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

        /// <summary>
        /// När skicka knappen klickas på
        /// </summary>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                //Är klienten uppkopplad
                if (us.Client.Connected)
                {
                    //Är textrutan där meddelandet är inte tom
                    if (!String.IsNullOrEmpty(tbxSend.Text))
                    {
                        //Skicka meddelandet
                        StartSending(new Message(new Userpack(us.Id, us.Name, us.Image, us.Username), tbxSend.Text, DateTime.Now));
                        
                        //Rensa textrutan
                        tbxSend.Clear();
                    }

                    //Hämta meddelande från databasen
                    UpdateMessagesDB();
                    
                }
                else
                {
                    //Hämta meddelande från databasen
                    UpdateMessagesDB();
                }

                //Uppdaterar strukturen för hur objektet meddelande ska tas in i ConversationCTRL
                UpdateMessboard();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }


        /// <summary>
        /// Uppkopplar mot den server som användaren väljer att dubbelklicka på
        /// </summary>
        private void twServers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //För varje server
                foreach (Server s in us.Servers)
                {
                    //Stämmer namnet på den server som jag klickade på
                    if (twServers.SelectedNode.Text == s.Name)
                    {
                        //Sätt serverobjektet till den valda servern
                        pickedServer = s;

                        //Skulle användaren redan tidigare vara uppkopplad stäng den tidigare uppkopplingen
                        if (us.Client.Connected)
                        {
                            RemoveHandshake();
                        }
                        
                        //Starta uppkoppling mot den valda servern
                        StartHandshake(s.Ip, s.Port,s.Name);
                        
                        //Skapar nytt meddelandeTable
                        newRow = table.NewConversationMessagesRow();
                        
                        //Namnet på den server man är uppkopplad mot ändrats
                        lblNameServer.Text = twServers.SelectedNode.Text;
                        
                        //Uppdatera meddelande
                        UpdateMessagesDB();
                        UpdateMessboard();

                        //Uppdaterar treeview och se de anslutna användarna samt sig själv
                        twServers.SelectedNode.Nodes.Clear();
                        foreach (User u in pickedServer.Users)
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

        /// <summary>
        /// Startar handshake mellan client och server
        /// </summary>
        /// <param name="address">Ipaddress till servern</param>
        /// <param name="port">Portnummer</param>
        /// <param name="name">Namnet på servern</param>
        public async void StartHandshake(IPAddress address, int port, string name)
        {
            try
            {
                //Skapar nu klient
                us.Client = new TcpClient();

                //Kopplar upp sig asynkront
                await us.Client.ConnectAsync(address, port);

                //Skickar infomeddelande till servern att en användare kopplar upp sig
                StartSending(new Message(new Userpack(us.Id, us.Name, us.Image,us.Username), "connected", DateTime.Now, true));

                //Börjar läsa från servern
                StartReading();

                MessageBox.Show($"Du connectar till {name}");
                
                //Uppdaterar meddelande som finns på servern
                UpdateMessagesDB();
                UpdateMessboard();

                //Uppdaterar uppkopplingsstatus
                cDConnected.UpdateStatus(true);
            }
            catch
            {
                cDConnected.UpdateStatus(false);
                MessageBox.Show("Kan inte ansluta till servern");
            }
        }

        /// <summary>
        /// Tar bort handshaken med servern
        /// </summary>
        public void RemoveHandshake()
        {
            try
            {
                //Stänger uppkopplingen med servern
                us.Client.Client.Close();

                //Uppdaterar uppkopplingsstatus
                cDConnected.UpdateStatus(false);
            }
            catch
            {
                cDConnected.UpdateStatus(false);
                MessageBox.Show("Ett fel uppstod kontakta utvecklaren");
            }
        }

        /// <summary>
        /// Uppdaterar controlCtrl (grafiska med bubblorna) samt kopplar de till ett dataSet
        /// </summary>
        public void UpdateMessboard()
        {
            try
            {
                //Kopplar dataSet till respektive modul
                conversationCtrl.DataSource = table;
                conversationCtrl.MessageColumnName = table.textColumn.ColumnName;
                conversationCtrl.IdColumnName = table.idColumn.ColumnName;
                conversationCtrl.DateColumnName = table.timeColumn.ColumnName;
                conversationCtrl.IsIncomingColumnName = table.incomingColumn.ColumnName;
                conversationCtrl.NameColumnName = table.nameColumn.ColumnName;

                //Uppdaterar komponenten
                conversationCtrl.Rebind();
            }
            catch
            {

            }
            
        }

        /// <summary>
        /// Gör om ett object till en bytearray med hjälp av Serialization
        /// </summary>
        /// <param name="obj">Objektet</param>
        /// <returns>Returnerar en bytearray</returns>
        byte[] ObjectToByteArray(object obj)
        {
            try
            {
                //Om objektet inte är definierat
                if (obj == null)
                    return null;

                //Skapar en binärformaterare
                BinaryFormatter bf = new BinaryFormatter();

                //Serializar objectet och returnerar en array
                using (MemoryStream ms = new MemoryStream())
                {
                    bf.Serialize(ms, obj);
                    return ms.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Påbörja sändning
        /// </summary>
        /// <param name="msg">Meddelande</param>
        public void StartSending(Message msg)
        {
            try
            {
                //Skapar en metatag
                byte[] meta = new byte[8];

                //Skapar en datadel i bytearray
                byte[] outData = ObjectToByteArray(msg);

                //Lägger längden på objektet i metan
                meta = Encoding.ASCII.GetBytes(outData.Length.ToString());

                //Skickar metan
                us.Client.GetStream().Write(meta, 0, meta.Length);

                //Skickar objektet
                us.Client.GetStream().Write(outData, 0, outData.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Det går inte skicka meddelandet" + "\n "+ ex);
            }
        }



        /// <summary>
        /// Påbörjar läsning
        /// </summary>
        public async void StartReading()
        {
            try
            {
                //Är klienten uppkopplad
                if (us.Client.Connected)
                {
                    //Har den inte läst id:et
                    if (!_readId)
                    {
                        //skapar en buffert för att hämta id:et
                        byte[] buffId = new byte[254];

                        int n = 0;
                        try
                        {
                            //Läser in id:et från servern
                            n = await us.Client.GetStream().ReadAsync(buffId, 0, buffId.Length);
                        }
                        catch
                        {
                            //MessageBox.Show("Fel i överföringen" + ex);
                        }
                        
                        //Skapar en sträng id och gör om bytearrayen till sträng
                        string id = Encoding.Unicode.GetString(buffId, 0, n);

                        //Sätter valda serverns Id till det id:et den fick 
                        pickedServer.Id = ObjectId.Parse(id.ToString());
                        _readId = true;

                        //Uppdaterar meddelandena från databasen samt statusen på servern
                        UpdateMessagesDB();
                        UpdateMessboard();
                        cDConnected.UpdateStatus(true);
                    }

                    //Annars väntar den på att läsa in de meddelande som servern skickar
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
                    
                    //Gör om meddelandet till text
                    string mess = Encoding.Unicode.GetString(buffert, 0, bRead);

                    //Är det ett meddelande så uppdatera meddelanda på klienten
                    if (mess == "newmess")
                    {
                        UpdateMessagesDB();
                        UpdateMessboard();
                    }

                    //Är det att klienten blev kickad så lämna servern
                    if(mess == "kicked")
                    {
                        MessageBox.Show("Du blev kickad");
                        RemoveHandshake();
                        cDConnected.UpdateStatus(false);
                    }

                    //Uppdatera status
                    cDConnected.UpdateStatus(true);
                    StartReading();
                }
                else
                {
                    cDConnected.UpdateStatus(false);
                }
            }
            catch(Exception ex)
            {
                cDConnected.UpdateStatus(false);
                MessageBox.Show("Startreading \n"+ex);
            }
        }

        /// <summary>
        /// UppdateraMeddelande från databasen
        /// </summary>
        private void UpdateMessagesDB()
        {
            try
            {
                //Rensa meddelande hso klienten
                table.Clear();

                //Hämta alla tillgängliga serverar från databasen
                List<Server> allServ = _db.GetAll<Server>("Servers");

                //Skapa en ny rad som meddelandena kan ligga på
                newRow = table.NewConversationMessagesRow();

                //Letar upp servern som klienten är uppkopplad mot
                foreach (Server sv in allServ)
                {
                    if (pickedServer.Id == sv.Id)
                    {
                        pickedServer = sv;
                    }
                }

                //Så länge där finns meddelande
                if(pickedServer.Messages != null)
                {
                    //Gå igenom alla meddalnden
                    foreach (Message msg in pickedServer.Messages)
                    {
                        //Är meddelande mitt id
                        if (msg.Auther.Id == us.Id)
                        {
                            //Finns där meddelanden
                            if (table.Count < 0)
                            {
                                //Bygger meddelande
                                newRow.time = msg.DelivaryTime;
                                newRow.text = msg.Text;
                                newRow.name = "Jag";
                                newRow.incoming = true;
                            }
                            else
                            {
                                //Bygger meddelande
                                newRow = table.NewConversationMessagesRow();
                                newRow.time = msg.DelivaryTime;
                                newRow.text = msg.Text;
                                newRow.name = "Jag";
                                newRow.incoming = true;
                            }

                            table.AddConversationMessagesRow(newRow);
                        }

                        //Är meddelandet någon annans id
                        else
                        {
                            //Finns där meddelanden
                            if (table.Count < 0)
                            {
                                //Bygger meddelande
                                newRow.time = msg.DelivaryTime;
                                newRow.text = msg.Text;
                                newRow.name = msg.Auther.Name;
                                newRow.incoming = false;
                            }
                            else
                            {
                                //Bygger meddelande
                                newRow = table.NewConversationMessagesRow();
                                newRow.time = msg.DelivaryTime;
                                newRow.text = msg.Text;
                                newRow.name = msg.Auther.Name;
                                newRow.incoming = false;
                            }
                            table.AddConversationMessagesRow(newRow);
                        }
                    }
                }

                //Uppdatera controlCTRL
                UpdateMessboard();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        /// <summary>
        /// Hämta användarens inställningar
        /// </summary>
        private void RetriveSettings()
        {

            try
            {
                //Finns det en mapp som heter Chay i Appdata
                if(Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ "\\Chay\\"))
                {
                    //Skapar en filströmm
                    FileStream stream = new FileStream(Settings.fileName, FileMode.Open, FileAccess.Read);
                    
                    //Skapar en läsare
                    StreamReader reader = new StreamReader(stream);

                    //Läser inställningarna
                    string colorMessage = reader.ReadLine();
                    string timeFormat = reader.ReadLine();

                    //Skulle värdena vara ogiltliga så kastar den en Exception
                    if(String.IsNullOrEmpty(colorMessage) && String.IsNullOrEmpty(timeFormat))
                    {
                        throw new System.ArgumentException("Värdena är ogiltliga", "Ogiltliga värden");
                    }

                    //Släpper läsarresurserna
                    reader.Dispose();

                    //Kopplar den färgen som valts till bubblorna
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

                    //Kopplar tidsformatet som valts till den inställningen
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

        /// <summary>
        /// Visar antalet bokstäver som man kan skriva
        /// </summary>
        private void tbxSend_TextChanged(object sender, EventArgs e)
        {
            lblRemainingWords.Text = (512 - (int)tbxSend.Text.Count<Char>()).ToString();
        }

        /// <summary>
        /// Klickar på maximera
        /// </summary>
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

        /// <summary>
        /// Klickar på minimera
        /// </summary>
        private void btnMiniMize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Klickar på avsluta
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

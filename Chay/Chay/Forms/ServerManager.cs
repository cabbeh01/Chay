using MongoDBLogin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chay.Forms
{
    public partial class ServerManager : Form
    {
        /// <summary>Muspekarens position</summary>
        private Point _mouseLocation;

        /// <summary>Definerar standardvärden på server som lagts till</summary>
        private Server _def = new Server("new1", IPAddress.Parse("127.0.0.1"), 2000);

        /// <summary>Användare</summary>
        internal User _us;

        /// <summary>Databas</summary>
        internal MongoCRUD _db;

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public ServerManager()
        {
            try
            {
                InitializeComponent();
                GraphicalComponents();
            }
            catch
            {
                MessageBox.Show("Ett fel har uppstått kontakta utvecklaren");
            }
        }

        /// <summary>
        /// Läser in grafiska komponenter som typsnitt
        /// </summary>
        public void GraphicalComponents()
        {
            try
            {
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

        /// <summary>
        /// Hämtar alla serverna hos användaren
        /// </summary>
        /// <returns>Returnerar användarens serverar</returns>
        public List<Server> GetServers()
        {
            return _us.Servers;
        }

        /// <summary>
        /// Flyttar fönstret till den position som musen rör sig till
        /// </summary>
        private void PHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(_mouseLocation.X, _mouseLocation.Y);
                this.Location = mousePose;
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
        /// Uppdaterar serverna för användaren uppe i databasen
        /// </summary>
        private async void UpdateServer()
        {
            //Kollar så att servern har ett namn
            if (!String.IsNullOrEmpty(tbxServername.Text))
            {
                try
                {
                    //Försöker parsa en IP-Adress (sträng) till en Ip-Address (IPAddress)
                    IPAddress ip = IPAddress.Parse(tbxIp.Text);
                    try
                    {
                        //Kollar så att porten som matas in är en giltlig port
                        if(ushort.Parse(tbxPort.Text) > 0 && ushort.Parse(tbxPort.Text) < 65535) 
                        {
                            //Skulle användaren inte ha en lista på databasen så skapas den nu i alla fall
                            if(_us.Servers == null)
                            {
                                _us.Servers = new List<Server>();
                            }

                            //Skapa ett temporärt serverobjekt
                            Server temp = new Server(tbxServername.Text, ip, ushort.Parse(tbxPort.Text));

                            //Lägger till ObjectID
                            temp.Id = _db.GenID();

                            //Sätter in den sparade servern och ersätter den tempservern som är deklarerad i början av denna klassen
                            lbxOut.Items.Insert(lbxOut.SelectedIndex,temp);
                            lbxOut.Items.RemoveAt(lbxOut.SelectedIndex);

                            //Uppdaterar informationen på databasen
                            await UpdateStruct();

                            //Rensar textrutorna
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

        /// <summary>
        /// Uppdaterar informationen på databasen
        /// </summary>
        private async Task UpdateStruct()
        {
            await Task.Run(() => {
                _us.Servers = lbxOut.Items.Cast<Server>().ToList();
                _db.UpdateOne<User>("Users", _us.Id, _us);
            });
        }

        /// <summary>
        /// Hämtar serverar om det finns tillgängliga på databasen
        /// </summary>
        public void RetrieveServers()
        {
            try
            {
                //Rensar listan i serverhanteraren
                lbxOut.Items.Clear();
                try
                {
                    //Hittas en användare
                    _us = _db.FindById<User>("Users", _us.Id);
                }
                catch
                {
                    MessageBox.Show("Kan inte nå serven");
                }

                //Söker den igenom serverna och lägger till i listan
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

        /// <summary>
        /// Tar bort server från listan
        /// </summary>
        /// <param name="s">Servern som ska plockas bort</param>
        private async void RemoveServer(Server s)
        {
            try
            {
                //Tar bort servern från listboxen
                lbxOut.Items.Remove(s);

                //Uppdaterar användaren på databasen
                await UpdateStruct();

                //Avaktiverar bortagninsknappen om där inte finns några serverar
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

        /// <summary>
        /// Sparar knappen klickas på
        /// </summary>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            UpdateServer();
        }

        /// <summary>
        /// Lägg till server knappen klickas på
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lbxOut.Items.Add(_def);
            btnRemove.Enabled = true;
        }

        /// <summary>
        /// Ta bort server knappen klickas på
        /// </summary>
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            RemoveServer((Server)lbxOut.SelectedItem);
            ClearTextboxes();
        }

        /// <summary>
        /// Rensar textrutorna
        /// </summary>
        private void ClearTextboxes()
        {
            tbxIp.Clear();
            tbxServername.Clear();
            tbxPort.Clear();
        }

        /// <summary>
        /// Väljer vald server om det valda värdet skulle ändra sig
        /// </summary>
        private void LbxOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPickedServer();
        }

        /// <summary>
        /// Laddar in information om vald server
        /// </summary>
        private void LoadPickedServer()
        {
            //Sålänge vald server inte är odefinierat
            if(!(lbxOut.SelectedItem == null))
            {
                try
                {
                    //Aktiverar groupboxen om det servern som är vald finns
                    gbxPickServer.Enabled = true;
                    Server a = (Server)lbxOut.SelectedItem;

                    //Tilldelar informationen på respektive textruta
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

        /// <summary>
        /// Flyttar upp den valda servern ett steg
        /// </summary>
        private void BtnServerUp_Click(object sender, EventArgs e)
        {
            try
            {
                //Endast om första objektet inte är den valda
                if (lbxOut.SelectedIndex > 0)
                {
                    //Lägger till ett dublicerat objekt ett upp i listboxen
                    lbxOut.Items.Insert(lbxOut.SelectedIndex - 1, lbxOut.SelectedItem);

                    //Gör det till den valda
                    lbxOut.SelectedIndex = (lbxOut.SelectedIndex - 2);

                    //Tar bort den gamla instansen av det objektet
                    lbxOut.Items.RemoveAt(lbxOut.SelectedIndex + 2);
                }
            }
            catch
            {
                MessageBox.Show("Går inte att flytta objektet");
            }
            
        }

        /// <summary>
        /// Flyttar ned den valda servern ett steg
        /// </summary>
        private void BtnServerDown_Click(object sender, EventArgs e)
        {
            try
            {
                //Endast om sista objektet inte är den valda
                if ((lbxOut.SelectedIndex != -1) && (lbxOut.SelectedIndex < lbxOut.Items.Count - 1))
                {
                    //Lägger till ett dublicerat objekt ett ner i listboxen
                    lbxOut.Items.Insert(lbxOut.SelectedIndex + 2, lbxOut.SelectedItem);

                    //Gör det till den valda
                    lbxOut.SelectedIndex = lbxOut.SelectedIndex + 2;

                    //Tar bort den gamla instansen av det objektet
                    lbxOut.Items.RemoveAt(lbxOut.SelectedIndex - 2);
                }
            }
            catch
            {
                MessageBox.Show("Går inte att flytta objektet");
            }
            
        }

        /// <summary>
        /// Stänger fönstret
        /// </summary>
        private async void BtnExit_Click(object sender, EventArgs e)
        {
            try
            {
                //Uppdaterar databasen
                await UpdateStruct();

                //Gömmer fönstret
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Går inte spara på databasen");

                //Gömmer fönstret
                this.Hide();
            }
            
        }
    }
}

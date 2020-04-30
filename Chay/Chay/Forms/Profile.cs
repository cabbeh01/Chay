using MongoDBLogin;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chay.Forms
{
    public partial class Profile : Form
    {
        /// <summary>Muspekarens position</summary>
        private Point _mouseLocation;

        /// <summary>Bildens sträng i base64</summary>
        private string _base64String;

        /// <summary>Är bilden uppladdad?</summary>
        private bool _pictureuploaded;


        /// <summary>Användaren</summary>
        internal User _us;

        /// <summary>Databasen</summary>
        internal MongoCRUD _db;
        
        
        /// <summary>
        /// Standardkonstrukter för klassen
        /// </summary>
        public Profile()
        {
            InitializeComponent();
            GraphicalComponents();
            _pictureuploaded = false;
        }

        /// <summary>
        /// Läser in typsnitt
        /// </summary>
        public void GraphicalComponents()
        {
            try
            {
                lblProfil.Font = new Font(Login.pfc.Families[0], 25.25f, FontStyle.Regular);
                lblChattnamn.Font = new Font(Login.pfc.Families[0], 20.25f, FontStyle.Regular);
            }
            catch
            {
                MessageBox.Show("Typsnitten kunde ej laddas in");
            }
        }

        /// <summary>
        /// Flyttar fönstret till den position som musen rör sig till
        /// </summary>
        private void pHeader2_MouseMove(object sender, MouseEventArgs e)
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
        private void pHeader2_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(-e.X, -e.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                dlgOpenImage.Filter = "PNG files (*.png)|*.png|JPEG/JPG files (*.jpg)|*.jpg";

                //Öppnar openFile dialog
                DialogResult result = dlgOpenImage.ShowDialog();

                //Klickar användaren OK/Ja
                if (DialogResult.OK == result)
                {
                    //Den valda filen lagras i Image img
                    Image img = Image.FromFile(dlgOpenImage.FileName);

                    //Kollar begränsningar så att inte bilden överskrider 1000x1000px samt är i förhållande 1x1
                    if(img.Width/img.Height == 1 && img.Width <= 1000 && img.Height <= 1000)
                    {
                        //Skapar en minnesström
                        MemoryStream stream = new MemoryStream();
                        
                        //Sparar bilden till strömmen
                        img.Save(stream, img.RawFormat);

                        //Konverterar bilden till bytes
                        byte[] imgBytes = stream.ToArray();

                        //Sätter bilden till den som användaren valde
                        rpbxImage.Image = img;

                        //Konverterar byte[] till Base64 sträng
                        _base64String = Convert.ToBase64String(imgBytes);

                        stream.Dispose();
                        _pictureuploaded = true;
                    }
                    else
                    {
                        MessageBox.Show("Bilden är för stor eller i fel format");
                    }

                    //Släpper använda resurser
                    img.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Det går inte ladda upp bilden");
            }
        }
        
        /// <summary>
        /// Updaterar datan på användaren
        /// </summary>
        private async Task UpdateStruct()
        {
            await Task.Run(() => {
                if (_pictureuploaded)
                {
                    //Sätter användarbilden till den valda bilden om användaren varit inne i upload
                    _us.Image = _base64String;
                }
                _us.Name = tbxChatName.Text;

                //Lägger till uppdaterar namnet i användarobjektet och updaterar sedan användaren på databasen
                _db.UpdateOne<User>("Users", _us.Id, _us);
            });
        }

        /// <summary>
        /// Hämtar datan från databasen
        /// </summary>
        public void RetrieveData()
        {
            try
            {
                try
                {
                    //Försöker leta upp den inloggade användaren på databasen
                    _us = _db.FindById<User>("Users", _us.Id);
                }
                catch
                {
                    MessageBox.Show("Kan inte hitta användaren");
                }

                //Kollar om bilden inte är tom annars hämtar den bilden på databasen
                if(_us.Image != "")
                {
                    try
                    {
                        //konverterar Base64 till Bytes
                        byte[] imgBytes = Convert.FromBase64String(_us.Image);

                        //Gör om bytesen till en stream
                        MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);

                        ms.Write(imgBytes, 0, imgBytes.Length);

                        //Bygger ihop bilden
                        Image restImg = Image.FromStream(ms, true);
                        rpbxImage.Image = restImg;

                        //Släpper använda resurser
                        ms.Dispose();
                    }
                    catch
                    {
                        try
                        {
                            //Standardbild
                            rpbxImage.Image = Image.FromFile("Images\\icon.jpg");
                        }
                        catch
                        {
                            //Färg ifall standardbilden inte kan laddas in
                            rpbxImage.BackColor = Color.Gray;
                        }
                    }
                    
                }
                else
                {
                    try
                    {
                        //Standardbild
                        rpbxImage.Image = Image.FromFile("\\Images\\icon.jpg");
                    }
                    catch
                    {
                        //Färg ifall standardbilden inte kan laddas in
                        rpbxImage.BackColor = Color.Gray;
                    }
                    
                }
                tbxChatName.Text = _us.Name;
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// Sparar ändringar som gjorts
        /// </summary>
        private async void btnSaveProf_Click(object sender, EventArgs e)
        {
            //Uppdaterar datan som namnet och bilden till användaren
            await UpdateStruct();
            MessageBox.Show("Dina ändringar har sparats");
            this.Hide();
        }

        /// <summary>
        /// Avbryter och sparar inga ändringar
        /// </summary>
        private void btnCancleProf_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Klickar på logga ut
        /// </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}

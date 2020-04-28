using MongoDBLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
                DialogResult result = dlgOpenImage.ShowDialog();
                if (DialogResult.OK == result)
                {
                    Image img = Image.FromFile(dlgOpenImage.FileName);
                    if(img.Width/img.Height == 1 && img.Width <= 1000 && img.Height <= 1000)
                    {

                        //Image temp = img.GetThumbnailImage(100, 100, () => false, IntPtr.Zero);
                        MemoryStream stream = new MemoryStream();
                        img.Save(stream, img.RawFormat);
                        byte[] imgBytes = stream.ToArray();

                        MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                        ms.Write(imgBytes, 0, imgBytes.Length);
                        rpbxImage.Image = Image.FromStream(ms, true);

                        //https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp

                        //Konverterar byte[] till Base64 sträng
                        _base64String = Convert.ToBase64String(imgBytes);

                        //MessageBox.Show(_base64String);
                        stream.Dispose();
                        ms.Dispose();
                        _pictureuploaded = true;
                    }
                    else
                    {
                        MessageBox.Show("Bilden är för stor eller i fel format");
                    }
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
                        byte[] imgBytes = Convert.FromBase64String(_us.Image);

                        MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                        ms.Write(imgBytes, 0, imgBytes.Length);
                        Image restImg = Image.FromStream(ms, true);
                        rpbxImage.Image = restImg;
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

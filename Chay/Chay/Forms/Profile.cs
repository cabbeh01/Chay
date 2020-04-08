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
        private Point _mouseLocation;
        private string _base64String;
        private bool _pictureuploaded;

        internal User _us;
        internal MongoCRUD _db;
        
        //internal MongoCRUD _db;

        public Profile()
        {
            InitializeComponent();
            GraphicalComponents();
            _pictureuploaded = false;
        }
        public void GraphicalComponents()
        {
            try
            {
                //lblRegister.Font = new Font(Login.pfc.Families[0], 24, FontStyle.Regular);
                lblProfil.Font = new Font(Login.pfc.Families[0], 25.25f, FontStyle.Regular);
                lblChattnamn.Font = new Font(Login.pfc.Families[0], 20.25f, FontStyle.Regular);
            }
            catch
            {
                MessageBox.Show("Typsnitten kunde ej laddas in");

            }
        }
        private void pHeader2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(_mouseLocation.X, _mouseLocation.Y);
                this.Location = mousePose;
            }
        }

        private void pHeader2_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(-e.X, -e.Y);
        }

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

                        // Convert byte[] to Base64 String
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
        
        private async Task UpdateStruct()
        {
            await Task.Run(() => {
                if (_pictureuploaded)
                {
                    _us.Image = _base64String;
                }
                _us.Name = tbxChatName.Text;
                //Add the line of code to update certain things in user
                _db.UpdateOne<User>("Users", _us.Id, _us);
            });
        }
        public void RetrieveData()
        {
            try
            {
                try
                {
                    _us = _db.FindById<User>("Users", _us.Id);
                }
                catch
                {
                    MessageBox.Show("Kan inte hitta användaren");
                }

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
                            rpbxImage.Image = Image.FromFile("Images\\icon.jpg");
                        }
                        catch
                        {
                            rpbxImage.BackColor = Color.Gray;
                        }
                    }
                    
                }
                else
                {
                    try
                    {
                        rpbxImage.Image = Image.FromFile("\\Images\\icon.jpg");
                    }
                    catch
                    {
                        rpbxImage.BackColor = Color.Gray;
                    }
                    
                }
                tbxChatName.Text = _us.Name;
            }
            catch
            {

            }
        }
        private async void btnSaveProf_Click(object sender, EventArgs e)
        {
            await UpdateStruct();
            MessageBox.Show("Dina ändringar har sparats");
            this.Hide();
        }

        private void btnCancleProf_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}

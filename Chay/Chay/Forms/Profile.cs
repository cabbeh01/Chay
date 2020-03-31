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
        public Profile(User us)
        {
            InitializeComponent();
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
            DialogResult result = dlgOpenImage.ShowDialog();
            if(DialogResult.OK == result)
            {
                Image img = Image.FromFile(dlgOpenImage.FileName);
                MemoryStream stream = new MemoryStream();
                img.Save(stream, img.RawFormat);
                byte[] imgBytes = stream.ToArray();
                
                rpbxImage.Image = img;

                //https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imgBytes);

                MessageBox.Show(base64String);
            }
            
            
        }

        private void btnSaveProf_Click(object sender, EventArgs e)
        {

        }

        private void btnCancleProf_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

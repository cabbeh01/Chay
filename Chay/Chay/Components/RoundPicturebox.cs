using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Chay.Components
{
    public class RoundPicturebox : PictureBox
    {
        /// <summary>
        /// Ändrar pictureboxen till en rund picturebox
        /// </summary>
        protected override void OnPaint(PaintEventArgs pe)
        {
            
            try
            {
                //En path konstrueras
                GraphicsPath grpath = new GraphicsPath();

                //Skapar en Ellipse (Cirkel) och kopplar sedan bilden till Ellipsen (Cirkeln) 
                grpath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                this.Region = new System.Drawing.Region(grpath);

                //Drar ut bilden över det nyskapadeområdet 
                this.SizeMode = PictureBoxSizeMode.StretchImage;
                base.OnPaint(pe);
            }
            catch
            {
                MessageBox.Show("Går inte ladda upp bilden pågrund att den är för stor. Vänligen ladda upp en kvadratisk bild som är max 1000x1000 px");
            }
            
        }
    }
}

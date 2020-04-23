using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chay
{
    public partial class BigCheckbox : UserControl
    {
        /// <summary>Status för checkboxen</summary>
        private bool check = false;

        /// <summary>Iconen för checkboxen</summary>
        // En bättre lösning skulle kunna vara att ha använt
        // tecken från unicode-8. Fast nu är bilden gjord och det fungerar
        private Image img;
        
        /// <summary>
        /// Konstruktor för checkboxen som läser in viktiga resurserr
        /// </summary>
        public BigCheckbox()
        {
            InitializeComponent();
            try
            {
                img = Image.FromFile("Images\\cross.jpg");
            }
            catch
            {
                MessageBox.Show("Kan inte hitta resurser");
            }
            
        }

        /// <summary>
        /// GET/SET Statusvärde för om den är i kryssad
        /// </summary>
        [Category("Appearance"), Description("Checked"), DefaultValue("...")]
        public bool Check
        {
            get
            {
                return check;
            }
            set
            {
                check = value;
            }
        }

        /// <summary>
        /// GET/SET Bild
        /// </summary>
        [Category("Appearance"), Description("Image"), DefaultValue("...")]
        public Image Img
        {
            get
            {
                return img;
            }
            set
            {
                img = value;
            }
        }

        /// <summary>
        /// Klickas bilden på ska statusen förändras
        /// </summary>
        private void pbxImage_Click(object sender, EventArgs e)
        {
            Switch();
        }

        /// <summary>
        /// En funktion som ändrar värdena från att vara på till av och tilbaka
        /// </summary>
        private void Switch()
        {
            //Är den i kryssad
            if (Check)
            {
                //Ta bort krysset och set false på variablen
                check = false;
                pbxImage.Image = img;
            }
            else
            {
                //Lägger till krysset och set trrue på variablen
                check = true;
                pbxImage.Image = null;
            }
        }

        /// <summary>
        /// Lägger till event om att knappen trycks på
        /// </summary>
        public new event EventHandler Click
        {
            add
            {
                base.Click += value;
                foreach (Control control in Controls)
                {
                    control.Click += value;
                }
            }
            remove
            {
                base.Click -= value;
                foreach (Control control in Controls)
                {
                    control.Click -= value;
                }
            }
        }
    }
}

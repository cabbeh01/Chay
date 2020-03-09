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
        private bool check = false;
        private Image img;
        
        public BigCheckbox()
        {
            InitializeComponent();
        }

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

        private void pbxImage_Click(object sender, EventArgs e)
        {
            Switch();
        }

        
        private void Switch()
        {
            if (Check)
            {
                check = false;
                pbxImage.Image = img;
            }
            else
            {
                check = true;
                pbxImage.Image = null;
            }
        }

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

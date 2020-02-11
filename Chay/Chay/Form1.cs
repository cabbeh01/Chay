using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chay
{
    public partial class Form : System.Windows.Forms.Form
    {
        

        public Form()
        {
            InitializeComponent();
            GraphicalComponents();
        }

        private void PHeader_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        public void GraphicalComponents()
        {
            Logo.Font = new Font("Ranchers", 20, FontStyle.Regular);
            Logo.ForeColor = Color.White;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMaxi_Click(object sender, EventArgs e)
        {

        }

        private void BtnMini_Click(object sender, EventArgs e)
        {

        }
    }
}

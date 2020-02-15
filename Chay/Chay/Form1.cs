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
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Point mouseLocation;
        bool isMaxi = false;

        public Form1()
        {
            InitializeComponent();
            GraphicalComponents();

            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }


        //Resizeable windows form without border

        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);

                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)3;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }

                if (pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)15;
                    return;
                }
            }

            base.WndProc(ref m);
        }

        //Moveable header
        private void PHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                this.Location = mousePose;
            }
        }


        //Logo
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
            if (!isMaxi)
            {
                this.WindowState = FormWindowState.Maximized;
                isMaxi = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                isMaxi = false;
            }
            
        }

        private void BtnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
    }
}

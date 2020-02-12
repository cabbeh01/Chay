﻿using System;
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
        }

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
using Chay.Forms;
using MongoDBLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chay
{
    public partial class Login : Form
    {
        public Point mouseLocation;
        MongoCRUD db = new MongoCRUD("dbChay");
        public Login()
        {
            InitializeComponent();
            GraphicalComponents();
        }

        //Moveable header
        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                this.Location = mousePose;
            }
        }

        //Logo
        public void GraphicalComponents()
        {
            Logo.Font = new Font("Ranchers", 56, FontStyle.Regular);
            Logo.ForeColor = Color.White;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User found = db.FindByParameter<User>("Users", "Username", tbxUsername.Text);
                if (found.Password == MongoCRUD.Encrypt(tbxPassword.Text))
                {
                    Form1 form = new Form1(found);
                    //MessageBox.Show("Du är nu inloggad");
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Användare eller lösenord fel");
                }

            }
            catch
            {
                MessageBox.Show("Användare eller lösenord fel");
            } 
        }

        private void LlblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }

    }
}

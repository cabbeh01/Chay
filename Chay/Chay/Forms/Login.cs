using Chay.Forms;
using MongoDBLogin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chay
{
    public partial class Login : Form
    {
        private Point _mouseLocation;
        private MongoCRUD _db = new MongoCRUD("dbChay");
        public static PrivateFontCollection pfc = new PrivateFontCollection();
        
        public Login()
        {
            InitializeComponent();
            GraphicalComponents();
        }

        //Moveable header
        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(-e.X, -e.Y);
        }

        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(_mouseLocation.X, _mouseLocation.Y);
                this.Location = mousePose;
            }
        }

        //Logo
        public void GraphicalComponents()
        {
            try
            {
                pfc.AddFontFile("Font//Myriad-Pro-Condensed.ttf");
                pfc.AddFontFile("Font//Ranchers-Regular.ttf");
                Logo.Font = new Font(pfc.Families[1], 56, FontStyle.Regular);
                Font text = new Font(pfc.Families[0], 15.75f, FontStyle.Regular);
                lblPass.Font = text;
                lblPass.Font = text;
                lblRegister.Font = new Font(pfc.Families[0], 12, FontStyle.Regular);
            }
            catch
            {
                MessageBox.Show("Typsnitten kunde ej laddas in");
                Logo.Font = new Font("Arial", 56, FontStyle.Regular);
            }
            
            Logo.ForeColor = Color.White;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User found = _db.FindByParameter<User>("Users", "Username", tbxUsername.Text);
                if (found.Password == MongoCRUD.Encrypt(tbxPassword.Text))
                {
                    Form1 form = new Form1(found);
                    
                    //MessageBox.Show("Du är nu inloggad");
                    form.Show();
                    //this.Dispose();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Användare eller lösenord fel");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }

        private void LlblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

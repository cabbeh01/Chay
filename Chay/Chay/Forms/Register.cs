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
    public partial class Register : Form
    {
        public Point mouseLocation;
        MongoCRUD db = new MongoCRUD("dbChay");
        public Register()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }


        private void PHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                this.Location = mousePose;
            }
        }

        private void PHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxUsername.Text))
            {
                if (!string.IsNullOrEmpty(tbxPassword.Text) && PasswordValidator(tbxPassword.Text))
                {
                    if (tbxRepassword.Text == tbxPassword.Text)
                    {
                        db.InsertOne("Users", new User { Username = tbxUsername.Text, Password = Encrypt(tbxPassword.Text) });
                        MessageBox.Show("Ditt konto är nu skapat");
                        this.Close();
                        Login log = new Login();
                        log.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Du måste mata in ett lösenord som är mer än 6 tecken och har minst ett specialtecken och en versal");
                }
            }
            else
            {
                MessageBox.Show("Du måste mata in ett användarnamn");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }

        private void tbxRepassword_TextChanged(object sender, EventArgs e)
        {
            if (tbxRepassword.Text == tbxPassword.Text && !string.IsNullOrEmpty(tbxPassword.Text) && !string.IsNullOrEmpty(tbxRepassword.Text))
            {
                tbxRepassword.BackColor = Color.LightGreen;
                plRepass.BackColor = Color.LightGreen;
            }
            else
            {
                tbxRepassword.BackColor = Color.White;
                plRepass.BackColor = Color.White;
            }
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbxRepassword.Text == tbxPassword.Text && !string.IsNullOrEmpty(tbxPassword.Text) && !string.IsNullOrEmpty(tbxRepassword.Text))
            {
                tbxRepassword.BackColor = Color.LightGreen;
                plRepass.BackColor = Color.LightGreen;
            }
            else
            {
                tbxRepassword.BackColor = Color.White;
                plRepass.BackColor = Color.White;
            }
        }

        private bool PasswordValidator(string password)
        {
            if (password.Length > 6)
            {
                int checkUpper = 0;
                int checkSymbol = 0;
                foreach (char a in password)
                {
                    if (char.IsUpper(a))
                    {
                        checkUpper++;
                    }
                    if (char.IsPunctuation(a))
                    {
                        checkSymbol++;
                    }
                }

                if (checkSymbol > 0 && checkUpper > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        static string Encrypt(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        private void bCbxShowPass_Click(object sender, EventArgs e)
        {
            if (!bCbxShowPass.Check)
            {
                tbxPassword.PasswordChar = '\0';
                tbxRepassword.PasswordChar = '\0';
            }
            else
            {
                tbxPassword.PasswordChar = '•';
                tbxRepassword.PasswordChar = '•';
            }
        } 
    }
}

using MongoDBLogin;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Chay
{
    public partial class Register : Form
    {
        private Point _mouseLocation;
        private MongoCRUD _db = new MongoCRUD("dbChay");

        public Register()
        {
            InitializeComponent();
            GraphicalComponents();
        }

        public void GraphicalComponents()
        {
            try
            {
                lblRegister.Font = new Font(Login.pfc.Families[0], 24, FontStyle.Regular);
                Font text = new Font(Login.pfc.Families[0], 15.75f, FontStyle.Regular);
                lblPass.Font = text;
                lblRegPassre.Font = text;
                lblRUser.Font = text;
                lblShpass.Font = text;
            }
            catch
            {
                MessageBox.Show("Typsnitten kunde ej laddas in");
                
            }
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
                mousePose.Offset(_mouseLocation.X, _mouseLocation.Y);
                this.Location = mousePose;
            }
        }

        private void PHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(-e.X, -e.Y);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxUsername.Text))
            {
                if (!string.IsNullOrEmpty(tbxPassword.Text) && PasswordValidator(tbxPassword.Text))
                {
                    if (tbxRepassword.Text == tbxPassword.Text)
                    {
                        try
                        {
                            User u = _db.FindByParameter<User>("Users", "Username", tbxUsername.Text);
                            if (!(u.Username == tbxUsername.Text))
                            {
                                User n = new User(tbxUsername.Text, MongoCRUD.Encrypt(tbxPassword.Text));
                                n.Name = tbxUsername.Text;
                                _db.InsertOne("Users", n);
                                MessageBox.Show("Ditt konto är nu skapat");
                                this.Close();
                                Login log = new Login();
                                log.Show();
                            }
                            else
                            {
                                MessageBox.Show("Användaren existerar redan, vänligen välj ett annat användare");
                            }
                        }
                        catch
                        {
                            _db.InsertOne("Users", new User(tbxUsername.Text, MongoCRUD.Encrypt(tbxPassword.Text)));
                            MessageBox.Show("Ditt konto är nu skapat");
                            this.Close();
                            Login log = new Login();
                            log.Show();
                        }
                        
                        
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

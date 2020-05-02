using MongoDBLogin;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chay
{
    public partial class Register : Form
    {
        /// <summary>Muspekarens position</summary>
        private Point _mouseLocation;

        /// <summary>Databasen</summary>
        private MongoCRUD _db = new MongoCRUD("dbChay");

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Register()
        {
            try
            {
                InitializeComponent();
                GraphicalComponents();
            }
            catch
            {
                MessageBox.Show("Ett fel har uppstått kontakta utvecklaren");
            }
        }

        /// <summary>
        /// Läser in typsnitten
        /// </summary>
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

        /// <summary>
        /// Flyttar fönstret till den position som musen rör sig till
        /// </summary>
        private void PHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(_mouseLocation.X, _mouseLocation.Y);
                this.Location = mousePose;
            }
        }

        /// <summary>
        /// Musposition lagras när användaren klickar med musknappen
        /// </summary>
        private void PHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(-e.X, -e.Y);
        }

        /// <summary>
        /// Registreringknappen klickas på
        /// </summary>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //Kollar om användarfältet inte är tomt
                if (!string.IsNullOrEmpty(tbxUsername.Text))
                {
                    //Kollar om lösenordfältet inte är tomt och validerar så att lösenordet är tillräckligt stark
                    if (!string.IsNullOrEmpty(tbxPassword.Text) && PasswordValidator(tbxPassword.Text))
                    {
                        //Kollar så att lösenorden stämmer överens med varandra
                        if (tbxRepassword.Text == tbxPassword.Text)
                        {
                            try
                            {
                                //Om allt godkänts så letar programmet upp den registrerade användaren i databasen
                                User u = _db.FindByParameter<User>("Users", "Username", tbxUsername.Text);

                                //Finns användaren inte så skapar den nya användaren
                                if (!(u.Username == tbxUsername.Text))
                                {
                                    //Användare skapas med de inmatade värdena
                                    User n = new User(tbxUsername.Text, MongoCRUD.Encrypt(tbxPassword.Text));
                                    n.Name = tbxUsername.Text;
                                    _db.InsertOne("Users", n);
                                    MessageBox.Show("Ditt konto är nu skapat");
                                    this.Close();

                                    //Omdirekterar dig till inloggningsfönstret
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
                        else
                        {
                            MessageBox.Show("Lösenorden måste matcha");
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
            catch
            {
                MessageBox.Show("Går ej att registrera");
            }
        }

        /// <summary>
        /// Tillbaka knappen klickas på
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }

        /// <summary>
        /// Om upprepalösenords rutan ändrar text
        /// </summary>
        private void tbxRepassword_TextChanged(object sender, EventArgs e)
        {
            //Ändrar färgen på textrutorna ifall dem är lika eller olika
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

        /// <summary>
        /// Om lösenords rutan ändrar text
        /// </summary>
        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            //Ändrar färgen på textrutorna ifall dem är lika eller olika
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

        /// <summary>
        /// Kontrollerar så att lösenordet är godkänt
        /// </summary>
        private bool PasswordValidator(string password)
        {
            try
            {
                //Måste vara minst 7 tecken samt en stor bokstav och ett specialtecken
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
            catch
            {
                return false;
            }
            

        }

        /// <summary>
        /// Om visa lösenord klickas på
        /// </summary>
        private void bCbxShowPass_Click(object sender, EventArgs e)
        {
            //Ändrar så att lösenordet visas om checkboxen är ikryssad
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

        /// <summary>
        /// Klickar på avsluta
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //Stänger programmet
            this.Close();
            Login log = new Login();
            log.Show();
        }
    }
}

using MongoDBLogin;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Chay
{
    public partial class Login : Form
    {
        /// <summary>Muspekarens position</summary>
        private Point _mouseLocation;

        /// <summary>Databasen</summary>
        private MongoCRUD _db = new MongoCRUD("dbChay");

        /// <summary>Egen fontcollection</summary>
        public static PrivateFontCollection pfc = new PrivateFontCollection();
        
        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public Login()
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
        /// Musposition lagras när användaren klickar med musknappen
        /// </summary>
        private void pHeader_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseLocation = new Point(-e.X, -e.Y);
        }

        /// <summary>
        /// Flyttar fönstret till den position som musen rör sig till
        /// </summary>
        private void pHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Sätter fönsterpositionen till där musen är
                Point mousePose = Control.MousePosition;
                mousePose.Offset(_mouseLocation.X, _mouseLocation.Y);
                this.Location = mousePose;
            }
        }

        
        /// <summary>
        /// Grafiska komponenter läses in
        /// </summary>
        public void GraphicalComponents()
        {
            try
            {
                pfc.AddFontFile("Font//Myriad-Pro-Condensed.ttf");
                pfc.AddFontFile("Font//Ranchers-Regular.ttf");
                Logo.Font = new Font(pfc.Families[1], 56, FontStyle.Regular);
                Font text = new Font(pfc.Families[0], 15.75f, FontStyle.Regular);
                lblPass.Font = text;
                lblUser.Font = text;
                lblRegister.Font = new Font(pfc.Families[0], 12, FontStyle.Regular);
            }
            catch
            {
                MessageBox.Show("Typsnitten kunde ej laddas in");
                Logo.Font = new Font("Arial", 56, FontStyle.Regular);
            }
            
            Logo.ForeColor = Color.White;
        }

        /// <summary>
        /// Login knappen klickas på
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //Data basen returnerar en användare ifall användaren finns
                User found = _db.FindByParameter<User>("Users", "Username", tbxUsername.Text);

                //Jämför det krypterade lösenordet på databasen med det som användaren skrev in
                if (found.Password == MongoCRUD.Encrypt(tbxPassword.Text))
                {
                    //Deklarerar den nya formen och skickar med användaren
                    Form1 form = new Form1(found);
                    
                    //Visar den nya formen
                    form.Show();

                    //Gömmer denna formen
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

        /// <summary>
        /// Registreringsknappen klickas på
        /// </summary>
        private void LlblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //Deklararerar formen för registreringen
                Register reg = new Register();

                //Visar formen
                reg.Show();

                //Gömmer denna formen
                this.Hide();
            }
            catch
            {

            }
        }

        /// <summary>
        /// Klickar på avsluta
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

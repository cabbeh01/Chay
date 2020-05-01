using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Chay
{
    public partial class Settings : Form
    {
        /// <summary>Muspekarens position</summary>
        private Point _mouseLocation;

        /// <summary>Standard ställe att spara inställningar filen på</summary>
        internal static string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Chay\\Settings.sett";

        /// <summary>Chattfärger</summary>
        public enum ChatColor
        {
            Blå,
            Grön,
            Orange,
            Röd,
            Lila
        }

        /// <summary>Tidsformat</summary>
        public enum TimeFormat
        {
            HHmmss,
            HHmm
        }

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        /// <param name="c">Referar till Chattfärg</param>
        /// <param name="tf">Referar till Tidsformat</param>
        public Settings(ref ChatColor c, ref TimeFormat tf)
        {
            InitializeComponent();
            InsertDataCombobox();
            GraphicalComponents();

            cbxChatColor.SelectedItem = c;
            cbxTimeFormat.SelectedItem = tf;
        }

        /// <summary>
        /// Läser in grafiska kommponenter som typsnitt etc.
        /// </summary>
        public void GraphicalComponents()
        {
            try
            {
                Font text = new Font(Login.pfc.Families[0], 20.25f, FontStyle.Regular);
                lblMessagecolor.Font = text;
                lblTimestamp.Font = text;
                lblInstallningar.Font = new Font(Login.pfc.Families[0], 25.25f, FontStyle.Regular);
            }
            catch
            {
                MessageBox.Show("Typsnitten kunde ej laddas in");
            }
        }

        /// <summary>
        /// Sätter in alternativen i comboboxarna
        /// </summary>
        private void InsertDataCombobox()
        {
            try
            {
                foreach (ChatColor cColor in (ChatColor[])Enum.GetValues(typeof(ChatColor)))
                {
                    cbxChatColor.Items.Add(cColor);
                }
                foreach (TimeFormat tFormat in (TimeFormat[])Enum.GetValues(typeof(TimeFormat)))
                {
                    cbxTimeFormat.Items.Add(tFormat);
                }
            }
            catch
            {
                MessageBox.Show("Ett fel uppstod så att inte värdena kunde hämtas");
            }
        }

        /// <summary>
        /// Sparar inställningarna
        /// </summary>
        private void SaveSettings()
        {
            try
            {
                //Finns den nuvarande mappen för Chay
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Chay\\"))
                {
                    //Annars skapas den mappen
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Chay\\");
                }

                //En filström skapas så att en fil kan skrivas
                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);

                //Öppnar så att man kan skriva till filen
                StreamWriter writer = new StreamWriter(stream);

                //Skriver inställningarna
                writer.WriteLine(cbxChatColor.SelectedItem);
                writer.WriteLine(cbxTimeFormat.SelectedItem);

                //Släpper resurser
                writer.Dispose();

                MessageBox.Show("Inställningarna har sparats");

                //Stänger fönster
                this.Close();
            }
            catch
            {
                MessageBox.Show("Går inte spara");
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
        /// Klickar på spara knappen
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        /// <summary>
        /// Avbryter
        /// </summary>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

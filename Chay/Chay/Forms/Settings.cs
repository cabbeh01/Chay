using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chay
{
    public partial class Settings : Form
    {
        private Point _mouseLocation;
        internal static string fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Chay\\Settings.sett";
        public enum ChatColor
        {
            Blå,
            Grön,
            Orange,
            Röd,
            Lila
        }

        public enum TimeFormat
        {
            HHmmss,
            HHmm
        }

        public Settings(ref ChatColor c, ref TimeFormat tf)
        {
            InitializeComponent();
            InsertDataCombobox();
            GraphicalComponents();

            cbxChatColor.SelectedItem = c;
            cbxTimeFormat.SelectedItem = tf;
        }
        public void GraphicalComponents()
        {
            try
            {
                //lblRegister.Font = new Font(Login.pfc.Families[0], 24, FontStyle.Regular);
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

        private void SaveSettings()
        {
            try
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Chay\\"))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Chay\\");
                }

                FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);

                //Default settings
                writer.WriteLine(cbxChatColor.SelectedItem);
                writer.WriteLine(cbxTimeFormat.SelectedItem);

                writer.Dispose();
                MessageBox.Show("Inställningarna har sparats");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Går inte spara");
            }
            
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

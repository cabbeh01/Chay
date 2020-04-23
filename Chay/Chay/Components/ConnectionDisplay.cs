using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chay.Components
{
    public partial class ConnectionDisplay : UserControl
    {
        /// <summary>
        /// Variabel som är status för om användaren är uppkopplad
        /// </summary>
        private bool _connected = false;

        /// <summary>
        /// Standardkonstruktor
        /// </summary>
        public ConnectionDisplay()
        {
            InitializeComponent();
            UpdateStatus(_connected);
        }

        /// <summary>
        /// Uppdaterar statusen på modulen beroende på parametern som matas in
        /// </summary>
        /// <param name="status">Status värdet på servern</param>
        public void UpdateStatus(bool status)
        {
            _connected = status;
            
            //Kollar ifall statusen på klienten är uppkopplad och isåfall ändras färgen till grönt
            if (_connected)
            {
                this.rpbxStatus.BackColor = Color.SeaGreen;
            }
            else
            {
                this.rpbxStatus.BackColor = Color.Maroon;
            }
        }
    }
}

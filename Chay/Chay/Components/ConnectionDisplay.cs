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
        public bool connected = false;
        public ConnectionDisplay()
        {
            InitializeComponent();
            UpdateStatus(connected);
        }

        public void UpdateStatus(bool status)
        {
            connected = status;
            if (connected)
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

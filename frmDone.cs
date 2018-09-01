using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connector
{
    public partial class frmDone : Form
    {
        public frmDone(string msg)
        {
            InitializeComponent();
            txtMsg.Text = msg;
        }

        private void btnExite_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

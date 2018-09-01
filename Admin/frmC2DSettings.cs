using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connector.Admin
{
    public partial class frmC2DSettings : Form
    {
        public frmC2DSettings()
        {
            InitializeComponent();
            Push();
            Secuirty();
        }

        bool valdation()
        {
            if (txtPartnerName.Text == "" || txtPartnerName.Text == null )
            {
                frmDone frmdone = new frmDone("Please Enter Partner Name ");
                frmdone.ShowDialog();
                return false;
            }
            if (txtServerName.Text == "" || txtPartnerName.Text == null)
            {
                frmDone frmdone = new frmDone("Please Enter Server Name ");
                frmdone.ShowDialog();
                return false;
            }
            if (txtDBName.Text == "" || txtPartnerName.Text == null)
            {
                frmDone frmdone = new frmDone("Please Enter DataBase Name ");
                frmdone.ShowDialog();
                return false;
            }
            if (txtUser.Text == "" || txtPartnerName.Text == null)
            {
                frmDone frmdone = new frmDone("Please Enter User Name ");
                frmdone.ShowDialog();
                return false;
            }
            if (txtPassword.Text == "" || txtPartnerName.Text == null)
            {
                frmDone frmdone = new frmDone("Please Enter Password ");
                frmdone.ShowDialog();
                return false;
            }

            return true;
        }

        void Collect()
        {
            Properties.Settings.Default.C2DPartnerName = txtPartnerName.Text;
            Properties.Settings.Default.C2DServerName = txtServerName.Text;
            Properties.Settings.Default.C2DDataBaseName = txtDBName.Text;
            Properties.Settings.Default.C2DUserName = txtUser.Text;
            Properties.Settings.Default.C2DPassword = txtPassword.Text;
        }

        void Push()
        {
            txtPartnerName.Text = Properties.Settings.Default.C2DPartnerName;
            txtServerName.Text = Properties.Settings.Default.C2DServerName;
            txtDBName.Text = Properties.Settings.Default.C2DDataBaseName;
            txtUser.Text = Properties.Settings.Default.C2DUserName;
            txtPassword.Text = Properties.Settings.Default.C2DPassword;
        }

        // Check With Our Online DB If Partner Name Is Allow To Access  Or No 
        void Secuirty()
        {
            if (true)
            {
                txtPartnerName.ReadOnly = false;
                txtServerName.ReadOnly = false;
                txtDBName.ReadOnly = false;
                txtUser.ReadOnly = false;
                txtPassword.ReadOnly = false;
            }
            else
            {
                txtPartnerName.ReadOnly = true;
                txtServerName.ReadOnly = true;
                txtDBName.ReadOnly = true;
                txtUser.ReadOnly = true;
                txtPassword.ReadOnly = true;
            }
        }
        

        private void Save(object sender, EventArgs e)
        {
            if (valdation())
            {
                Collect();
                Properties.Settings.Default.Save();
                frmDone frmdone = new frmDone("Saved Done ");
                frmdone.ShowDialog();
                Push();
            }
            else
            {
                frmDone frmdone = new frmDone("Sorry Not Allow To Update");
                frmdone.ShowDialog();
            }
        }
        private void Close(object sender, EventArgs e)
        {
            Close();
        }
    }
}

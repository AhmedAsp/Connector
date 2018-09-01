using Connector.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connector
{
    public partial class frmConnectCitey2Day : Form
    {
        public frmConnectCitey2Day()
        {
            InitializeComponent();
            Push();
            GetServerName();
        }

        #region Tab Setting
        DBHelper Helper = new DBHelper();

        void Collect()
        {
            //DBGate.FOServerName = txtServerName2.Text;
            //DBGate.FODataBaseName = txtDataName2.Text;
            //DBGate.FOUserName = txtUserName2.Text;
            DBGate.C2DPassword = txtPasword.Text;
            //
            //SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            //System.Data.DataTable table = instance.GetDataSources();
        }
        void Push()
        {

            //txtServerName2.Text = DBGate.FOServerName;
            //txtDataName2.Text = DBGate.FODataBaseName;
            txtUserName.Text = DBGate.C2DUserName;
            txtPasword.Text = DBGate.C2DPassword;
        }

        private void GetServerName()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();
            foreach (DataRow server in table.Rows)
            {
                CMPServerName.Items.Add(server[table.Columns["ServerName"]].ToString());
            }
            CMPServerName.SelectedIndex = 0;
        }
        private void ConnectDB(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.PASSWORD = txtPasword.Text;
                Properties.Settings.Default.USERNAME = txtUserName.Text;
                Properties.Settings.Default.SERVER = CMPServerName.SelectedItem.ToString();
                Properties.Settings.Default.ProjName = "";
                Properties.Settings.Default.DB = "";
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {

                MessageBox.Show("User Name Or Password data error");
            }

            try
            {
                CMPDataBaseName.Items.Clear();
                foreach (string s in Helper.GetDatabases())
                {
                    CMPDataBaseName.Items.Add(s);
                }
                CMPDataBaseName.SelectedIndex = 0;
                MessageBox.Show("Connection data Succeeded");
            }
            catch
            {
                MessageBox.Show("Connection data error");
            }
        }
        void gettables(object sender, EventArgs e)
        {
            if (CMPDataBaseName.SelectedItem != null)
            {
                Properties.Settings.Default.DB = CMPDataBaseName.SelectedItem.ToString();
                Properties.Settings.Default.Save();
                try
                {
                    CMPReservationTB.Items.Clear();
                    CMPRateTB.Items.Clear();
                    CMPAvailabilityTB.Items.Clear();
                    foreach (string s in Helper.GetTables())
                    {
                        CMPReservationTB.Items.Add(s);
                        CMPRateTB.Items.Add(s);
                        CMPAvailabilityTB.Items.Add(s);
                    }
                    CMPReservationTB.SelectedIndex = 0;
                    CMPRateTB.SelectedIndex = 0;
                    CMPAvailabilityTB.SelectedIndex = 0;
                }
                catch
                {
                    MessageBox.Show("Connection Table error");
                }
            }
        }
        private void GetReservationColumnsName(object sender, EventArgs e)
        {
            if (CMPReservationTB.SelectedItem != null)
            {
                try
                {
                    CMPFirstName.Items.Clear();
                    CMPLastName.Items.Clear();
                    CMPMobile.Items.Clear();
                    CMPBookdate.Items.Clear();
                    CMPArrivaldate.Items.Clear();
                    CMPDepartdate.Items.Clear();
                    CMPRoomtype.Items.Clear();
                    CMPRoomNo.Items.Clear();
                    CMPPrice.Items.Clear();
                    CMPDays.Items.Clear();
                    CMPAmount.Items.Clear();
                    foreach (string s in Helper.GetColumnsName((CMPReservationTB.SelectedItem.ToString())))
                    {
                        CMPFirstName.Items.Add(s);
                        CMPLastName.Items.Add(s);
                        CMPMobile.Items.Add(s);
                        CMPBookdate.Items.Add(s);
                        CMPArrivaldate.Items.Add(s);
                        CMPDepartdate.Items.Add(s);
                        CMPRoomtype.Items.Add(s);
                        CMPRoomNo.Items.Add(s);
                        CMPPrice.Items.Add(s);
                        CMPDays.Items.Add(s);
                        CMPAmount.Items.Add(s);
                    }
                }
                catch
                {
                    MessageBox.Show("Connection Table error");
                }
            }
        }
        private void GetRateColumnsName(object sender, EventArgs e)
        {
            if (CMPRateTB.SelectedItem != null)
            {
                try
                {
                    CMBRoomType2.Items.Clear();
                    CMBPrice2.Items.Clear();
                    foreach (string s in Helper.GetColumnsName((CMPRateTB.SelectedItem.ToString())))
                    {
                        CMBRoomType2.Items.Add(s);
                        CMBPrice2.Items.Add(s);
                    }
                }
                catch
                {
                    MessageBox.Show("Connection Table error");
                }
            }
        }
        private void OpenReservation(object sender, EventArgs e)
        {
            if (CheckReservation.Checked == true)
            {
                GBReservation.Enabled = true;
                CMPReservationTB.Enabled = true;
            }
            else
            {
                GBReservation.Enabled = false;
                CMPReservationTB.Enabled = false;
            }
        }
        //
        private void OpenRate(object sender, EventArgs e)
        {
            if (CheckRate.Checked == true)
            {
                GBRate.Enabled = true;
                CMPRateTB.Enabled = true;
            }
            else
            {
                GBRate.Enabled = false;
                CMPRateTB.Enabled = false;
            }
        }
        //
        private void GetUserName(object sender, EventArgs e)
        {
            //if (CMPServerName.SelectedItem != null)
            //{
            //    Properties.Settings.Default.SERVER = CMPServerName.SelectedItem.ToString();
            //    Properties.Settings.Default.Save();
            //    try
            //    {

            //        CMPUserName.Items.Clear();
            //        foreach (string s in Helper.GetTables())
            //        {
            //            CMPUserName.Items.Add(s);
            //        }
            //        CMPUserName.SelectedIndex = 0;
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Server UserName error");
            //    }
            //}
        }
        #endregion

        private void Close(object sender, EventArgs e)
        {
            Close();
        }
    }
}

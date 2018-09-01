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
    public partial class frmLogin : Form
    {
        DAL.Users currentObj = new DAL.Users();
        //
        public frmLogin()
        {
            InitializeComponent();
        }
        //
        bool ValidatControles()
        {
            //int outa;
            //if (!int.TryParse(txtUserName.Text, out outa))
            //{
            //    MessageBox.Show("Wrong User ID ");
            //    return false;
            //}
            if (txtUserName.TextLength == 0)
            {
                MessageBox.Show("Enter User ID ");
                return false;
            }

            if (txtPassword.TextLength == 0)
            {
                MessageBox.Show("Enter Password");
                return false;
            }
            else
                return true;
        }
        //
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidatControles())
            {
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
                //currentObj = currentObj.GetByUserID(int.Parse(txtUserName.Text.Trim()));
                //if (currentObj.num > 0)
                //{
                //    if (currentObj.pw1.Trim() == txtPassword.Text.Trim())
                //    {
                //        //DAL.Gate.UserID = currentObj.num;
                //        //DAL.Gate.UserName = currentObj.name;
                //        //frmMain frm = new frmMain();
                //        //frm.Show();
                //        //this.Close();
                //    }

                //    else
                //    {
                //        MessageBox.Show("Sorry Wrong Password");
                //    }
                //}
                //else
                //{
                    
                //    MessageBox.Show(" Sorry User ID Not Found");
                //}
               
            }
 
        }
       
        private void LogByEnter(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyData == Keys.Enter)
            {
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
                //if (ValidatControles())
                //{
                //   // currentObj = currentObj.GetByUserID(int.Parse(txtUserName.Text.Trim()));
                //    if (currentObj.num > 0)
                //    {
                //        if (currentObj.pw1.Trim() == txtPassword.Text.Trim())
                //        {
                //            //DAL.Gate.UserID = currentObj.num;
                //            //DAL.Gate.UserName = currentObj.name;
                //            //frmMain frm = new frmMain();
                //            //frm.Show();
                //            //this.Close();
                //        }

                //        else
                //            MessageBox.Show("Sorry Wrong Password");
                //    }
                //    else
                //        MessageBox.Show(" Sorry User ID Not Found");

                //}
            }
        }
        private void CleanByEnter(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyData == Keys.Enter)
            {
                if (ValidatControles())
                {
                    currentObj = currentObj.GetByUserID(int.Parse(txtUserName.Text.Trim()));
                    if (currentObj.num > 0)
                    {
                        if (currentObj.pw1.Trim() == txtPassword.Text.Trim())
                        {
                            //DAL.Gate.UserID = currentObj.num;
                            //DAL.Gate.UserName = currentObj.name;
                            //frmOrdrs frm = new frmOrdrs();
                            //frm.Show();
                            this.Hide();
                        }

                        else
                            MessageBox.Show("Sorry Wrong Password");
                    }
                    else
                        MessageBox.Show(" Sorry User ID Not Found");

                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
    }
}

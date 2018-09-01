using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Connector.DataLayer;
using System.Data.Sql;

namespace Connector
{
    public partial class frmReservations : Form
    {
        SendData SendObj = new SendData();
        //
        GetData GetObj = new GetData();
        List<GetData> getlst = new List<GetData>();
        //
        DAL.Reservations CurrentObj = new DAL.Reservations();
        List<DAL.Reservations> lst = new List<DAL.Reservations>();
        frmDone frm = new frmDone("Please Select Room No");
        frmDone _frm = new frmDone("Print Form");
        //
        public frmReservations()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(SendData);
            timer1.Interval = (1000) * (60 * 60);
            //timer1.Start();
            //
            timer2.Tick += new EventHandler(GetReservations);
            timer2.Interval = (1000) * (60);
            //timer2.Start();
            BindGrid();
            cmbSearch.SelectedIndex = 0;
 
         }

        void BindGrid()
        {
            lst = CurrentObj.GetAll();
            dataGridView1.Rows.Clear();
            if (lst.Count > 0)
            {
                foreach (var row in lst)
                {
                    dataGridView1.Rows.Add(row.ID, row.FirstName + row.LastName, row.CheckIn.ToShortDateString(), row.CheckOut.ToShortDateString(), row.UniteName, row.Bookedon, row.Status, row.TotalPrice, row.Commission);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Print
            if (e.ColumnIndex == 9)
            {
                int ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                _frm.ShowDialog();
                // Print Form
            }
                // Dowunload
            if (e.ColumnIndex == 10)
            {
                int ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                frm.ShowDialog();
                // Download  reservation
            }

        }

        private void SendData(object sender, EventArgs e)
        {
            //lst = CurrentObj.GetAll();
            //var jsonSerialiser = new JavaScriptSerializer();
            //var MyjsonList = jsonSerialiser.Serialize(lst);
            //SendObj.SendMyData("myuser", "mypassword", MyjsonList);
        }

        private void GetReservations(object sender, EventArgs e)
        {
            // Recived Data From Website
            //getlst = GetObj.GetMyData("myuser", "mypassword");
            //dataGridView1.DataSource = null;
            //dataGridView1.DataSource = getlst;
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }


     
 
 
    }
}

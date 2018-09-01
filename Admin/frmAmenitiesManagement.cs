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
    public partial class frmAmenitiesManagement : Form
    {
        DAL.Amenities currentobj = new DAL.Amenities();
        List<DAL.Amenities> Amenitieslst = new List<DAL.Amenities>();
        //
        DAL.AmenitiesType typeobj = new DAL.AmenitiesType();
        List<DAL.AmenitiesType> lst = new List<DAL.AmenitiesType>();
        int ID = 0;

        public frmAmenitiesManagement()
        {
            InitializeComponent();
            BindControl();
            BindGrid();
        }

        void BindGrid()
        {
            Amenitieslst = currentobj.GetAmenitiesName();
            if (Amenitieslst.Count != 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Amenitieslst;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
        }
        void BindControl()
        {
            lst = typeobj.GetAll();
            CMBType.DataSource = lst;
            CMBType.DisplayMember = "Name";
            CMBType.ValueMember = "ID";
        }
        void push()
        {
            txtName.Text = currentobj.AmenitiesName;
           CMBType.SelectedValue = currentobj.AmenitiesTypeID;
        }
        void Add()
        {
            currentobj.AmenitiesTypeID = int.Parse(CMBType.SelectedValue.ToString());
            currentobj.AmenitiesName = txtName.Text;

            bool msg = currentobj.AddAmenities();
            if (msg == true)
            {
                frmDone frmdone = new frmDone("Saved Done");
                frmdone.ShowDialog();
                BindGrid();
            }
            else
            {
                frmDone frmdone = new frmDone("Error");
                frmdone.ShowDialog();
            }
        }
        void Updated()
        {
            currentobj.AmenitiesTypeID = int.Parse(CMBType.SelectedValue.ToString());
            currentobj.AmenitiesName = txtName.Text;
            currentobj.ID = ID;
            bool msg = currentobj.Update();
            if (msg == true)
            {
                frmDone frmdone = new frmDone("Update Done");
                frmdone.ShowDialog();
                BindGrid();
            }
            else
            {
                frmDone frmdone = new frmDone("Error");
                frmdone.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Updated();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool msg = currentobj.Delete(ID);
            if (msg == true)
            {
                frmDone frmdone = new frmDone("Delete Done");
                frmdone.ShowDialog();
                BindGrid();
            }
            else
            {
                frmDone frmdone = new frmDone("Error");
                frmdone.ShowDialog();
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentRow.Index;
            ID = int.Parse(dataGridView1.Rows[rowindex].Cells[0].Value.ToString());
            currentobj = currentobj.GetByID(ID);
            push();
        }
        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}

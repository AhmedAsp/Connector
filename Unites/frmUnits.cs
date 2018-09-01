using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connector.Unites
{
    public partial class frmUnits : Form
    {
        DAL.Unites currentobj = new DAL.Unites();
        List<DAL.Unites> Uniteslst = new List<DAL.Unites>();
        //
        DAL.UniteType typeobj = new DAL.UniteType();
        List<DAL.UniteType> lst = new List<DAL.UniteType>();
        //
        DAL.Floors Floorsobj = new DAL.Floors();
        List<DAL.Floors> Floorslst = new List<DAL.Floors>();
        int ID = 0;
        public frmUnits()
        {
            InitializeComponent();
            BindControl();
            BindGrid();
        }

        void BindGrid()
        {
            Uniteslst = currentobj.GetUnitName();
            if (Uniteslst.Count != 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Uniteslst;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
            }
        }
        void BindControl()
        {
            lst = typeobj.GetAll();
            CMBType.DataSource = lst;
            CMBType.DisplayMember = "UniteName";
            CMBType.ValueMember = "ID";
            //
            Floorslst = Floorsobj.GetAll();
            CMBFloors.DataSource = Floorslst;
            CMBFloors.DisplayMember = "FloorName";
            CMBFloors.ValueMember = "ID";

        }
        void push()
        {
            txtName.Text = currentobj.UnitName;
            CMBType.SelectedValue = currentobj.UnitTypeID;
            CMBFloors.SelectedValue = currentobj.FloorID;
        }
        void Add()
        {
            currentobj.UnitTypeID = int.Parse(CMBType.SelectedValue.ToString());
            currentobj.FloorID = int.Parse(CMBFloors.SelectedValue.ToString());
            currentobj.StatusID = 1;
            currentobj.StatusReason = " ";
            currentobj.UnitName = txtName.Text;

            bool msg = currentobj.Add();
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
            currentobj.UnitTypeID = int.Parse(CMBType.SelectedValue.ToString());
            currentobj.FloorID = int.Parse(CMBFloors.SelectedValue.ToString());
            currentobj.StatusID = 1;
            currentobj.StatusReason = " ";
            currentobj.UnitName = txtName.Text;
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

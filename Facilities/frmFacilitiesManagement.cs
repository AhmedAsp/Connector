using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connector.Facilities
{
    public partial class frmFacilitiesManagement : Form
    {
        DAL.FacilitiesType FacilitiesTypeobj = new DAL.FacilitiesType();
        List<DAL.FacilitiesType> FacilitiesTypelst = new List<DAL.FacilitiesType>();
        //
        DAL.Facilities currentobj = new DAL.Facilities();
        List<DAL.Facilities> lst = new List<DAL.Facilities>();
        public frmFacilitiesManagement()
        {
            InitializeComponent();
            BindControl();
            bindgrid();
        }

        void bindgrid()
        {
            //GetAll
            try
            {
                lst = currentobj.GetAllByFacilitiesTypeID((int)CMBFacilitiesType.SelectedValue);
            }
            catch (Exception)
            {

                lst = currentobj.GetAll();
            }
            dataGridView1.Rows.Clear();
            if (lst.Count > 0)
            {
                foreach (var row in lst)
                {
                    if (row.Statuis == true)
                    {
                        dataGridView1.Rows.Add(row.ID, row.FacilitiesName, true, false);
                    }
                    else
                    { dataGridView1.Rows.Add(row.ID, row.FacilitiesName, false, true); }
                }
            }
        }
        void BindControl()
        {
            FacilitiesTypelst = FacilitiesTypeobj.GetAll();
            if (FacilitiesTypelst.Count > 0)
            {
                CMBFacilitiesType.DataSource = FacilitiesTypelst;
                CMBFacilitiesType.DisplayMember = "Name";
                CMBFacilitiesType.ValueMember = "ID";
                CMBFacilitiesType.SelectedIndex = 0;
            }
        }
        void Save()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Yes
                if ((bool)row.Cells[2].Value == true && (bool)row.Cells[3].Value == false)
                {
                    currentobj.ID = (int)row.Cells[0].Value;
                    currentobj.FacilitiesTypeID = (int)CMBFacilitiesType.SelectedValue;
                    currentobj.FacilitiesName = row.Cells[1].Value.ToString();
                    currentobj.Statuis = true;
                    currentobj.Update();
                    //
                }
                // No
                if ((bool)row.Cells[3].Value == true || (bool)row.Cells[2].Value == (bool)row.Cells[3].Value)
                {
                    currentobj.ID = (int)row.Cells[0].Value;
                    currentobj.FacilitiesTypeID = (int)CMBFacilitiesType.SelectedValue;
                    currentobj.FacilitiesName = row.Cells[1].Value.ToString();
                    currentobj.Statuis = false;
                    currentobj.Update();
                }
            }
        }
        //
        private void Save(object sender, EventArgs e)
        {
            Save();
            frmDone frm = new frmDone("Saved Done");
            frm.ShowDialog();
        }
        private void GetFacilities(object sender, EventArgs e)
        {
            // Update Data
            bindgrid();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                dataGridView1.CurrentCell.Value = true;
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = false;
            }
            else if (e.ColumnIndex == 3)
            {
                dataGridView1.CurrentCell.Value = true;
                dataGridView1.Rows[e.RowIndex].Cells[2].Value = false;
            }

        }
        private void Close(object sender, EventArgs e)
        {
            Close();
        }

    }
}

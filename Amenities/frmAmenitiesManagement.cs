using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connector.Amenities
{
    public partial class frmAmenitiesManagement : Form
    {
        DAL.AmenitiesType AmenitiesTypeobj = new DAL.AmenitiesType();
        List<DAL.AmenitiesType> AmenitiesTypelst = new List<DAL.AmenitiesType>();
        //
        DAL.Amenities currentobj = new DAL.Amenities();
        List<DAL.Amenities> lst = new List<DAL.Amenities>();
        //
        DAL.AmenitiesOfUnits Amenitiestobj = new DAL.AmenitiesOfUnits();
        List<DAL.AmenitiesOfUnits> Amenitieslst = new List<DAL.AmenitiesOfUnits>();
        Unites.frmShowUnit frm = new Unites.frmShowUnit("Please Select Unit to Your Aminities" );
        //
        public frmAmenitiesManagement()
        {
            InitializeComponent();
            BindControl();
            bindgrid();
        }
        //
        void bindgrid()
        {
            //GetAll
            try
            {
                lst = currentobj.GetAllByAmenitiesTypeID((int)CMBAmenitiesType.SelectedValue);
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
                        dataGridView1.Rows.Add(row.ID, row.AmenitiesName, true, false);
                    }
                    else
                    { dataGridView1.Rows.Add(row.ID, row.AmenitiesName, false, true); }
                }
            }
        }
        void BindControl()
        {
            AmenitiesTypelst = AmenitiesTypeobj.GetAll();
            if (AmenitiesTypelst.Count > 0)
            {
                CMBAmenitiesType.DataSource = AmenitiesTypelst;
                CMBAmenitiesType.DisplayMember = "Name";
                CMBAmenitiesType.ValueMember = "ID";
                CMBAmenitiesType.SelectedIndex = 0;
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
                    currentobj.AmenitiesTypeID = (int)CMBAmenitiesType.SelectedValue;
                    currentobj.AmenitiesName = row.Cells[1].Value.ToString();
                    currentobj.Statuis = true;
                    currentobj.Update();
                    //
                    frm.Add((int)row.Cells[0].Value  );
                }
                // No
                if ((bool)row.Cells[3].Value == true || (bool)row.Cells[2].Value == (bool)row.Cells[3].Value )
                {
                    currentobj = currentobj.GetByID((int)row.Cells[0].Value);
                    if (currentobj.Statuis == true)
                    {
                        currentobj.ID = (int)row.Cells[0].Value;
                        currentobj.AmenitiesTypeID = (int)CMBAmenitiesType.SelectedValue;
                        currentobj.AmenitiesName = row.Cells[1].Value.ToString();
                        currentobj.Statuis = false;
                        currentobj.Update();
                        //
                        Amenitiestobj.Delete((int)row.Cells[0].Value);
                    }
                    
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
        // CMB Index Change
        private void GetAmenities(object sender, EventArgs e)
        {
            bindgrid();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                dataGridView1.CurrentCell.Value = true;
                dataGridView1.Rows[e.RowIndex].Cells[3].Value = false;
                //
                int ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                frm.frmUnit_AmenitiesID = ID;
                frm.BindGrid();
                frm.BindAmenities();
                frm.ShowDialog();
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

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
    public partial class frmShowUnit : Form
    {
        #region Pro /  obj
        DAL.UniteType currentobj = new DAL.UniteType();
        List<DAL.UniteType> lst = new List<DAL.UniteType>();
        //
        DAL.AmenitiesOfUnits Amenitiestobj = new DAL.AmenitiesOfUnits();
        List<DAL.AmenitiesOfUnits> Amenitieslst = new List<DAL.AmenitiesOfUnits>();
        //
        DAL.AmenitiesOfUnits RuntimeAmenitiestobj = new DAL.AmenitiesOfUnits();
        List<DAL.AmenitiesOfUnits> RuntimeAminitelst = new List<DAL.AmenitiesOfUnits>();
        public int frmUnit_AmenitiesID = 0;
        #endregion

        public frmShowUnit(string msg)
        {
            InitializeComponent();
            txtMsg.Text = msg;
        }

        public void BindGrid()
        {
            lst = currentobj.GetAll();
            if (lst.Count != 0)
            {
                dataGridView1.Rows.Clear();
                foreach (var item in lst)
                {
                    dataGridView1.Rows.Add(item.ID, item.UniteName, false);
                }
            }
        }
        public void BindAmenities()
        {
            Amenitieslst = Amenitiestobj.GetAllByAmenitiesID(frmUnit_AmenitiesID);
            foreach (var item in Amenitieslst)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (item.UnitID == (int)row.Cells[0].Value)
                    {
                        row.Cells[2].Value = true;
                    }
                }
            }
        }
        public void FillLst()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((bool)row.Cells[2].Value == true)
                {
                    RuntimeAmenitiestobj = RuntimeAmenitiestobj.GetByUnitIDandAmenitiesID((int)row.Cells[0].Value, frmUnit_AmenitiesID);
                    if (RuntimeAmenitiestobj.ID == 0)
                    {
                        RuntimeAmenitiestobj.UnitID = (int)row.Cells[0].Value;
                        RuntimeAmenitiestobj.AmenitiesID = frmUnit_AmenitiesID;
                        RuntimeAminitelst.Add(RuntimeAmenitiestobj);
                    }
                }
            }
        }
        public void Add( int _amenitiesid)
        {
            foreach (var item in RuntimeAminitelst.ToList())
            {
                if (item.AmenitiesID == _amenitiesid)
                {
                    RuntimeAmenitiestobj = RuntimeAmenitiestobj.GetByUnitIDandAmenitiesID(item.UnitID, item.AmenitiesID);
                    if (RuntimeAmenitiestobj.ID == 0)
                    {
                        Amenitiestobj.AmenitiesID = item.AmenitiesID;
                        Amenitiestobj.UnitID = item.UnitID;
                        Amenitiestobj.Add();
                    }
                    RuntimeAminitelst.Remove(item);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FillLst();
            BindGrid();
            BindAmenities();
            this.Hide();
        }

        private void btnExite_Click(object sender, EventArgs e)
        {
            BindGrid();
            BindAmenities();
            this.Hide();
        }
 
    }
}

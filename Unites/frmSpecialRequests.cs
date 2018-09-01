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
    public partial class frmSpecialRequests : Form
    {
        DAL.SpecialRequests currentobj = new DAL.SpecialRequests();
        List<DAL.SpecialRequests> lst = new List<DAL.SpecialRequests>();
        int ID = 0;
        public frmSpecialRequests()
        {
            InitializeComponent();
            BindGrid();
        }
        void BindGrid()
        {
            lst = currentobj.GetAll();
            if (lst.Count != 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lst;
            }
        }
        void push()
        {
            txtName.Text = currentobj.Name;
        }
        void Add()
        {
            currentobj.Name = txtName.Text;

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
            currentobj.Name = txtName.Text;
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

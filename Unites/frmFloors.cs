﻿using System;
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
    public partial class frmFloors : Form
    {
        DAL.Floors currentobj = new DAL.Floors();
        List<DAL.Floors> lst = new List<DAL.Floors>();
        int ID = 0;
        public frmFloors()
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
            txtName.Text = currentobj.FloorName;
         }
        void Add()
        {
             currentobj.FloorName = txtName.Text;

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
             currentobj.FloorName = txtName.Text;
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

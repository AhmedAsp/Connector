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

namespace Connector.Rooms
{
    public partial class frmUnitesDetails : Form
    {
        DAL.UniteDetails currentobj = new DAL.UniteDetails();
        List<DAL.UniteDetails> lst = new List<DAL.UniteDetails>();
        //
        DAL.Pictures Picobj = new DAL.Pictures();
        List<DAL.Pictures> Piclst = new List<DAL.Pictures>();
        //
        DAL.UniteType UniteTypeobj = new DAL.UniteType();
        List<DAL.UniteType> UniteTypelst = new List<DAL.UniteType>();
        //
        int ID = 0;
        //
        public frmUnitesDetails()
        {
            InitializeComponent();
            BindGrid();
            Push();
            BindControl();
            CMBUnitType.SelectedIndex = 0;
            CMBBedKind.SelectedIndex = 0;
            CMBSmoking.SelectedIndex = 0;
        }
        //
        void BindGrid()
        {
            lst = currentobj.GetAll();
            if (lst.Count != 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lst;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Unite Name";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                //
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = lst;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[2].HeaderText = "Unite Name";
                dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView2.Columns[3].Visible = false;
                dataGridView2.Columns[4].Visible = false;
                dataGridView2.Columns[5].Visible = false;
                dataGridView2.Columns[6].Visible = false;
                dataGridView2.Columns[7].Visible = false;
                dataGridView2.Columns[8].Visible = false;
                dataGridView2.Columns[9].Visible = false;
                dataGridView2.Columns[10].Visible = false;
                dataGridView2.Columns[11].Visible = false;
                dataGridView2.Columns[12].Visible = false;
                dataGridView2.Columns[13].Visible = false;
                dataGridView2.Columns[14].Visible = false;
            }
        }
        void BindControl()
        {
            UniteTypelst = UniteTypeobj.GetAll();
            if (UniteTypelst.Count != 0)
            {
                CMBUnitType.DataSource = UniteTypelst;
                CMBUnitType.DisplayMember = "UniteName";
                CMBUnitType.ValueMember = "ID";
                CMBUnitType.SelectedIndex = 0;
            }
        }
        //
        bool Collect()
        {
            try
            {
                currentobj.UnittypeID =(int) CMBUnitType.SelectedValue;
                currentobj.UniteName = txtApartmentName.Text;
                currentobj.SmokingPolicy = true;
                currentobj.PoolPolicy = true;
                currentobj.Size = txtUniteSize.Text;
                currentobj.ApartmentNumber = int.Parse(txtApartmentNumber.Text);
                currentobj.GustNumber = int.Parse(txtGustNumber.Text);
                currentobj.BedRoomNumber = int.Parse(txtBedRoomNumber.Text);
                currentobj.LivingRoomNumber = int.Parse(txtLivingRoomNumber.Text);
                currentobj.BedKind = CMBBedKind.SelectedIndex;
                currentobj.BedNumber = int.Parse(txtBedNumber.Text);
                currentobj.SofaBedNumber = int.Parse(txtSofaBedNumber.Text);
                currentobj.BathroomNumber = int.Parse(txtBathroomNumber.Text);
                currentobj.PrivateBathRoomNumber = int.Parse(txtPrivateBathRoomNumber.Text);
                return true;
            }
            catch (SqlException ex)
            {
                frmDone frm = new frmDone(ex.ToString());
                frm.ShowDialog();
                return false;
            }
        }
        bool Push()
        {
            try
            {
                currentobj = currentobj.GetByID(ID);
                CMBUnitType.SelectedValue = currentobj.UnittypeID;
                txtApartmentName.Text = currentobj.UniteName;
                currentobj.SmokingPolicy = true;
                currentobj.PoolPolicy = true;
                txtUniteSize.Text = currentobj.Size;
                txtApartmentNumber.Text = currentobj.ApartmentNumber.ToString();
                txtGustNumber.Text = currentobj.GustNumber.ToString();
                txtBedRoomNumber.Text = currentobj.BedRoomNumber.ToString();
                txtLivingRoomNumber.Text = currentobj.LivingRoomNumber.ToString();
                CMBBedKind.SelectedIndex = 0;
                txtBedNumber.Text = currentobj.BedNumber.ToString();
                txtSofaBedNumber.Text = currentobj.SofaBedNumber.ToString();
                txtBathroomNumber.Text = currentobj.BathroomNumber.ToString();
                txtPrivateBathRoomNumber.Text = currentobj.PrivateBathRoomNumber.ToString();
                return true;
            }
            catch (SqlException ex)
            {
                frmDone frm = new frmDone(ex.ToString());
                frm.ShowDialog();
                return false;
            }

        }
        void Clear()
        {
            currentobj = new DAL.UniteDetails();
            CMBUnitType.SelectedIndex = 1;
            CMBBedKind.SelectedIndex = 0;
            CMBSmoking.SelectedIndex = 0;
            //
            txtApartmentName.Clear();
            ChkFeet.Checked = false;
            ChkMeters.Checked = false;
            //
            txtUniteSize.Text = "0";
            txtApartmentNumber.Text = "0";
            txtGustNumber.Text = "0";
            txtBedRoomNumber.Text = "0";
            txtLivingRoomNumber.Text = "0";
            //
            txtBedNumber.Text = "0";
            txtSofaBedNumber.Text = "0";
            txtBathroomNumber.Text = "0";
            txtPrivateBathRoomNumber.Text = "0";
            //
            Pic1.Image = Properties.Resources.MyLogoSmlleBag___Copy;
            Pic2.Image = Properties.Resources.MyLogoSmlleBag___Copy;
            Pic3.Image = Properties.Resources.MyLogoSmlleBag___Copy;
            Pic4.Image = Properties.Resources.MyLogoSmlleBag___Copy;
        }
        bool Valadations()
        {
            if (CMBUnitType.SelectedIndex == -1)
            {
                frmDone frm = new frmDone("Please Select Unite Type");
                frm.ShowDialog();
                return false;
            }
            if (CMBBedKind.SelectedIndex == -1)
            {
                frmDone frm = new frmDone("What kind of beds are available in this room?");
                frm.ShowDialog();
                return false;
            }
            if (CMBSmoking.SelectedIndex == -1)
            {
                frmDone frm = new frmDone("Please Select Smoking policy");
                frm.ShowDialog();
                return false;
            }
            if (txtApartmentName.TextLength == 0)
            {
                frmDone frm = new frmDone("Please Enter ApartmentName");
                frm.ShowDialog();
                return false;
            }
            // Numbers
            if (txtUniteSize.TextLength == 0)
            {
                frmDone frm = new frmDone("Please Enter UniteSize");
                frm.ShowDialog();
                return false;
            }
            if (txtGustNumber.TextLength == 0)
            {
                frmDone frm = new frmDone("How many guests can stay in this Apartment?");
                frm.ShowDialog();
                return false;
            }
            if (txtBedNumber.TextLength == 0)
            {
                frmDone frm = new frmDone("Please Enter Number of bed");
                frm.ShowDialog();
                return false;
            }
            if (txtSofaBedNumber.TextLength == 0)
            {
                frmDone frm = new frmDone("Number of sofa beds in the room");
                frm.ShowDialog();
                return false;
            }
            if (txtApartmentNumber.TextLength == 0)
            {
                frmDone frm = new frmDone("Number of sofa beds in the room");
                frm.ShowDialog();
                return false;
            }
            if (txtBedRoomNumber.TextLength == 0)
            {
                frmDone frm = new frmDone("Number of BedRoom in the Unit");
                frm.ShowDialog();
                return false;
            }
            if (txtLivingRoomNumber.TextLength == 0)
            {
                frmDone frm = new frmDone("Number of LivingRoom in the Unit");
                frm.ShowDialog();
                return false;
            }
            if (txtBathroomNumber.TextLength == 0)
            {
                frmDone frm = new frmDone("Number of Bathroom in the Unit");
                frm.ShowDialog();
                return false;
            }
            if (txtPrivateBathRoomNumber.TextLength == 0)
            {
                frmDone frm = new frmDone("Number of PrivateBathRoom in the Unit");
                frm.ShowDialog();
                return false;
            }
            return true;
        }
        void Delete()
        {
            DialogResult msg = MessageBox.Show("هل تريد حذف هذا الصنف بالفعل", "تنبيه", MessageBoxButtons.OKCancel);
            if (msg == DialogResult.OK)
            {
                int RowIndex = dataGridView1.CurrentRow.Index;
                int ID = int.Parse(dataGridView1.Rows[RowIndex].Cells[0].Value.ToString());
                currentobj.Delete(ID);
            }
        }
        void Save()
        {
            if (Valadations())
            {
                if (Collect())
                {
                    if (ID == 0)
                    {
                        bool check = currentobj.Add();
                        if (check)
                        {
                            frmDone frm = new frmDone("Saved Done");
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        currentobj.ID = ID;
                        bool check = currentobj.Update();
                        if (check)
                        {
                            frmDone frm = new frmDone("Update Done");
                            frm.ShowDialog();
                        }
                    }

                }
            }

        }
        void AddImage()
        {
            if (Pic1.Image == null)
            {
                Pic1.Image = Properties.Resources.download_icon_2x;
            }
            if (Pic2.Image == null)
            {
                Pic2.Image = Properties.Resources.download_icon_2x;
            }
            if (Pic3.Image == null)
            {
                Pic3.Image = Properties.Resources.download_icon_2x;
            }
            if (Pic4.Image == null)
            {
                Pic4.Image = Properties.Resources.download_icon_2x;
            }
            PictureBox[] pictureBoxs = new PictureBox[4];
            pictureBoxs[0] = Pic1;
            pictureBoxs[1] = Pic2;
            pictureBoxs[2] = Pic3;
            pictureBoxs[3] = Pic4;
            for (int i = 0; i < 4; i++)
            {
                if (pictureBoxs[i].Image != null)
                {
                    Picobj.UniteID = ID;
                    Picobj.Image = pictureBoxs[i].Image;
                    Picobj.Add();
                }
            }
            frmDone frm = new frmDone("Saved Done");
            frm.ShowDialog();
        }
        void PushImages()
        {
            if (Pic1.Image == null)
            {
                Pic1.Image = Properties.Resources.download_icon_2x;
            }
            if (Pic2.Image == null)
            {
                Pic2.Image = Properties.Resources.download_icon_2x;
            }
            if (Pic3.Image == null)
            {
                Pic3.Image = Properties.Resources.download_icon_2x;
            }
            if (Pic4.Image == null)
            {
                Pic4.Image = Properties.Resources.download_icon_2x;
            }
            Piclst = Picobj.GetImageByUnitID(ID);
            if (Piclst.Count > 0)
            {
                PictureBox[] pictureBoxs = new PictureBox[4];
                pictureBoxs[0] = Pic1;
                pictureBoxs[1] = Pic2;
                pictureBoxs[2] = Pic3;
                pictureBoxs[3] = Pic4;
                int i = 0;

                foreach (var item in Piclst)
                {
                    if (i < 4)
                    {
                        pictureBoxs[i].Image = item.Image;
                        i++;
                    }

                }
            }
        }
        //
        private void Add(object sender, EventArgs e)
        {
            ID = 0;
            Save();
            Clear();
            BindGrid();
            Push();
            PushImages();
        }
        private void Update(object sender, EventArgs e)
        {
            Save();
            Clear();
            BindGrid();
            Push();
            PushImages();
        }
        private void Delete(object sender, EventArgs e)
        {
            Delete();
            Clear();
            BindGrid();
            Push();
        }
        private void AddPictures(object sender, EventArgs e)
        {
            Picobj.Delete(ID);
            AddImage();
        }
        //
        private void Upload1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Pic1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
        private void Upload2(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Pic2.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
        private void Upload3(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Pic3.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
        private void Upload4(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Pic4.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
        //
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Clear();
            int RowIndex = dataGridView1.CurrentRow.Index;
            ID = int.Parse(dataGridView1.Rows[RowIndex].Cells[0].Value.ToString());
            Push();
            PushImages();
        }
        //
        private void Close(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
    public partial class frmFrontOffice : Form
    {
        DAL.Floors Floorobj = new DAL.Floors();
        List<DAL.Floors> Floorlst = new List<DAL.Floors>();
        //
        DAL.Unites Unitestobj = new DAL.Unites();
        List<DAL.Unites> Uniteslst = new List<DAL.Unites>();
        //
        DAL.Status Statustobj = new DAL.Status();
        List<DAL.Status> Statuslst = new List<DAL.Status>();
        public frmFrontOffice()
        {
            InitializeComponent();
            BindFloors();
            BindUnit();
        }
        //
        #region Units
        void BindUnit()
        {
            Uniteslst = Unitestobj.GetAll();
            Button[] btns = new Button[Uniteslst.Count];
            int i = 0;
            foreach (var row in Uniteslst)
            {
                btns[i] = new Button();
                btns[i].Text =  row.UnitName;
                btns[i].Visible = true;
                btns[i].TextAlign = ContentAlignment.MiddleCenter;
                btns[i].UseCompatibleTextRendering = true;
                btns[i].Size = new Size(120, 40);
                btns[i].Click += new EventHandler(this.UnitEvent);
                btns[i].FlatStyle = FlatStyle.Flat;
                btns[i].BackColor = Color.LawnGreen;
                btns[i].ForeColor = Color.Black;
                btns[i].Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                flowLayoutPanelUnits.Controls.Add(btns[i]);
                i++;
            }
        }
        void BindUnitByFloorID( int _FloorID)
        {
            Uniteslst = Unitestobj.GetByFloorID(_FloorID);
            Button[] btns = new Button[Uniteslst.Count];
            int i = 0;
            foreach (var row in Uniteslst)
            {
                btns[i] = new Button();
                btns[i].Text =   row.UnitName;
                btns[i].Visible = true;
                btns[i].TextAlign = ContentAlignment.MiddleCenter;
                btns[i].UseCompatibleTextRendering = true;
                btns[i].Size = new Size(120 , 40);
                btns[i].Click += new EventHandler(this.UnitEvent);
                btns[i].FlatStyle = FlatStyle.Flat;
                btns[i].BackColor = Color.LawnGreen;
                btns[i].ForeColor = Color.Black;
                btns[i].Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                flowLayoutPanelUnits.Controls.Add(btns[i]);
                i++;
            }
        }
        void MentItem()
        {
            ContextMenuStrip PopupMenu = new ContextMenuStrip();
            PopupMenu.BackColor = Color.OrangeRed;
            PopupMenu.ForeColor = Color.Black;
            PopupMenu.Text = "File Menu";
            PopupMenu.Font = new Font("Georgia", 16);
            this.ContextMenuStrip = PopupMenu;
            PopupMenu.Show();

        }
        private void UnitEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            lbUnitNumber.Text = btn.Text;
            //GruopName = btn.Text;
            //FlowPanelMeals.Controls.Clear();
            //MealsObj = new BL.MealsBl();
            // MealButtom();
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("New Reservation");
            cm.MenuItems.Add("Item 2");

            btn.ContextMenu = cm;
            //frmDone frm = new frmDone(btn.Text);
            //frm.ShowDialog();

        }
        #endregion
        //
        #region Floors
        void BindFloors()
        {
            Floorlst = Floorobj.GetAll();
            Button[] btns = new Button[Floorlst.Count];
            int i = 0;
            foreach (var row in Floorlst)
            {
                btns[i] = new Button();
                btns[i].Text = row.FloorName;
                btns[i].Name = row.ID.ToString();
                btns[i].Visible = true;
                btns[i].Size = new Size(100, 40);
                btns[i].Click += new EventHandler(this.FloorEvent);
                btns[i].FlatStyle = FlatStyle.Flat;
                btns[i].BackColor = Color.WhiteSmoke;
                btns[i].ForeColor = Color.Black;
                btns[i].Font = new Font("Times New Roman", 10, FontStyle.Bold);
                flowLayoutPanelFloor.Controls.Add(btns[i]);
                i++;
            }
        }
        private void btnAllFloors_Click(object sender, EventArgs e)
        {
            flowLayoutPanelUnits.Controls.Clear();
            BindUnit();
        }
        private void FloorEvent(object sender, EventArgs e)
        {
            flowLayoutPanelUnits.Controls.Clear();
            Button btn = (Button)sender;
            BindUnitByFloorID((int.Parse(btn.Name)));
        }

        #endregion
        //
        private void Departure(object sender, EventArgs e)
        {

        }
        private void Arrivale(object sender, EventArgs e)
        {

        }
        private void Close(object sender, EventArgs e)
        {
            Close();
        }

        private void btnShowNewReservation_Click(object sender, EventArgs e)
        {
            MenuPanal.Visible = false;
            ReservationPanal.Visible = true;
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            MenuPanal.Visible = true;
            ReservationPanal.Visible = false;
        }

        private void btnReservationDetails_Click(object sender, EventArgs e)
        {
            frmDone frm = new frmDone("Reservation Details");
            frm.ShowDialog();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            frmDone frm = new frmDone("Check In");
            frm.ShowDialog();
        }

       

 
    }
}

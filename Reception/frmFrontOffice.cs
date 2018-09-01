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
        #region Prop and Obj
        DAL.Floors Floorobj = new DAL.Floors();
        List<DAL.Floors> Floorlst = new List<DAL.Floors>();
        //
        DAL.Unites Unitestobj = new DAL.Unites();
        List<DAL.Unites> Uniteslst = new List<DAL.Unites>();
        //
        DAL.Status Statustobj = new DAL.Status();
        List<DAL.Status> Statuslst = new List<DAL.Status>();
        //
        DAL.Reservations Reservationsobj = new DAL.Reservations();
        List<DAL.Reservations> Reservationslst = new List<DAL.Reservations>();
        #endregion
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
                //
                btns[i].BackColor = Color.LimeGreen;
                btns[i].ForeColor = Color.White;
                //
                btns[i].Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                flowLayoutPanelUnits.Controls.Add(btns[i]);
                i++;
            }
            Status();
            Colors();
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
                //
                btns[i].BackColor = Color.LimeGreen;
                btns[i].ForeColor = Color.White;
                //
                btns[i].Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                flowLayoutPanelUnits.Controls.Add(btns[i]);
                i++;
            }
            Status();
            Colors();
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
        void Status()
        {
            Uniteslst = Unitestobj.GetAll();
            if (Uniteslst.Count > 0)
            {
                foreach (var item in Uniteslst)
                {
                    foreach (Control c in flowLayoutPanelUnits.Controls)
                    {
                        if ((c.Text).Trim() == (item.UnitName).Trim())
                        {
                            // Dirty  V,DI
                            if (item.StatusID == 4)
                            {
                                c.BackColor = Color.SandyBrown;
                                c.ForeColor = Color.White;
                            }
                            // OO_OS
                            if (item.StatusID == 9)
                            {
                                c.BackColor = Color.DarkGray;
                                c.ForeColor = Color.White;
                            }

                        }
                    }
                }
            }
 
        }
        void Colors()
        {
            DateTime now = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yy"));
            Reservationslst = Reservationsobj.Search(now);
            if (Reservationslst.Count > 0)
            {
                foreach (var item in Reservationslst)
                {
                    foreach (Control c in flowLayoutPanelUnits.Controls)
                    {
                        if ((c.Text).Trim() == (item.RoomNo).Trim())
                        {
                            // Arrival today ( V,CL,B  - V,DI,B) 
                            #region
                            if (item.CheckIn.Day == DateTime.Now.Day
                                && item.CheckIn.Month == DateTime.Now.Month
                                && item.CheckIn.Year == DateTime.Now.Year
                                && item.Status == (1).ToString())
                            {
                                // Clean 1  V,CL,B
                                if (c.BackColor == Color.LimeGreen)
                                {
                                    c.BackColor = Color.Yellow;
                                    c.ForeColor = Color.Black;
                                }
                                // Dirty 3  V,DI,B
                                else if (c.BackColor == Color.Brown)
                                {
                                    c.BackColor = Color.Red;
                                    c.ForeColor = Color.White;
                                }
                                c.Tag = item.ID;
                            }
                            #endregion
                            // Occupied ( O,CL,E  - O,CL  - O,DI,E  - O,DI)  
                            #region
                            else if (item.Status == (5).ToString() || item.Status == (6).ToString() || item.Status == (7).ToString() || item.Status == (8).ToString())
                            {
                                if (item.CheckOut.Day > DateTime.Now.Day
                                   && item.CheckOut.Month == DateTime.Now.Month
                                   && item.CheckOut.Year == DateTime.Now.Year)
                                {
                                    // Clean 6  O,CL
                                    if (c.BackColor == Color.LimeGreen)
                                    {
                                        c.BackColor = Color.Blue;
                                        c.ForeColor = Color.White;
                                    }
                                    // Dirty 8  O,DI
                                    else if (c.BackColor == Color.SandyBrown)
                                    {
                                        c.BackColor = Color.MediumVioletRed;
                                        c.ForeColor = Color.White;
                                    }
                                }
                                if (item.CheckOut.Day == DateTime.Now.Day
                                   && item.CheckOut.Month == DateTime.Now.Month
                                   && item.CheckOut.Year == DateTime.Now.Year )
                                {
                                    // Clean 5  O,CL,E
                                    if (c.BackColor == Color.LimeGreen)
                                    {
                                        c.BackColor = Color.SkyBlue;
                                        c.ForeColor = Color.White;
                                    }
                                    // Dirty  7  O,DI,E
                                    else if (c.BackColor == Color.SandyBrown)
                                    {
                                        c.BackColor = Color.Black;
                                        c.ForeColor = Color.White;
                                    }

                                }
                            }
                            #endregion
                        }
                    }
                }
            }
        }
        private void UnitEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtUnitNumber.Text = btn.Text.Trim();
            txtUnitNumber.ForeColor = btn.ForeColor;
            txtUnitNumber.BackColor = btn.BackColor;
            //
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("New Reservation");
            cm.MenuItems.Add("Item 2");

            btn.ContextMenu = cm;
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
        private void btnAllFloors_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanelUnits.Controls.Clear();
            BindUnit();
        }
        #endregion
        //
        #region Menu

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            Reception.frmManagmentReservations frm = new Reception.frmManagmentReservations();
            frm.ShowDialog();
        }
        private void btnReservationDetails_Click(object sender, EventArgs e)
        {
            Reception.frmManagmentReservations frm = new Reception.frmManagmentReservations(5);
            frm.ShowDialog();
        }
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            frmDone frm = new frmDone("Check In");
            frm.ShowDialog();
        }
        private void Close(object sender, EventArgs e)
        {
            Close();
        }
        #endregion







    }
}

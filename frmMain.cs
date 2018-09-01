using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Connector
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        void OpenForm(Form _frm)
        {
            PanelForm.Visible = false;
            foreach (Form frm in this.MdiChildren)
            {
                frm.WindowState = FormWindowState.Minimized;
            }
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == _frm.Name)
                {
                    frm.WindowState = FormWindowState.Normal;
                    return;
                }
                frm.WindowState = FormWindowState.Minimized;
            }
            _frm.MdiParent = this;
            _frm.ShowInTaskbar = false;
            _frm.MaximizeBox = false;
            _frm.Show();
        }
        void openforminpanal(Form _frm)
        {
            PanelForm.Visible = true;
            _frm.TopLevel = false;
            PanelForm.Controls.Add(_frm);
            _frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            _frm.Dock = DockStyle.Fill;
            _frm.Show();
        }

        #region Hotel
        private void TSMFrontOffice_Click(object sender, EventArgs e)
        {
            frmFrontOffice frm = new frmFrontOffice();
            openforminpanal(frm);
        }
        private void TSMGeneralReports_Click(object sender, EventArgs e)
        {
            
        }
        private void TSMReservations_Click(object sender, EventArgs e)
        {
            frmReservations frm = new frmReservations();
            OpenForm(frm);
        }
        private void TSMRateAvailability_Click(object sender, EventArgs e)
        {
            Rooms.frmRateAvailability frm = new Rooms.frmRateAvailability();
            OpenForm(frm);
        }
        private void TSMOffers_Click(object sender, EventArgs e)
        {
            frmOffers frm = new frmOffers();
            OpenForm(frm);
        }
        private void TSMRoomsProperty_Click(object sender, EventArgs e)
        {
            Rooms.frmUnitesDetails frm = new Rooms.frmUnitesDetails();
            OpenForm(frm);
        }
        private void TSMfloors_Click(object sender, EventArgs e)
        {
            Unites.frmFloors frm = new Unites.frmFloors();
            OpenForm(frm);
        }
        private void TSMUnitType_Click(object sender, EventArgs e)
        {
            Unites.frmUnitType frm = new Unites.frmUnitType();
            OpenForm(frm);
        }
        private void TSMUnitNumber_Click(object sender, EventArgs e)
        {
            Unites.frmUnits frm = new Unites.frmUnits();
            OpenForm(frm);
        }
        #endregion

        #region Facilities
        private void TSMHotelFacilities_Click(object sender, EventArgs e)
        {
            Facilities.frmFacilitiesManagement frm = new Facilities.frmFacilitiesManagement();
            OpenForm(frm);
        }
        #endregion

        #region Amenities
        private void TSMRoomAmenities_Click(object sender, EventArgs e)
        {
            Amenities.frmAmenitiesManagement frm = new Amenities.frmAmenitiesManagement();
            OpenForm(frm);
        }
        #endregion

        #region Admin / Connection
        private void TSMamenitiesManagement_Click(object sender, EventArgs e)
        {
            Admin.frmAmenitiesManagement frm = new Admin.frmAmenitiesManagement();
            OpenForm(frm);
        }
        private void TSMfacilitiesManagment_Click(object sender, EventArgs e)
        {
            Admin.frmFacilitiesManagment frm = new Admin.frmFacilitiesManagment();
            OpenForm(frm);
        }
        private void TSMPartnerConnection_Click(object sender, EventArgs e)
        {
            Admin.frmC2DSettings frm = new Admin.frmC2DSettings();
            OpenForm(frm);
        }
        private void TSMConnectCity2Day_Click(object sender, EventArgs e)
        {
            frmConnectCitey2Day frm = new frmConnectCitey2Day();
            OpenForm(frm);
        }
        #endregion

        private void Exite(object sender, EventArgs e)
        {
            Application.Exit();

        }

        

       

 

    }
}

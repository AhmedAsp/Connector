using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connector.Reception
{
    public partial class frmManagmentReservations : Form
    {

        DAL.Unites Unitesobj = new DAL.Unites();
        List<DAL.Unites> Uniteslst = new List<DAL.Unites>();
        //
        DAL.UniteType UniteTypeobj = new DAL.UniteType();
        List<DAL.UniteType> UniteTypelst = new List<DAL.UniteType>();
         //
        DAL.PriceType PriceTypeobj = new DAL.PriceType();
        List<DAL.PriceType> PriceTypelst = new List<DAL.PriceType>();
        //
        DAL.Company Companyobj = new DAL.Company();
        List<DAL.Company> Companyst = new List<DAL.Company>();
        //
        DAL.Groups Groupsobj = new DAL.Groups();
        List<DAL.Groups> Groupslst = new List<DAL.Groups>();
        //
        DAL.SpecialRequests SpecialRequestsobj = new DAL.SpecialRequests();
        List<DAL.SpecialRequests> SpecialRequestslst = new List<DAL.SpecialRequests>();
        //
        DAL.MealSystem MealSystemobj = new DAL.MealSystem();
        List<DAL.MealSystem> MealSystemlst = new List<DAL.MealSystem>();

        int ReservationID = 0;
        public frmManagmentReservations()
        {
            InitializeComponent();
            BindControl();
        }
        public frmManagmentReservations(int _ReservationID)
        {
            InitializeComponent();
            ReservationID = _ReservationID;
            BindControl();
        }

        void BindControl()
        {
            // CMBUnitType
            UniteTypelst = UniteTypeobj.GetAll();
            CMBUnitType.DataSource = UniteTypelst;
            CMBUnitType.DisplayMember = "UniteName";
            CMBUnitType.ValueMember = "ID";
            CMBUnitType.SelectedIndex = 0;

            // CMBUnitNumber
            //UniteTypelst = UniteTypeobj.GetAll();
            //CMBUnitNumber.DataSource = UniteTypelst;
            //CMBUnitNumber.DisplayMember = "UniteName";
            //CMBUnitNumber.ValueMember = "ID";
            //CMBUnitNumber.SelectedIndex = 0;

            // CMBPrice
            PriceTypelst = PriceTypeobj.GetAll();
            CMBPrice.DataSource = PriceTypelst;
            CMBPrice.DisplayMember = "Name";
            CMBPrice.ValueMember = "ID";
            CMBPrice.SelectedIndex = 0;

            //  CMBCompany
            Companyst = Companyobj.GetAll();
            CMBCompany.DataSource = Companyst;
            CMBCompany.DisplayMember = "Name";
            CMBCompany.ValueMember = "ID";
            CMBCompany.SelectedIndex = 0;

            //  CMBGroups
            Groupslst = Groupsobj.GetAll();
            CMBGroups.DataSource = Groupslst;
            CMBGroups.DisplayMember = "Name";
            CMBGroups.ValueMember = "ID";
            CMBGroups.SelectedIndex = 0;

            //  CMBMealSystem
            MealSystemlst = MealSystemobj.GetAll();
            CMBMealSystem.DataSource = MealSystemlst;
            CMBMealSystem.DisplayMember = "Name";
            CMBMealSystem.ValueMember = "ID";
            CMBMealSystem.SelectedIndex = 0;

            //  CMBSpecialReqeyests
            SpecialRequestslst = SpecialRequestsobj.GetAll();
            CMBSpecialReqeyests.DataSource = SpecialRequestslst;
            CMBSpecialReqeyests.DisplayMember = "Name";
            CMBSpecialReqeyests.ValueMember = "ID";
            CMBSpecialReqeyests.SelectedIndex = 0;

        }

        private void Close(object sender, EventArgs e)
        {
            Close();
        }
    }
}

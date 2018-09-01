using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.DAL
{
    class Reservations
    {
        #region Properts

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string UniteName { get; set; }
        //
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime Bookedon { get; set; }
        public string Status { get; set; }
        public int Days { get; set; }
        //
        public double TotalPrice { get; set; }
        public double Commission { get; set; }
        public string RoomNo { get; set; }

        #endregion

        public bool Add()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Add = "INSERT into "
            + "     Reservations "
            + "     ( "
            + "      FirstName "
            + "     ,LastName "
            + "     ,Mobile "
            + "     ,UniteName "
            //
            + "     ,CheckIn "
            + "     ,CheckOut "
            + "     ,Bookedon "
            + "     ,Status "
            + "     ,Days "
            //
            + "     ,TotalPrice "
            + "     ,Commission "
            + "     ,RoomNo "
            //
            + "     ) "
            + "VALUES "
            + "     ( "
            //
            + "      @FirstName "
            + "     ,@LastName "
            + "     ,@Mobile "
            + "     ,@UniteName "
                //
            + "     ,@CheckIn "
            + "     ,@CheckOut "
            + "     ,@Bookedon "
            + "     ,@Status "
            + "     ,@Days "
                //
            + "     ,@TotalPrice "
            + "     ,@Commission "
            + "     ,@RoomNo "
            + "     ) "
            + "";
            SqlCommand cmd = new SqlCommand(Add, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@UniteName", UniteName);
            //
            cmd.Parameters.AddWithValue("@CheckIn", CheckIn);
            cmd.Parameters.AddWithValue("@CheckOut", CheckOut);
            cmd.Parameters.AddWithValue("@Bookedon", Bookedon);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Days", Days);
            //
            cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
            cmd.Parameters.AddWithValue("@Commission", Commission);
            cmd.Parameters.AddWithValue("@RoomNo", RoomNo);
            try
            {
                Connection.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                frmDone frmerror = new frmDone(ex.ToString());
                frmerror.ShowDialog();
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
        public bool Update()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Update = "update  Reservations "
            + "      Set     "
            //
            + "     FirstName = @FirstName "
            + "     ,LastName =@LastName "
            + "     ,Mobile =@Mobile "
            + "     ,UniteName =@UniteName "
            //
            + "     ,CheckIn =@CheckIn "
            + "     ,CheckOut =@CheckOut "
            + "     ,Bookedon =@Bookedon "
            + "     ,Status =@Status "
            + "     ,Days =@Days "
            //
            + "     ,TotalPrice =@TotalPrice "
            + "     ,Commission =@Commission "
            + "     ,RoomNo =@RoomNo "
            //
            + "     where "
            + "     ID =@ID ";
            SqlCommand cmd = new SqlCommand(Update, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@UniteName", UniteName);
            //
            cmd.Parameters.AddWithValue("@CheckIn", CheckIn);
            cmd.Parameters.AddWithValue("@CheckOut", CheckOut);
            cmd.Parameters.AddWithValue("@Bookedon", Bookedon);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@Days", Days);
            //
            cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
            cmd.Parameters.AddWithValue("@Commission", Commission);
            cmd.Parameters.AddWithValue("@RoomNo", RoomNo);
            try
            {
                Connection.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }

            catch (SqlException ex)
            {
                frmDone frmerror = new frmDone(ex.ToString());
                frmerror.ShowDialog();
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
        public bool Delete(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Delete = "Delete from Reservations where ID =@ID";
            SqlCommand cmd = new SqlCommand(Delete, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                Connection.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                frmDone frmerror = new frmDone(ex.ToString());
                frmerror.ShowDialog();
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
        public DAL.Reservations GetByID(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectByID = "Select  *  from Reservations  where  ID = @ID ";
            SqlCommand cmd = new SqlCommand(SelectByID, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            Reservations _obj = new Reservations();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FirstName = reader["FirstName"].ToString();
                    _obj.LastName = reader["LastName"].ToString();
                    _obj.Mobile = reader["Mobile"].ToString();
                    _obj.UniteName = reader["UniteName"].ToString();
                    //
                    _obj.CheckIn =DateTime.Parse( reader["CheckIn"].ToString());
                    _obj.CheckOut = DateTime.Parse(reader["CheckOut"].ToString());
                    _obj.Bookedon = DateTime.Parse(reader["Bookedon"].ToString());
                    _obj.Status = reader["Status"].ToString();
                    _obj.Days = int.Parse(reader["Days"].ToString());
                    //
                    _obj.TotalPrice = double.Parse(reader["TotalPrice"].ToString());
                    _obj.Commission = double.Parse(reader["Commission"].ToString());
                    _obj.RoomNo = reader["RoomNo"].ToString();
                }
            }
            catch (SqlException ex)
            {
                frmDone frmerror = new frmDone(ex.ToString());
                frmerror.ShowDialog();
            }
            finally
            {
                Connection.Close();
            }
            return _obj;
        }
        public List<Reservations> GetAll()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Reservations ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<Reservations> lst = new List<Reservations>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reservations _obj = new Reservations();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FirstName = reader["FirstName"].ToString();
                    _obj.LastName = reader["LastName"].ToString();
                    _obj.Mobile = reader["Mobile"].ToString();
                    _obj.UniteName = reader["UniteName"].ToString();
                    //
                    _obj.CheckIn = DateTime.Parse(reader["CheckIn"].ToString());
                    _obj.CheckOut = DateTime.Parse(reader["CheckOut"].ToString());
                    _obj.Bookedon = DateTime.Parse(reader["Bookedon"].ToString());
                    _obj.Status = reader["Status"].ToString();
                    _obj.Days = int.Parse(reader["Days"].ToString());
                    //
                    _obj.TotalPrice = double.Parse(reader["TotalPrice"].ToString());
                    _obj.Commission = double.Parse(reader["Commission"].ToString());
                    _obj.RoomNo = reader["RoomNo"].ToString();
                    lst.Add(_obj);
                }
            }
            catch (SqlException ex)
            {
                frmDone frmerror = new frmDone(ex.ToString());
                frmerror.ShowDialog();
            }
            finally { Connection.Close(); }
            return lst;
        }
        public List<Reservations> Search( string SerachKey , DateTime _from , DateTime _to)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Reservations   ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<Reservations> lst = new List<Reservations>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reservations _obj = new Reservations();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FirstName = reader["FirstName"].ToString();
                    _obj.LastName = reader["LastName"].ToString();
                    _obj.Mobile = reader["Mobile"].ToString();
                    _obj.UniteName = reader["UniteName"].ToString();
                    //
                    _obj.CheckIn = DateTime.Parse(reader["CheckIn"].ToString());
                    _obj.CheckOut = DateTime.Parse(reader["CheckOut"].ToString());
                    _obj.Bookedon = DateTime.Parse(reader["Bookedon"].ToString());
                    _obj.Status = reader["Status"].ToString();
                    _obj.Days = int.Parse(reader["Days"].ToString());
                    //
                    _obj.TotalPrice = double.Parse(reader["TotalPrice"].ToString());
                    _obj.Commission = double.Parse(reader["Commission"].ToString());
                    _obj.RoomNo = reader["RoomNo"].ToString();
                    lst.Add(_obj);
                }
            }
            catch (SqlException ex)
            {
                frmDone frmerror = new frmDone(ex.ToString());
                frmerror.ShowDialog();
            }
            finally { Connection.Close(); }
            return lst;
        }
    }
}

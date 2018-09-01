using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.DAL
{
    class UniteDetails
    {
        #region Properts
        public int ID { get; set; }
        public int UnittypeID { get; set; }
        public string UniteName { get; set; }
        public bool SmokingPolicy { get; set; }
        public bool PoolPolicy { get; set; }
        public string Size { get; set; }
        //
        public int ApartmentNumber { get; set; }
        public int GustNumber { get; set; }
        public int BedRoomNumber { get; set; }
        public int LivingRoomNumber { get; set; }
        public int BedKind { get; set; }
        public int BedNumber { get; set; }
        public int SofaBedNumber { get; set; }
        public int BathroomNumber { get; set; }
        public int PrivateBathRoomNumber { get; set; }
        #endregion

        public bool Add()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Add = "INSERT into "
            + "     UniteDetails "
            + "     ( "
            + "      UnittypeID "
            + "     ,UniteName "
            + "     ,SmokingPolicy "
            + "     ,PoolPolicy "
            + "     ,Size "
            //
            + "     ,ApartmentNumber "
            + "     ,GustNumber "
            + "     ,BedRoomNumber "
            + "     ,LivingRoomNumber "
            + "     ,BedKind "
            + "     ,BedNumber "
            + "     ,SofaBedNumber "
            + "     ,BathroomNumber "
            + "     ,PrivateBathRoomNumber "
            //
            + "     ) "
            + "VALUES "
            + "     ( "
            //
            + "      @UnittypeID "
            + "     ,@UniteName "
            + "     ,@SmokingPolicy "
            + "     ,@PoolPolicy "
            + "     ,@Size "
            //
            + "     ,@ApartmentNumber "
            + "     ,@GustNumber "
            + "     ,@BedRoomNumber "
            + "     ,@LivingRoomNumber "
            + "     ,@BedKind "
            + "     ,@BedNumber "
            + "     ,@SofaBedNumber "
            + "     ,@BathroomNumber "
            + "     ,@PrivateBathRoomNumber "
            + "     ) "
            + "";
            SqlCommand cmd = new SqlCommand(Add, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UnittypeID", UnittypeID);
            cmd.Parameters.AddWithValue("@UniteName", UniteName);
            cmd.Parameters.AddWithValue("@SmokingPolicy", SmokingPolicy);
            cmd.Parameters.AddWithValue("@PoolPolicy", PoolPolicy);
            cmd.Parameters.AddWithValue("@Size", Size);
            //
            cmd.Parameters.AddWithValue("@ApartmentNumber", ApartmentNumber);
            cmd.Parameters.AddWithValue("@GustNumber", GustNumber);
            cmd.Parameters.AddWithValue("@BedRoomNumber", BedRoomNumber);
            cmd.Parameters.AddWithValue("@LivingRoomNumber", LivingRoomNumber);
            cmd.Parameters.AddWithValue("@BedKind", BedKind);
            cmd.Parameters.AddWithValue("@BedNumber", BedNumber);
            cmd.Parameters.AddWithValue("@SofaBedNumber", SofaBedNumber);
            cmd.Parameters.AddWithValue("@BathroomNumber", BathroomNumber);
            cmd.Parameters.AddWithValue("@PrivateBathRoomNumber", PrivateBathRoomNumber);
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
                return true;
            }
            finally
            {
                Connection.Close();
            }
        }
        public bool Update()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Update = "update  UniteDetails "
            + "      Set     "
            //
            + "     UnittypeID = @UnittypeID "
            + "     ,UniteName =@UniteName "
            + "     ,SmokingPolicy =@SmokingPolicy "
            + "     ,PoolPolicy =@PoolPolicy "
            + "     ,Size =@Size "
            //
            + "     ,ApartmentNumber =@ApartmentNumber "
            + "     ,GustNumber =@GustNumber "
            + "     ,BedRoomNumber =@BedRoomNumber "
            + "     ,LivingRoomNumber =@LivingRoomNumber "
            + "     ,BedKind =@BedKind "
            + "     ,BedNumber =@BedNumber "
            + "     ,SofaBedNumber =@SofaBedNumber "
            + "     ,BathroomNumber =@BathroomNumber "
            + "     ,PrivateBathRoomNumber =@PrivateBathRoomNumber "
            //
            + "     where "
            + "     ID =@ID ";
            SqlCommand cmd = new SqlCommand(Update, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@UnittypeID", UnittypeID);
            cmd.Parameters.AddWithValue("@UniteName", UniteName);
            cmd.Parameters.AddWithValue("@SmokingPolicy", SmokingPolicy);
            cmd.Parameters.AddWithValue("@PoolPolicy", PoolPolicy);
            cmd.Parameters.AddWithValue("@Size", Size);
            //
            cmd.Parameters.AddWithValue("@ApartmentNumber", ApartmentNumber);
            cmd.Parameters.AddWithValue("@GustNumber", GustNumber);
            cmd.Parameters.AddWithValue("@BedRoomNumber", BedRoomNumber);
            cmd.Parameters.AddWithValue("@LivingRoomNumber", LivingRoomNumber);
            cmd.Parameters.AddWithValue("@BedKind", BedKind);
            cmd.Parameters.AddWithValue("@BedNumber", BedNumber);
            cmd.Parameters.AddWithValue("@SofaBedNumber", SofaBedNumber);
            cmd.Parameters.AddWithValue("@BathroomNumber", BathroomNumber);
            cmd.Parameters.AddWithValue("@PrivateBathRoomNumber", PrivateBathRoomNumber);
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
            string Delete = "Delete from UniteDetails where ID =@ID";
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

        public DAL.UniteDetails GetByID(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectByID = "Select  *  from UniteDetails  where  ID = @ID ";
            SqlCommand cmd = new SqlCommand(SelectByID, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            UniteDetails _obj = new UniteDetails();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.UnittypeID = int.Parse(reader["UnittypeID"].ToString());
                    _obj.UniteName = reader["UniteName"].ToString();
                    _obj.SmokingPolicy = bool.Parse(reader["SmokingPolicy"].ToString());
                    _obj.PoolPolicy = bool.Parse(reader["PoolPolicy"].ToString());
                    _obj.Size =  reader["Size"].ToString();
                    //
                    _obj.ApartmentNumber = int.Parse(reader["ApartmentNumber"].ToString());
                    _obj.GustNumber = int.Parse(reader["GustNumber"].ToString());
                    _obj.BedRoomNumber = int.Parse(reader["BedRoomNumber"].ToString());
                    _obj.LivingRoomNumber = int.Parse(reader["LivingRoomNumber"].ToString());
                    _obj.BedKind = int.Parse(reader["BedKind"].ToString());
                    _obj.BedNumber = int.Parse(reader["BedNumber"].ToString());
                    _obj.SofaBedNumber = int.Parse(reader["SofaBedNumber"].ToString());
                    _obj.BathroomNumber = int.Parse(reader["BathroomNumber"].ToString());
                    _obj.PrivateBathRoomNumber = int.Parse(reader["PrivateBathRoomNumber"].ToString());
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
        public List<UniteDetails> GetAll()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from UniteDetails ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<UniteDetails> lst = new List<UniteDetails>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UniteDetails _obj = new UniteDetails();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.UnittypeID = int.Parse(reader["UnittypeID"].ToString());
                    _obj.UniteName = reader["UniteName"].ToString();
                    _obj.SmokingPolicy = bool.Parse(reader["SmokingPolicy"].ToString());
                    _obj.PoolPolicy = bool.Parse(reader["PoolPolicy"].ToString());
                    _obj.Size = reader["Size"].ToString();
                    //
                    _obj.ApartmentNumber = int.Parse(reader["ApartmentNumber"].ToString());
                    _obj.GustNumber = int.Parse(reader["GustNumber"].ToString());
                    _obj.BedRoomNumber = int.Parse(reader["BedRoomNumber"].ToString());
                    _obj.LivingRoomNumber = int.Parse(reader["LivingRoomNumber"].ToString());
                    _obj.BedKind = int.Parse(reader["BedKind"].ToString());
                    _obj.BedNumber = int.Parse(reader["BedNumber"].ToString());
                    _obj.SofaBedNumber = int.Parse(reader["SofaBedNumber"].ToString());
                    _obj.BathroomNumber = int.Parse(reader["BathroomNumber"].ToString());
                    _obj.PrivateBathRoomNumber = int.Parse(reader["PrivateBathRoomNumber"].ToString());
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

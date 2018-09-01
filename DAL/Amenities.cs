using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Connector.DAL
{
    class Amenities
    {
        #region Properts
        public int ID { get; set; }
        public int AmenitiesTypeID { get; set; }
        public string TypeName { get; set; }
        public string AmenitiesName { get; set; }
        public bool Statuis { get; set; }
        #endregion

        public bool AddAmenities()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Add = "INSERT into "
            + "     Amenities "
            + "     ( "
            + "      AmenitiesTypeID "
            + "     ,AmenitiesName "
            + "     ,Statuis "
            + "     ) "
            + "VALUES "
            + "     ( "
            + "     @AmenitiesTypeID "
            + "    ,@AmenitiesName "
            + "    ,@Statuis "
            + "     ) "
            + "";
            SqlCommand cmd = new SqlCommand(Add, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@AmenitiesTypeID", AmenitiesTypeID);
            cmd.Parameters.AddWithValue("@AmenitiesName", AmenitiesName);
            cmd.Parameters.AddWithValue("@Statuis", Statuis);
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
        public bool Delete(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Delete = "Delete from Amenities where ID =@ID";
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
        public bool Update()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Update = "update  Amenities "
            + "      Set     "
            + "     AmenitiesTypeID = @AmenitiesTypeID "
            + "     ,AmenitiesName =@AmenitiesName "
            + "     ,Statuis =@Statuis "
            + "     where "
            + "     ID =@ID ";
            SqlCommand cmd = new SqlCommand(Update, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@AmenitiesTypeID", AmenitiesTypeID);
            cmd.Parameters.AddWithValue("@AmenitiesName", AmenitiesName);
            cmd.Parameters.AddWithValue("@Statuis", Statuis);
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
        public DAL.Amenities GetByID(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectByID = "Select  *  from Amenities  where  ID = @ID ";
            SqlCommand cmd = new SqlCommand(SelectByID, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            Amenities _obj = new Amenities();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.AmenitiesName = reader["AmenitiesName"].ToString();
                    _obj.AmenitiesTypeID = int.Parse(reader["AmenitiesTypeID"].ToString());
                    _obj.Statuis = bool.Parse(reader["Statuis"].ToString());
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
        public List<Amenities> GetAll()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Amenities ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<Amenities> lst = new List<Amenities>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Amenities _obj = new Amenities();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.AmenitiesName = reader["AmenitiesName"].ToString();
                    _obj.AmenitiesTypeID = int.Parse(reader["AmenitiesTypeID"].ToString());
                    _obj.Statuis = bool.Parse(reader["Statuis"].ToString());
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
        public List<Amenities> GetAmenitiesName()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select Amenities.id , AmenitiesType.AmenitiesName as TypeName  , Amenities.AmenitiesName as AmenitiesName   from Amenities join   AmenitiesType   on AmenitiesType.ID = Amenities.AmenitiesTypeID";

            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<Amenities> lst = new List<Amenities>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Amenities _obj = new Amenities();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.TypeName = reader["TypeName"].ToString();
                    _obj.AmenitiesName = reader["AmenitiesName"].ToString();
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
        public List<Amenities> GetAllByAmenitiesTypeID(int _AmenitiesTypeID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Amenities  where AmenitiesTypeID=@AmenitiesTypeID";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            cmd.Parameters.AddWithValue("@AmenitiesTypeID", _AmenitiesTypeID);
            List<Amenities> lst = new List<Amenities>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Amenities _obj = new Amenities();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.AmenitiesName = reader["AmenitiesName"].ToString();
                    _obj.AmenitiesTypeID = int.Parse(reader["AmenitiesTypeID"].ToString());
                    _obj.Statuis = bool.Parse(reader["Statuis"].ToString());
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

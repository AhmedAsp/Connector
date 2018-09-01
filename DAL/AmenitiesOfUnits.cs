using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Connector.DAL
{
    class AmenitiesOfUnits
    {
        #region Properts
        public int ID { get; set; }
        public int UnitID { get; set; }
        public int AmenitiesID { get; set; }
        #endregion

        public bool Add()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Add = "INSERT into "
            + "     AmenitiesOfUnits "
            + "     ( "
            + "      UnitID "
            + "     ,AmenitiesID "
            + "     ) "
            + "VALUES "
            + "     ( "
            + "     @UnitID "
            + "    ,@AmenitiesID "
            + "     ) "
            + "";
            SqlCommand cmd = new SqlCommand(Add, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            cmd.Parameters.AddWithValue("@AmenitiesID", AmenitiesID);
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
        public bool Delete(int _AmenitiesID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Delete = "Delete from AmenitiesOfUnits where  AmenitiesID=@AmenitiesID";
            SqlCommand cmd = new SqlCommand(Delete, Connection);
            cmd.Parameters.Clear();
             cmd.Parameters.AddWithValue("@AmenitiesID", _AmenitiesID);
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
        public bool Delete(int _UnitID, int _AmenitiesID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Delete = "Delete from AmenitiesOfUnits where UnitID =@UnitID and AmenitiesID=@AmenitiesID";
            SqlCommand cmd = new SqlCommand(Delete, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UnitID", _UnitID);
            cmd.Parameters.AddWithValue("@AmenitiesID", _AmenitiesID);
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
            string Update = "update  AmenitiesOfUnits "
            + "      Set     "
            + "     UnitID = @UnitID "
            + "    ,AmenitiesID = @AmenitiesID"
            + "     where "
            + "     ID =@ID ";
            SqlCommand cmd = new SqlCommand(Update, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@UnitID", UnitID);
            cmd.Parameters.AddWithValue("@AmenitiesID", AmenitiesID);
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
        public DAL.AmenitiesOfUnits GetByID(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectByID = "Select  *  from AmenitiesOfUnits  where  ID = @ID ";
            SqlCommand cmd = new SqlCommand(SelectByID, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            AmenitiesOfUnits _obj = new AmenitiesOfUnits();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.UnitID = int.Parse(reader["UnitID"].ToString());
                    _obj.AmenitiesID = int.Parse(reader["AmenitiesID"].ToString());

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
        public List<AmenitiesOfUnits> GetAll()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from AmenitiesOfUnits ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<AmenitiesOfUnits> lst = new List<AmenitiesOfUnits>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AmenitiesOfUnits _obj = new AmenitiesOfUnits();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.UnitID = int.Parse(reader["UnitID"].ToString());
                    _obj.AmenitiesID = int.Parse(reader["AmenitiesID"].ToString());
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
        public List<AmenitiesOfUnits> GetAllByAmenitiesID(int _AmenitiesID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from AmenitiesOfUnits  where AmenitiesID = @AmenitiesID ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            cmd.Parameters.AddWithValue("@AmenitiesID", _AmenitiesID);
            List<AmenitiesOfUnits> lst = new List<AmenitiesOfUnits>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AmenitiesOfUnits _obj = new AmenitiesOfUnits();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.UnitID = int.Parse(reader["UnitID"].ToString());
                    _obj.AmenitiesID = int.Parse(reader["AmenitiesID"].ToString());
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
        public DAL.AmenitiesOfUnits GetByUnitIDandAmenitiesID(int _UnitID, int _AmenitiesID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectByID = "Select  *  from AmenitiesOfUnits  where UnitID =@UnitID and AmenitiesID=@AmenitiesID ";
            SqlCommand cmd = new SqlCommand(SelectByID, Connection);
            cmd.Parameters.AddWithValue("@UnitID", _UnitID);
            cmd.Parameters.AddWithValue("@AmenitiesID", _AmenitiesID);
            AmenitiesOfUnits _obj = new AmenitiesOfUnits();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.UnitID = int.Parse(reader["UnitID"].ToString());
                    _obj.AmenitiesID = int.Parse(reader["AmenitiesID"].ToString());

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Connector.DAL
{
    class AmenitiesType
    {
        #region Properts
        public int ID { get; set; }
        public string Name { get; set; }
        #endregion

        public bool AddFacilities()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Add = "INSERT into "
            + "     AmenitiesType "
            + "     ( "
            + "      Name "
            + "     ) "
            + "VALUES "
            + "     ( "
             + "     @Name "
            + "     ) "
            + "";
            SqlCommand cmd = new SqlCommand(Add, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Name", Name);
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
            string Delete = "Delete from AmenitiesType where ID =@ID";
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
            string Update = "update  AmenitiesType "
            + "      Set     "
             + "     Name =@Name "
            + "     where "
            + "     ID =@ID ";
            SqlCommand cmd = new SqlCommand(Update, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
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
        public DAL.AmenitiesType GetByID(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectByID = "Select  *  from AmenitiesType  where  ID = @ID ";
            SqlCommand cmd = new SqlCommand(SelectByID, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            AmenitiesType _obj = new AmenitiesType();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.Name = reader["Name"].ToString();
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
        public List<AmenitiesType> GetAll()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from AmenitiesType ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<AmenitiesType> lst = new List<AmenitiesType>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AmenitiesType _obj = new AmenitiesType();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.Name = reader["AmenitiesName"].ToString();
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

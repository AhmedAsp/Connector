using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Connector.DAL
{
    class Facilities
    {
        #region Properts
        public int ID { get; set; }
        public int FacilitiesTypeID { get; set; }
        public string FacilitiesType { get; set; }
        public string FacilitiesName { get; set; }
        public bool Statuis { get; set; }
        #endregion

        public bool AddFacilities()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Add = "INSERT into "
            + "     Facilities "
            + "     ( "
            + "      FacilitiesTypeID "
            + "     ,FacilitiesName "
            + "     ,Statuis "
            + "     ) "
            + "VALUES "
            + "     ( "
            + "     @FacilitiesTypeID "
            + "    ,@FacilitiesName "
            + "    ,@Statuis "
            + "     ) "
            + "";
            SqlCommand cmd = new SqlCommand(Add, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@FacilitiesTypeID", FacilitiesTypeID);
            cmd.Parameters.AddWithValue("@FacilitiesName", FacilitiesName);
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
        public bool Delete(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Delete = "Delete from Facilities where ID =@ID";
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
            string Update = "update  Facilities "
            + "      Set     "
            + "     FacilitiesTypeID = @FacilitiesTypeID "
            + "     ,FacilitiesName =@FacilitiesName "
            + "     ,Statuis =@Statuis "
            + "     where "
            + "     ID =@ID ";
            SqlCommand cmd = new SqlCommand(Update, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@FacilitiesTypeID", FacilitiesTypeID);
            cmd.Parameters.AddWithValue("@FacilitiesName", FacilitiesName);
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
        public DAL.Facilities GetByID(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectByID = "Select  *  from Facilities  where  ID = @ID ";
            SqlCommand cmd = new SqlCommand(SelectByID, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            Facilities _obj = new Facilities();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FacilitiesName = reader["FacilitiesName"].ToString();
                    _obj.FacilitiesTypeID = int.Parse(reader["FacilitiesTypeID"].ToString());
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
        public List<Facilities> GetAll()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Facilities ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<Facilities> lst = new List<Facilities>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Facilities _obj = new Facilities();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FacilitiesName = reader["FacilitiesName"].ToString();
                    _obj.FacilitiesTypeID = int.Parse(reader["FacilitiesTypeID"].ToString());
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
        public List<Facilities> GetFacilitiesName()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select Facilities.id , FacilitiesType.Name as TypeName  , Facilities.FacilitiesName as FacilitiesName   from Facilities join   Facilitiestype   on FacilitiesType.ID = Facilities.FacilitiesTypeID";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<Facilities> lst = new List<Facilities>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Facilities _obj = new Facilities();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FacilitiesType = reader["TypeName"].ToString();
                    _obj.FacilitiesName = reader["FacilitiesName"].ToString();
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
        public List<Facilities> GetAllByFacilitiesTypeID(int _FacilitiesTypeID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Facilities  where FacilitiesTypeID=@FacilitiesTypeID";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            cmd.Parameters.AddWithValue("@FacilitiesTypeID", _FacilitiesTypeID);
            List<Facilities> lst = new List<Facilities>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Facilities _obj = new Facilities();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FacilitiesName = reader["FacilitiesName"].ToString();
                    _obj.FacilitiesTypeID = int.Parse(reader["FacilitiesTypeID"].ToString());
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

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.DAL
{
    class Unites
    {
        #region Properts
        public int ID { get; set; }
        public int UnitTypeID { get; set; }
        public string TypeName { get; set; }
        public int FloorID { get; set; }
        public string UnitName { get; set; }
        public int StatusID { get; set; }
        public string StatusReason { get; set; }

        #endregion

        public bool Add()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Add = "INSERT into "
            + "     Unites "
            + "     ( "
            + "        UnitTypeID "
            + "       ,FloorID "
            + "       ,UnitName "
            + "       ,StatusID "
            + "       ,StatusReason "
            + "     ) "
            + "VALUES "
            + "     ( "
            + "        @UnitTypeID "
            + "       ,@FloorID "
            + "       ,@UnitName "
            + "       ,@StatusID "
            + "       ,@StatusReason "
            + "     ) "
            + "";
            SqlCommand cmd = new SqlCommand(Add, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UnitTypeID", UnitTypeID);
            cmd.Parameters.AddWithValue("@FloorID", FloorID);
            cmd.Parameters.AddWithValue("@UnitName", UnitName);
            cmd.Parameters.AddWithValue("@StatusID", StatusID);
            cmd.Parameters.AddWithValue("@StatusReason", StatusReason);
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
            string Update = "update  Unites "
            + "      Set     "
            + "      UnitTypeID =@UnitTypeID "
            + "     ,FloorID =@FloorID "
            + "     ,UnitName =@UnitName "
            + "     ,StatusID =@StatusID "
            + "     ,StatusReason =@StatusReason "
            + "     where "
            + "     ID =@ID ";
            SqlCommand cmd = new SqlCommand(Update, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@UnitTypeID", UnitTypeID);
            cmd.Parameters.AddWithValue("@FloorID", FloorID);
            cmd.Parameters.AddWithValue("@UnitName", UnitName);
            cmd.Parameters.AddWithValue("@StatusID", StatusID);
            cmd.Parameters.AddWithValue("@StatusReason", StatusReason);
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
            string Delete = "Delete from Unites where ID=@ID ";
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
        public DAL.Unites GetByID(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectByID = "Select  *  from Unites  where  ID = @ID ";
            SqlCommand cmd = new SqlCommand(SelectByID, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            Unites _obj = new Unites();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.UnitTypeID = int.Parse(reader["UnitTypeID"].ToString());
                    _obj.FloorID = int.Parse(reader["FloorID"].ToString());
                    _obj.StatusID = int.Parse(reader["StatusID"].ToString());
                    _obj.UnitName = reader["UnitName"].ToString();
                    _obj.StatusReason = reader["StatusReason"].ToString();

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
        public List<Unites> GetAll()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Unites   ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<Unites> lst = new List<Unites>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Unites _obj = new Unites();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.UnitTypeID = int.Parse(reader["UnitTypeID"].ToString());
                    _obj.FloorID = int.Parse(reader["FloorID"].ToString());
                    _obj.StatusID = int.Parse(reader["StatusID"].ToString());
                    _obj.UnitName = reader["UnitName"].ToString();
                    _obj.StatusReason = reader["StatusReason"].ToString();
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
        public List<Unites> GetByFloorID(int _FloorID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Unites  where  FloorID = @FloorID ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            cmd.Parameters.AddWithValue("@FloorID", _FloorID);
            List<Unites> lst = new List<Unites>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Unites _obj = new Unites();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.UnitTypeID = int.Parse(reader["UnitTypeID"].ToString());
                    _obj.FloorID = int.Parse(reader["FloorID"].ToString());
                    _obj.StatusID = int.Parse(reader["StatusID"].ToString());
                    _obj.UnitName = reader["UnitName"].ToString();
                    _obj.StatusReason = reader["StatusReason"].ToString();
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
        public List<Unites> GetUnitName()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select Unites.id , UniteType.UniteName as TypeName  , Unites.UnitName as UnitName ";
            SelectAll += "  from Unites join   UniteType   on UniteType.ID = Unites.UnitTypeID ";

            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<Unites> lst = new List<Unites>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Unites _obj = new Unites();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.TypeName = reader["TypeName"].ToString();
                    _obj.UnitName = reader["UnitName"].ToString();
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

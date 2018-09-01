using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.DAL
{
    class Floors
    {
        #region Properts
        public int ID { get; set; }
        public string FloorName { get; set; }
        #endregion

        public bool Add()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Add = "INSERT into "
            + "     Floors "
            + "     ( "
            + "       FloorName "
            + "     ) "
            + "VALUES "
            + "     ( "
             + "      @FloorName "
            + "     ) "
            + "";
            SqlCommand cmd = new SqlCommand(Add, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@FloorName", FloorName);
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
            string Update = "update  Floors "
            + "      Set     "
            + "     FloorName =@FloorName "
            + "     where "
            + "     ID =@ID ";
            SqlCommand cmd = new SqlCommand(Update, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@FloorName", FloorName);
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
            string Delete = "Delete from Floors where ID=@ID ";
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
        public DAL.Floors GetByID(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectByID = "Select  *  from Floors  where  ID = @ID ";
            SqlCommand cmd = new SqlCommand(SelectByID, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            Floors _obj = new Floors();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FloorName =  reader["FloorName"].ToString();

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
        public DAL.Floors GetByName(string ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectByID = "Select  *  from Floors  where  ID = @ID ";
            SqlCommand cmd = new SqlCommand(SelectByID, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            Floors _obj = new Floors();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FloorName = reader["FloorName"].ToString();

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
        public List<Floors> GetAll()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Floors   ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<Floors> lst = new List<Floors>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Floors _obj = new Floors();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FloorName = reader["FloorName"].ToString();
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

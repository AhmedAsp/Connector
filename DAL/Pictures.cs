using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.DAL
{
    class Pictures
    {
        #region Properts
        public int ID { get; set; }
        public System.Drawing.Image Image { set; get; }
        public int UniteID { get; set; }
        #endregion

        public bool Add()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Add = "INSERT into "
            + "     Pictures "
            + "     ( "
            + "      Image "
            + "      ,UniteID "
            + "     ) "
            + "VALUES "
            + "     ( "
             + "     @Image "
             + "      ,@UniteID "
            + "     ) "
            + "";
            SqlCommand cmd = new SqlCommand(Add, Connection);
            cmd.Parameters.Clear();
            //
            System.IO.MemoryStream Mem = new System.IO.MemoryStream();
            Image.Save(Mem, System.Drawing.Imaging.ImageFormat.Png);
            byte[] Data = new byte[Mem.Length];
            Data = Mem.ToArray();
            //
            cmd.Parameters.AddWithValue("@Image", Data);
             cmd.Parameters.AddWithValue("@UniteID", UniteID);
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
            string Update = "update  Pictures "
            + "      Set     "
            + "     Image =@Image "
            + "     ,UniteID =@UniteID "
            + "     where "
            + "     ID =@ID ";
            SqlCommand cmd = new SqlCommand(Update, Connection);
            cmd.Parameters.Clear();
            //
            System.IO.MemoryStream Mem = new System.IO.MemoryStream();
            Image.Save(Mem, System.Drawing.Imaging.ImageFormat.Png);
            byte[] Data = new byte[Mem.Length];
            Data = Mem.ToArray();
            //
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Image", Data);
            cmd.Parameters.AddWithValue("@UniteID", UniteID);
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
            string Delete = "Delete from Pictures where UniteID=@UniteID ";
            SqlCommand cmd = new SqlCommand(Delete, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UniteID", ID  );
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
        public List<Pictures> GetImageByUnitID(int _UniteID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Pictures where UniteID=@UniteID ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            cmd.Parameters.AddWithValue("@UniteID", _UniteID);
            List<Pictures> lst = new List<Pictures>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pictures _obj = new Pictures();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.UniteID = int.Parse(reader["UniteID"].ToString());
                    byte[] ImgBytes = (byte[])reader["Image"]; 
                    System.IO.MemoryStream Ms = new System.IO.MemoryStream(ImgBytes);
                    _obj.Image = System.Drawing.Image.FromStream(Ms);

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

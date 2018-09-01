using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.DAL
{
    class Users
    {
        #region Properties
        public int num { set; get; }
        public string name { set; get; }
        public string pw1 { set; get; }
        #endregion Properties

        public Users GetByUserID(int UserID)
        {
            SqlConnection con = DBGate.GetConnection();
            string Get = "select * from file3  where num =  @num";
            SqlCommand cmd = new SqlCommand(Get, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num", UserID);
            Users _obj = new Users();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.num = int.Parse(reader["num"].ToString());
                    _obj.name = reader["name"].ToString();
                    _obj.pw1 = reader["pw1"].ToString();
                 }
            }
            catch (SqlException ex)
            {
                frmDone frmerror = new frmDone(ex.ToString());
                frmerror.ShowDialog();
             }
            finally
            {
                con.Close();
            }
            return _obj;
        }
    }

}

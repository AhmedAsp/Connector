using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector
{
    class htl011
    {
        #region Properties
        public int ProductID { set; get; }
        public string ProductName { set; get; }
        public double Price { set; get; }
         #endregion Properties

       
        public List<htl011> getall()
        {
            SqlConnection con = Gate.GetConnectionFront();
            string Get = "  select * from htl011   ";
            SqlCommand cmd = new SqlCommand(Get, con);
             List<htl011> lst = new List<htl011>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    htl011 _obj = new htl011();
                    _obj.ProductID = int.Parse(reader["ords"].ToString()); // bookid
                    _obj.ProductName = reader["roomtype"].ToString();
                    _obj.Price = int.Parse(reader["Price"].ToString());
                     lst.Add(_obj);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return lst;

         }
 
    }
}

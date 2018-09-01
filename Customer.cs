using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Connector
{
    public class Customer
    {

        #region Propertis
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationalty { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        public string City { get; set; }
        public string VisteResion { get; set; }
        public string HowKnowUs { get; set; }

         public DateTime DateOfBirth { get; set; }
        public string Jop { get; set; }
        //
        //public int GroupID { get; set; }
        public string CustomerType { get; set; }
        #endregion
        public void Add()
        {
            SqlConnection con = Gate.GetConnectionRemot();
            string Add = "insert into Customers ( FirstName ,LastName  ,  Nationalty , Mobile , Email  , Gender  ,  CustomerType , DateOfBirth , Jop , City , VisteResion , HowKnowUs  )";
            Add += " Values ( @FirstName , @LastName  ,  @Nationalty , @Mobile , @Email  , @Gender  , @CustomerType , @DateOfBirth , @Jop , @City , @VisteResion , @HowKnowUs )"; 
            SqlCommand cmd = new SqlCommand(Add, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Nationalty", Nationalty);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);

            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@CustomerType", CustomerType);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Jop", Jop);

            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@VisteResion", VisteResion);
            cmd.Parameters.AddWithValue("@HowKnowUs", HowKnowUs);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }
        public List<Customer> GetAll()
        {
            SqlConnection con = Gate.GetConnectionRemot();
            string Get = "Select * from Customers ";
            SqlCommand cmd = new SqlCommand(Get, con);
            List<Customer> lst = new List<Customer>();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer _obj = new Customer();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FirstName = reader["FirstName"].ToString();
                    _obj.LastName = reader["LastName"].ToString();

                    _obj.Nationalty = reader["Nationalty"].ToString();
                    _obj.Mobile = reader["Mobile"].ToString();
                    _obj.Email = reader["Email"].ToString();
                    _obj.Gender = reader["Gender"].ToString();

                    _obj.Jop = reader["Jop"].ToString();
                    
                   
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
        public Customer GetByEmail(string Email)
        {
            SqlConnection con = Gate.GetConnectionRemot();
            string Get = "Select * from Customers where  Email=@Email  ";
            SqlCommand cmd = new SqlCommand(Get, con);
            cmd.Parameters.AddWithValue("@Email", Email);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Customer _obj = new Customer();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FirstName = reader["FirstName"].ToString();
                    _obj.LastName = reader["LastName"].ToString();
                    _obj.Email = reader["Email"].ToString();
                    _obj.Mobile = reader["Mobile"].ToString();
                }
                return _obj;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        public Customer GetByMobileOrEmail(string Mobile, string Email)
        {
            SqlConnection con = Gate.GetConnectionRemot();
            string Get = "Select * from Customers where  Mobile=@Mobile or  Email =@Email ";
            SqlCommand cmd = new SqlCommand(Get, con);
            cmd.Parameters.AddWithValue("@Mobile", Mobile);
            cmd.Parameters.AddWithValue("@Email", Email);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Customer _obj = new Customer();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.FirstName = reader["FirstName"].ToString();
                    _obj.LastName = reader["LastName"].ToString();
                    _obj.Email = reader["Email"].ToString();
                    _obj.Mobile = reader["Mobile"].ToString();
                }
                return _obj;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Connector
{
    public class Products
    {
        #region Properts
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public string Keywords { get; set; }
        public int Availability { get; set; }
        public bool IsShipEnabled { get; set; }
        public bool IsFreeShipping { get; set; }
        public bool DeliveryDateID { get; set; }
        public bool ShippingCharge { get; set; }
        public int TaxCategoryID { get; set; }
        public float Price { get; set; }
        public float ProductCost { get; set; }
        public bool New { get; set; }
        public bool Used { get; set; }
        public bool Actived { get; set; }
        #endregion

        public bool Add()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Add = " insert into Products  (Name  , Description , CategoryID ,Keywords , Availability " ;
            Add += " , IsShipEnabled  , IsFreeShipping , DeliveryDateID ,ShippingCharge , TaxCategoryID ";
            Add += " , Price  , ProductCost , New , Used , Actived ) ";

            Add += "Values (@Name  ,@Description , @CategoryID  , @Keywords , @Availability  ,@IsShipEnabled ";
            Add += " , @IsFreeShipping  , @DeliveryDateID , @ShippingCharge  ,@TaxCategoryID  ";
            Add += " , @Price  , @ProductCost , @New  ,@Used ,@Actived ) ";
          
            SqlCommand cmd = new SqlCommand(Add, Connection);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Name ", Name);
            cmd.Parameters.AddWithValue("@Description ", Description);
            cmd.Parameters.AddWithValue("@CategoryID ", CategoryID);
            cmd.Parameters.AddWithValue("@Keywords ", Keywords);
            cmd.Parameters.AddWithValue("@Availability ", Availability);
            cmd.Parameters.AddWithValue("@IsShipEnabled ", IsShipEnabled);
            cmd.Parameters.AddWithValue("@IsFreeShipping ", IsFreeShipping);
            cmd.Parameters.AddWithValue("@DeliveryDateID ", DeliveryDateID);
            cmd.Parameters.AddWithValue("@ShippingCharge ", ShippingCharge);
            cmd.Parameters.AddWithValue("@TaxCategoryID ", TaxCategoryID);
            cmd.Parameters.AddWithValue("@Price ", Price);
            cmd.Parameters.AddWithValue("@ProductCost ", ProductCost);
            cmd.Parameters.AddWithValue("@New ", New);
            cmd.Parameters.AddWithValue("@Used ", Used);
            cmd.Parameters.AddWithValue("@Actived ", Actived);

            try
            {
                Connection.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connection.Close(); }

        }

        public bool Update()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Update = " Update Products Set   Name = @Name ,Description=@Description , CategoryID= @CategoryID , Keywords=@Keywords ,Availability=@Availability ";
            Update += " , IsShipEnabled=@IsShipEnabled , IsFreeShipping=@IsFreeShipping , DeliveryDateID=@DeliveryDateID , ShippingCharge=@ShippingCharge ";
            Update += " , TaxCategoryID=@TaxCategoryID , Price=@Price , ProductCost=@ProductCost , New=@New , Used=@Used , Actived=@Actived  ";
            Update += " where ID=@ID";
            SqlCommand cmd = new SqlCommand(Update, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
            cmd.Parameters.AddWithValue("@Keywords", Keywords);
            cmd.Parameters.AddWithValue("@Availability", Availability);
            cmd.Parameters.AddWithValue("@IsShipEnabled", IsShipEnabled);
            cmd.Parameters.AddWithValue("@IsFreeShipping", IsFreeShipping);
            cmd.Parameters.AddWithValue("@DeliveryDateID", DeliveryDateID);
            cmd.Parameters.AddWithValue("@ShippingCharge", ShippingCharge);
            cmd.Parameters.AddWithValue("@TaxCategoryID", TaxCategoryID);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@ProductCost", ProductCost);
            cmd.Parameters.AddWithValue("@New", New);
            cmd.Parameters.AddWithValue("@Used", Used);
            cmd.Parameters.AddWithValue("@Actived", Actived);

            try
            {
                Connection.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connection.Close(); }

        }

        public bool Delete(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string Delete = " Delete from Products  where ID = @ID";
            SqlCommand cmd = new SqlCommand(Delete, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
            try
            {
                Connection.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                    return false;
            }

            catch (SqlException)
            {

                throw;
            }
            finally { Connection.Close(); }
        }

        public  Products SelecteByID(int ID)
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelecteAll = " select * from Products where ID=@ID ";
            SqlCommand cmd = new SqlCommand(SelecteAll, Connection);
            cmd.Parameters.AddWithValue("@ID", ID);
             Products _obj = new  Products();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.Name = reader["Name"].ToString();
                    _obj.Description = reader["Description"].ToString();
                    _obj.CategoryID = int.Parse(reader["CategoryID"].ToString());
                    _obj.Keywords = reader["Keywords"].ToString();
                    _obj.Availability = int.Parse(reader["Availability"].ToString());
                    _obj.IsShipEnabled = bool.Parse(reader["IsShipEnabled"].ToString());
                    _obj.IsFreeShipping = bool.Parse(reader["IsFreeShipping"].ToString());
                    _obj.DeliveryDateID = bool.Parse(reader["DeliveryDateID"].ToString());
                    _obj.ShippingCharge = bool.Parse(reader["ShippingCharge"].ToString());
                    _obj.TaxCategoryID = int.Parse(reader["TaxCategoryID"].ToString());
                    _obj.Price = float.Parse(reader["Price"].ToString());
                    _obj.ProductCost = float.Parse(reader["ProductCost"].ToString());
                    _obj.New = bool.Parse(reader["New"].ToString());
                    _obj.Used = bool.Parse(reader["Used"].ToString());
                    _obj.Actived = bool.Parse(reader["Actived"].ToString());
                   
                }
            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connection.Close(); }
            return _obj;
        }

        public DataTable SelecteAll()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelecteAll = " select * from Products ";
            SqlCommand cmd = new SqlCommand(SelecteAll, Connection);
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                    return dt;
                }
            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connection.Close(); }
            return dt;
        }

        public List<Products> GetAll()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Products ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<Products> lst = new List<Products>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Products _obj = new Products();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.Name = reader["Name"].ToString();
                    _obj.Description = reader["Description"].ToString();
                    _obj.CategoryID = int.Parse(reader["CategoryID"].ToString());
                    _obj.Keywords = reader["Keywords"].ToString();
                    _obj.Availability = int.Parse(reader["Availability"].ToString());
                    _obj.IsShipEnabled = bool.Parse(reader["IsShipEnabled"].ToString());
                    _obj.IsFreeShipping = bool.Parse(reader["IsFreeShipping"].ToString());
                    _obj.DeliveryDateID = bool.Parse(reader["DeliveryDateID"].ToString());
                    _obj.ShippingCharge = bool.Parse(reader["ShippingCharge"].ToString());
                    _obj.TaxCategoryID = int.Parse(reader["TaxCategoryID"].ToString());
                    _obj.Price = float.Parse(reader["Price"].ToString());
                    _obj.ProductCost = float.Parse(reader["ProductCost"].ToString());
                    _obj.New = bool.Parse(reader["New"].ToString());
                    _obj.Used = bool.Parse(reader["Used"].ToString());
                    _obj.Actived = bool.Parse(reader["Actived"].ToString());
                    lst.Add(_obj);
                }
            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connection.Close(); }
            return lst;
        }
        public List<Products> testGetAll()
        {
            SqlConnection Connection = DBGate.GetConnection();
            string SelectAll = " select * from Products ";
            SqlCommand cmd = new SqlCommand(SelectAll, Connection);
            List<Products> lst = new List<Products>();
            try
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Products _obj = new Products();
                    _obj.ID = int.Parse(reader["ID"].ToString());
                    _obj.Name = reader["Name"].ToString();
                    _obj.Description = reader["Description"].ToString();
                    _obj.Availability = int.Parse(reader["Availability"].ToString());
                    _obj.Price = float.Parse(reader["Price"].ToString());
                    lst.Add(_obj);
                }
            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connection.Close(); }
            return lst;
        }

    }
}
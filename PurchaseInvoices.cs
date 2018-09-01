using Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C2D.DAL
{
    public class PurchaseInvoices
    {

        #region Variables
        DBGate Gate = new DBGate();
        #endregion Variables
        #region Properties
        public int ID { set; get; }
        public int CustomerID { set; get; }
        public DateTime Date { set; get; }
        public float AmountValue { set; get; }
        public float Discount { set; get; }
        public float Tax { set; get; }
        public float Total { set; get; }
        public string PaidType { set; get; }
        public string Notes { set; get; }
        #endregion Properties
        protected void Update()
        {
            Gate.Command.CommandText = "update PurchaseInvoices set ";
            if (CustomerID != null)
            {
                Gate.Command.CommandText += "CustomerID = @CustomerID,";
            }

            if (Date != null)
            {
                Gate.Command.CommandText += "Date = @Date,";
            }

            if (AmountValue != null)
            {
                Gate.Command.CommandText += "AmountValue = @AmountValue,";
            }

            if (Discount != null)
            {
                Gate.Command.CommandText += "Discount = @Discount,";
            }

            if (Tax != null)
            {
                Gate.Command.CommandText += "Tax = @Tax,";
            }

            if (Total != null)
            {
                Gate.Command.CommandText += "Total = @Total,";
            }

            if (PaidType != null)
            {
                Gate.Command.CommandText += "PaidType = @PaidType,";
            }

            if (Notes != null)
            {
                Gate.Command.CommandText += "Notes = @Notes ";
            }

            Gate.Command.CommandText += " where ID = @ID";
            Gate.Command.Parameters.Clear();
            if (CustomerID != null)
            {

                Gate.Command.Parameters.AddWithValue("@CustomerID", CustomerID);
            }

            if (Date != null)
            {

                Gate.Command.Parameters.AddWithValue("@Date", Date);
            }

            if (AmountValue != null)
            {

                Gate.Command.Parameters.AddWithValue("@AmountValue", AmountValue);
            }

            if (Discount != null)
            {

                Gate.Command.Parameters.AddWithValue("@Discount", Discount);
            }

            if (Tax != null)
            {

                Gate.Command.Parameters.AddWithValue("@Tax", Tax);
            }

            if (Total != null)
            {

                Gate.Command.Parameters.AddWithValue("@Total", Total);
            }

            if (PaidType != null)
            {

                Gate.Command.Parameters.AddWithValue("@PaidType", PaidType);
            }

            if (Notes != null)
            {

                Gate.Command.Parameters.AddWithValue("@Notes", Notes);
            }

            Gate.Command.Parameters.AddWithValue("@ID", ID);
            Gate.Execute();
            Gate.Close();
        }

        protected void Insert()
        {
            Gate.Command.CommandText = "Insert Into PurchaseInvoices (";

            if (CustomerID != null)
            {
                Gate.Command.CommandText += "CustomerID,";
            }

            if (Date != null)
            {
                Gate.Command.CommandText += "Date,";
            }

            if (AmountValue != null)
            {
                Gate.Command.CommandText += "AmountValue,";
            }

            if (Discount != null)
            {
                Gate.Command.CommandText += "Discount,";
            }

            if (Tax != null)
            {
                Gate.Command.CommandText += "Tax,";
            }

            if (Total != null)
            {
                Gate.Command.CommandText += "Total,";
            }

            if (PaidType != null)
            {
                Gate.Command.CommandText += "PaidType,";
            }

            if (Notes != null)
            {
                Gate.Command.CommandText += "Notes";
            }

            Gate.Command.CommandText += " ) values (";
            if (CustomerID != null)
            {
                Gate.Command.CommandText += "@CustomerID,";
            }

            if (Date != null)
            {
                Gate.Command.CommandText += "@Date,";
            }

            if (AmountValue != null)
            {
                Gate.Command.CommandText += "@AmountValue,";
            }

            if (Discount != null)
            {
                Gate.Command.CommandText += "@Discount,";
            }

            if (Tax != null)
            {
                Gate.Command.CommandText += "@Tax,";
            }

            if (Total != null)
            {
                Gate.Command.CommandText += "@Total,";
            }

            if (PaidType != null)
            {
                Gate.Command.CommandText += "@PaidType,";
            }

            if (Notes != null)
            {
                Gate.Command.CommandText += "@Notes)";
            }

            Gate.Command.Parameters.Clear();
            if (CustomerID != null)
            {

                Gate.Command.Parameters.AddWithValue("@CustomerID", CustomerID);
            }

            if (Date != null)
            {

                Gate.Command.Parameters.AddWithValue("@Date", Date);
            }

            if (AmountValue != null)
            {

                Gate.Command.Parameters.AddWithValue("@AmountValue", AmountValue);
            }

            if (Discount != null)
            {

                Gate.Command.Parameters.AddWithValue("@Discount", Discount);
            }

            if (Tax != null)
            {

                Gate.Command.Parameters.AddWithValue("@Tax", Tax);
            }

            if (Total != null)
            {

                Gate.Command.Parameters.AddWithValue("@Total", Total);
            }

            if (PaidType != null)
            {

                Gate.Command.Parameters.AddWithValue("@PaidType", PaidType);
            }

            if (Notes != null)
            {

                Gate.Command.Parameters.AddWithValue("@Notes", Notes);
            }

            Gate.Execute();
            Gate.Close();
        }
        protected void Delete()
        {
            Gate.Command.CommandText = "Delete from PurchaseInvoices where ID = @ID";
            Gate.Command.Parameters.Clear();
            Gate.Command.Parameters.AddWithValue("@ID", ID);
            Gate.Execute();
            Gate.Close();
        }
        protected List<PurchaseInvoices> GetAll()
        {
            Gate.Command.CommandText = "select * from PurchaseInvoices";
            Gate.Command.Parameters.Clear();
            System.Data.SqlClient.SqlDataReader Reader = Gate.Execute();
            List<PurchaseInvoices> List = new List<PurchaseInvoices>();
            while (Reader != null && Reader.Read())
            {
                PurchaseInvoices NewObj = new PurchaseInvoices();
                if (Reader["ID"] != null)
                {
                    NewObj.ID = int.Parse(Reader["ID"].ToString());
                }
                if (Reader["CustomerID"] != null)
                {
                    NewObj.CustomerID = int.Parse(Reader["CustomerID"].ToString());
                }
                if (Reader["Date"] != null)
                {
                    NewObj.Date = (DateTime)Reader["Date"];
                }
                if (Reader["AmountValue"] != null)
                {
                    NewObj.AmountValue = float.Parse(Reader["AmountValue"].ToString());
                }
                if (Reader["Discount"] != null)
                {
                    NewObj.Discount = float.Parse(Reader["Discount"].ToString());
                }
                if (Reader["Tax"] != null)
                {
                    NewObj.Tax = float.Parse(Reader["Tax"].ToString());
                }
                if (Reader["Total"] != null)
                {
                    NewObj.Total = float.Parse(Reader["Total"].ToString());
                }
                if (Reader["PaidType"] != null)
                {
                    NewObj.PaidType = Reader["PaidType"].ToString();
                }
                if (Reader["Notes"] != null)
                {
                    NewObj.Notes = Reader["Notes"].ToString();
                }
                List.Add(NewObj);
            };
            Gate.Close();
            return List;
        }
        protected PurchaseInvoices GetByID(int _ID)
        {

            Gate.Command.CommandText = "select * from PurchaseInvoices";
            Gate.Command.CommandText += " Where ID = @ID ";
            Gate.Command.Parameters.Clear();
            Gate.Command.Parameters.AddWithValue("@ID", _ID);
            System.Data.SqlClient.SqlDataReader Reader = Gate.Execute();
            PurchaseInvoices NewObj = new PurchaseInvoices();
            if (Reader != null && Reader.Read())
            {
                if (Reader["ID"] != null)
                {
                    NewObj.ID = int.Parse(Reader["ID"].ToString());
                }
                if (Reader["CustomerID"] != null)
                {
                    NewObj.CustomerID = int.Parse(Reader["CustomerID"].ToString());
                }
                if (Reader["Date"] != null)
                {
                    NewObj.Date = (DateTime)Reader["Date"];
                }
                if (Reader["AmountValue"] != null)
                {
                    NewObj.AmountValue = float.Parse(Reader["AmountValue"].ToString());
                }
                if (Reader["Discount"] != null)
                {
                    NewObj.Discount = float.Parse(Reader["Discount"].ToString());
                }
                if (Reader["Tax"] != null)
                {
                    NewObj.Tax = float.Parse(Reader["Tax"].ToString());
                }
                if (Reader["Total"] != null)
                {
                    NewObj.Total = float.Parse(Reader["Total"].ToString());
                }
                if (Reader["PaidType"] != null)
                {
                    NewObj.PaidType = Reader["PaidType"].ToString();
                }
                if (Reader["Notes"] != null)
                {
                    NewObj.Notes = Reader["Notes"].ToString();
                }
            };
            Gate.Close();
            return NewObj;
        }
    }
}
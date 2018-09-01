using Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connector
{
 public class PurchaseInvoicesDetails
{

#region Variables
DBGate Gate = new DBGate();
#endregion Variables
#region Properties
public int ID {set;get;}
public int pur_invoiceID {set;get;}
public int ProductID {set;get;}
public int QTY {set;get;}
public float BuyPrice {set;get;}
public float SalePrice {set;get;}
public float Tax {set;get;}
public DateTime ExpireDate {set;get;}
public float Total {set;get;}
public float Discount {set;get;}
#endregion Properties
protected void Update()
{
Gate.Command.CommandText = "update PurchaseInvoicesDetails set ";
 if (pur_invoiceID!= null)

 {
Gate.Command.CommandText += "pur_invoiceID = @pur_invoiceID,";
 }

 if (ProductID!= null)

 {
Gate.Command.CommandText += "ProductID = @ProductID,";
 }

 if (QTY!= null)

 {
Gate.Command.CommandText += "QTY = @QTY,";
 }

 if (BuyPrice!= null)

 {
Gate.Command.CommandText += "BuyPrice = @BuyPrice,";
 }

 if (SalePrice!= null)

 {
Gate.Command.CommandText += "SalePrice = @SalePrice,";
 }

 if (Tax!= null)

 {
Gate.Command.CommandText += "Tax = @Tax,";
 }

 if (ExpireDate!= null)

 {
Gate.Command.CommandText += "ExpireDate = @ExpireDate,";
 }

 if (Total!= null)

 {
Gate.Command.CommandText += "Total = @Total,";
 }

 if (Discount!= null)

 {
Gate.Command.CommandText += "Discount = @Discount ";
 }

 Gate.Command.CommandText += " where ID = @ID";
 Gate.Command.Parameters.Clear();
 if (pur_invoiceID!= null)

 {

 Gate.Command.Parameters.AddWithValue("@pur_invoiceID", pur_invoiceID);
 }

 if (ProductID!= null)

 {

 Gate.Command.Parameters.AddWithValue("@ProductID", ProductID);
 }

 if (QTY!= null)

 {

 Gate.Command.Parameters.AddWithValue("@QTY", QTY);
 }

 if (BuyPrice!= null)

 {

 Gate.Command.Parameters.AddWithValue("@BuyPrice", BuyPrice);
 }

 if (SalePrice!= null)

 {

 Gate.Command.Parameters.AddWithValue("@SalePrice", SalePrice);
 }

 if (Tax!= null)

 {

 Gate.Command.Parameters.AddWithValue("@Tax", Tax);
 }

 if (ExpireDate!= null)

 {

 Gate.Command.Parameters.AddWithValue("@ExpireDate", ExpireDate);
 }

 if (Total!= null)

 {

 Gate.Command.Parameters.AddWithValue("@Total", Total);
 }

 if (Discount!= null)

 {

 Gate.Command.Parameters.AddWithValue("@Discount", Discount);
 }

Gate.Command.Parameters.AddWithValue("@ID", ID);
Gate.Execute();
Gate.Close();
}

protected void Insert()
{
Gate.Command.CommandText = "Insert Into PurchaseInvoicesDetails (";

 if (pur_invoiceID!= null)

 {
Gate.Command.CommandText += "pur_invoiceID,";
 }

 if (ProductID!= null)

 {
Gate.Command.CommandText += "ProductID,";
 }

 if (QTY!= null)

 {
Gate.Command.CommandText += "QTY,";
 }

 if (BuyPrice!= null)

 {
Gate.Command.CommandText += "BuyPrice,";
 }

 if (SalePrice!= null)

 {
Gate.Command.CommandText += "SalePrice,";
 }

 if (Tax!= null)

 {
Gate.Command.CommandText += "Tax,";
 }

 if (ExpireDate!= null)

 {
Gate.Command.CommandText += "ExpireDate,";
 }

 if (Total!= null)

 {
Gate.Command.CommandText += "Total,";
 }

 if (Discount!= null)

 {
Gate.Command.CommandText += "Discount";
 }

 Gate.Command.CommandText += " ) values (";
 if (pur_invoiceID!= null)
 {
Gate.Command.CommandText += "@pur_invoiceID,";
 }

 if (ProductID!= null)
 {
Gate.Command.CommandText += "@ProductID,";
 }

 if (QTY!= null)
 {
Gate.Command.CommandText += "@QTY,";
 }

 if (BuyPrice!= null)
 {
Gate.Command.CommandText += "@BuyPrice,";
 }

 if (SalePrice!= null)
 {
Gate.Command.CommandText += "@SalePrice,";
 }

 if (Tax!= null)
 {
Gate.Command.CommandText += "@Tax,";
 }

 if (ExpireDate!= null)
 {
Gate.Command.CommandText += "@ExpireDate,";
 }

 if (Total!= null)
 {
Gate.Command.CommandText += "@Total,";
 }

 if (Discount!= null)
 {
Gate.Command.CommandText += "@Discount)";
 }

Gate.Command.Parameters.Clear();
 if (pur_invoiceID!= null)
 {

Gate.Command.Parameters.AddWithValue("@pur_invoiceID", pur_invoiceID);
 }

 if (ProductID!= null)
 {

Gate.Command.Parameters.AddWithValue("@ProductID", ProductID);
 }

 if (QTY!= null)
 {

Gate.Command.Parameters.AddWithValue("@QTY", QTY);
 }

 if (BuyPrice!= null)
 {

Gate.Command.Parameters.AddWithValue("@BuyPrice", BuyPrice);
 }

 if (SalePrice!= null)
 {

Gate.Command.Parameters.AddWithValue("@SalePrice", SalePrice);
 }

 if (Tax!= null)
 {

Gate.Command.Parameters.AddWithValue("@Tax", Tax);
 }

 if (ExpireDate!= null)
 {

Gate.Command.Parameters.AddWithValue("@ExpireDate", ExpireDate);
 }

 if (Total!= null)
 {

Gate.Command.Parameters.AddWithValue("@Total", Total);
 }

 if (Discount!= null)
 {

Gate.Command.Parameters.AddWithValue("@Discount", Discount);
 }

Gate.Execute();
Gate.Close();}
 protected void Delete()
{
Gate.Command.CommandText = "Delete from PurchaseInvoicesDetails where ID = @ID";
 Gate.Command.Parameters.Clear();
 Gate.Command.Parameters.AddWithValue("@ID", ID);
Gate.Execute();
Gate.Close();}
 protected List<PurchaseInvoicesDetails> GetAll()
{
Gate.Command.CommandText = "select * from PurchaseInvoicesDetails";
 Gate.Command.Parameters.Clear();
 System.Data.SqlClient.SqlDataReader Reader = Gate.Execute();
 List<PurchaseInvoicesDetails> List = new List<PurchaseInvoicesDetails>();
 while (Reader!= null && Reader.Read())
 {
 PurchaseInvoicesDetails NewObj = new PurchaseInvoicesDetails();
 if (Reader["ID"] != null)
{
 NewObj.ID= int.Parse(Reader["ID"].ToString());
}
 if (Reader["pur_invoiceID"] != null)
{
 NewObj.pur_invoiceID= int.Parse(Reader["pur_invoiceID"].ToString());
}
 if (Reader["ProductID"] != null)
{
 NewObj.ProductID= int.Parse(Reader["ProductID"].ToString());
}
 if (Reader["QTY"] != null)
{
 NewObj.QTY= int.Parse(Reader["QTY"].ToString());
}
 if (Reader["BuyPrice"] != null)
{
 NewObj.BuyPrice= float.Parse(Reader["BuyPrice"].ToString());
}
 if (Reader["SalePrice"] != null)
{
 NewObj.SalePrice= float.Parse(Reader["SalePrice"].ToString());
}
 if (Reader["Tax"] != null)
{
 NewObj.Tax= float.Parse(Reader["Tax"].ToString());
}
 if (Reader["ExpireDate"] != null)
{
 NewObj.ExpireDate= (DateTime)Reader["ExpireDate"];
}
 if (Reader["Total"] != null)
{
 NewObj.Total= float.Parse(Reader["Total"].ToString());
}
 if (Reader["Discount"] != null)
{
 NewObj.Discount= float.Parse(Reader["Discount"].ToString());
}
List.Add(NewObj);
 };
Gate.Close();
return List;
}
 protected PurchaseInvoicesDetails GetByID(int _ID)
{

Gate.Command.CommandText = "select * from PurchaseInvoicesDetails";
Gate.Command.CommandText += " Where ID = @ID ";
 Gate.Command.Parameters.Clear();
 Gate.Command.Parameters.AddWithValue("@ID", _ID);
 System.Data.SqlClient.SqlDataReader Reader = Gate.Execute();
 PurchaseInvoicesDetails NewObj = new PurchaseInvoicesDetails();
 if (Reader!= null && Reader.Read())
 {
 if (Reader["ID"] != null)
{
 NewObj.ID= int.Parse(Reader["ID"].ToString());
}
 if (Reader["pur_invoiceID"] != null)
{
 NewObj.pur_invoiceID= int.Parse(Reader["pur_invoiceID"].ToString());
}
 if (Reader["ProductID"] != null)
{
 NewObj.ProductID= int.Parse(Reader["ProductID"].ToString());
}
 if (Reader["QTY"] != null)
{
 NewObj.QTY= int.Parse(Reader["QTY"].ToString());
}
 if (Reader["BuyPrice"] != null)
{
 NewObj.BuyPrice= float.Parse(Reader["BuyPrice"].ToString());
}
 if (Reader["SalePrice"] != null)
{
 NewObj.SalePrice= float.Parse(Reader["SalePrice"].ToString());
}
 if (Reader["Tax"] != null)
{
 NewObj.Tax= float.Parse(Reader["Tax"].ToString());
}
 if (Reader["ExpireDate"] != null)
{
 NewObj.ExpireDate= (DateTime)Reader["ExpireDate"];
}
 if (Reader["Total"] != null)
{
 NewObj.Total= float.Parse(Reader["Total"].ToString());
}
 if (Reader["Discount"] != null)
{
 NewObj.Discount= float.Parse(Reader["Discount"].ToString());
}
 };
Gate.Close();
return NewObj;
}
}
}
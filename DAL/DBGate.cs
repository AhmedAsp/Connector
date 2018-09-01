using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Connector 
{
    public class DBGate
    {
         public static bool LoadPage = false;
         public static string C2DServerName = Properties.Settings.Default.C2DServerName;
         public static string C2DDataBaseName = Properties.Settings.Default.C2DDataBaseName;
         public static string C2DUserName = Properties.Settings.Default.C2DUserName;
         public static string C2DPassword = Properties.Settings.Default.C2DPassword;

         // Remote Db
         //public static string ConnectionString = " Data Source=SERVER ; Initial Catalog = FINAL_DB ; user='ahmed'; password='suiteinn@2015' ;";
         public static string Remot = "Data Source=192.185.11.183; Initial Catalog = suiteinnnet_SuiteInnDB ; User Id=suite_ahmed; Password=ahmed@15; ";
         public static SqlConnection GetConnectionRemot()
         {
             SqlConnection Connection = new SqlConnection(Remot);
             return Connection;
         }

         // Main Connection
         public static string MyString = " Data Source="
             + C2DServerName
             + "; Initial Catalog ="
             + C2DDataBaseName
             + "; user="
             + C2DUserName
             + "; password="
             + C2DPassword
             + " ;";
         public static SqlConnection GetConnection()
         {
             SqlConnection Connection = new SqlConnection(MyString);
             return Connection;
         }

    }
}
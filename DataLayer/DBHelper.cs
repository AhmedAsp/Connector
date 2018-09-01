using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Connector.DataLayer
{
    public class DBHelper
    {
        DBGate Gate = new DBGate();
        public ArrayList GetDatabases()
        {
            ArrayList Result = new ArrayList();
            Gate.Command.CommandText = "EXEC sp_databases";
            SqlDataReader Read = Gate.Execute();
            while (Read != null && Read.Read())
            {
                Result.Add(Read[0].ToString());
            }
            Gate.Close();
            return Result;
        }
        public ArrayList GetTables()
        {
            ArrayList Result = new ArrayList();
            Gate.Command.CommandText = "Select * from sys.Tables";
            SqlDataReader Read =  Gate.Execute();
            while (Read != null && Read.Read())
            {
                Result.Add(Read[0].ToString());
            }
            Gate.Close();
            return Result;
        }
        public ArrayList GetColumnsName(string TableName)
        {
            ArrayList Result = new ArrayList();
            Gate.Command.CommandText = "Select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + TableName + "'";
            SqlDataReader Read = Gate.Execute();
            while (Read != null && Read.Read())
            {
                Result.Add(Read[0].ToString());
            }
            Gate.Close();
            return Result;
        }
        public ArrayList GetUserName(string ServerName)
        {
            ArrayList Result = new ArrayList();
            Gate.Command.CommandText = "Select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + ServerName + "'";
            SqlDataReader Read = Gate.Execute();
            while (Read != null && Read.Read())
            {
                Result.Add(Read[0].ToString());
            }
            Gate.Close();
            return Result;
        }
        public List<Column> GetColumns(string TableName)
        {
            List<Column> Result = new List<Column>();
            Gate.Command.CommandText = "Select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '"+TableName +"'";
            SqlDataReader Read = Gate.Execute();
            while (Read != null && Read.Read())
            {
                Column Col = new Column();
                Col.Name = Read[3].ToString();
                #region GetType
                switch (Read[7].ToString())
                {
                    case "int":
                        Col.Type = "int";
                        break;
                    case "nvarchar":
                        Col.Type = "string";
                        break;
                    case "float":
                        Col.Type = "float";
                        break;
                    case "image":
                        Col.Type = "System.Drawing.Image";
                        break;
                    case "bit":
                        Col.Type = "bool";
                        break;
                    case "date":
                        Col.Type = "DateTime";
                        break;
                    case "time":
                        Col.Type = "TimeSpan";
                        break;
                    default:
                        Col.Type = "object";
                        break;
                }
                #endregion
                if (Col.Name == "ID")
                    Col.IsAutoIncrement = true;
                Result.Add(Col);
            }
            Gate.Close();
            return Result;
        }    }
    public struct Column
    {
        public string Name;
        public string Type;
        public bool IsAutoIncrement;
    }
}

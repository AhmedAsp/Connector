using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace Connector.DataLayer
{
    class DBGate
    {
        string DBPath = "";
        string BaseconnectionString = @"Data Source=$ADD;Initial Catalog=$DB;User Id=$USERNAME;Password=$PASS;";
        string connectionString = @"Data Source=$ADD;Initial Catalog=$DB;User Id=$USERNAME;Password=$PASS;";
        public SqlCommand Command;
        SqlConnection Connection;
        SqlDataReader Reader = null;
        public DBGate()
        {
            connectionString = BaseconnectionString.Replace("$ADD", Properties.Settings.Default.SERVER);
            connectionString = connectionString.Replace("$DB", Properties.Settings.Default.DB);
            connectionString = connectionString.Replace("$USERNAME", Properties.Settings.Default.USERNAME);
            connectionString = connectionString.Replace("$PASS", Properties.Settings.Default.PASSWORD);
            Connection = new SqlConnection(connectionString.Replace("$[path]", DBPath));
            Command = new SqlCommand();
            Command.Connection = Connection;
        }
        public SqlDataReader Execute()
        {
            connectionString = BaseconnectionString.Replace("$ADD", Properties.Settings.Default.SERVER);
            connectionString = connectionString.Replace("$DB", Properties.Settings.Default.DB);
            connectionString = connectionString.Replace("$USERNAME", Properties.Settings.Default.USERNAME);
            connectionString = connectionString.Replace("$PASS", Properties.Settings.Default.PASSWORD);
            Connection.ConnectionString = connectionString;
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
            try
            {
                foreach (System.Data.IDataParameter Pr in Command.Parameters)
                {
                    if (Pr.Value == null)
                    {
                        switch (Pr.DbType)
                        {
                            case DbType.String:
                                Pr.Value = "";
                                break;
                            case DbType.Date:
                                Pr.Value = null;
                                break;
                            case DbType.Decimal:
                                Pr.Value = default(decimal);
                                break;
                            case DbType.Int16:
                                Pr.Value = default(int);
                                break;
                            case DbType.DateTime:
                                Pr.Value = default(DateTime);
                                break;
                        }
                    }
                }
                Reader = Command.ExecuteReader();
            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
            return Reader;
        }
        public void Close()
        {
            if (Reader != null)
            {
                Reader.Close();
                Reader.Dispose();
            }
            if (Connection.State == ConnectionState.Open)
                Connection.Close();

        }
    }
}

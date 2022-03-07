using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Models
{
    public class Connection
    {
        public static string _errMsg;
        public static bool OpenConnection(ref SqlConnection _connection)
        {
            try
            {
                //SetConnectionString();
                if (_connection.State != ConnectionState.Open)
                {
                    _connection = new SqlConnection();

                    _connection.ConnectionString = @"Data Source=192.168.10.34;Initial Catalog=ERP;User ID=sa;Password=sa";
                    //_connection.ConnectionString = @"Data Source=192.168.1.34;Initial Catalog=ERP;User ID=sa;Password=sa";

                    //// _connection.ConnectionString += ";MultipleActiveResultSets=True;connect timeout=300;";

                    _connection.Open();
                }

                return true;
            }
            catch (Exception ex)
            {
                _errMsg = ex.Message;
                String strException = ex.Message;
                return false;
            }
        }

        public static void CloseConnection(ref SqlConnection _connection)
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
            }
            catch (Exception e)
            {
                String str;
                str = e.Message;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    public class DataLayer
    {
        public static string errMsg;

        public static string _errMsg;
        public static bool Open(ref SqlConnection _connection)
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

        public static void Close(ref SqlConnection _connection)
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

        public static DataTable FillDataTable(string pProcedureName, Hashtable pValues)
        {
            DataTable dt = null;
            SqlConnection connection = new SqlConnection();
            SqlCommand sqlCmd = null;

            SqlDataAdapter adapter = null;
            try
            {

                if (OpenConnection(ref connection))
                {
                    sqlCmd = new SqlCommand(pProcedureName, connection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    IDictionaryEnumerator enumerator = pValues.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        sqlCmd.Parameters.AddWithValue(enumerator.Key.ToString(), enumerator.Value);
                    }
                    sqlCmd.CommandTimeout = 300;
                    adapter = new SqlDataAdapter(sqlCmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                //Response.Write(ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                adapter.Dispose();
                CloseConnection(ref connection);
            }
            return dt;
        }
        public static DataTable FillDataTable(string pProcedureName)
        {
            DataTable dt = null;
            SqlConnection connection = new SqlConnection();
            SqlCommand sqlCmd = null;

            SqlDataAdapter adapter = null;
            try
            {

                if (OpenConnection(ref connection))
                {
                    sqlCmd = new SqlCommand(pProcedureName, connection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    //IDictionaryEnumerator enumerator = pValues.GetEnumerator();
                    //while (enumerator.MoveNext())
                    //{
                    //    sqlCmd.Parameters.AddWithValue(enumerator.Key.ToString(), enumerator.Value);
                    //}
                    sqlCmd.CommandTimeout = 300;
                    adapter = new SqlDataAdapter(sqlCmd);
                    dt = new DataTable();
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                //Response.Write(ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                adapter.Dispose();
                CloseConnection(ref connection);
            }
            return dt;
        }

        public static bool OpenConnection(ref SqlConnection connection)
        {
            try
            {
                //SetConnectionString();
                if (connection.State != ConnectionState.Open)
                {
                    connection = new SqlConnection();
                  //  connection.ConnectionString = @"Data Source=192.168.101.48;User ID=sa;password=sa;Initial Catalog=WEBWMCBankDb;MultipleActiveResultSets=True;connect timeout=300;";
                    connection.ConnectionString = @"Data Source=192.168.10.34;User ID=sa;password=sa;Initial Catalog=ERP;MultipleActiveResultSets=True;connect timeout=300;";
                   // connection.ConnectionString = @"Data Source=192.168.1.34;User ID=sa;password=sa;Initial Catalog=ERP;MultipleActiveResultSets=True;connect timeout=300;";

                    //// _connection.ConnectionString += ";MultipleActiveResultSets=True;connect timeout=300;";

                    connection.Open();
                }

                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                String strException = ex.Message;
                return false;
            }
        }

        protected static void CloseConnection(ref SqlConnection connection)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception e)
            {
                String str;
                str = e.Message;
            }
        }
        public static bool Insert(string tableName, Hashtable pValues)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand sqlCmd = null;
            try
            {

                if (OpenConnection(ref connection))
                {

                    string Columns = "", Values = "";

                    IDictionaryEnumerator enumerator = pValues.GetEnumerator();

                    while (enumerator.MoveNext())
                    {
                        Columns += enumerator.Key.ToString() + ",";
                        Values += "'" + enumerator.Value.ToString() + "',";

                    }
                    Columns = Columns.PadLeft(Columns.Length - 1);
                    Values = Values.PadLeft(Values.Length - 1);


                    string insertQuery = "Insert into " + tableName + "(" + Columns + ") Values (" + Values + ")";

                    sqlCmd = new SqlCommand(insertQuery, connection);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandTimeout = 300;

                    sqlCmd.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
            catch (SqlException sx)
            {
                // SetMessage(sx);
                return false;
            }

            catch (Exception ex)
            {


                errMsg = ex.Message;
                return false;
            }
            finally
            {
                sqlCmd.Dispose();
                CloseConnection(ref connection);
            }
        }


        public static bool ExecuteTransact(string[] pProcedureName, Hashtable[] pValues, DataTable TableList)
        {
            SqlConnection connection = new SqlConnection();
            SqlTransaction transaction = null;
            bool transCheck = false;
            SqlCommand[] sqlCommand = new SqlCommand[pProcedureName.Length];
            try
            {

                if (OpenConnection(ref connection))
                {
                    // Start a local transaction.
                    transaction = connection.BeginTransaction();
                    // Must assign both transaction object and connection
                    // to Command object for a pending local transaction
                    SqlBulkCopy blkCpy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction);

                    for (int i = 0; i < pProcedureName.Length; i++)
                    {
                        if (pProcedureName[i] != null && pProcedureName[i] != "")
                        {
                            sqlCommand[i] = new SqlCommand(pProcedureName[i], connection);
                            sqlCommand[i].Transaction = transaction;
                            sqlCommand[i].CommandType = CommandType.StoredProcedure;
                            if (pValues[i] != null)
                            {
                                IDictionaryEnumerator enumerator = pValues[i].GetEnumerator();
                                while (enumerator.MoveNext())
                                {
                                    sqlCommand[i].Parameters.AddWithValue(enumerator.Key.ToString(), enumerator.Value);
                                }
                            }

                            sqlCommand[i].ExecuteNonQuery();
                        }
                    }
                    if (TableList != null)

                        if (TableList != null && TableList.Rows.Count >= 1)
                        {
                            blkCpy.DestinationTableName = TableList.TableName;
                            blkCpy.WriteToServer(TableList);
                        }

                    transaction.Commit();
                    transCheck = true;
                }
            }
            catch (SqlException sx)
            {
                //SetMessage(sx);
                transaction.Rollback();
                transCheck = false;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                transaction.Rollback();
                transCheck = false;
            }
            finally
            {
                CloseConnection(ref connection);
            }
            return transCheck;
        }


        public static bool ExecuteDMLQuery(string pProcedureName)
        {

            SqlConnection connection = new SqlConnection();
            SqlCommand sqlCmd = null;


            try
            {

                if (OpenConnection(ref connection))
                {
                    sqlCmd = new SqlCommand(pProcedureName, connection);
                    sqlCmd.CommandTimeout = 300;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (SqlException sx)
            {
                // SetMessage(sx);
                return false;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            finally
            {
                sqlCmd.Dispose();
                CloseConnection(ref connection);
            }
        }

        public static bool ExecuteDMLQuery(string pProcedureName, Hashtable pValues)
        {

            SqlConnection connection = new SqlConnection();
            SqlCommand sqlCmd = null;


            try
            {

                if (OpenConnection(ref connection))
                {
                    sqlCmd = new SqlCommand(pProcedureName, connection);
                    IDictionaryEnumerator enumerator = pValues.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        sqlCmd.Parameters.AddWithValue(enumerator.Key.ToString(), enumerator.Value);
                    }
                    sqlCmd.CommandTimeout = 300;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            catch (SqlException sx)
            {
               // SetMessage(sx);
                return false;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            finally
            {
                sqlCmd.Dispose();
                CloseConnection(ref connection);
            }
        }
    }


}


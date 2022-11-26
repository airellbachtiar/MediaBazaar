using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Media_Bazaar_Logic.DAL
{
    public abstract class DAL
    {
        private static string connectionString = "Server=studmysql01.fhict.local;Username=dbi423421_app;Database=dbi423421_app;Password=24VzmmPSUEMRUM;ssl mode= none";
        private static MySqlConnection connection = new MySqlConnection(connectionString);

        private static MySqlParameter GetParam(KeyValuePair<string, dynamic> keyValuePair)
        {
            MySqlParameter param = new MySqlParameter
            {
                ParameterName = "@" + keyValuePair.Key,
                Value = keyValuePair.Value
            };
            return param;
        }

        protected static DataSet ExecuteSql(string sql, List<KeyValuePair<string, dynamic>> parameters)
        {
            try
            {
                DataSet dataSet = new DataSet();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                MySqlCommand mySqlCommand = connection.CreateCommand();

                foreach (KeyValuePair<string, dynamic> keyValuePair in parameters)
                {
                    mySqlCommand.Parameters.Add(GetParam(keyValuePair));
                }

                mySqlCommand.CommandText = sql;
                dataAdapter.SelectCommand = mySqlCommand;
                connection.Open();
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        protected static void ExecuteInsert(string sql, List<KeyValuePair<string, dynamic>> parameters)
        {
            try
            {
                MySqlCommand mySqlCommand = connection.CreateCommand();
                foreach (KeyValuePair<string, dynamic> keyValuePair in parameters)
                {
                    mySqlCommand.Parameters.Add(GetParam(keyValuePair));
                }
                mySqlCommand.CommandText = sql;
                connection.Open();
                mySqlCommand.ExecuteScalar();
            }
            catch (Exception)

            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

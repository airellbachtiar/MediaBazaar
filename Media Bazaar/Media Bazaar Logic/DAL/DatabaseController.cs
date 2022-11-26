using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Media_Bazaar_Logic.DAL
{
    public static class DatabaseController
    {

        private static string connectionstring = "Server=studmysql01.fhict.local;Username=dbi423421_app;Database=dbi423421_app;Password=24VzmmPSUEMRUM;ssl mode= none";
        //private static string connectionstring = "Server=localhost;Uid=root;Database=dbi423421_app;Pwd=;ssl mode= none";
        private static MySqlConnection connection = new MySqlConnection(connectionstring);

        /*public DatabaseController()
        {

            string connectionstring = "Server=studmysql01.fhict.local;Username=dbi423421_app;Database=dbi423421_app;Password=24VzmmPSUEMRUM;ssl mode= none";
            //string connectionstring = "Server=localhost;Uid=root;Database=dbi423421_app;Pwd=;ssl mode= none";

            this.connection = new MySqlConnection(connectionstring);
        }*/


        private static MySqlParameter GetParam(KeyValuePair<string, dynamic> keyValuePair)
        {
            MySqlParameter param = new MySqlParameter
            {
                ParameterName = "@" + keyValuePair.Key,
                Value = keyValuePair.Value
            };
            return param;
        }




        public static DataSet ExecuteSql(string sql, List<KeyValuePair<string, dynamic>> parameters)
        {
            try
            {
                DataSet dataset = new DataSet();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                MySqlCommand mySqlCommand = connection.CreateCommand();

                foreach (KeyValuePair<string, dynamic> keyValuePair in parameters)
                {
                    mySqlCommand.Parameters.Add(GetParam(keyValuePair));
                }

                mySqlCommand.CommandText = sql;
                dataAdapter.SelectCommand = mySqlCommand;
                connection.Open();
                dataAdapter.Fill(dataset);
                return dataset;
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


        public static void ExecuteInsert(string sql, List<KeyValuePair<string, dynamic>> parameters)
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

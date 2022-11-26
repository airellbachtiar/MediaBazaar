using System;
using System.Collections.Generic;
using System.Data;

namespace Media_Bazaar_Logic.DAL
{
    public class DepartmentDAL
    {



        public static void AddNewDepartment(string departmentname,string description)
        {

            string sql = "INSERT INTO `departments` (`departmentname`,`description`)" +
                              "VALUES (@departmentname,@description)";





            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("departmentname", departmentname),
                  new KeyValuePair<string, dynamic>("description", description),


                };


            DatabaseController.ExecuteInsert(sql, parameters);


        }

        public static DataSet GetAllDepartment()
        {
            try
            {
                string sql = "SELECT * FROM departments";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {

                };
                DataSet result = DatabaseController.ExecuteSql(sql, parameters);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        public static void UpdateDepartment(int departmentid, string departmentname, string description)
        {
            string sql = "UPDATE `departments` SET departmentname = @departmentname, description =@description WHERE `departmentid` = @departmentid";





            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("departmentid", departmentid),
                  new KeyValuePair<string, dynamic>("departmentname", departmentname),
                  new KeyValuePair<string, dynamic>("description", description),



                };


            DatabaseController.ExecuteInsert(sql, parameters);
        }



        public static DataSet GetDepartmentByID(int departmentid)
        {

            try
            {
                string sql = "SELECT * FROM departments WHERE departmentid = @departmentid";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("departmentid", departmentid),

                };


                DataSet d = DatabaseController.ExecuteSql(sql, parameters);
                return d;



            }
            catch (Exception)
            {
                throw;
            }
        }


        public static int GetDepartmentIDByName(string departmentname)
        {

            try
            {
                string sql = "SELECT * FROM departments WHERE departmentname = @departmentname";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("departmentname", departmentname),

                };


                DataSet d = DatabaseController.ExecuteSql(sql, parameters);

                int depid = (int)d.Tables[0].Rows[0]["departmentid"];

                return depid;



            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}

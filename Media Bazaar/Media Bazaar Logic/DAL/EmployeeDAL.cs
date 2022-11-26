using System;
using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Enums;
using Media_Bazaar_Logic.Parsers;

namespace Media_Bazaar_Logic.DAL
{
    public static class EmployeeDAL
    {

        public static DataSet GetAllEmployees()
        {

            try
            {
                string sql = "SELECT * FROM employee";
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


        public static DataSet GetAllEmployeesByDepartment(int departmentid)
        {

            try
            {
                string sql = "SELECT * FROM employee WHERE Department =@Department";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new KeyValuePair<string, dynamic>("Department", departmentid),
                };
                DataSet result = DatabaseController.ExecuteSql(sql, parameters);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetAllActiveUsersByDepartment(int departmentid)
        {

            try
            {
                string sql = "SELECT employee.* FROM `employee` INNER JOIN employeecontract ON employee.ID = employeecontract.EmployeeID WHERE employeecontract.EndDate > CURRENT_DATE AND employee.Department = @Department GROUP BY employee.ID";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new KeyValuePair<string, dynamic>("Department", departmentid),
                };
                DataSet result = DatabaseController.ExecuteSql(sql, parameters);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetAllInActiveUsersByDepartment(int departmentid)
        {

            try
            {
                string sql = "SELECT employee.* FROM `employee` INNER JOIN employeecontract ON employee.ID = employeecontract.EmployeeID WHERE employeecontract.EndDate < CURRENT_DATE AND employee.Department = @Department GROUP BY employee.ID";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new KeyValuePair<string, dynamic>("Department", departmentid),
                };
                DataSet result = DatabaseController.ExecuteSql(sql, parameters);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet Login(string username, string password)
        {
            try
            {
                string sql = "SELECT * FROM employee WHERE Username = @username AND Password = @password";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("username", username),
                  new KeyValuePair<string, dynamic>("password", password),

                };



                return DatabaseController.ExecuteSql(sql, parameters);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void AddNewUser(string firstname,string surname,string username,string password,int phonenumber,int contactperson,string email,int bsn,RoleType role,string job,int department,string note)
        {

            string sql = "INSERT INTO `employee` (`FirstName`,`Surname`,`Username`,`Password`,`PhoneNumber`,`Contactperson`,`Email`,`BSN`,`Role`,`Job`,`Department`,`Note`)" +
                              "VALUES (@FirstName,@Surname,@Username,@Password,@PhoneNumber,@Contactperson,@Email,@BSN,@Role,@Job,@Department,@Note)";








            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("FirstName", firstname),
                  new KeyValuePair<string, dynamic>("Surname", surname),
                  new KeyValuePair<string, dynamic>("Username", username),
                  new KeyValuePair<string, dynamic>("Password", password),
                  new KeyValuePair<string, dynamic>("PhoneNumber", phonenumber),
                  new KeyValuePair<string, dynamic>("Contactperson", contactperson),
                  new KeyValuePair<string, dynamic>("Email", email),
                  new KeyValuePair<string, dynamic>("BSN", bsn),
                  new KeyValuePair<string, dynamic>("Role", role),
                  new KeyValuePair<string, dynamic>("Job", job),
                  new KeyValuePair<string, dynamic>("Department", department),
                  new KeyValuePair<string, dynamic>("Note", note),

                };


            DatabaseController.ExecuteInsert(sql, parameters);




        }

        public static void UpdateUser(int BSN, int phone, int contact, string email, string function, string notes,int department)
        {

            string sql = "UPDATE `employee` SET PhoneNumber = @PhoneNumber, Contactperson = @Contactperson, Email = @Email, Job = @Job, Note = @Note, Department = @Department WHERE `BSN` = @BSN";





            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("BSN", BSN),
                  new KeyValuePair<string, dynamic>("PhoneNumber", phone),
                  new KeyValuePair<string, dynamic>("Contactperson", contact),
                  new KeyValuePair<string, dynamic>("Email", email),
                  new KeyValuePair<string, dynamic>("Job", function),
                  new KeyValuePair<string, dynamic>("Note", notes),
                  new KeyValuePair<string, dynamic>("Department", department),


                };


            DatabaseController.ExecuteInsert(sql, parameters);




        }

        public static void UpdateProfile(int id, long phone, long contact, string surname)
        {
            string sql = "UPDATE `employee` SET PhoneNumber = @PhoneNumber, Contactperson = @Contactperson, Surname = @Surname  WHERE `ID` = @ID";





            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("ID", id),
                  new KeyValuePair<string, dynamic>("PhoneNumber", phone),
                  new KeyValuePair<string, dynamic>("Contactperson", contact),
                  new KeyValuePair<string, dynamic>("Surname", surname),


                };


            DatabaseController.ExecuteInsert(sql, parameters);


        }

        public static void UpdatePassword(int id, string password)
        {
            string sql = "UPDATE `employee` SET Password = @Password WHERE `ID` = @ID";





            List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("ID", id),
                  new KeyValuePair<string, dynamic>("Password", password),



                };


            DatabaseController.ExecuteInsert(sql, parameters);


        }




        public static DataSet GetUserByBSN(int bsn)
        {

            try
            {
                string sql = "SELECT * FROM employee WHERE BSN = @bsn";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("bsn", bsn),

                };


                DataSet d = DatabaseController.ExecuteSql(sql, parameters);
                return d;



            }
            catch (Exception)
            {
                throw;
            }
        }





        public static int GetUserIDByBSN(long bsn)
        {

            try
            {
                string sql = "SELECT ID FROM employee WHERE BSN = @bsn";
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                  new KeyValuePair<string, dynamic>("bsn", bsn),

                };


                DataSet d = DatabaseController.ExecuteSql(sql, parameters);
                return (int)d.Tables[0].Rows[0]["ID"];
                ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static User GetUserById(int userId)
        {
            User u = null;
            string sql = "SELECT * FROM employee WHERE ID = @id";
            
            try
            {
                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new KeyValuePair<string, dynamic>("id", userId),
                };

                DataSet d = DatabaseController.ExecuteSql(sql, parameters);
                u = UserParser.DataSetToUser(d, 0);
            }
            catch (Exception)
            {
                return null;
            }

            return u;
        }

        public static bool UpdateUserInWebsite(int id, string username, string surname, string email, int phoneNumber, int contactPerson)
        {
            try
            {
                string sql = "UPDATE `employee` SET Username = @Username, Surname = @Surname, Email = @Email, PhoneNumber = @PhoneNumber, ContactPerson = @ContactPerson WHERE ID = @ID";

                List<KeyValuePair<string, dynamic>> parameters = new List<KeyValuePair<string, dynamic>>
                {
                    new KeyValuePair<string, dynamic>("Username", username),
                    new KeyValuePair<string, dynamic>("Surname", surname),
                    new KeyValuePair<string, dynamic>("Email", email),
                    new KeyValuePair<string, dynamic>("PhoneNumber", phoneNumber),
                    new KeyValuePair<string, dynamic>("ContactPerson", contactPerson),
                    new KeyValuePair<string, dynamic>("ID", id)
                };
                DatabaseController.ExecuteInsert(sql, parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




        //    public static List<Class.User> GetEmployees()
        //    {
        //        sql = "SELECT * FROM employee";
        //        cmd = new MySqlCommand(sql, connection);

        //        string sqlEmployeeContract = "SELECT * FROM employeecontract";
        //        MySqlCommand cmdEmployeeContract = new MySqlCommand(sqlEmployeeContract, connection);

        //        List<Class.User> users = new List<Class.User>();

        //        try
        //        {
        //            connection.Open();
        //            MessageBox.Show("Connection successful");
        //            MySqlDataReader readerEmployee = cmd.ExecuteReader();
        //            MySqlDataReader readerEmployeeContract = cmdEmployeeContract.ExecuteReader();

        //            while (readerEmployee.Read() || readerEmployeeContract.Read())
        //            {
        //                users.Add(new Class.User());
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Error, failed to load data");
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //        return users;
        //    }

        //    public static List<Class.Contract> GetContracts()
        //    {
        //        sql = "SELECT * FROM contract";
        //        cmd = new MySqlCommand(sql, connection);

        //        List<Class.Contract> contracts = new List<Class.Contract>();

        //        try
        //        {
        //            connection.Open();
        //            MessageBox.Show("Connection successful");
        //            MySqlDataReader readerEmployee = cmd.ExecuteReader();

        //            while (readerEmployee.Read())
        //            {
        //                contracts.Add(new Class.Contract());
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Error, failed to load data");
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //        return contracts;
        //    }

        //    public static void AddEmployee(Class.User user)
        //    {
        //        sql = "INSERT INTO employee VALUES(@ID, @FirstName, @Surname, @Username, @Password, @Email, @BSN, @Role, @Job, @Department, @Note)";
        //        cmd = new MySqlCommand(sql, connection);
        //        /*cmd.Parameters.AddWithValue("@ID", );
        //        cmd.Parameters.AddWithValue("@FirstName", );
        //        cmd.Parameters.AddWithValue("@Surname", );
        //        cmd.Parameters.AddWithValue("@Username", );
        //        cmd.Parameters.AddWithValue("@Password", );
        //        cmd.Parameters.AddWithValue("@Email", );
        //        cmd.Parameters.AddWithValue("@BSN", );
        //        cmd.Parameters.AddWithValue("@Role", );
        //        cmd.Parameters.AddWithValue("@Job", );
        //        cmd.Parameters.AddWithValue("@Department", );
        //        cmd.Parameters.AddWithValue("@Note", );*/
        //        string sqlEmployeeContract = "INSERT INTO employeecontract VALUES(@EmployeeID, @ContractID, @StartDate, @EndDate)";
        //        MySqlCommand cmdEmployeeContract = new MySqlCommand(sqlEmployeeContract, connection);
        //        /*cmdEmployeeContract.Parameters.AddWithValue("@EmployeeID", );
        //        cmdEmployeeContract.Parameters.AddWithValue("@ContractID", );
        //        cmdEmployeeContract.Parameters.AddWithValue("@StartDate", );
        //        cmdEmployeeContract.Parameters.AddWithValue("@EndDate", );*/

        //        try
        //        {
        //            connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Error, failed to load data");
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }

        //    public static void AddContract(Class.Contract contract)
        //    {
        //        sql = "INSERT INTO employeecontract VALUES(@EmployeeID, @ContractID, @StartDate, @EndDate)";
        //        cmd = new MySqlCommand(sql, connection);
        //        /*cmdEmployeeContract.Parameters.AddWithValue("@EmployeeID", );
        //        cmdEmployeeContract.Parameters.AddWithValue("@ContractID", );
        //        cmdEmployeeContract.Parameters.AddWithValue("@StartDate", );
        //        cmdEmployeeContract.Parameters.AddWithValue("@EndDate", );*/

        //        try
        //        {
        //            connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Error, failed to load data");
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }

        //    public static void EditEmployee(Class.User user)
        //    {
        //        string column = "";
        //        string column2 = "";
        //        int id = 0;
        //        sql = $"UPDATE employee SET {column} = {column2} WHERE id={id.ToString()}";
        //        cmd = new MySqlCommand(sql, connection);
        //        try
        //        {
        //            connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Error, failed to load data");
        //        }
        //        finally 
        //        {
        //            connection.Close();
        //        }
        //    }

        //    public static void DeleteEmployee(Class.User user)
        //    {
        //        int id = 0;
        //        sql = $"DELETE FROM employee WHERE id={id.ToString()}";
        //        cmd = new MySqlCommand(sql, connection);
        //        try
        //        {
        //            connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Error, failed to load data");
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }

        //    public static void DeleteEmployeeContract(Class.User user)
        //    {
        //        int id = 0;
        //        sql = $"DELETE FROM employeecontract WHERE id={id.ToString()}";
        //        cmd = new MySqlCommand(sql, connection);
        //        try
        //        {
        //            connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Error, failed to load data");
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }

        //    public static void FilterEmployee(string sql)
        //    {
        //        try
        //        {
        //            cmd = new MySqlCommand(sql, connection);
        //            connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Error, failed to load data");
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
    }


}

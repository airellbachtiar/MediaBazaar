using System.Collections.Generic;
using System.Data;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.DAL;
using Media_Bazaar_Logic.Parsers;

namespace Media_Bazaar_Logic.Controllers
{
    public class DepartmentController 
    {






        public static void AddNewDepartment(string departmentname,string description)
        {
            DepartmentDAL.AddNewDepartment(departmentname,description);

        }


        public static Department GetDepartmentByID(int ID)
        {
            return DepartmentParser.DataSetToUser(DepartmentDAL.GetDepartmentByID(ID), 0);
        }

        public static int GetDepartmentIDByName(string name)
        {
            return DepartmentDAL.GetDepartmentIDByName(name);
        }




        public static List<Department> GetAllDepartments()
        {
            DataSet d = DepartmentDAL.GetAllDepartment();
            List<Department> list = new List<Department>();

            for (int x = 0; x < d.Tables[0].Rows.Count; x++)
            {
                Department p = DepartmentParser.DataSetToUser(d, x);
                list.Add(p);
            }
            return list;
        }


        public static void UpdateDepartment(int departmentid,string departmentname,string description)
        {
            DepartmentDAL.UpdateDepartment(departmentid,departmentname,description);
        }


    }
}

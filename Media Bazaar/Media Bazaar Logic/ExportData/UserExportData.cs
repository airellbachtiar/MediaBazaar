using System.Text;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;

namespace Media_Bazaar_Logic.ExportData
{
    public class UserExportData : IExportDataFormat
    {
        public string GetCSVString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID,FirstName,Surname,Username,PhoneNumber,ContactPerson,Email,BSN,Role,Job,Department,Note");
            foreach (User u in UserController.GetAllUsers())
            {
                sb.AppendLine(string.Format($"{u.ID},{u.FirstName},{u.SurName},{u.UserName},{u.PhoneNumber.ToString()},{u.ContactPerson.ToString()},{u.Email},{u.BSN.ToString()},{u.Role.ToString()},{u.Job},{u.Department},{u.Note}"));
            }
            return sb.ToString();
        }
    }
}

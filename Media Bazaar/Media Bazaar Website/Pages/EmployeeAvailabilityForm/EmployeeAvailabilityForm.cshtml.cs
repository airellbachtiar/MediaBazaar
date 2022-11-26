using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Media_Bazaar_Logic.Controllers;

namespace Media_Bazaar_Website.Pages
{
    public class EmployeeAvailabilityFormModel : PageModel
    {
        public int EmployeeID { get; set; }
        public List<string> Availability { get; set; }

        [BindProperty]
        public bool Monday { get; set; }

        [BindProperty]
        public bool Tuesday { get; set; }

        [BindProperty]
        public bool Wednesday { get; set; }

        [BindProperty]
        public bool Thursday { get; set; }

        [BindProperty]
        public bool Friday { get; set; }

        [BindProperty]
        public bool Saturday { get; set; }

        [BindProperty]
        public bool Sunday { get; set; }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                EmployeeID = Convert.ToInt32(Request.Cookies["UserID"]);
                Availability = EmployeeAvailabilityController.GetEmpAvailability().Where(employee => employee[0] == EmployeeID.ToString()).FirstOrDefault();
                Monday = Convert.ToBoolean(Availability[2]);
                Tuesday = Convert.ToBoolean(Availability[3]);
                Wednesday = Convert.ToBoolean(Availability[4]);
                Thursday = Convert.ToBoolean(Availability[5]);
                Friday = Convert.ToBoolean(Availability[6]);
                Saturday = Convert.ToBoolean(Availability[7]);
                Sunday = Convert.ToBoolean(Availability[8]);
                if (Availability == null)
                {
                    Redirect("/Index");
                }
            }
            else
            {
                Redirect("/Index");
            }
        }

        public IActionResult OnPost()
        {
            EmployeeID = Convert.ToInt32(Request.Cookies["UserID"]);
            Availability = EmployeeAvailabilityController.GetEmpAvailability().Where(employee => employee[0] == EmployeeID.ToString()).FirstOrDefault();

            //Monday
            Availability[2] = Monday.ToString().ToLower();

            //Tuesday
            Availability[3] = Tuesday.ToString().ToLower();

            //Wednesday
            Availability[4] = Wednesday.ToString().ToLower();

            //Thursday
            Availability[5] = Thursday.ToString().ToLower();

            //Friday
            Availability[6] = Friday.ToString().ToLower();

            //Saturday
            Availability[7] = Saturday.ToString().ToLower();

            //Sunday
            Availability[8] = Sunday.ToString().ToLower();

            //Update database
            EmployeeAvailabilityController.UpdateEmpAvailability(Availability);

            OnGet();
            return Page();
        }
    }
}

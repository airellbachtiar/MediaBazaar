using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;
using Media_Bazaar_Website.ClassCollection.UserCollection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Media_Bazaar_Website.Pages.LogPages
{
    public class ViewProfileModel : PageModel
    {
        public User user { get; set; }

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                user = UserController.GetUserByID(Convert.ToInt32(Request.Cookies["UserID"]));
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Media_Bazaar_Website.ClassCollection.UserCollection;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;

namespace Media_Bazaar_Website.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        public User user { get; set; }


        /*public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }*/

        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                user = UserController.GetUserByID(Convert.ToInt32(Request.Cookies["UserID"]));
                ViewData["LoggedUser"] = user.UserName;
            }
        }
    }
}

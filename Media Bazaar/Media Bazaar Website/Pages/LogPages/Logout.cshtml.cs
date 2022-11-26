using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Media_Bazaar_Website.Pages.LogPages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            HttpContext.Session.Remove("UserID");
            Response.Cookies.Delete("UserID");
            await HttpContext.SignOutAsync("MyCookiesAuth");
            return RedirectToPage("/Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Media_Bazaar_Website.ClassCollection.UserCollection;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;

namespace Media_Bazaar_Website.Pages
{
    public class LoginFormModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please insert your username")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please insert your password")]
        public string Password { get; set; }
        
        public bool WrongPassword { get; set; }

        public void OnGet(string state)
        {
            if (state != null)
            {
                if (state.Equals("WrongPassword"))
                {
                    WrongPassword = true;
                }
                else
                {
                    WrongPassword = false;
                }
            }
            else
            {
                WrongPassword = false;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                User loggedUser = UserController.Login(Username, Password);
                if (loggedUser != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, loggedUser.UserName),
                        new Claim(ClaimTypes.Email, loggedUser.Email),
                        new Claim("UserID", loggedUser.ID.ToString())
                    };
                    var identity = new ClaimsIdentity(claims, "MyCookiesAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("MyCookiesAuth", claimsPrincipal);

                    Response.Cookies.Append("UserID", loggedUser.ID.ToString());
                    HttpContext.Session.SetInt32("UserID", loggedUser.ID);
                    return Redirect("/index");
                }

                return Redirect("/LogPages/LoginForm?state=WrongPassword");
            }
            return Redirect("/LogPages/LoginForm?state=WrongPassword");
        }
    }
}

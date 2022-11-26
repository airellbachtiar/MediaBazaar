using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Media_Bazaar_Website.ClassCollection.UserCollection;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;

namespace Media_Bazaar_Website.Pages
{
    public class EditProfileFormModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Phone Number is required")]
        public int PhoneNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Contact Person is required")]
        public int ContactPerson { get; set; }

        public User user { get; set; }

        public void OnGet()
        {
            if(User.Identity.IsAuthenticated)
            {
                user = UserController.GetUserByID(Convert.ToInt32(Request.Cookies["UserID"]));
                ViewData["LoggedUser"] = user.UserName;
            }
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                user = UserController.GetUserByID(Convert.ToInt32(Request.Cookies["UserID"]));
                UserController.EditUserInWebsite(user.ID, Username, Surname, Email, PhoneNumber, ContactPerson);
                return RedirectToPage("/LogPages/ViewProfile");
            }
            OnGet();
            return Page();
        }
    }
}

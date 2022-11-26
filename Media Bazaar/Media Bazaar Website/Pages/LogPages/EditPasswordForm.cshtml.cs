using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.Controllers;
using Media_Bazaar_Website.ClassCollection.UserCollection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Media_Bazaar_Website.Pages.LogPages
{
    public class EditPasswordFormModel : PageModel
    {
        public User user { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Old password is required"), ]
        public string EnterOldPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Repeat new password is required"), Compare(nameof(NewPassword), ErrorMessage = "Password doesn't match")]
        public string RepeatNewPassword { get; set; }

        public void OnGet()
        {
            if(User.Identity.IsAuthenticated)
            {
                user = UserController.GetUserByID(Convert.ToInt32(Request.Cookies["UserID"]));
            }
        }

        public IActionResult OnPost()
        {
            OnGet();
            if (ModelState.IsValid)
            {
                if(user.Password == PasswordHashingHelper.StringToHash(EnterOldPassword))
                {
                    UserController.UpdatePassword(user.ID, RepeatNewPassword);
                    return Redirect("/LogPages/EditProfileForm");
                }
                else
                {
                    TempData["Incorrect Password"] = "Incorrect Password";
                }
            }
            OnGet();
            return Page();
        }
    }
}

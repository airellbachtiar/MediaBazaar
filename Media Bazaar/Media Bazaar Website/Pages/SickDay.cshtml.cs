using System;
using System.Collections.Generic;
using Media_Bazaar_Logic.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Media_Bazaar_Website.Pages
{
    public class SickDay : PageModel
    {
        public bool Sick { get; set; }
        
        public void OnGet()
        {
            Sick = false;
            int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
            
            List<DateTime> sickMoments = SickDayDAL.GetSickDaysForUser((int)userId);
            if (sickMoments.Contains(DateTime.Today))
            {
                Sick = true; 
            }
        }

        public void OnPost()
        {
            int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
            SickDayDAL.AddSickDay(userId);
            Sick = true;
        }
    }
}
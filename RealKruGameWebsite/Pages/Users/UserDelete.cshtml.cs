using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModels.Models;
using UserServices.Services;

namespace RealKruGameWebsite.Pages.Users
{
    public class UserDeleteModel : PageModel
    {

        private readonly IUserRepository userRepository;
        public UserDeleteModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [BindProperty]
        public new User User { get; set; }
        //Gets user ID. If it gets nothing, redirect to not found page.
        public IActionResult OnGet(int id)
        {
            User = userRepository.GetUser(id);

            if (User == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        //Deletes user ID. If it gets nothing, redirect to not found page.
        public IActionResult OnPost()
        {
            User DeletedWork = userRepository.Delete(User.Id);

            if (User == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("/users/userprofile");
        }
    }
}

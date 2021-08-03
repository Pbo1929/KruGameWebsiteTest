using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModels.Models;
using UserServices.Services;

namespace RealGameWebsiteTest.Pages
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

        public IActionResult OnGet(int id)
        {
            User = userRepository.GetUser(id);

            if (User == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            User DeletedWork = userRepository.Delete(User.Id);

            if (User == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("Work");
        }
    }
}

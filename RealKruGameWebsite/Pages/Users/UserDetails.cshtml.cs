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
    public class UserDetailsModel : PageModel
    {
        private readonly IUserRepository userRepository;

        public UserDetailsModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public new User User { get; private set; }

        public void OnGet(int id)
        {
            User = userRepository.GetUser(id);
        }
    }
}

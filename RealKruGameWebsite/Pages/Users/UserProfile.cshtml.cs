using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModels.Models;
using UserServices.Services;

namespace RealGameWebsiteTest.Pages.Users
{
    public class UserProfileModel : PageModel
    {
        private readonly IUserRepository userRepository;
        public IEnumerable<User> Users { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public UserProfileModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void OnGet()
        {
            Users = userRepository.Search(SearchTerm);
        }
    }
}
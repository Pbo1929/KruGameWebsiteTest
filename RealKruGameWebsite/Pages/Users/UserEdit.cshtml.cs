using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserModels.Models;
using UserServices.Services;

namespace RealKruGameWebsite.Pages.Users
{
    public class UserEditModel : PageModel
    {
        private readonly IUserRepository userRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserEditModel(IUserRepository userRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.userRepository = userRepository;
            // IWebHostEnvironment service allows us to get the
            // absolute path of WWWRoot folder
            this.webHostEnvironment = webHostEnvironment;
        }

        // This is the property the display template will use to
        // display existing Work data

        [BindProperty]
        public new User User { get; set; }

        // We use this property to store and process
        // the newly uploaded photo

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        [TempData]
        public string Message { get; set; }

        // Populate User property
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                User = userRepository.GetUser(id.Value);
            }
            else
            {
                User = new User();
            }

            if (User == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (User.PhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                            "workimages", User.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the employee object
                    User.PhotoPath = ProcessUploadedFile();
                }

                if(User.Id > 0)
                {
                    User = userRepository.Update(User);
                }
                else
                {
                    User = userRepository.Add(User);
                }
                return RedirectToPage("/users/userprofile");
            }
            return Page();
        }

        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications";
            }
            else
            {
                Message = "You turned off notifications";
            }

            TempData["message"] = Message;

            return RedirectToPage("WorkDetails", new { id = id });
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "workimages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}

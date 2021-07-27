using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkModels.Models;
using WorkServices.Services;

namespace RealKruGameWebsite.Pages.Works
{
    public class WorkEditModel : PageModel
    {
        private readonly IWorkRepository workRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public WorkEditModel (IWorkRepository workRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.workRepository = workRepository;
            // IWebHostEnvironment service allows us to get the
            // absolute path of WWWRoot folder
            this.webHostEnvironment = webHostEnvironment;
        }

        // This is the property the display template will use to
        // display existing Work data

        [BindProperty]
        public Work Work { get; private set; }

        // We use this property to store and process
        // the newly uploaded photo

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }

        [TempData]
        public string Message { get; set; }

        // Populate Employee property
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Work = workRepository.GetWork(id.Value);
            }
            else
            {
                Work = new Work();
            }

            if (Work == null)
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
                    if (Work.PhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                            "workimages", Work.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the employee object
                    Work.PhotoPath = ProcessUploadedFile();
                }

                if(Work.Id > 0)
                {
                    Work = workRepository.Update(Work);
                }
                else
                {
                    Work = workRepository.Add(Work);
                }
                return RedirectToPage("/works/work");
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

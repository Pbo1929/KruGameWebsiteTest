using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Aardvark.Base.Native;
using Microsoft.AspNetCore.Hosting;
using RealGameWebsiteTest.BackgroundTasks;
using System.IO;
using RealGameWebsiteTest.Models;

namespace RealGameWebsiteTest.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IToastNotification toastNotification;
        private IWebHostEnvironment _env;
        private string _dir;

        public HomeController(IWebHostEnvironment env,
            ILogger<HomeController> logger, IToastNotification toastNotification)
        {
            _logger = logger;
            this.toastNotification = toastNotification;
            _env = env;
            _dir = _env.ContentRootPath;
        }

        //When Index page is rendered, display text message "Notification Successful."
        public IActionResult IndexModel()
        {
            toastNotification.AddSuccessToastMessage("Notification Successful.");
            return View();
        }


        public IActionResult SingleFile(IFormFile file)
        {
            var dir = _env.ContentRootPath;
            
            using (var fileStream = new FileStream(Path.Combine(_dir, "file.png"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
                return RedirectToAction("Index");
        }

        public IActionResult MultipleFiles(IEnumerable<IFormFile> files)
        {
            int i = 0;
            foreach(var file in files)
            {
                using (var fileStream = new FileStream(Path.Combine(_dir, $"file{i++}.png"), FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult FileInModel(SomeForm someForm)
        {
            using (var fileStream = new FileStream(Path.Combine(_dir, $"file{someForm.Name}.png"), 
                FileMode.Create, 
                FileAccess.Write))
            {
                someForm.File.CopyTo(fileStream);
            }

            return RedirectToAction("Index");
        }
    }
}

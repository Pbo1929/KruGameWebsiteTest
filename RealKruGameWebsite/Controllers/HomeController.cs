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

namespace RealGameWebsiteTest.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IToastNotification toastNotification;

        public HomeController(
            ILogger<HomeController> logger, IToastNotification toastNotification)
        {
            _logger = logger;
            this.toastNotification = toastNotification;
        }

        //When Index page is rendered, display text message "Notification Successful."
        public IActionResult IndexModel()
        {
            toastNotification.AddSuccessToastMessage("Notification Successful.");
            return View();
        }
    }
}

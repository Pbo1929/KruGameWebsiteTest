using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGameWebsiteTest.Controllers
{
    public class HomeController : Controller
    {

        private readonly INotyfService _notyf;
        public HomeController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            _notyf.Success("Success Notification");
            _notyf.Success("Success Notification that closes in 10 Seconds.", 3);
            return View();
        }
    }
}

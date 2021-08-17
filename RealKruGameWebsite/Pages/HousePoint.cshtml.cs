using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RealKruGameWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RealKruGameWebsite.Pages
{
    public class HousePointModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public Email sendmail { get; set; }

        public async Task OnPost()
        {
            string To = sendmail.To;
            string Subject = sendmail.Subject;
            string Body = sendmail.Body;

            MailMessage mm = new MailMessage();
            mm.To.Add(To);
            mm.Subject = Subject;
            mm.Body = Body;
            mm.IsBodyHtml = false;
            mm.From = new MailAddress("lulztit1929@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("lulztit1929@gmail.com", "Prematascot123456");
            await smtp.SendMailAsync(mm);
            ViewData["Message"] = "The Mail Has Been Sent To " + sendmail.To;
        }
    }
}


using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealKruGameWebsite.Models
{
    //Structure for email sender
    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public System.Net.Mail.AttachmentCollection Attachments { get; }
    }
}

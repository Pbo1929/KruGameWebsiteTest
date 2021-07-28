using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RealGameWebsiteTest.Areas.Identity.Data
{
    public class WebUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "navchar(100)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "navchar(100)")]
        public string LastName {get;set;}
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesTutorials.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int HousePoint { get; set; }
        public int Warning { get; set; }
        public string PhotoPath { get; set; }
    }
}

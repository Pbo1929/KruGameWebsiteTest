using System;
using System.Collections.Generic;
using System.Text;

namespace UserModels.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public int HousePoint { get; set; }
        public int Warning { get; set; }

    }
}

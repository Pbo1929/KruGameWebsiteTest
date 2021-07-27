using RazorPagesTutorials.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RazorPagesTutorial.Services
{
    public class MockWorkRepository : IWorkRepository
    {
        private List<User> _userList;
        
        public MockWorkRepository()
        {
            _userList = new List<User>()
            {
                new User(){Username = "Prem", Email = "Prem.s@ascot.ac.th", Password = "Prematascot123456", PhotoPath="Cosmos.PNG"},
                new User(){Username = "God", Email = "lulztit1929@gmail.com", Password="Prematascot123456", PhotoPath="Raelina 2.jpg"}
            };
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userList;
        }

        public User GetUser(string Username)
        {
            return _userList.FirstOrDefault(e => e.Username == Username);
        }

        public User Update(User updatedUser)
        {
            User user = _userList.FirstOrDefault(e => e.Username == updatedUser.Username);

            if(user != null)
            {
                user.Username = updatedUser.Username;
                user.Username = updatedUser.Username;
                user.Email = updatedUser.Email;
                user.PhotoPath = updatedUser.Email;
            }
            return user;
        }
    }
}

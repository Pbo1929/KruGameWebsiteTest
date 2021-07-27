using RazorPagesTutorials.Models;
using System;
using System.Collections.Generic;

namespace RazorPagesTutorial.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUser(string Username);
        User Update(User updatedUser);
    }
}

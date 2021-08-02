using System;
using System.Collections.Generic;
using UserModels.Models;

namespace UserServices.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> Search(string searchTerm);
        IEnumerable<User> GetAllUsers();
        User GetUser(int id);
        User Update(User updatedUser);
        User Add(User newUser);
        User Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserModels.Models;

namespace UserServices.Services
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _userList;
        //A repository of users
        public MockUserRepository()
        {
            _userList = new List<User>()
            {
                new User() {Id = 1, Username = "Prem", Email = "prem.s@ascot.ac.th", HousePoint = 1, Warning = 0, PhotoPath = "noimage.png" }
            };
        }
        //Adds a user and gives them an Id.
        public User Add(User newUser)
        {
            newUser.Id = _userList.Max(e => e.Id) + 1;
            _userList.Add(newUser);
            return newUser;
        }
        //Finds user Id and delete a user with that Id.
        public User Delete(int id)
        {
            User userToDelete = _userList.FirstOrDefault(e => e.Id == id);

            if (userToDelete != null)
            {
                _userList.Remove(userToDelete);
            }
            return userToDelete;
        }
        //Gets a list of users.
        public IEnumerable<User> GetAllUsers()
        {
            return _userList;
        }
        //Gets a specific user.
        public User GetUser(int id)
        {
            return _userList.FirstOrDefault(e => e.Id == id);
        }
        //Finds a user depending on their name.
        public IEnumerable<User> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _userList;
            }

            return _userList.Where(e => e.Username.Contains(searchTerm));
        }
        //Updates a user's info.
        public User Update(User updatedUser)
        {
            User user = _userList
                .FirstOrDefault(e => e.Id == updatedUser.Id);
            if (user != null)
            {
                user.Username = updatedUser.Username;
                user.Email = updatedUser.Email;
                user.HousePoint = updatedUser.HousePoint;
                user.Warning = updatedUser.Warning;
                user.PhotoPath = updatedUser.PhotoPath;
            }
            return user;
        }
    }
}


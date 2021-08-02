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

        public MockUserRepository()
        {
            _userList = new List<User>()
            {
            };
        }

        public User Add(User newUser)
        {
            newUser.Id = _userList.Max(e => e.Id) + 1;
            _userList.Add(newUser);
            return newUser;
        }

        public User Delete(int id)
        {
            User userToDelete = _userList.FirstOrDefault(e => e.Id == id);

            if (userToDelete != null)
            {
                _userList.Remove(userToDelete);
            }
            return userToDelete;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userList;
        }

        public User GetUser(int id)
        {
            return _userList.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<User> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _userList;
            }

            return _userList.Where(e => e.Username.Contains(searchTerm));
        }

        public User Update(User updatedUser)
        {
            User user = _userList
                .FirstOrDefault(e => e.Id == updatedUser.Id);
            if (user != null)
            {
                user.Username = updatedUser.Username;
                user.Email = updatedUser.Email;
                user.Password = updatedUser.Password;
                user.PhotoPath = updatedUser.PhotoPath;
            }
            return user;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserModels.Models;

namespace UserServices.Services
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public User Add(User newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser;
        }

        public User Delete(int id)
        {
            User user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users;
        }

        public User GetUser(int id)
        {
            return context.Users.Find(id);
        }

        public IEnumerable<User> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return context.Users;
            }

            return context.Users.Where(e => e.Username.Contains(searchTerm) ||
                                            e.Email.Contains(searchTerm));
        }

        public User Update(User updatedUser)
        {
            var user = context.Users.Attach(updatedUser);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedUser;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Data.Models;
using TimeCo.Data.Data;

namespace TimeCo.Data.Repositories
{
    public class UserRepository
    {
        // Private field
        private TimeCoAspContext _context;

        // Constructor
        public UserRepository()
        {
            _context = new TimeCoAspContext();
        }

        // Method for returning all users
        public  List<User> GetUsersList()
        {
            using (var context = new TimeCoAspContext()) // Replace YourDbContext with your actual DbContext class
            {
                return context.Users.Select(x => x).ToList();
            }
        }

        // Method for returning user by given username
        public User GetUser(string username)
        {
            return _context.Users.Where(x => x.Username == username).FirstOrDefault();
        }

        // Method for adding user
        public void AddUser(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();
        }

        // Method for making user an admin
        public void MakeUserAnAdmin(User user)
        {
            _context.Users.Update(user);

            _context.SaveChanges();
        }

        // Method for editin user
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);

            _context.SaveChanges();
        }
    }
}

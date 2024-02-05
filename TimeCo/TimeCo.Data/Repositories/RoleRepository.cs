using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Data.Models;
using TimeCo.Data.Data;

namespace TimeCo.Data.Repositories
{
    public class RoleRepository
    {
        // Private fields
        private TimeCoAspContext _context;
        private UserRepository _userRepository;

        // Constructor
        public RoleRepository()
        {
            _context = new TimeCoAspContext();
            _userRepository = new UserRepository();
        }

        // Method for returning user's role
        public Role GetUserRole(string username)
        {
            User user = _userRepository.GetUser(username);

            return _context.Roles.Where(x => x.Id == user.RoleId).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Data.Repositories;
using TimeCo.Data.Models;
using TimeCo.Data.Data;
using TimeCo.Data.Models;

namespace TimeCo.Services
{
    public class UserService
    {
        // Private fields
        private TimeCoAspContext _context;
        private DepartmentRepository _departmentRepository;
        private UserRepository _userRepository;
        //private TimeCo.Utilities.Converter _converter;
        //private TimeCo.Utilities.PasswordHash _passwordHash;

        // Constructor
        public UserService()
        {
            _context = new TimeCoAspContext();
            _departmentRepository = new DepartmentRepository();
            _userRepository = new UserRepository();
            //_converter = new Utilities.Converter();
            //_passwordHash = new Utilities.PasswordHash();
        }

        // Method for returning all users
        public List<User> GetAllUsers()
        {
            List<User> userList = _userRepository.GetUsersList();
            return userList;

        }

        // Method for verifying user
        public bool CheckUser(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(user => user.Username == username);
            //bool checkPass = _passwordHash.VerifyPassword(password, user.Password);
            var checkPass = _context.Users.FirstOrDefault(user => user.Password == password);
            return user != null && checkPass != null;
        }

        // Method for making user an admin
        public void MakeUserAnAdmin(string username)
        {

            var user = _context.Users.FirstOrDefault(user => user.Username == username);
            var role = _context.Roles.FirstOrDefault(role => role.Name == "Admin");

            if (user != null)
            {
                user.RoleId = role.Id;
            }
            _userRepository.MakeUserAnAdmin(user);
        }

        // Method for adding user
        public void AddUser(string firstName, string lastName, string email, string password, string username, string departmentName, string roleName = "Standard")
        {

            var department = _context.Departments.FirstOrDefault(item => item.Name == departmentName);
            var role = _context.Roles.FirstOrDefault(role => role.Name == roleName);

            User user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                //Password = _passwordHash.HashPassword(password),
                Username = username,
                //CreatedAt = _converter.GetCurrentTime(),
                //ModifiedAt = _converter.GetCurrentTime(),
                MainVacationHours = 200,
                RoleId = role.Id,
                DepartmentId = department.Id
            };

            _userRepository.AddUser(user);
        }

        // Method for editing user
        public void UpdateUser(string username, string firstName, string lastName, string newUsername)
        {
            var user = _context.Users.FirstOrDefault(user => user.Username == username);
            user.Username = newUsername;
            user.FirstName = firstName;
            user.LastName = lastName;

            _userRepository.UpdateUser(user);

        }

        // Method for changing user's password 
        public void ChangePass(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(user => user.Username == username);
            user.Password = password;

            _userRepository.UpdateUser(user);

        }

        // Method for adding user to department
        public void AddUserToDepartment(string username, string departmentName)
        {
            var user = _context.Users.FirstOrDefault(user => user.Username == username);
            var department = _context.Departments.FirstOrDefault(department => department.Name == departmentName);
            user.DepartmentId = department.Id;

            _userRepository.UpdateUser(user);

        }
    }
}

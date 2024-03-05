using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Service.Users.Models;

namespace TimeCo.Service.Users.Services
{
    public class UserService : IUserService
    {
        public Task<UserDTO> FetchUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Data;
using TimeCo.Service.Roles.Models;

namespace TimeCo.Service.Roles.Services
{
    public interface IRoleService
    {
        string GetRoleByIdAsync(Guid id);
    }
}

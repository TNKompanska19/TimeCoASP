using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimeCo.Data;
using TimeCo.Service.Roles.Models;
using TimeCo.Service.Schedules.Services;
using TimeCo.Service.Vacations.Models;

namespace TimeCo.Service.Roles.Services
{
    public class RoleService : IRoleService
    {
        private readonly EntityContext context;
        private readonly ILogger<ScheduleService> logger;
        public RoleService(EntityContext context, ILogger<ScheduleService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public string GetRoleByIdAsync(Guid id)
        {
            Role? role = this.context.Roles
                .FirstOrDefault(v => v.Id == id);
            return role?.Name ?? "User";
        }
    }
}

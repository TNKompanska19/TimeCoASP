using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCo.Data
{
    public class ApplicationUser : IdentityUser<Guid>, IEntity
    {
        public ICollection<Schedule> Schedules { get; }
        public ICollection<Vacation> Vacations { get; }
    }
}

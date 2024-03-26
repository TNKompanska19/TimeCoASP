using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Data;

namespace TimeCo.Service.Roles.Models
{
    public class RoleDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
    }
}

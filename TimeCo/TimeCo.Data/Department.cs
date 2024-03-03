using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCo.Data
{
    public class Department : AuditableEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ApplicationUser> Users { get; }
    }
}

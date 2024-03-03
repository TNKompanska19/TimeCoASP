using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCo.Data
{
    public class Vacation : AuditableEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

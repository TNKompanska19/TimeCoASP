using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCo.Data
{
    public class Schedule : AuditableEntity
    {
        public string Shift { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

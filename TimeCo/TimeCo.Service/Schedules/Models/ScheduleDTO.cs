using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Data;

namespace TimeCo.Service.Schedules.Models
{
    public class ScheduleDTO : IAuditableEntity
    {
        public Guid Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string Shift { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

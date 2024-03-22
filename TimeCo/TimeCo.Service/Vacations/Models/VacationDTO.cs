using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Data;

namespace TimeCo.Service.Vacations.Models
{
    public class VacationDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public Guid? UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

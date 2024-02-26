using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCo.Service.Models
{
    public class ScheduleDTO
    {
        public Guid Id { get; set; }
        public string StartDate { get; set; }
        public Guid UserID { get; set; }
        public string Shift { get; set; }
    }
}

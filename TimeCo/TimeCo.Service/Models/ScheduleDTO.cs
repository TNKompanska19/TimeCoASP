using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCo.Service.Models
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public int UserID { get; set; }
       // public TimeOnly StartHour { get; set; }
        //public TimeOnly EndHour { get; set; }
        public string Shift { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Data.Models;
using TimeCo.Data.Data;
using TimeCo.Data.Data;

namespace TimeCo.Data.Repositories
{
    public class ScheduleRepository
    {
        // Private fields
        private TimeCoAspContext _context;
        private UserRepository _userRepository;

        // Constructor
        public ScheduleRepository()
        {
            _context = new TimeCoAspContext();
            _userRepository = new UserRepository();
        }

        // Method for adding schedule
        public void AddSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);

            _context.SaveChanges();
        }
    }
}

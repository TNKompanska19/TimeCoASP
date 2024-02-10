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

        // Method for returning the user's schedule
        public List<Schedule> GetUserSchedule(string username)
        {
            using (_context)
            {
                var results = from schedule in _context.Schedules
                              join user in _context.Users on schedule.UserId equals user.Id
                              where user.Username == username
                              select new Schedule
                              {
                                  StartDate = schedule.StartDate,
                                  EndDate = schedule.EndDate,
                                  StartHour = schedule.StartHour,
                                  EndHour = schedule.EndHour
                              };

                List<Schedule> result = results.ToList();
                return result;
            }
        }
    }
}

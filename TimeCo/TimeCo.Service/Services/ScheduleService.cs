using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Service.Models;
using TimeCo.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using TimeCo.Data.Data;

namespace TimeCo.Services
{
    public class ScheduleService
    {
        private TimeCoAspContext _context;
        private ScheduleRepository _scheduleRepository;
        public ScheduleService()
        {
            _scheduleRepository = new ScheduleRepository();
            _context = new TimeCoAspContext();
        }
        public List<ScheduleDTO> GetUserSchedule(string username)
        {
            using (_context)
            {
                var results = from schedule in _context.Schedules
                              join user in _context.Users on schedule.UserId equals user.Id
                              where user.Username == username
                              select new ScheduleDTO
                              {
                                  Id = schedule.Id,
                                  StartDate = schedule.StartDate.ToString(),       
                                  Shift = schedule.Shift,
                                  UserID = user.Id
                              };

                List<ScheduleDTO> result = results.ToList();
                return result;
            }
        }
    }
}

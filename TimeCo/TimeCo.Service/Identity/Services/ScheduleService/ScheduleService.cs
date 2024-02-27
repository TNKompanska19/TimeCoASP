using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Data;
using TimeCo.Service.Models;

namespace TimeCo.Service.Identity.Services.ScheduleService
{
    public class ScheduleService
    {
        private readonly EntityContext _context;

        public ScheduleService(EntityContext context)
        {
            _context = context;
        }

        public List<ScheduleDTO> GetUserSchedule(string username)
        {
            var results = from schedule in _context.Schedules
                          join user in _context.Users on schedule.UserId equals user.Id
                          where user.UserName == username
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

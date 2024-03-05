using Essentials.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TimeCo.Data;
using TimeCo.Service.Schedules.Models;

namespace TimeCo.Service.Schedules.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly EntityContext context;
        private readonly ILogger<ScheduleService> logger;
        private readonly UserManager<ApplicationUser> userManager;
        public ScheduleService(EntityContext context, ILogger<ScheduleService> logger, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.logger = logger;
            this.userManager = userManager;
        }

        public async Task<MutationResult> CreateScheduleAsync(ScheduleDTO schedule)
        {
            try
            {
                var scheduleEntity = new Schedule();
                scheduleEntity.Shift = schedule.Shift;
                scheduleEntity.StartDate = DateOnly.ParseExact(schedule.StartDate, "yyyy-MM-dd");
                scheduleEntity.EndDate = DateOnly.ParseExact(schedule.EndDate, "yyyy-MM-dd");
                scheduleEntity.UserId = schedule.UserId;

                this.context.Schedules.Add(scheduleEntity);
                await this.context.SaveChangesAsync();

                return MutationResult.ResultFrom(scheduleEntity.Id, "Schedule has been assigned");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Schedule assignment failed");
                return MutationResult.ResultFrom(null, "Schedule assignment failed");
            }
        }

        public Task<ScheduleDTO> FetchScheduleAsync()
        {
            throw new NotImplementedException();
        }

        public List<ScheduleDTO> GetUserSchedule(string username)
        {
            var results = from schedule in this.context.Schedules
                          join user in this.context.Users on schedule.UserId equals user.Id
                          where user.UserName == username
                          select new ScheduleDTO
                          {
                              Id = schedule.Id,
                              StartDate = schedule.StartDate.ToString(),
                              Shift = schedule.Shift,
                              UserId = user.Id,
                          };

            List<ScheduleDTO> result = results.ToList();
            return result;
        }
    }
}

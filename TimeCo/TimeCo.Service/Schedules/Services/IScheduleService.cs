using System.Collections.Generic;
using System.Threading.Tasks;
using Essentials.Results;
using TimeCo.Service.Schedules.Models;

namespace TimeCo.Service.Schedules.Services
{
    public interface IScheduleService
    {
        Task<ScheduleDTO> FetchScheduleAsync();
        Task<MutationResult> CreateScheduleAsync(ScheduleDTO schedule);
        public List<ScheduleDTO> GetUserSchedule(string username);
    }
}

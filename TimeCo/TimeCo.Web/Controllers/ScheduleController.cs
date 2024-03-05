using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeCo.Common.Contracts;
using TimeCo.Data;
using TimeCo.Service.Schedules.Models;
using TimeCo.Service.Schedules.Services;
using TimeCo.Web.Models;
using TimeCo.Web.Shared;
using Volo.Abp.Clients;
using Volo.Abp.Users;

namespace TimeCo.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleService scheduleService;
        private readonly TimeCo.Common.Contracts.ICurrentUser currentUser;
        private readonly UserManager<ApplicationUser> userManager;

        public ScheduleController(IScheduleService scheduleService, UserManager<ApplicationUser> userManager, TimeCo.Common.Contracts.ICurrentUser currentUser)
        {
            this.scheduleService = scheduleService;
            this.userManager = userManager;
            this.currentUser = currentUser;
        }

        [HttpGet("create-schedule")]
        public async Task<IActionResult> CreateSchedule()
        {
            var users = await this.userManager.Users.ToListAsync();
            var scheduleModel = new CreateScheduleViewModel
            {
                Users = users,
            };

            return this.View(scheduleModel);
        }

        [HttpPost("create-schedule")]
        public async Task<IActionResult> CreateSchedule(CreateScheduleViewModel scheduleModel)
        {
            var scheduleDto = new ScheduleDTO()
            {
                Shift = scheduleModel.Shift,
                StartDate = scheduleModel.StartDate,
                EndDate = scheduleModel.EndDate,
                UserId = scheduleModel.UserId,
            };
            var createResult = await this.scheduleService.CreateScheduleAsync(scheduleDto);

            this.ViewData.SetResult(createResult);

            if (createResult.Succeeded)
            {
                return this.View(new CreateScheduleViewModel());
            }

            return this.View(scheduleModel);
        }
    }
}

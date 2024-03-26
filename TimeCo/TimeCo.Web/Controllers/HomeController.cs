using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using TimeCo.Service.Schedules.Services;
using TimeCo.Service.Vacations.Services;
using TimeCo.Web.Models;

namespace TimeCo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScheduleService scheduleService;
        private readonly IVacationService vacationService;
        public HomeController(IScheduleService scheduleService, IVacationService vacationService)
        {
            this.scheduleService = scheduleService;
            this.vacationService = vacationService;
        }

        [Route("/index")]
        public IActionResult Index(string username)
        {
            // Fetch user schedules and vacations
            var userSchedules = this.scheduleService.GetUserSchedule(username);
            var userVacations = this.vacationService.GetUserVacation(username);

            // Combine schedules and vacations into a unified list of events
            var events = new List<CalendarEventViewModel>();

            foreach (var schedule in userSchedules)
            {
                events.Add(new CalendarEventViewModel
                {
                    Id = schedule.Id.ToString(),
                    Title = schedule.Shift,
                    StartDate = schedule.StartDate,
                    EndDate = schedule.EndDate,
                    Type = "Schedule"
                });
            }

            foreach (var vacation in userVacations)
            {
                events.Add(new CalendarEventViewModel
                {
                    Id = vacation.Id.ToString(),
                    Title = "Vacation",
                    StartDate = vacation.StartDate,
                    EndDate = vacation.EndDate,
                    Type = "Vacation"
                });
            }

            // Pass the combined events to the view
            this.ViewData["events"] = events;

            return this.View();
        }
    }
}

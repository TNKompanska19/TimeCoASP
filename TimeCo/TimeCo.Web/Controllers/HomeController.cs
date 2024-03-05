using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using TimeCo.Service.Schedules.Services;
using TimeCo.Web.Models;

namespace TimeCo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScheduleService scheduleService;

        public HomeController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        [Route("/index")]
        public IActionResult Index(string username)
        {
            this.ViewData["events"] = this.scheduleService.GetUserSchedule(username);
            return this.View();
        }
    }
}

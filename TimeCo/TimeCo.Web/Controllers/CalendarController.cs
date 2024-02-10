using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeCo.Services;
using TimeCo.Web.Models;

namespace TimeCo.Web.Controllers
{
    public class CalendarController : Controller
    {
        private ScheduleService _scheduleService;

        public CalendarController()
        {
            _scheduleService = new ScheduleService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calendar(string username)
        {
          
           
            ViewData["events"] = _scheduleService.GetUserSchedule(username);

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using TimeCo.Service.Identity.Services.ScheduleService;
using TimeCo.Web.Models;

namespace TimeCo.Web.Controllers
{
    public class HomeController : Controller
    {
        private ScheduleService _scheduleService;

        public HomeController(DbContextOptions<EntityContext> dbContextOptions)
        {
            _scheduleService = new ScheduleService(dbContextOptions);
        }
   
        [Route("/index")]
        public IActionResult Index(string username)
        { 
            ViewData["events"] = _scheduleService.GetUserSchedule(username);
            return View();
        }
    }
}

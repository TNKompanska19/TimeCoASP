using Microsoft.AspNetCore.Mvc;

namespace TimeCo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

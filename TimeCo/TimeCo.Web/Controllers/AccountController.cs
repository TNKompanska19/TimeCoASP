using Microsoft.AspNetCore.Mvc;
using TimeCo.Web.Models;
using TimeCo.Services;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
namespace TimeCo.Web.Controllers
{
    public class AccountController : Controller
    {
        private UserService _userService;

        public AccountController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // Simulate user authentication logic (replace with your actual logic)
            if (_userService.CheckUser(model.Username, model.Password))
            {
                string username = model.Username;
                // Redirect to the home page upon successful login


                // Replace "yourUsername" with the desired username
                return RedirectToAction("Calendar", "Calendar", new { username = model.Username });

            }

            // Display error message if credentials are invalid
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }

       

    }
}


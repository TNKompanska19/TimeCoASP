using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeCo.Data;
using TimeCo.Service.Vacations.Services;
using TimeCo.Web.Models;

namespace TimeCo.Web.Controllers
{
    public class VacationHandle : Controller
    {
        private readonly IVacationService vacationService;
        private readonly TimeCo.Common.Contracts.ICurrentUser currentUser;
        private readonly UserManager<ApplicationUser> userManager;

        public VacationHandle(IVacationService vacationService, UserManager<ApplicationUser> userManager, TimeCo.Common.Contracts.ICurrentUser currentUser)
        {
            this.vacationService = vacationService;
            this.userManager = userManager;
            this.currentUser = currentUser;
        }

        [HttpGet("/vacation-handle")]
        public async Task<IActionResult> VacationHandler()
        {
            var vacations = await this.vacationService.FetchVacationsAsync();
            return this.View(vacations);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveVacation(string name)
        {
            await this.vacationService.UpdateVacationStatusAsync(name, "Approved");

            return this.RedirectToAction("VacationHandler", "VacationHandle");
        }

        [HttpPost]
        public async Task<IActionResult> DenyVacation(string name)
        {
            // Retrieve the vacation from the database
            var vacation = await this.vacationService.GetVacationByNameAsync(name);

            await this.vacationService.UpdateVacationStatusAsync(vacation.Name, "Denied");

            return this.RedirectToAction("VacationHandler", "VacationHandle");
        }
    }
}

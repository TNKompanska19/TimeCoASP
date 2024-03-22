using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeCo.Data;
using TimeCo.Service.Vacations.Models;
using TimeCo.Service.Vacations.Services;
using TimeCo.Web.Models;
using TimeCo.Web.Shared;

namespace TimeCo.Web.Controllers
{
    public class VacationRequestController : Controller
    {
        private readonly IVacationService vacationService;
        private readonly TimeCo.Common.Contracts.ICurrentUser currentUser;
        private readonly UserManager<ApplicationUser> userManager;

        public VacationRequestController(IVacationService vacationService, UserManager<ApplicationUser> userManager, TimeCo.Common.Contracts.ICurrentUser currentUser)
        {
            this.vacationService = vacationService;
            this.userManager = userManager;
            this.currentUser = currentUser;
        }

        [HttpGet("/vacation")]
        public IActionResult VacationRequest()
        {
            return this.View();
        }

        [HttpPost("/vacation")]
        public async Task<IActionResult> VacationRequest(VacationViewModel vacationModel, string username)
        {
            var vacationDto = new VacationDTO()
            {
                Name = vacationModel.Name,
                Description = vacationModel.Description,
                StartDate = vacationModel.StartDate,
                EndDate = vacationModel.EndDate,
                UserId = this.currentUser.Id,
            };
            var createResult = await this.vacationService.CreateVacationAsync(vacationDto);

            this.ViewData.SetResult(createResult);

            if (createResult.Succeeded)
            {
                return this.View(new VacationViewModel());
            }

            return this.View(vacationModel);
        }
    }
}

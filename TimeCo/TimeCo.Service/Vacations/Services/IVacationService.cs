using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Essentials.Results;
using TimeCo.Data;
using TimeCo.Service.Users.Models;
using TimeCo.Service.Vacations.Models;

namespace TimeCo.Service.Vacations.Services
{
    public interface IVacationService
    {
        Task<MutationResult> CreateVacationAsync(VacationDTO vacation);
        Task<List<VacationDTO>> FetchVacationsAsync();
        Task<Vacation?> GetVacationByNameAsync(string name);
        Task UpdateVacationStatusAsync(string name, string newStatus);
    }
}

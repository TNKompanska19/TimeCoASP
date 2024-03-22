using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Essentials.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimeCo.Data;
using TimeCo.Service.Schedules.Services;
using TimeCo.Service.Vacations.Models;

namespace TimeCo.Service.Vacations.Services
{
    public class VacationService : IVacationService
    {
        private readonly EntityContext context;
        private readonly ILogger<ScheduleService> logger;
        public VacationService(EntityContext context, ILogger<ScheduleService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<MutationResult> CreateVacationAsync(VacationDTO vacation)
        {
            try
            {
                var vacationEntity = new Vacation();
                vacationEntity.Name = vacation.Name;
                vacationEntity.Description = vacation.Description;
                vacationEntity.Status = "Pending";
                vacationEntity.StartDate = DateOnly.ParseExact(vacation.StartDate, "yyyy-MM-dd");
                vacationEntity.EndDate = DateOnly.ParseExact(vacation.EndDate, "yyyy-MM-dd");
                vacationEntity.UserId = vacation.UserId;
                this.context.Vacations.Add(vacationEntity);
                await this.context.SaveChangesAsync();

                return MutationResult.ResultFrom(vacationEntity.Id, "Vacation request sent");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Vacation request failed");
                return MutationResult.ResultFrom(null, "Vacation request failed");
            }
        }

        public async Task<List<VacationDTO>> FetchVacationsAsync()
        {
            var vacations = await this.context.Vacations
                .Include(v => v.User)
                .Select(v => new VacationDTO
                {
                    Name = v.Name,
                    Description = v.Description,
                    Status = v.Status,
                    StartDate = v.StartDate.ToString("yyyy-MM-dd"),
                    EndDate = v.EndDate.ToString("yyyy-MM-dd"),
                    UserId = v.UserId,
                    User = v.User
                })
                .ToListAsync();

            return vacations;
        }

        public async Task<Vacation?> GetVacationByNameAsync(string name)
        {
            Vacation? vacation = await this.context.Vacations
                .Include(v => v.User)
                .FirstOrDefaultAsync(v => v.Name == name);

            return vacation;
        }

        public async Task UpdateVacationStatusAsync(string name, string newStatus)
        {
            Vacation? vacation = await this.GetVacationByNameAsync(name);

            if (vacation == null)
            {
                throw new ArgumentException("Vacation not found");
            }

            vacation.Status = newStatus;
            await this.context.SaveChangesAsync();
        }
    }
}

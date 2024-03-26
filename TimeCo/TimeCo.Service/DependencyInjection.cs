using Microsoft.Extensions.DependencyInjection;
using TimeCo.Common.Contracts;
using TimeCo.Service.Identity;
using TimeCo.Service.Roles.Services;
using TimeCo.Service.Schedules.Services;
using TimeCo.Service.Vacations.Services;
namespace TimeCo.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IVacationService, VacationService>();
            return services;
        }
    }
}

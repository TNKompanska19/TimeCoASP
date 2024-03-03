using Microsoft.Extensions.DependencyInjection;
using TimeCo.Common.Contracts;
using TimeCo.Service.Identity.Services;
using TimeCo.Service.Identity.Services.ScheduleService;

namespace TimeCo.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUser, CurrentUser>();
            services.AddScoped<ScheduleService>();

            return services;
        }
    }
}

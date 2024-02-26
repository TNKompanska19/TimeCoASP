using TimeCo.Common.Contracts;
using TimeCo.Service.Identity.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TimeCo.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUser, CurrentUser>();

            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TimeCo.Data; // Make sure to include the namespace of your EntityContext class

namespace TimeCo.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<EntityContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), builder =>
                {
                    builder.MigrationsAssembly(typeof(EntityContext).Assembly.FullName);
                });
            });

            return services;
        }
    }
}

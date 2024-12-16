using eCommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceApp.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            string connctionString = "default";
            services.AddDbContext<AppDbContext>(
                option => option.UseSqlServer(configuration.GetConnectionString(connctionString),
                sqlOptions => {
                    sqlOptions.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure();
                }),
                ServiceLifetime.Scoped);

            return services;
        }

    }
}

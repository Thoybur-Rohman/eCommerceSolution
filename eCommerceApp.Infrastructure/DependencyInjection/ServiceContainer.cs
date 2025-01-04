using System.Runtime.CompilerServices;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;
using eCommerceApp.Infrastructure.Data;
using eCommerceApp.Infrastructure.Middleware;
using eCommerceApp.Infrastructure.Repositories;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceApp.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            string connctionString = "Default";
            services.AddDbContext<AppDbContext>(
                option => option.UseSqlServer(configuration.GetConnectionString(connctionString),
                sqlOptions => {
                    sqlOptions.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure();
                }).UseExceptionProcessor(),
                ServiceLifetime.Scoped);

            services.AddScoped <IGeneric<Product>, GenericRepository<Product>>();
            services.AddScoped <IGeneric<Category>, GenericRepository<Category>>();
            return services;
        }

        public static IApplicationBuilder UserInfrastructureService(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHanlingMiddleware>();
            return app;
        }

    }
}

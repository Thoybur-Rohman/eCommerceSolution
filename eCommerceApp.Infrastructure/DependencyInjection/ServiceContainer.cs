using System.Runtime.CompilerServices;
using eCommerceApp.Application.Service.Implementations.Login;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;
using eCommerceApp.Infrastructure.Data;
using eCommerceApp.Infrastructure.Middleware;
using eCommerceApp.Infrastructure.Repositories;
using eCommerceApp.Infrastructure.Service;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
            services.AddScoped(typeof(IAppLogger<>),typeof(SerilogLoggerAdapter<>));
            return services;
        }

        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }

    }
}

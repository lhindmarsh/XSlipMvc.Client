using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Infrastructure.Persistence.Context;
using XSlipMvc.Client.Infrastructure.Persistence.Repositories;
using XSlipMvc.Client.Infrastructure.Services;

namespace XSlipMvc.Client.Infrastructure.Persistence.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<XSlipContext>(options =>
                options.UseSqlServer(config.GetConnectionString("ConnectionString_Local"))
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information));

            services = AddServicesAndRepos(services);

            return services;
        }

        private static IServiceCollection AddServicesAndRepos(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IExpenseService, ExpenseService>();

            return services;
        }
    }
}
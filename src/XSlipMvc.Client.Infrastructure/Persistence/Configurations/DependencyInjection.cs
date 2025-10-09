using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Infrastructure.Persistence.Context;
using XSlipMvc.Client.Infrastructure.Persistence.Repositories;

namespace XSlipMvc.Client.Infrastructure.Persistence.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<XSlipContext>(options =>
                options.UseSqlServer(config.GetConnectionString("ConnectionString_Local")));

            services.AddScoped<IExpenseRepository, ExpenseRepository>();

            return services;
        }
    }
}
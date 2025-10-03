using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using XSlipMvc.Client.Infrastructure.Persistence.Context;

namespace XSlipMvc.Client.Infrastructure.Persistence.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<XSlipContext>(options =>
                options.UseSqlServer(config.GetConnectionString("ConnectionString_Local")));

            return services;
        }
    }
}
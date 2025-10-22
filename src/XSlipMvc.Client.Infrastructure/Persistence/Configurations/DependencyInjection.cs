using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Infrastructure.Identity;
using XSlipMvc.Client.Infrastructure.Persistence.Context;
using XSlipMvc.Client.Infrastructure.Persistence.Repositories;
using XSlipMvc.Client.Infrastructure.Persistence.Seeding;
using XSlipMvc.Client.Infrastructure.Services.BankService;
using XSlipMvc.Client.Infrastructure.Services.ExpenseService;

namespace XSlipMvc.Client.Infrastructure.Persistence.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var connection = config.GetConnectionString("ConnectionString_SQLExpress");

            //DbContext for SQL Server (Express)
            services.AddDbContext<XSlipContext>(options =>
                options.UseSqlServer(connection)
                .LogTo(Console.WriteLine, LogLevel.Information));

            //DbContext for Identity (same database)
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseSqlServer(connection));

            //Identity Registration
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();

            services = AddServicesAndRepos(services);

            return services;
        }

        private static IServiceCollection AddServicesAndRepos(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();

            services.AddScoped<IBankAccountService, BankAccountService>();
            services.AddScoped<IBankService, BankService>();

            services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
            services.AddScoped<IExpenseService, ExpenseService>();

            return services;
        }
    }
}
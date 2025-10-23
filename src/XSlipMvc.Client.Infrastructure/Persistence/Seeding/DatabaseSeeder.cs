using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using XSlipMvc.Client.Domain.Entities.Bank;
using XSlipMvc.Client.Domain.Entities.Expense;
using XSlipMvc.Client.Infrastructure.Identity;
using XSlipMvc.Client.Infrastructure.Persistence.Context;

namespace XSlipMvc.Client.Infrastructure.Persistence.Seeding
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly XSlipContext _context;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DatabaseSeeder> _logger;

        public DatabaseSeeder(XSlipContext context, IServiceProvider serviceProvider, ILogger<DatabaseSeeder> logger)
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            try
            {
                _logger.LogInformation("\n***Ensuring database is created...***\n");
                await _context.Database.EnsureCreatedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the database.");
                throw;
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                //Seed admin & user manager roles
                using var scope = _serviceProvider.CreateScope();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                _logger.LogInformation("\n***Seeding roles...***\n");

                // Ensure roles
                string[] roles = new[] { "Admin", "User" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        var r = new IdentityRole(role);
                        var res = await roleManager.CreateAsync(r);
                        if (!res.Succeeded) _logger.LogWarning("\nFailed to create role {Role}: {Errors}", role, string.Join(", ", res.Errors.Select(e => e.Description)));
                    }
                }

                // Create admin account
                string adminEmail = config["AdminUser:Email"];
                if (string.IsNullOrEmpty(adminEmail))
                {
                    throw new ArgumentNullException("AdminUser:Email", "Admin email must be configured in the configuration settings.\nSet a local secret to store the relevant email.");
                }

                var admin = await userManager.FindByEmailAsync(adminEmail);

                if (admin == null)
                {
                    string adminPassword = config["AdminUser:Password"];

                    if (string.IsNullOrEmpty(adminPassword) || string.IsNullOrEmpty(adminEmail))
                    {
                        throw new ArgumentNullException("AdminUser:Password", "Admin password and email must be configured in the configuration settings.\nSet a local secret to store the relevant details");
                    }

                    admin = new ApplicationUser
                    {
                        UserName = adminEmail,
                        Email = adminEmail,
                        DisplayName = "Administrator",
                        EmailConfirmed = true // set to true for seed admin; change as needed
                    };

                    var createRes = await userManager.CreateAsync(admin, adminPassword); // change to secure secret from secrets store
                    if (!createRes.Succeeded)
                    {
                        _logger.LogError("Failed to create admin user: {Errors}", string.Join(", ", createRes.Errors.Select(e => e.Description)));
                    }
                    else
                    {
                        _logger.LogInformation("\n***Admin user created.***\n");

                        // add to Admin role
                        var addRoleRes = await userManager.AddToRoleAsync(admin, "Admin");
                        if (!addRoleRes.Succeeded)
                        {
                            _logger.LogWarning("\n***Failed to add admin to role: {Errors}***\n", string.Join(", ", addRoleRes.Errors.Select(e => e.Description)));
                        }
                    }
                }
                else
                {
                    _logger.LogInformation("\n***Admin user already exists.***\n");
                }

                if (!_context.ExpenseCategories.Any())
                {
                    _context.ExpenseCategories.AddRange(
                    [
                        new ExpenseCategory { Category = "Food & Drink" },
                        new ExpenseCategory { Category = "Transport" },
                        new ExpenseCategory { Category = "Utilities" },
                        new ExpenseCategory { Category = "Entertainment/Leisure" },
                        new ExpenseCategory { Category = "Healthcare" }
                    ]);

                    await _context.SaveChangesAsync();
                }

                if (!_context.Banks.Any())
                {
                    _context.Banks.AddRange(
                    [
                        new Bank { Name = "Lloyds Bank" },
                        new Bank { Name = "Barclays" },
                        new Bank { Name = "HSBC" },
                        new Bank { Name = "NatWest" },
                        new Bank { Name = "Santander UK" },
                        new Bank { Name = "TSB Bank" },
                        new Bank { Name = "Virgin Money" },
                        new Bank { Name = "Metro Bank" },
                        new Bank { Name = "The Co-operative Bank" },
                        new Bank { Name = "Royal Bank of Scotland (RBS)" },
                        new Bank { Name = "Yorkshire Bank" },
                        new Bank { Name = "Clydesdale Bank" },
                        new Bank { Name = "Monzo" },
                        new Bank { Name = "Starling Bank" },
                        new Bank { Name = "Revolut" },
                        new Bank { Name = "Bank of America" },
                        new Bank { Name = "Chase" },
                        new Bank { Name = "Wells Fargo" },
                        new Bank { Name = "Citibank" }
                    ]);

                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                _logger.LogError("\n***An error occurred while seeding the database: the transaction has been rolled back.***\n");
                throw;
            }
        }
    }
}
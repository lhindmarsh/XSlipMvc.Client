using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using XSlipMvc.Client.Infrastructure.Identity;

namespace XSlipMvc.Client.Infrastructure.Persistence.Context
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationIdentityDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.BankOwners)
                .WithOne()
                .HasForeignKey(bo => bo.ApplicationUserId);
        }
    }
}
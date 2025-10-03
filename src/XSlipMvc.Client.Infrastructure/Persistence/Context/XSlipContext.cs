using Microsoft.EntityFrameworkCore;

using XSlipMvc.Client.Domain.Entities;

namespace XSlipMvc.Client.Infrastructure.Persistence.Context
{
    public class XSlipContext : DbContext
    {
        public XSlipContext(DbContextOptions<XSlipContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)");
        }

        public DbSet<Expense> Expenses { get; set; }
    }
}
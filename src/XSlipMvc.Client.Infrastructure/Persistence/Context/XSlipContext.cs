using Microsoft.EntityFrameworkCore;

using XSlipMvc.Client.Domain.Entities;
using XSlipMvc.Client.Domain.Entities.Expense;

namespace XSlipMvc.Client.Infrastructure.Persistence.Context
{
    public class XSlipContext : DbContext
    {
        public XSlipContext(DbContextOptions<XSlipContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Expense
            modelBuilder.Entity<Expense>()
                .Property(e => e.Description)
                .HasColumnType("nvarchar(255)");

            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Expense>()
                .HasOne(e => e.ExpenseCategory)
                .WithMany(ec => ec.Expenses)
                .HasForeignKey(e => e.ExpenseCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            //ExpenseCategory
            modelBuilder.Entity<ExpenseCategory>()
                .HasIndex(ec => ec.Category)
                .IsUnique();

            modelBuilder.Entity<ExpenseCategory>()
                .Property(ec => ec.Category)
                .HasColumnType("nvarchar(50)");

            //Bank
            modelBuilder.Entity<Bank>()
                .Property(b => b.Name)
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<Bank>()
                .Property(b => b.AccountNumber)
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<Bank>()
                .Property(b => b.Nickname)
                .HasColumnType("nvarchar(15)");
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        public DbSet<Bank> Banks { get; set; }
    }
}
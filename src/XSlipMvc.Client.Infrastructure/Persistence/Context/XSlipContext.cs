using Microsoft.EntityFrameworkCore;

using XSlipMvc.Client.Domain.Entities.Bank;
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
                .HasOne(e => e.ExpenseCategory)
                .WithMany(ec => ec.Expenses)
                .HasForeignKey(e => e.ExpenseCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Expense>()
                .Property(e => e.Description)
                .HasColumnType("nvarchar(255)");

            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)");

            //ExpenseCategory
            modelBuilder.Entity<ExpenseCategory>()
                .HasIndex(ec => ec.Category)
                .IsUnique();

            modelBuilder.Entity<ExpenseCategory>()
                .Property(ec => ec.Category)
                .HasColumnType("nvarchar(50)");

            //Bank
            modelBuilder.Entity<Bank>()
                .HasMany(b => b.BankDetails)
                .WithOne()
                .HasForeignKey(bd => bd.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bank>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<Bank>()
                .Property(b => b.Name)
                .HasColumnType("nvarchar(100)");

            //BankDetails
            modelBuilder.Entity<BankDetails>()
                .HasIndex(bd => bd.AccountNumber)
                .IsUnique();

            modelBuilder.Entity<BankDetails>()
                .Property(bd => bd.AccountNumber)
                .HasColumnType("nvarchar(20)");

            modelBuilder.Entity<BankDetails>()
                .Property(b => b.Nickname)
                .HasColumnType("nvarchar(15)");
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<BankDetails> BankDetails { get; set; }
    }
}
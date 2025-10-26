using Microsoft.EntityFrameworkCore;

using XSlipMvc.Client.Domain.Entities.Banks;
using XSlipMvc.Client.Domain.Entities.Expenses;
using XSlipMvc.Client.Domain.Entities.Identity;

namespace XSlipMvc.Client.Infrastructure.Persistence.Context
{
    public class XSlipDbContext : DbContext
    {
        public XSlipDbContext(DbContextOptions<XSlipDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ApplicationUser configuration is done in ApplicationIdentityDbContext
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("AspNetUsers", t => t.ExcludeFromMigrations(true));

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasMany(e => e.Banks)
                .WithMany(b => b.Owners)
                .UsingEntity(j => j.ToTable("BankOwners"));
            });

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
                .HasMany(b => b.BankAccounts)
                .WithOne()
                .HasForeignKey(ba => ba.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bank>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<Bank>()
                .Property(b => b.Name)
                .HasColumnType("nvarchar(100)");


            //BankAccount
            modelBuilder.Entity<BankAccount>()
                .HasIndex(ba => ba.AccountNumber)
                .IsUnique();

            modelBuilder.Entity<BankAccount>()
                .Property(ba => ba.AccountNumber)
                .HasColumnType("nvarchar(20)");

            modelBuilder.Entity<BankAccount>()
                .Property(ba => ba.SortCode)
                .HasColumnType("nvarchar(15)");

            modelBuilder.Entity<BankAccount>()
                .Property(ba => ba.Nickname)
                .HasColumnType("nvarchar(15)");

        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
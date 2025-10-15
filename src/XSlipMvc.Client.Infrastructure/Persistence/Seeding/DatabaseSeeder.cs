using XSlipMvc.Client.Domain.Entities.Bank;
using XSlipMvc.Client.Domain.Entities.Expense;
using XSlipMvc.Client.Infrastructure.Persistence.Context;

namespace XSlipMvc.Client.Infrastructure.Persistence.Seeding
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly XSlipContext _context;

        public DatabaseSeeder(XSlipContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
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
                throw;
            }
        }
    }
}
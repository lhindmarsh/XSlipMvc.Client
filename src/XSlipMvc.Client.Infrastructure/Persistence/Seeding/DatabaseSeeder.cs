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
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
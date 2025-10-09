using Microsoft.EntityFrameworkCore;

using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Domain.Entities;
using XSlipMvc.Client.Infrastructure.Persistence.Context;

namespace XSlipMvc.Client.Infrastructure.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly XSlipContext _context;

        public ExpenseRepository(XSlipContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
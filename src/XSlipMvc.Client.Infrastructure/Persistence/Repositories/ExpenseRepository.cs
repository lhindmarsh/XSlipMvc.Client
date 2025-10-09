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

        public void Add(Expense expense)
        {
            _context.Expenses.Add(expense);
        }

        public IEnumerable<Expense> GetAll()
        {
            return _context.Expenses.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
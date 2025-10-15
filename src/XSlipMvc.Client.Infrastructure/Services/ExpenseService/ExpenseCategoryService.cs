using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Domain.Entities.Expense;

namespace XSlipMvc.Client.Infrastructure.Services.ExpenseService
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IGenericRepository<ExpenseCategory> _repo;

        public ExpenseCategoryService(IGenericRepository<ExpenseCategory> repo)
        {
            _repo = repo;
        }

        public Task<ServiceResult> AddAsync(ExpenseCategory expense)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Delete(ExpenseCategory expense)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExpenseCategory>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}
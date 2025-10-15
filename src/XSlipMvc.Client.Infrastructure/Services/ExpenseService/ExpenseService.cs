using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Domain.Entities.Expense;

namespace XSlipMvc.Client.Infrastructure.Services.ExpenseService
{
    public class ExpenseService : IExpenseService
    {
        private readonly IGenericRepository<Expense> _repo;

        public ExpenseService(IGenericRepository<Expense> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<IEnumerable<Expense>> GetAllWithCategoryAsync()
        {
            return await _repo.GetAllIncludingAsync(e => e.ExpenseCategory);
        }

        public async Task<ServiceResult> AddAsync(Expense expense)
        {
            var result = new ServiceResult();

            if (expense == null)
            {
                result.AddError("Expense is invalid.");
            }

            if (!result.Success)
            {
                return result;
            }

            await _repo.AddAsync(expense);

            await _repo.SaveAsync();

            return ServiceResult.Ok();
        }

        public async Task<ServiceResult> Delete(Expense expense)
        {
            var result = new ServiceResult();

            if (expense.Id == 0)
            {
                result.AddError("Expense Id is invalid");
            }

            var foundExpense = await _repo.GetByIdAsync(expense.Id);
            if (foundExpense == null)
            {
                result.AddError($"Failed to find Expense with Id {expense.Id}");
            }

            if (!result.Success)
            {
                return result;
            }

            _repo.Delete(foundExpense);

            await _repo.SaveAsync();

            return ServiceResult.Ok();
        }
    }
}
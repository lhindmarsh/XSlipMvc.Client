using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Domain.Entities.Expenses;

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
            var serviceResult = new ServiceResult();

            if (expense == null)
            {
                serviceResult.AddError("Expense is invalid.");
            }

            if (!serviceResult.Success)
            {
                return serviceResult;
            }

            await _repo.AddAsync(expense);

            await _repo.SaveAsync();

            return ServiceResult.Ok();
        }

        public async Task<ServiceResult> Delete(Expense expense)
        {
            var serviceResult = new ServiceResult();

            if (expense.Id == 0)
            {
                serviceResult.AddError("Expense Id is invalid");
            }

            var foundExpense = await _repo.GetByIdAsync(expense.Id);
            if (foundExpense == null)
            {
                serviceResult.AddError($"Failed to find expense with Id {expense.Id}");
            }

            if (!serviceResult.Success)
            {
                return serviceResult;
            }

            try
            {
                _repo.Delete(foundExpense);

                await _repo.SaveAsync();

                return ServiceResult.Ok();
            }
            catch
            {
                serviceResult.AddError("An error occurred while deleting the expense.");

                return serviceResult;
            }
        }
    }
}
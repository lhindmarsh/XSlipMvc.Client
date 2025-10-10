using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Domain.Entities;

namespace XSlipMvc.Client.Infrastructure.Services
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

        public async Task<ServiceResult> AddAsync(Expense expense)
        {
            var result = new ServiceResult();

            if (expense == null)
            {
                result.AddError("Expense description is invalid.");
            }

            if (!result.Success)
            {
                return result;
            }

            await _repo.AddAsync(expense);

            await _repo.SaveAsync();

            return ServiceResult.Ok();
        }

        public ServiceResult Delete(Expense expense)
        {


            return ServiceResult.Ok();
        }
    }
}
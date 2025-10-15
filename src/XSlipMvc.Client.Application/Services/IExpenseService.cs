using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Domain.Entities.Expense;

namespace XSlipMvc.Client.Application.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllAsync();

        Task<IEnumerable<Expense>> GetAllWithCategoryAsync();

        Task<ServiceResult> AddAsync(Expense expense);

        Task<ServiceResult> Delete(Expense expense);

        //Task<ServiceResult> GetByIdAsync(int id);
    }
}
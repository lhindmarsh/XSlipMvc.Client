using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Domain.Entities;

namespace XSlipMvc.Client.Application.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllAsync();

        Task<ServiceResult> AddAsync(Expense expense);

        ServiceResult Delete(Expense expense);
    }
}
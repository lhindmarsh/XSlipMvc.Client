using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Domain.Entities.Expenses;

namespace XSlipMvc.Client.Application.Services
{
    public interface IExpenseCategoryService
    {
        Task<IEnumerable<ExpenseCategory>> GetAllAsync();

        Task<ServiceResult> AddAsync(ExpenseCategory expense);

        Task<ServiceResult> Delete(ExpenseCategory expense);
    }
}
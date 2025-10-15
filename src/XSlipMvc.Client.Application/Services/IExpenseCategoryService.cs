using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Domain.Entities.Expense;

namespace XSlipMvc.Client.Application.Services
{
    public interface IExpenseCategoryService
    {
        Task<IEnumerable<ExpenseCategory>> GetAllAsync();

        Task<ServiceResult> AddAsync(ExpenseCategory expense);

        Task<ServiceResult> Delete(ExpenseCategory expense);
    }
}
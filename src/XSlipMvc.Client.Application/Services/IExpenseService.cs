using XSlipMvc.Client.Domain.Entities;
using XSlipMvc.Client.Web.ViewModels.Expense;

namespace XSlipMvc.Client.Application.Services
{
    public interface IExpenseService
    {
        IEnumerable<ExpenseViewModel> GetAll();
    }
}
using XSlipMvc.Client.Domain.Entities;

namespace XSlipMvc.Client.Application.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllAsync();

        Task AddAsync(Expense expense);
    }
}
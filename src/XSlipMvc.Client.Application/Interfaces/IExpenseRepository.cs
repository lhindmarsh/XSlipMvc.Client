using XSlipMvc.Client.Domain.Entities;

namespace XSlipMvc.Client.Application.Interfaces
{
    public interface IExpenseRepository
    {
        //ASYNC**********

        Task<IEnumerable<Expense>> GetAllAsync();

        Task AddAsync(Expense expense);

        Task SaveAsync();
    }
}
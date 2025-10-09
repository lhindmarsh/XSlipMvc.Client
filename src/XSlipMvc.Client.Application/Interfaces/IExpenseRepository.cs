using XSlipMvc.Client.Domain.Entities;

namespace XSlipMvc.Client.Application.Interfaces
{
    public interface IExpenseRepository
    {
        //ASYNC**********

        IEnumerable<Expense> GetAll();

        void Add(Expense expense);

        void Save();
    }
}
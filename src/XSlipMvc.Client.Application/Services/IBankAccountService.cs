using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Domain.Entities.Bank;

namespace XSlipMvc.Client.Application.Services
{
    public interface IBankAccountService
    {
        Task<IEnumerable<BankAccount>> GetAllAsync();

        Task<ServiceResult> AddAsync(BankAccount bankAccount);

        Task<ServiceResult> Delete(BankAccount bankAccount);
    }
}
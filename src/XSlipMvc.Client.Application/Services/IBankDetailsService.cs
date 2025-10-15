using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Domain.Entities.Bank;

namespace XSlipMvc.Client.Application.Services
{
    public interface IBankDetailsService
    {
        Task<IEnumerable<BankDetails>> GetAllAsync();

        Task<ServiceResult> AddAsync(BankDetails bankDetails);

        Task<ServiceResult> Delete(BankDetails bankDetails);
    }
}
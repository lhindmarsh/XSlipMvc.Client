using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Domain.Entities.Bank;

namespace XSlipMvc.Client.Application.Services
{
    public interface IBankService
    {
        Task<IEnumerable<Bank>> GetAllAsync();

        Task<IEnumerable<Bank>> GetAllWithDetailsAsync();

        Task<ServiceResult> AddAsync(Bank expense);

        Task<ServiceResult> Delete(Bank expense);
    }
}
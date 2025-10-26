using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Domain.Entities.Banks;

namespace XSlipMvc.Client.Application.Services
{
    public interface IBankService
    {
        Task<IEnumerable<Bank>> GetAllAsync();

        Task<IEnumerable<Bank>> GetAllWithAccountsAsync();

        Task<Bank> GetByIdAsync(int id);

        Task<ServiceResult> AddAsync(Bank expense);

        Task<ServiceResult> Delete(int bankId);
    }
}
using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Domain.Entities.Bank;

namespace XSlipMvc.Client.Infrastructure.Services.BankService
{
    public class BankDetailsService : IBankDetailsService
    {
        private readonly IGenericRepository<BankDetails> _repo;

        public BankDetailsService(IGenericRepository<BankDetails> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<BankDetails>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public Task<ServiceResult> AddAsync(BankDetails bankDetails)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Delete(BankDetails bankDetails)
        {
            throw new NotImplementedException();
        }
    }
}
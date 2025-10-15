using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Domain.Entities.Bank;

namespace XSlipMvc.Client.Infrastructure.Services.BankService
{
    public class BankService : IBankService
    {
        private readonly IGenericRepository<Bank> _repo;
        
        public BankService(IGenericRepository<Bank> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Bank>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<IEnumerable<Bank>> GetAllWithDetailsAsync()
        {
            return await _repo.GetAllIncludingAsync(b => b.BankDetails);
        }

        public Task<ServiceResult> AddAsync(Bank expense)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Delete(Bank expense)
        {
            throw new NotImplementedException();
        }
    }
}
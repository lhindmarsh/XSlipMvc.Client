using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Domain.Entities.Bank;

namespace XSlipMvc.Client.Infrastructure.Services.BankService
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IGenericRepository<BankAccount> _repo;

        public BankAccountService(IGenericRepository<BankAccount> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<BankAccount>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public Task<ServiceResult> AddAsync(BankAccount bankAccount)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Delete(BankAccount bankAccount)
        {
            throw new NotImplementedException();
        }
    }
}
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

        public async Task<ServiceResult> AddAsync(BankAccount bankAccount)
        {
            var serviceResult = new ServiceResult();

            if (bankAccount.BankId == 0)
            {
                serviceResult.AddError("Bank Id is invalid.");
            }

            if (!serviceResult.Success)
            {
                return serviceResult;
            }

            try
            {
                await _repo.AddAsync(bankAccount);

                await _repo.SaveAsync();

                return ServiceResult.Ok();
            }
            catch
            {
                serviceResult.AddError("An error occurred while adding the bank account.");

                return serviceResult;
            }
        }

        public Task<ServiceResult> Delete(BankAccount bankAccount)
        {
            throw new NotImplementedException();
        }
    }
}
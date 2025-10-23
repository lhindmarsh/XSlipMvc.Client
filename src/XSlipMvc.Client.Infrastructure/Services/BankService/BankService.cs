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

        public async Task<IEnumerable<Bank>> GetAllWithAccountsAsync()
        {
            return await _repo.GetAllIncludingAsync(b => b.BankAccounts);
        }

        public async Task<Bank> GetByIdAsync(int id)
        {
            var serviceResult = new ServiceResult();

            if (id == 0)
            {
                serviceResult.AddError("Bank Id is invalid.");
            }

            var foundBank = await _repo.GetByIdAsync(id);
            if (foundBank == null)
            {
                serviceResult.AddError($"Failed to find bank with Id {id}");
            }

            return serviceResult.Success ? foundBank : null;
        }

        public Task<ServiceResult> AddAsync(Bank bank)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> Delete(Bank bank)
        {
            var serviceResult = new ServiceResult();

            if (bank.Id == 0)
            {
                serviceResult.AddError("Bank Id is invalid.");
            }

            var foundBank = await _repo.GetByIdAsync(bank.Id);
            if (foundBank == null)
            {
                serviceResult.AddError($"Failed to find bank with Id {bank.Id}");
            }

            if (!serviceResult.Success)
            {
                return serviceResult;
            }

            try
            {
                _repo.Delete(foundBank);

                await _repo.SaveAsync();

                return ServiceResult.Ok();
            }
            catch
            {
                serviceResult.AddError("An error occurred while deleting the bank.");

                return serviceResult;
            }
        }
    }
}
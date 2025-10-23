using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using XSlipMvc.Client.Application.Common;
using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Domain.Entities.Bank;
using XSlipMvc.Client.Web.ViewModels.Bank;

namespace XSlipMvc.Client.Web.Controllers
{
    public class BanksController : Controller
    {
        private readonly IBankService _bankService;
        private readonly IBankAccountService _bankAccountsService;

        public BanksController(IBankService bankService, IBankAccountService bankAccountsService)
        {
            _bankService = bankService;
            _bankAccountsService = bankAccountsService;
        }

        public async Task<IActionResult> BankList()
        {
            var banks = await _bankService.GetAllWithAccountsAsync();

            var viewModel = banks.Select(b => new BankViewModel
            {
                Id = b.Id,
                Name = b.Name,
                BankAccounts = b.BankAccounts.Select(ba => new SelectListItem
                {
                    Value = ba.Id.ToString(),
                    Text = ba.AccountNumber
                })
            }).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> EditBank(int id)
        {
            var bank = (await _bankService.GetAllWithAccountsAsync()).FirstOrDefault(b => b.Id == id);
            if (bank == null)
            {
                return NotFound();
            }

            var viewModel = new BankAccountViewModel
            {
                BankId = bank.Id,
                //BankDetails = bank.BankDetails.Select(bd => new BankDetailItemViewModel
                //{
                //    Id = bd.Id,
                //    AccountNumber = bd.AccountNumber,
                //    AccountType = bd.AccountType,
                //    Balance = bd.Balance,
                //    CreatedDate = bd.CreatedDate
                //}).ToList()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> RemoveBank(BankViewModel bankViewModel)
        {
            var serviceResult = new ServiceResult();

            if (bankViewModel.Id == 0)
            {
                serviceResult.AddError("Bank Id is invalid.");

                return RedirectToAction("BankList");
            }

            var result = await _bankService.Delete(bankViewModel.Id);

            if (!result.Success)
            {
                serviceResult.AddError($"Failed to remove bank with Id {bankViewModel.Id}");
                TempData["MessageType"] = "Error";
                TempData["MessageText"] = $"{serviceResult.Errors.First()}";
            }
            else
            {
                TempData["MessageType"] = "Success";
                TempData["MessageText"] = $"Bank ({bankViewModel.Name}) with Id {bankViewModel.Id} removed successfully.";
            }

            return RedirectToAction("BankList");
        }

        public async Task<IActionResult> CreateEditBankAccounts(BankAccountViewModel bankAccountViewModel)
        {
            var serviceResult = new ServiceResult();

            if (bankAccountViewModel.Id == 0)
            {
                serviceResult.AddError("Bank account details are not valid.");

                return View(bankAccountViewModel);
            }

            var bank = await _bankService.GetByIdAsync(bankAccountViewModel.Id);

            if (bank == null)
            {
                serviceResult.AddError($"Bank with Id {bankAccountViewModel.Id} not found.");
                return View(bankAccountViewModel);
            }


            if (!ModelState.IsValid)
            {
                return View(bankAccountViewModel);
            }

            var bankAccount = new BankAccount
            {
                BankId = bankAccountViewModel.Id,
                AccountNumber = bankAccountViewModel.AccountNumber,
                SortCode = bankAccountViewModel.SortCode,
                Nickname = bankAccountViewModel?.Nickname
            };

            var result = await _bankAccountsService.AddAsync(bankAccount);

            if (!result.Success)
            {
                serviceResult.AddError("Failed to add bank account.");
                foreach (var error in result.Errors)
                {
                    serviceResult.AddError(error);
                }

                TempData["MessageType"] = "Error";
                TempData["MessageText"] = $"{serviceResult.Errors.First()}";

                return View("CreateEditBankAccounts", bankAccountViewModel);
            }
            else
            {
                TempData["MessageType"] = "Success";
                TempData["MessageText"] = $"Bank account ({bankAccountViewModel.AccountNumber}) added successfully.";
            }

            return View("CreateEditBankAccounts", bankAccountViewModel);
        }

        //[HttpPost]
        //public async Task<IActionResult> EditBankDetails(BankDetailsViewModel bankDetails)
        //{
        //    var serviceResult = new ServiceResult();

        //    if (!ModelState.IsValid)
        //    {
        //        serviceResult.AddError("Bank details are not valid.");

        //        return View(BankDetails);
        //    }
        //}
    }
}
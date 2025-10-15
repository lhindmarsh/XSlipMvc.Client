using Microsoft.AspNetCore.Mvc;

using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Web.ViewModels.Bank;

namespace XSlipMvc.Client.Web.Controllers
{
    public class BanksController : Controller
    {
        private readonly IBankService _bankService;
        private readonly IBankDetailsService _bankDetailsService;

        public BanksController(IBankService bankService, IBankDetailsService bankDetailsService)
        {
            _bankService = bankService;
            _bankDetailsService = bankDetailsService;
        }

        public async Task<IActionResult> Index()
        {
            var banks = await _bankService.GetAllWithDetailsAsync();
            var viewModel = banks.Select(b => new BankViewModel
            {
                Id = b.Id,
                Name = b.Name,
            }).ToList();

            return View(viewModel);
        }
    }
}
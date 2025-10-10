using Microsoft.AspNetCore.Mvc;

using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Web.ViewModels.Expense;

namespace XSlipMvc.Client.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _service;

        public ExpensesController(IExpenseService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _service.GetAllAsync();

            var viewModel = expenses
                .Select(e => new ExpenseViewModel
                {
                    Description = e.Description,
                    Amount = e.Amount,
                    Category = e.Category,
                    Date = e.Date
                }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ExpenseViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ExpenseViewModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return View(model);
            }

            var expense = new Domain.Entities.Expense
            {
                Description = model.Description,
                Amount = model.Amount,
                Category = model.Category,
                Date = model.Date
            };

            var result = await _service.AddAsync(expense);

            if (!result.Success)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);

                    return View(model);
                }
            }

            TempData["Success"] = "Expense added successfully";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExpense(ExpenseViewModel model)
        {
            var expense = new Domain.Entities.Expense
            {
                Id = model.Id
            };

            expense.Id = 2010;

            var result = await _service.Delete(expense);

            if (!result.Success)
            {
                return RedirectToAction("Index");
            }

            TempData["Success"] = "Expense removed successfully";

            return RedirectToAction("Index");
        }
    }
}
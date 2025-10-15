using Microsoft.AspNetCore.Mvc;

using XSlipMvc.Client.Application.Services;
using XSlipMvc.Client.Domain.Entities.Expense;
using XSlipMvc.Client.Web.ViewModels.Expense;

namespace XSlipMvc.Client.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _service;
        private readonly IExpenseCategoryService _expenseCategoryService;

        public ExpensesController(IExpenseService service, IExpenseCategoryService categoryService)
        {
            _service = service;
            _expenseCategoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _service.GetAllWithCategoryAsync();

            var viewModel = expenses
                .Select(e => new ExpenseViewModel
                {
                    Id = e.Id,
                    Description = e.Description,
                    Amount = e.Amount,
                    ExpenseCategoryId = e.ExpenseCategoryId,
                    ExpenseCategoryName = e.ExpenseCategory?.Category ?? string.Empty,
                    Date = e.Date
                }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _expenseCategoryService.GetAllAsync();

            var viewModel = new ExpenseViewModel
            {
                ExpenseCategories = categories.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Category
                })
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ExpenseViewModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return View(model);
            }

            var expense = new Expense
            {
                Description = model.Description,
                Amount = model.Amount,
                ExpenseCategoryId = model.ExpenseCategoryId,
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

            TempData["MessageType"] = "Success"; // or "Error", "Warning", "Info"
            TempData["MessageText"] = "Expense added successfully.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExpense(List<int> selectedIds)
        {
            if (selectedIds == null || selectedIds.Count == 0)
            {
                TempData["MessageType"] = "Warning";
                TempData["MessageText"] = "No expenses were selected.";

                return RedirectToAction("Index");
            }

            var failed = new List<int>();

            foreach (var id in selectedIds)
            {
                var result = await _service.Delete(new Expense { Id = id });

                if (!result.Success)
                {
                    failed.Add(id);
                }
            }

            if (failed.Count > 0)
            {
                TempData["MessageType"] = "Error";
                TempData["MessageText"] = $"Some expenses could not be removed: {string.Join(", ", failed)}.";
            }
            else
            {
                TempData["MessageType"] = "Success";
                TempData["MessageText"] = "Selected expenses removed successfully.";
            }

            return RedirectToAction("Index");
        }
    }
}
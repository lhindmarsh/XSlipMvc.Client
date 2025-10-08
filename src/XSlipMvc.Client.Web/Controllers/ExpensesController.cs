using Microsoft.AspNetCore.Mvc;

using XSlipMvc.Client.Infrastructure.Persistence.Context;
using XSlipMvc.Client.Web.ViewModels.Expense;

namespace XSlipMvc.Client.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly XSlipContext _context;

        public ExpensesController(XSlipContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var expenses = _context.Expenses
                .Select(e => new ExpenseViewModel
                {
                    Description = e.Description,
                    Amount = e.Amount,
                    Category = e.Category,
                    Date = e.Date
                }).ToList();

            return View(expenses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ExpenseViewModel());
        }

        [HttpPost]
        public IActionResult Add(ExpenseViewModel model)
        {
            if (ModelState.IsValid && model != null)
            {
                var expense = new Domain.Entities.Expense
                {
                    Description = model.Description,
                    Amount = model.Amount,
                    Category = model.Category,
                    Date = model.Date
                };

                _context.Expenses.Add(expense);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
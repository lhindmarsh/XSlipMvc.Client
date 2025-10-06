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
    }
}
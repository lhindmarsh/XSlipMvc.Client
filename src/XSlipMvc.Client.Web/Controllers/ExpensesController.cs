using Microsoft.AspNetCore.Mvc;

using XSlipMvc.Client.Infrastructure.Persistence.Context;

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
            var expenses = _context.Expenses.ToList();

            return View(expenses);
        }
    }
}
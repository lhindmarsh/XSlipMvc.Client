using Microsoft.AspNetCore.Mvc;

using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Web.ViewModels.Expense;

namespace XSlipMvc.Client.Web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseRepository _repository;

        public ExpensesController(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var expenses = _repository.GetAll()
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

                _repository.Add(expense);
                _repository.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
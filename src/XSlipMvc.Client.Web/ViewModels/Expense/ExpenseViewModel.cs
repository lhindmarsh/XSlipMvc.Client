using Microsoft.AspNetCore.Mvc.Rendering;

namespace XSlipMvc.Client.Web.ViewModels.Expense
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public decimal Amount { get; set; }

        public int ExpenseCategoryId { get; set; }

        public string ExpenseCategoryName { get; set; } = string.Empty;

        //[DisplayFormat(DataFormatString = "{dd-MMM-yyyy}")]
        public DateTime Date { get; set; } = DateTime.Now;

        //Populate the ExpenseView model with ExpenseCategory list
        public IEnumerable<SelectListItem>? ExpenseCategories { get; set; }
    }
}
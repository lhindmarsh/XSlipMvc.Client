using System.ComponentModel.DataAnnotations;

namespace XSlipMvc.Client.Web.ViewModels.Expense
{
    public class ExpenseViewModel
    {
        [Display(Name = "Expense Description")]
        public string Description { get; set; }

        [Display(Name = "Expense Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "Expense Category")]
        public string Category { get; set; }

        [Display(Name = "Date Added")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
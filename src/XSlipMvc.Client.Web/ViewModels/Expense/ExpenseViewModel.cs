using System.ComponentModel.DataAnnotations;

namespace XSlipMvc.Client.Web.ViewModels.Expense
{
    public class ExpenseViewModel
    {
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Amount { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Category { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; }
    }
}
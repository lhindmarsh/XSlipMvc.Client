using System.ComponentModel.DataAnnotations;

namespace XSlipMvc.Client.Web.ViewModels.Expense
{
    public class ExpenseViewModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string CategoryName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; }
    }
}
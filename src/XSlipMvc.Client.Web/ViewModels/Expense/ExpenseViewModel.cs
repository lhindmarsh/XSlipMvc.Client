namespace XSlipMvc.Client.Web.ViewModels.Expense
{
    public class ExpenseViewModel
    {
        public string Description { get; set; } = null!;

        public decimal Amount { get; set; }

        public string Category { get; set; } = null!;

        //[DisplayFormat(DataFormatString = "{dd-MMM-yyyy}")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
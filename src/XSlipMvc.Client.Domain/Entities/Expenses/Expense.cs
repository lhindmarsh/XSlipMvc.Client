using System.Text.Json.Serialization;

namespace XSlipMvc.Client.Domain.Entities.Expenses
{
    public class Expense
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        //[Range(typeof(decimal), "1.00", "5000", ErrorMessage = "Amount minimum is 1.00")]
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        public int ExpenseCategoryId { get; set; }

        public ExpenseCategory ExpenseCategory { get; set; } = null!;

        [JsonPropertyName("date")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
namespace XSlipMvc.Client.Domain.Entities.Expense
{
    public class ExpenseCategory
    {
        public int Id { get; set; }

        public string Category { get; set; } = null!;

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
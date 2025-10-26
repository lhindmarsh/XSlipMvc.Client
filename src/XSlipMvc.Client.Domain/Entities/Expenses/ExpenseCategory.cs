namespace XSlipMvc.Client.Domain.Entities.Expenses
{
    public class ExpenseCategory
    {
        public int Id { get; set; }

        public string Category { get; set; } = null!;

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
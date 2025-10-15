namespace XSlipMvc.Client.Domain.Entities.Bank
{
    public class Bank
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Nickname { get; set; }

        public ICollection<BankDetails> BankDetails { get; set; } = new List<BankDetails>();
    }
}
namespace XSlipMvc.Client.Domain.Entities.Bank
{
    public class Bank
    {
        public int Id { get; private set; }

        public string Name { get; set; } = null!;

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    }
}
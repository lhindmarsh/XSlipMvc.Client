using XSlipMvc.Client.Domain.Entities.Identity;

namespace XSlipMvc.Client.Domain.Entities.Banks
{
    public class Bank
    {
        public int Id { get; private set; }

        public string Name { get; set; } = null!;

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

        public virtual ICollection<ApplicationUser> Owners { get; set; } = new List<ApplicationUser>();

        public Bank() { }

        public Bank(int id, string name, ICollection<BankAccount> bankAccounts)
        {
            Id = id;
            Name = name;
            BankAccounts = bankAccounts;
        }
    }
}
namespace XSlipMvc.Client.Domain.Entities.Bank
{
    public class BankOwner
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public string ApplicationUserId { get; set; } = null!;

        // Navigation properties
        public Bank Bank { get; set; } = null!;
        // No direct reference to ApplicationUser (Domain cannot reference Infrastructure)
    }
}
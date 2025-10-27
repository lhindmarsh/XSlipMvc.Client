namespace XSlipMvc.Client.Domain.Entities.Banks
{
    public class BankAccount
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; } = null!;

        public string SortCode { get; set; } = string.Empty;

        public string? Nickname { get; set; }

        public int BankId { get; set; }

        public BankAccount() { }

        public BankAccount(int id, string accountNumber, string sortCode, string? nickname, int bankId)
        {
            Id = id;
            AccountNumber = accountNumber;
            SortCode = sortCode;
            Nickname = nickname;
            BankId = bankId;
        }
    }
}
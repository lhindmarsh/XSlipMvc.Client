namespace XSlipMvc.Client.Domain.Entities.Bank
{
    public class BankDetails
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public string SortCode { get; set; }

        public int BankId { get; set; }
    }
}
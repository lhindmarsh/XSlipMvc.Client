namespace XSlipMvc.Client.Web.ViewModels.Bank
{
    public class BankDetailsViewModel
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = null!;
        public string SortCode { get; set; } = string.Empty;
        public string? Nickname { get; set; }
        public int BankId { get; set; }
    }
}
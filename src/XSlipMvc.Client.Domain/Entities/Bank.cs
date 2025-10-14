namespace XSlipMvc.Client.Domain.Entities
{
    public class Bank
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string AccountNumber { get; set; } = null!;

        public string? Nickname { get; set; }
    }
}
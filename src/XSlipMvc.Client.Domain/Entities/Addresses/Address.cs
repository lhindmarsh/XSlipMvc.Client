namespace XSlipMvc.Client.Domain.Entities.Addresses
{
    public class Address
    {
        public int Id { get; set; }

        public string Address1 { get; set; } = null!;

        public string Address2 { get; set; } = null!;

        public string? Address3 { get; set; }

        public string TownCity { get; set; } = null!;
    }
}
namespace XSlipMvc.Client.Web.Models
{
    using System.Text.Json.Serialization;

    public class Expense
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("date")]
        public string Category { get; set; } = null!;
    }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XSlipMvc.Client.Domain.Entities
{
    public class Expense
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "1.00", "5000", ErrorMessage = "Amount minimum is 1.00")]
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("date")]
        public string Category { get; set; } = null!;

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
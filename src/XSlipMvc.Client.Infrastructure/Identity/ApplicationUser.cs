using Microsoft.AspNetCore.Identity;

using XSlipMvc.Client.Domain.Entities.Bank;

namespace XSlipMvc.Client.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }

        public ICollection<BankOwner> BankOwners { get; set; } = new List<BankOwner>();
    }
}
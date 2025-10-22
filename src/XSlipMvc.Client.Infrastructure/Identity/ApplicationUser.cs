using Microsoft.AspNetCore.Identity;

namespace XSlipMvc.Client.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }
    }
}
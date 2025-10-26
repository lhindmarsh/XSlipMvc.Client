using Microsoft.AspNetCore.Identity;

using XSlipMvc.Client.Domain.Entities.Banks;

namespace XSlipMvc.Client.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }

        //Navigation property: a user can have multiple bank ownerships
        public virtual ICollection<Bank> Banks { get; set; } = new List<Bank>();
    }
}
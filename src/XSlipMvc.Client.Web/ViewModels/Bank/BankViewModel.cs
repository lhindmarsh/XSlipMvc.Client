using Microsoft.AspNetCore.Mvc.Rendering;

namespace XSlipMvc.Client.Web.ViewModels.Bank
{
    public class BankViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int BankDetailsId { get; set; }

        public IEnumerable<SelectListItem>? BankAccounts { get; set; }
    }
}
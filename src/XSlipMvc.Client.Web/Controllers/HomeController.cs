using Microsoft.AspNetCore.Mvc;

namespace XSlipMvc.Client.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToPage("/Account/Login", new { area = "Identity" });

        }
    }
}
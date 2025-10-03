using Microsoft.AspNetCore.Mvc;

namespace XSlipMvc.Client.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

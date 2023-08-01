using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

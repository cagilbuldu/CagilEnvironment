using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.ViewComponents
{
    public class _DashboardNavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

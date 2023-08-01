using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.ViewComponents
{
    public class _DashboardHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

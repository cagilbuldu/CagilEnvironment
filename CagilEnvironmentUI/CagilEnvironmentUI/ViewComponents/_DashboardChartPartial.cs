using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.ViewComponents
{
    public class _DashboardChartPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

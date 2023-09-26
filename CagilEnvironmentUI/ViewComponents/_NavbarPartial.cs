using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.ViewComponents
{
	public class _NavbarPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

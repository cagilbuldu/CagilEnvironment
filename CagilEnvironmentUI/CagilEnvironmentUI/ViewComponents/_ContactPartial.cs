using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.ViewComponents
{
	public class _ContactPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

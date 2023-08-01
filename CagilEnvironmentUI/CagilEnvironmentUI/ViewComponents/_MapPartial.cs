using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.ViewComponents
{
	public class _MapPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			CagilEnvironmentContext context = new CagilEnvironmentContext();
			var values = context.Addresses.Select(x=>x.MapInfo).FirstOrDefault();
			ViewBag.v = values;
			return View();
		}
	}
}

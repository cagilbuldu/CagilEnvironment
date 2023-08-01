using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.ViewComponents
{
	public class _SocialMediaPartial:ViewComponent
	{
		private readonly ISocialMediaService _socialMediaService;
		public _SocialMediaPartial(ISocialMediaService socialMediaservice)
		{
			_socialMediaService = socialMediaservice;
		}

		public IViewComponentResult Invoke()
		{
			var values = _socialMediaService.GetAll();
			return View(values);
		}
	}
}

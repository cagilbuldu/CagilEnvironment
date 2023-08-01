using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.ViewComponents
{
    public class _DashboardOverviewPartial:ViewComponent
    {
        CagilEnvironmentContext c = new CagilEnvironmentContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.teamCount = c.Teams.Count();
            ViewBag.serviceCount = c.Services.Count();
            ViewBag.messageCount = c.Contacts.Count();

            //ViewBag.newstrue = c.AllNews.Where(x=>x.Status ==true).Count();
            //ViewBag.newsfalse = c.AllNews.Where(x => x.Status == false).Count();


            ViewBag.elektrik = c.Teams.Where(x=>x.Title == "Elektrik Mühendisi").Select(y=>y.PersonName).FirstOrDefault();
            ViewBag.cevre = c.Teams.Where(x => x.Title == "Çevre Mühendisi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.makine = c.Teams.Where(x => x.Title == "Makine Mühendisi").Select(y => y.PersonName).FirstOrDefault();

            return View();
        }
    }
}

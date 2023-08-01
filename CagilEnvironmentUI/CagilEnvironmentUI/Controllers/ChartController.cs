using CagilEnvironmentUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductChart()
        {
            List<ProductClass> productClasses= new List<ProductClass>();
            productClasses.Add(new ProductClass()
            {
                productname = "AAA Solar Panel",
                productvalue = 2000
            });
            productClasses.Add(new ProductClass()
            {
                productname = "BBB Solar Panel",
                productvalue = 2500
            });
            productClasses.Add(new ProductClass()
            {
                productname = "CCC Solar Panel",
                productvalue = 2700
            });
            productClasses.Add(new ProductClass()
            {
                productname = "DDD Solar Panel",
                productvalue = 3100
            });
            productClasses.Add(new ProductClass()
            {
                productname = "EEE Solar Panel",
                productvalue = 5500
            });
            return Json(new {jsonlist= productClasses});
        }
    }
}

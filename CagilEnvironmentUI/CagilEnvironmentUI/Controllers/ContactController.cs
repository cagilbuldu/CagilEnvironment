using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.GetAll();
            return View(values);
        }

        public IActionResult DeleteMessage(int id)
        {
            var values = _contactService.GetById(id);
            _contactService.Delete(values);
            return RedirectToAction("Index");
        }
        public IActionResult MessageDetails(int id)
        {
            var value = _contactService.GetById(id);
            return View(value);
        }
    }
}

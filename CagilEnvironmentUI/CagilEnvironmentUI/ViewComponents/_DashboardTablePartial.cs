﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CagilEnvironmentUI.ViewComponents
{
    public class _DashboardTablePartial: ViewComponent
    {
        private readonly IContactService _contactService;
        public _DashboardTablePartial(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _contactService.GetAll();
            return View(values);
        }
    }
}

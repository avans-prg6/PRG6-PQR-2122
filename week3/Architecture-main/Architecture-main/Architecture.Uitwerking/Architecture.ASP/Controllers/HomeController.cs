using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Architecture.ASP.Models;
using Architecture.BusinessLayer;
using Architecture.BusinessLayer.Interfaces;
using Architecture.Domain;

namespace Architecture.ASP.Controllers
{
    public class HomeController : Controller
    {
        private IBeschikbaarheidService _beschikbaarheid;
        private IVakantieService _vakantie;
        private MyContext _context;

        public HomeController(IBeschikbaarheidService beschikbaarheid, IVakantieService vakantie, MyContext context)
        {
            _beschikbaarheid = beschikbaarheid;
            _vakantie = vakantie;
            _context = context;
        }

        public IActionResult Index()
        {
            var items = _context.VakantieDagen.ToList();
            ViewBag.items = items;
            return View(new FormViewModel());
        }

        [HttpPost]
        public IActionResult PostForm(FormViewModel form)
        {
            //Validatie, kan natuurlijk slimmer dan dit!
            if (form.IsHoliday)
            {
                if (form.Omschrijving == null)
                {
                    ModelState.AddModelError("Omschrijving", "Omschrijving is verplicht als het om een vakantie gaat");
                }

                if (form.IsRepeat)
                {
                    ModelState.AddModelError("IsRepeat", "Vakanties kunnen niet herhaald worden");
                }
            }
            else
            {
                if(form.Start.Date != form.Einde.Date)
                {
                    //Dit is eignelijk een business rule... in de toekomst moeten we kijken of we deze niet kunnen verplaatsen naar de busines layer
                    ModelState.AddModelError("Einde", "Beschikbaarheid moet op dezelfde dag vallen");
                }

                if (form.IsRepeat && !form.AantalKeer.HasValue)
                {
                    ModelState.AddModelError("AantalKeer", "AantalKeer moet ingevuld worden als IsRepeat aangevinkt is");
                }
            }

            //dit doen we natuurlijk pas na het toevoegen van deze custom errors
            if (!ModelState.IsValid)
            {
                // The user didn't select any value => redisplay the form
                return View("Index", form);
            }

            if (form.IsHoliday)
            {
                _vakantie.PlanVakantie(form.Start, form.Einde, form.Omschrijving);
            }
            else
            {
                form.AantalKeer = form.AantalKeer.HasValue ? form.AantalKeer : 1;

                //Dit hadden we ook in de service kunnen doen
                for (int i = 0; i < form.AantalKeer; i++)
                {
                    _beschikbaarheid.ZetBeschikbaarheid(form.Start.AddDays(i * 7), form.Einde.AddDays(i * 7));
                }
            }



            return View("Response", form);
        }

    }
}

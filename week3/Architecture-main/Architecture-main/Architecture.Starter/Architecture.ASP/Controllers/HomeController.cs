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

namespace Architecture.ASP.Controllers
{
    public class HomeController : Controller
    {
        //Deze gaan we dadelijk initaliseren met DI
        //private IBeschikbaarheidService _beschikbaarheid;
        //private IVakantieService _vakantie;

        //Teken het formulier
        public IActionResult Index()
        {
            return View(new FormViewModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostForm(FormViewModel form)
        {
            //Validatie eerst

            //dit doen we natuurlijk pas na het toevoegen van deze custom errors
            //if (!ModelState.IsValid)

            //Vakantie of Holiday service aanroepen

            return View("Response", form);
        }
    }
}

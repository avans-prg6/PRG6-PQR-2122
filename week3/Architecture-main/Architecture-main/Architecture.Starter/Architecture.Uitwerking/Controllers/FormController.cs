using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.ASP.Controllers
{
    public class FormController : Controller
    {
        public ActionResult Index()
        {
            return View("Form");
        }
    }
}

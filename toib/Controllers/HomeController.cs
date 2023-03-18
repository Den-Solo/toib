using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToibSolovyov.Models;

namespace ToibSolovyov.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(HomePage model)
        {
            return View(new HomePage());
        }

        public ActionResult Test1(HomePage home, Test model)
        {
            model.Output = model.Input;
            return PartialView("TestRes", model.Input);
        }

        public ActionResult Test2(HomePage home, Test model)
        {
            model.Output = model.Input;
            return PartialView("TestRes", model.Input);
        }
    }
}
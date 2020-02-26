using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();

            model.Name = name ?? "No Name";

            model.Message = System.Configuration.ConfigurationManager.AppSettings["message"];

            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JotForm;

namespace jotform.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var jotformAPIClient = new JotForm.APIClient("09c407aeefdcd0b918b282df269fe015");

            var userInfo = jotformAPIClient.getUser();
            return View();
        }
    }
}
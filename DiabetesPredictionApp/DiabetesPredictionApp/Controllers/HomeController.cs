using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiabetesPredictionApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
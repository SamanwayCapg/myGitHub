using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pecunia.MVC.Models;

namespace Pecunia.MVC.Controllers
{
    public class HomeLoansController : Controller
    {
        // URL: HomeLoans/Apply
        public ActionResult Apply()
        {
            HomeLoanViewModel homeLoanViewModel = new HomeLoanViewModel()
            {

            };
            return View(homeLoanViewModel);
        }
    }
}
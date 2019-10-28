
using Pecunia.PresentationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pecunia.PresentationMVC.Controllers
{
    public class CarLoanApplyController : Controller
    {
        // URL: CarLoanApply/apply
        public ActionResult Apply()
        {
            CarLoanApplyModel carLoan = new CarLoanApplyModel();
            return View(carLoan);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pecunia.MVC.Models;

namespace Pecunia.MVC.Controllers
{
    public class CarLoansController : Controller
    {
        // URL: CarLoans/Apply
        public ActionResult Apply()
        {
            //creating and initializing view model object
            CarLoanViewModel carLoanViewModel = new CarLoanViewModel()
            {
                //initialize properties here
                LoanID = Guid.NewGuid()

            };

            //calling view and passing viewModel objct to view
            return View(carLoanViewModel);
        }
    }
}

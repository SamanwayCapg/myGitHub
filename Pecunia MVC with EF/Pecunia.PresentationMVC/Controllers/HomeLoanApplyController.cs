using Pecunia.PresentationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pecunia.PresentationMVC.Controllers
{
    public class HomeLoanApplyController : Controller
    {
        // GET: HomeLoanApply/apply
        public ActionResult Apply()
        {
            HomeLoanApplyModel homeLoanApplyModel = new HomeLoanApplyModel();
            return View(homeLoanApplyModel);
        }
    }
}
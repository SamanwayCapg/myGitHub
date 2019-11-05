using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pecunia.PresentationMVC.Models;

namespace Pecunia.PresentationMVC.Controllers
{
    public class ShowMessageController : Controller
    {
        // URL: ShowMessage/display
        public ActionResult DisplayMessage(string message)
        {
            ShowMessageModel showMessageView = new ShowMessageModel()
            {
                Message = message
            };

            return View(showMessageView);
        }

        [HttpPost]
        public ActionResult Redirect()
        {
            return RedirectToAction("EmployeeIndex", "EmployeeHome");
        }


        /////////////////////////////////////////////////////
        public ActionResult DisplayMessageForAdmin(string message)
        {
            ShowMessageModel showMessageView = new ShowMessageModel()
            {
                Message = message
            };

            return View("DisplayMessageAdmin",showMessageView);
        }

        [HttpPost]
        public ActionResult RedirectForAdmin()
        {
            return RedirectToAction("AdminIndex", "AdminHome");
        }
    }
}
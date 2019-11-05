using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Pecunia.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pecunia.Mvc.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET 
        //URL: AdminHome/AdminIndex
        
        public async Task<ActionResult> AdminIndex(Guid? adminID)
        {
            System.Diagnostics.Debug.WriteLine(adminID);
            AdminBL adminBL = new AdminBL();
            Admin admin = new Admin();
            AdminHomeModel adminHomeModel = new AdminHomeModel();

            admin = await adminBL.GetAdminByAdminIDBL(Guid.Parse(Convert.ToString(Session["adminID"])));
            adminHomeModel.AdminID = Guid.Parse(Convert.ToString(Session["adminID"]));
            adminHomeModel.AdminName = admin.AdminName;
            adminHomeModel.AdminEmail = admin.AdminEmail;
            adminHomeModel.LastModifiedDate = admin.LastModifiedDateTime;

            TempData["adminID"] = adminHomeModel.AdminID;
           

            return View(adminHomeModel);
        }

       

        //URL: AdminHome/Edit
        public async Task<ActionResult> Edit(Guid adminID)
        {
            AdminBL adminBL = new AdminBL();
            Admin admin = new Admin() {
                AdminID = adminID
            };

            admin = await adminBL.GetAdminByAdminIDBL(adminID);
            System.Diagnostics.Debug.WriteLine(admin.AdminID);
            AdminHomeModel homeModel = new AdminHomeModel();
            homeModel.AdminID = admin.AdminID;
            homeModel.AdminName = admin.AdminName;
            homeModel.AdminEmail = admin.AdminEmail;
            
            return View(homeModel);
            

        }


        [HttpPost]
        public async Task<ActionResult> Edit(AdminHomeModel homeModel)
        {
            bool isUpdated = false;
            AdminBL adminBL = new AdminBL();
            Admin admin = new Admin();

            admin.AdminID = Guid.Parse(Convert.ToString(Session["adminID"]));
            admin.AdminName = homeModel.AdminName;
            admin.AdminEmail = homeModel.AdminEmail;


            isUpdated = await adminBL.UpdateAdminBL(admin);
            if (isUpdated)
                return RedirectToAction("AdminIndex", "AdminHome", new {adminID =  TempData["adminID"] });
            else
                return Content("Your details were not updated");

        }



        public async Task<ActionResult> EditPassword(Guid? adminID)
        {
            AdminBL adminBL = new AdminBL();
            Admin admin = new Admin();

            admin = await adminBL.GetAdminByAdminIDBL((Guid)adminID);

            AdminHomeModel homeModel = new AdminHomeModel();
            homeModel.AdminID = admin.AdminID;
            homeModel.AdminPassword = admin.AdminPassword;
            

            return View(homeModel);
        }


        [HttpPost]
        public async Task<ActionResult> EditPassword(AdminHomeModel homeModel)
        {
            bool isUpdated = false;
            AdminBL adminBL = new AdminBL();
            Admin admin = new Admin();

            

            admin.AdminID = Guid.Parse(Convert.ToString(Session["adminID"]));
            admin.AdminPassword = homeModel.ConfirmPassword;
            

             isUpdated = await adminBL.UpdateAdminPasswordBL(admin);
            if (isUpdated)
                return RedirectToAction("AdminIndex", "AdminHome", new { adminID = TempData["adminID"] });
            else
                return Content("Your password was not updated");

        }

        //public ActionResult Cancel(Guid adminID)
        //{
        //    return RedirectToAction("AdminIndex", "AdminHome", new { adminID = TempData["adminID"] });
        //}
    }
}
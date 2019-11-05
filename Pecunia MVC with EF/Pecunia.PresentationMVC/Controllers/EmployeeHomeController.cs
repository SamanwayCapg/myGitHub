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
    public class EmployeeHomeController : Controller
    {
        // GET: EmployeeHome
        public async Task<ActionResult> EmployeeIndex(Guid? employeeID)
        {
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee();
            EmployeeHomeModel employeeHomeModel = new EmployeeHomeModel();

            employee = await employeeBL.GetEmployeeByEmployeeIDBL(Guid.Parse(Convert.ToString(Session["employeeID"])));
            employeeHomeModel.EmployeeID = Guid.Parse(Convert.ToString(Session["employeeID"]));
            employeeHomeModel.EmployeeName = employee.EmployeeName;
            employeeHomeModel.EmployeeEmail = employee.EmployeeEmail;
            employeeHomeModel.Mobile = employee.Mobile;
            employeeHomeModel.LastModifiedDate = employee.LastModifiedDateTime;

            TempData["employeeID"] = employeeHomeModel.EmployeeID;

            return View(employeeHomeModel);
        }


        //URL: AdminHome/Edit
        public async Task<ActionResult> Edit(Guid employeeID)
        {
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee()
            {
                EmployeeID = employeeID
            };

            employee = await employeeBL.GetEmployeeByEmployeeIDBL(employeeID);          
            EmployeeHomeModel employeeHomeModel = new EmployeeHomeModel();
            employeeHomeModel.EmployeeID = employee.EmployeeID;
            employeeHomeModel.EmployeeName = employee.EmployeeName;
            employeeHomeModel.EmployeeEmail = employee.EmployeeEmail;
            employeeHomeModel.Mobile = employee.Mobile;

            return View(employeeHomeModel);


        }


        [HttpPost]
        public async Task<ActionResult> Edit(EmployeeHomeModel employeeHomeModel)
        {
            bool isUpdated = false;
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee();

            employee.EmployeeID = Guid.Parse(Convert.ToString(Session["employeeID"]));
            employee.EmployeeName = employeeHomeModel.EmployeeName;
            employee.EmployeeEmail = employeeHomeModel.EmployeeEmail;
            employee.Mobile = employeeHomeModel.Mobile;

            isUpdated = await employeeBL.UpdateEmployeeBL(employee);
            if (isUpdated==true)
                return RedirectToAction("EmployeeIndex", "EmployeeHome", new { employeeID = TempData["employeeID"] });
            else
                return Content("Your details were not updated");

        }



        public async Task<ActionResult> EditPassword(Guid? employeeID)
        {
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee();

            employee = await employeeBL.GetEmployeeByEmployeeIDBL((Guid)employeeID);

            EmployeeHomeModel employeeHomeModel = new EmployeeHomeModel();
            employeeHomeModel.EmployeeID = employee.EmployeeID;
            employeeHomeModel.EmployeeEmail = employee.EmployeeEmail;
            employeeHomeModel.EmployeePassword = employee.EmployeePassword;

            TempData["employeeEmail"] = employeeHomeModel.EmployeeEmail;

            return View(employeeHomeModel);
        }


        [HttpPost]
        public async Task<ActionResult> EditPassword(EmployeeHomeModel employeeHomeModel)
        {
            System.Diagnostics.Debug.WriteLine(TempData["employeeEmail"]);
            System.Diagnostics.Debug.WriteLine(employeeHomeModel.EmployeePassword);

            bool isUpdated = false;
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee();
            Employee isCorrectEmployee = new Employee();

            employee.EmployeeID = Guid.Parse(Convert.ToString(Session["employeeID"]));
            employee.EmployeePassword = employeeHomeModel.ConfirmPassword;

            isCorrectEmployee = await employeeBL.GetEmployeeByEmailAndPasswordBL(Convert.ToString(TempData["employeeEmail"]), employeeHomeModel.EmployeePassword);
            if(isCorrectEmployee != null)
            {
                isUpdated = await employeeBL.UpdateEmployeePasswordBL(employee);
                if (isUpdated)
                    return RedirectToAction("EmployeeIndex", "EmployeeHome", new { employeeID = TempData["employeeID"] });
                else
                    return Content("Your password was not updated");

            }
            else
            {
                return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Previous password entered is incorrect!" });
                //Response.Write("<script>alert('Previous password entered is incorrect!')</script>");
                //return RedirectToAction("EditPassword","EmployeeHome", new { employeeID = TempData["employeeID"] });
            }
        }

    }
}
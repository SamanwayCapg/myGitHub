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
    public class LoginController : Controller
    {
        // GET: 
        //URL: Login/Index
        public ActionResult Index()
        {
            //creating login view model
            LoginViewModel loginViewModel = new LoginViewModel();

            //passing view model object to view
            return View(loginViewModel);
        }


        //POST 
        //URL: Login/Index
        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel loginViewModel)
        {
            //if user type is selected as admin
            if(loginViewModel.UserType == "Admin")
            {
                AdminBL adminBL = new AdminBL();
                Admin admin = new Admin();

                //aasigning view model object details to entity model object
                admin.AdminEmail = loginViewModel.Email;
                admin.AdminPassword = loginViewModel.Password;

                //admin object returned from the database
                Admin loginAdmin = await adminBL.GetAdminByEmailAndPasswordBL(admin.AdminEmail, admin.AdminPassword);
                if (loginAdmin != null)
                {
                    //admin home page    
                    Session["adminID"] = loginAdmin.AdminID;
                    return RedirectToAction("AdminIndex","AdminHome", new { adminID = loginAdmin.AdminID});
                }
                else
                {
                    return Content("Admin not found.");
                }
            }
            
            //if user type is selected as employee
            if(loginViewModel.UserType == "Employee")
            {
                EmployeeBL employeeBL = new EmployeeBL();
                Employee employee = new Employee();

                //aasigning view model object details to entity model object
                employee.EmployeeEmail = loginViewModel.Email;
                employee.EmployeePassword = loginViewModel.Password;

                //employee object returned from the database
                Employee loginEmployee = await employeeBL.GetEmployeeByEmailAndPasswordBL(employee.EmployeeEmail, employee.EmployeePassword);
                if(loginEmployee != null)
                {
                    //employee home page
                    Session["employeeID"] = loginEmployee.EmployeeID;
                    return RedirectToAction("EmployeeIndex","EmployeeHome", new { employeeID = loginEmployee.EmployeeID});
                    
                }
                else
                {
                    return Content("Employee not found.");
                }
            }
            else
                return Content("Please select user type");
        }
    }
}
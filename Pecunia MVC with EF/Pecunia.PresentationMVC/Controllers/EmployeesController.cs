using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.Entities;
using Pecunia.Mvc.Models;
using Pecunia.PresentationMVC.ServiceReference1;

namespace Pecunia.Mvc.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        //URL: Employees/Index
        public async Task<ActionResult> Index()
        {

            //creating and initializing viewmodel object
            List<EmployeeViewModel> employeeViewModelList = new List<EmployeeViewModel>();

            using (TransactionServiceClient employeeServiceClient = new TransactionServiceClient())
            {
                EmployeeBL employeeBL = new EmployeeBL();
                List<Employee> employeesList = await employeeBL.GetAllEmployeesBL();

                foreach (var emp in employeesList)
                {
                    EmployeeViewModel employeeView = new EmployeeViewModel()
                    {
                        EmployeeID = emp.EmployeeID,
                        EmployeeName = emp.EmployeeName,
                        EmployeeEmail = emp.EmployeeEmail,
                        Mobile = emp.Mobile
                    };
                    employeeViewModelList.Add(employeeView);
                }

                if (employeeViewModelList.Count == 0)
                {
                    return RedirectToAction("Add", "Employees");
                }
            }



            //calling view and passing viewmodel object to view
            return View(employeeViewModelList);
        }

        public async Task<ActionResult> Delete(Guid employeeID)
        {
            bool isDeleted = false;
            EmployeeBL employeeBL = new EmployeeBL();
            Employee employee = new Employee();
            employee = await employeeBL.GetEmployeeByEmployeeIDBL(employeeID);
            
            isDeleted = await employeeBL.DeleteEmployeeBL(employee.EmployeeID);
            if (isDeleted)
                return RedirectToAction("Index", "Employees");
            else
                return Content("Employee was not deleted");
        }


        public ActionResult Add()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            return View(employeeViewModel);
        }


        [HttpPost]
        public async Task<ActionResult> Add(EmployeeViewModel employeeViewModel)
        {
            // Create object of EmpoyeeBL
             EmployeeBL employeeBL = new EmployeeBL();

            //Creating object of Person EntityModel
            Employee employee = new Employee();
            employee.EmployeeName = employeeViewModel.EmployeeName;
            employee.EmployeeEmail = employeeViewModel.EmployeeEmail;
            employee.Mobile = employeeViewModel.Mobile;
            employee.EmployeePassword = employeeViewModel.EmployeePassword;

            //Invoke the AddEmployee method BL
            bool isAdded = await employeeBL.AddEmployeeBL(employee);

            if (isAdded)
            {
                //Go to Index action method of Employees Controller
                return RedirectToAction("Index", "Employees");
            }
            else
            {
                //Return plain html / plain string
                return Content("Person not added");
            }
        }
    }
}
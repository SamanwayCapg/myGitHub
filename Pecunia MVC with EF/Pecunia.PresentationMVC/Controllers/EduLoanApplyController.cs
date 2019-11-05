using Capgemini.Pecunia.BusinessLayer;
using Capgemini.Pecunia.BusinessLayer.LoanBL;
using Capgemini.Pecunia.Entities;
using Pecunia.PresentationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Pecunia.PresentationMVC.Controllers
{
    public class EduLoanApplyController : Controller
    {
        // URL: EduLoanApply/apply
        public ActionResult Apply()
        {
            EduLoanApplyModel eduLoanApplyModel = new EduLoanApplyModel()
            {
                //LoanID = Guid.NewGuid()
                button="submit"
            };

            //getting list of customers
            CustomerBL customerBL = new CustomerBL();
            List<DropDownListData> customers = new List<DropDownListData>();
            customers = GetDropDownListData();
            System.Diagnostics.Debug.WriteLine("loanID:"+eduLoanApplyModel.LoanID);

            ViewBag.customers = new SelectList( customers, "ID", "NameMobile");
            return View(eduLoanApplyModel);
        }

        [HttpPost]
        public async Task<ActionResult> Apply(EduLoanApplyModel eduLoanModel)
        {
            EduLoanBL eduLoanBL = new EduLoanBL();
            EduLoan eduLoan = new EduLoan();

            eduLoan.LoanID = Guid.NewGuid();
            eduLoan.CustomerID = eduLoanModel.CustomerID;
            eduLoan.AmountApplied = eduLoanModel.AmountApplied;
            eduLoan.RepaymentPeriod = eduLoanModel.RepaymentPeriod;
            eduLoan.Course = eduLoanModel.Course;
            eduLoan.InstituteName = eduLoanModel.InstituteName;
            eduLoan.StudentID = eduLoanModel.StudentID;

            bool isApplied = await eduLoanBL.ApplyLoanBL(eduLoan);
            if (isApplied == true)
                return RedirectToAction("ViewDetails", "EduLoanView", new { loanID = eduLoan.LoanID });
            else
                return RedirectToAction("DisplayMessage", "ShowMessage", new { Message = "Server Error! Try Again Later!" });


        }

        List<DropDownListData> GetDropDownListData()
        {
            List<DropDownListData> list = new List<DropDownListData>();
            using (PecuniaEntities pecEnt  = new PecuniaEntities())
            {
                list = (from cust
                        in pecEnt.Customers
                        select new DropDownListData
                        {
                            ID = cust.CustomerID,
                            NameMobile = "Name:"+cust.CustomerName+"|Mobile:"+cust.CustomerMobile
                        }).ToList();
            }
            return list;
        }
    }

    class DropDownListData
    {
        public Guid ID { get; set; }
        public string NameMobile { get; set; }
    }
}
using Capgemini.Pecunia.Entities;
using Pecunia.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pecunia.Mvc.Controllers
{
    public class TestWebApiController : ApiController
    {
        private PecuniaEntities pe = new PecuniaEntities();
        public IHttpActionResult getAllEmployees()
        {
            
            List<Employee> employeesVM = pe.Employees.ToList();
          
            if(employeesVM == null)
            {
                return NotFound();
            }
            return Ok(employeesVM);
        }
    }
}

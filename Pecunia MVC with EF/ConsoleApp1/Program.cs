using Capgemini.Pecunia.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            Test.doWork().Wait();
        }
    }

    class Test
    {
        public static async Task doWork()
        {
            List<Customer> customers = new List<Customer>();
            using (PecuniaEntities pecEnt  = new PecuniaEntities())
            {
                customers = pecEnt.Customers.ToList();
            }
            foreach (Customer cust in customers)
                Console.WriteLine(cust.CustomerID);
        }
    }
}

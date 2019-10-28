using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capgemini.Pecunia.Helpers
{
    public static class BusinessLogicUtil
    {
        public static decimal? ComputeEMI(decimal ?Amount, int ?RepaymentPeriod, decimal ?InterestRate)
        {
            // implements simple interset 
            decimal? TotalAmountToBePaid = Amount * (1 + (InterestRate / 100));
            int? TotalMonths = RepaymentPeriod;
            decimal? EMI = TotalAmountToBePaid / (decimal)TotalMonths;

            //Console.WriteLine($"total mounts to be paid {TotalAmountToBePaid}");
            return EMI;
        }

        public static DateTime validateDate(string v, string inputDateStr)
        {
            throw new NotImplementedException();
        }

        public static bool logException(string message, string stackTrace, string methodName)
        {
            try
            {
                using (StreamWriter writer = File.AppendText("ExceptionLog.txt"))
                {
                    string content = $"Source Method:{methodName},Time:{DateTime.Now},Message:{message},\n StackTrace:{stackTrace}";
                    writer.WriteLine(content);
                    writer.WriteLine();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

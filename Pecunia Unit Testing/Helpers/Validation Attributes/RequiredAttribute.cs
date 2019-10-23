using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Pecunia.Helper
{
    public class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }

        public RequiredAttribute() : base()
        {

        }

        public RequiredAttribute(string msg) : base()
        {
            ErrorMessage = msg;
        }
    }
}

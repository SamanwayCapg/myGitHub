﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Pecunia.Helper
{
    public class RegExpAttribute : Attribute
    {
        public string RegularExpressionToCheck { get; set; }
        public string ErrorMessage { get; set; }

        public RegExpAttribute(string regularExpression) : base()
        {
            RegularExpressionToCheck = regularExpression;
        }

        public RegExpAttribute(string regularExpression, string errorMessage) : base()
        {
            RegularExpressionToCheck = regularExpression;
            ErrorMessage = errorMessage;
        }
    }
}

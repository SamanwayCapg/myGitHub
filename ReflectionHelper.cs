using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.Helper
{
    public static class ReflectionHelper
    {

        public static void CopyProperties(object sourceObject, object destObject, List<string> properties)
        {
            Type sourceType = sourceObject.GetType();
            Type destType = destObject.GetType();

            foreach(var property in properties)
            {
                object sourceVal = sourceType.GetProperty(property).GetValue(sourceObject);
                destType.GetProperty(property).SetValue(destObject, sourceVal);
            }
        }
    }
}

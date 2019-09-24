using System;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Pecunia.Helper;
using Capgemini.Pecunia.Exceptions;

namespace Capgemini.Pecunia.BusinessLayer
{
    public abstract class BLbase<T>
    {
        protected async virtual Task<bool> Validate(T entityObject)
        {
            StringBuilder sb = new StringBuilder();
            bool valid = true;

            await Task.Run(() =>
            {
                Type type = typeof(T);
                PropertyInfo[] properties = type.GetProperties();

                foreach(var prop in properties)
                {
                    var attr = prop.GetCustomAttribute<RequiredAttribute>();
                    if(attr != null)
                    {
                        object currentValue = prop.GetValue(entityObject);
                        if (string.IsNullOrEmpty(Convert.ToString(currentValue)))
                        {
                            valid = false;
                            sb.Append(Environment.NewLine + attr.ErrorMessage);
                        }
                    }
                }


                foreach (var prop in properties)
                {
                    var attr = prop.GetCustomAttribute<RegExpAttribute>();
                    if (attr != null)
                    {
                        string currentValue = Convert.ToString(prop.GetValue(entityObject));
                        if (Regex.IsMatch(currentValue, attr.RegularExpressionToCheck) == false)
                        {
                            valid = false;
                            sb.Append(Environment.NewLine + attr.ErrorMessage);
                        }
                    }
                }
            }
            );

            if (valid == false)
                throw new InvalidStringException(sb.ToString());

            return valid;
        }
    }
}

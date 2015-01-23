using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopApplication.Validation
{
    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string str = (string)value;
            if(str.Length < 4)
            {
                return new ValidationResult(false, "A név túl rövid!");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}

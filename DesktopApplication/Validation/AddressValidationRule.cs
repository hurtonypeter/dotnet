using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopApplication.Validation
{
    public class AddressValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string str = (string)value;
            Regex regex = new Regex(@"^[0-9]*([.,]|[A-Za-z0-9]|[ ])*$");
            if (!regex.IsMatch(str))
                return new ValidationResult(false, "Nem megfelelő címformátum!");

            return new ValidationResult(true, null);
        }
    }
}

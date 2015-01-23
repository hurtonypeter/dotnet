using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopApplication.Validation
{
    public class TelephoneValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string str = (string)value;
            Regex reg = new Regex(@"^\d{2}[-]\d{2}[/]\d{2}[-]\d{2}[-]\d{3}$");
            if (!reg.IsMatch(str))
                return new ValidationResult(false, "Nem megfelelő telefonszám-formátum!");

            return new ValidationResult(true, null);
        }
    }
}

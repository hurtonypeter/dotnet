using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesktopApplication.Validation
{
    public class BarcodeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int barcode;
            try
            {
                string str = (string)value;
                barcode = int.Parse(str);
                if (str.Length != 10)
                {
                    return new ValidationResult(false, "A vonalkód 10 számjegyű!");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            catch (Exception)
            {
                return new ValidationResult(false, "A vonalkódnak számnak kell lennie!");
            }
        }
    }
}

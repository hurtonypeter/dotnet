using DesktopApplication.BookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DesktopApplication.Converter
{
    [ValueConversion(typeof(List<Writer>), typeof(string))]
    public class WriterListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return " - ";
            //if (targetType != typeof(List<Writer>))
            //    throw new InvalidOperationException("The target must be a List<Writer>.");

            return String.Join(", ", ((List<Writer>)value).Select(w => w.FirstName + " " + w.LastName));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

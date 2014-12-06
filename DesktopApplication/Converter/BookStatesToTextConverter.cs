using DesktopApplication.BookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DesktopApplication.Converter
{
    [ValueConversion(typeof(BookStates), typeof(string))]
    public class BookStatesToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((BookStates)value)
            {
                case BookStates.Free:
                    return "Szabad";
                case BookStates.Rent:
                    return "Kölcsönözve";
                case BookStates.Expired:
                    return "Lejárt!";
                default:
                    return "???";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

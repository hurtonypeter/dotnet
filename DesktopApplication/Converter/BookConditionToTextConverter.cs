using DesktopApplication.BookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DesktopApplication.Converter
{
    [ValueConversion(typeof(BookCondition), typeof(string))]
    public class BookConditionToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((BookCondition)value)
            {
                case BookCondition.New:
                    return "Új";
                case BookCondition.Good:
                    return "Jó";
                case BookCondition.Bad:
                    return "Rossz";
                case BookCondition.VeryBad:
                    return "Nagyon rossz";
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

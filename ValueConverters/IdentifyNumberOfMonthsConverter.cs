using System;
using System.Globalization;

namespace helloralph.ValueConverters
{
    public class IdentifyNumberOfMonthsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var numMonths = (int)value;
            var result = $"{numMonths} MONTHS";

            if (numMonths == 1)
                result = $"{numMonths} MONTH";
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var numMonths = (int)value;
            var result = $"{numMonths} MONTHS";

            if (numMonths == 1)
                result = $"{numMonths} MONTH";
            return result;
        }
    }
}


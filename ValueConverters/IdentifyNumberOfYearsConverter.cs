using System;
using System.Globalization;

namespace helloralph.ValueConverters
{
	public class IdentifyNumberOfYearsConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var numYears = (int)value;
            var result = $"{numYears} YEARS";

            if (numYears == 1)
                result = $"{numYears} YEAR";
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var numYears = (int)value;
            var result = $"{numYears} YEARS";

            if (numYears == 1)
                result = $"{numYears} YEAR";
            return result;
        }
    }
}


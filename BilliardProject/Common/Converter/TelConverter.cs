using System;
using System.Globalization;
using System.Windows.Data;

namespace BilliardProject.Common.Converter
{
    public class TelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? tel = value as string;
            return tel.Substring(0, 3) + "****" + tel.Substring(7, 4);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}

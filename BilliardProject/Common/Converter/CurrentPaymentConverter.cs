using System;
using System.Globalization;
using System.Windows.Data;

namespace BilliardProject.Common.Converter
{
    public class CurrentPaymentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int a = (int)value;
            if (a == 0)
                return "";
            return $"￥{a}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}

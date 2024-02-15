using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace BilliardProject.Common.Converter
{
    public class PlayHourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> hours = (List<string>)value;
            List<string> res = new List<string>();
            foreach (string hour in hours)
            {
                if (string.IsNullOrEmpty(hour))
                {
                    res.Add(hour);
                    continue;
                }
                res.Add(hour + "小时");
            }
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}

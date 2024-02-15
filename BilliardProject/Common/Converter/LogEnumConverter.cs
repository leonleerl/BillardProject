using System;
using System.Globalization;
using System.Windows.Data;

namespace BilliardProject.Common.Converter
{
    public class LogEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] items = value as string[];
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == "Tel")
                {
                    items[i] = "电话号码";
                }
                else if (items[i] == "EntertainmentType")
                {
                    items[i] = "项目类型";
                }
                else if (items[i] == "TableIndex")
                {
                    items[i] = "桌号";
                }
                else if (items[i] == "Time")
                {
                    items[i] = "时间";
                }
                else
                {
                    items[i] = "";
                }
            }
            return items;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}

using System;
using System.Globalization;
using System.Windows.Data;

namespace PatientDetails.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class StringToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertStringToDate(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertDateToString((DateTime)value);
        }

        public String ConvertStringToDate(string dateString)
        {
            DateTime date = DateTime.Parse(dateString);
            
            return date.ToShortDateString();
        }
        public string ConvertDateToString(DateTime date)
        {
            return date.ToShortDateString();
        }
    }
}

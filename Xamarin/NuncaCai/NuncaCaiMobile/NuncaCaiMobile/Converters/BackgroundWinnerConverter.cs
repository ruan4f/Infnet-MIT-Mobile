using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NuncaCaiMobile.Converters
{
    public class BackgroundWinnerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? Color.ForestGreen : Color.IndianRed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // You probably don't need this, this is used to convert the other way around
            // so from color to yes no or maybe
            throw new NotImplementedException();
        }
    }
}

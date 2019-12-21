using System;
using Windows.UI.Xaml.Data;

namespace UnoDesigner.Converters
{
    public class DoubleToCornerRadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ValueConversion.DoubleToCornerRadius((double)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
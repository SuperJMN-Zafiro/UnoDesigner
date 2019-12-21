using System;
using Windows.UI.Xaml.Data;

namespace UnoDesigner.Converters
{
    public class ZeroToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ValueConversion.DistanceToVisibility((double)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}
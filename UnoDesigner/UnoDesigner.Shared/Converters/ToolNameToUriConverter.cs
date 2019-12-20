using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace UnoDesigner
{
    public class ToolNameToUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string s)
            {
                var uri = new Uri($"ms-appx:///", UriKind.Absolute);
                var relativeUri = new Uri($"{parameter}/{s}.png", UriKind.Relative);
                var convert = new Uri(uri, relativeUri);
                return convert;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
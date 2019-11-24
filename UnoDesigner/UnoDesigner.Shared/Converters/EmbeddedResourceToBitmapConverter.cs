using System;
using Windows.UI.Xaml.Data;

namespace UnoDesigner.Converters
{
    public class EmbeddedResourceToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string resourceName)
            {
                var stream = ResourceUtils.GetStreamFromResourceFile(resourceName, typeof(MainPage));
                return BitmapUtils.FromStreamToBitmapSource(stream);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
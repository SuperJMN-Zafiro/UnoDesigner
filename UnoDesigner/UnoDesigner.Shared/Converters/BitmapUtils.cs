using System.IO;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Uno.Extensions;

namespace UnoDesigner.Converters
{
    public static class BitmapUtils 
    {
        public static BitmapSource FromStreamToBitmapSource(Stream stream)
        {
#if HAS_UNO
            BitmapImage result = new BitmapImage();
            result.SetSource(stream);
            return result;
#else
            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(stream.ReadBytes());
                    writer.StoreAsync().GetResults();
                }
                BitmapImage result = new BitmapImage();
                result.SetSource(ms);
                return result;
            }
#endif
        }
    }
}
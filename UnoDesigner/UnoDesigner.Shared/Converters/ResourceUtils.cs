using System;
using System.IO;

namespace UnoDesigner.Converters
{
    public class ResourceUtils
    {
        public static Stream GetStreamFromResourceFile(string resourceName, Type typeCalling)
        {
            try
            {
                var assy = typeCalling?.Assembly;
                var resources = assy?.GetManifestResourceNames();
                foreach (string sResourceName in resources)
                {
                    Console.WriteLine(sResourceName);
                    if (sResourceName.ToUpperInvariant().Contains(resourceName.ToUpperInvariant()))
                    {
                        return assy.GetManifestResourceStream(sResourceName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get the resource '{resourceName}'", ex);
            }

            throw new Exception("Unable to find resource file:" + resourceName);
        }

    }
}
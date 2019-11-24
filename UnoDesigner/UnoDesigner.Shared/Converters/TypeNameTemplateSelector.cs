using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UnoDesigner.Converters
{
    public class TypeNameTemplateSelector : DataTemplateSelector
    {
        public ResourceDictionary Items { get; set; } = new ResourceDictionary();

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var dict = (IDictionary<object, object>)Items;

            if (dict.TryGetValue(item.GetType().Name, out var t))
            {
                return (DataTemplate)t;
            }

            return base.SelectTemplateCore(item, container);
        }
    }
}
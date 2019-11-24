using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using UnoDesigner.Design;

namespace UnoDesigner
{
    public partial class DesignerSurface : ItemsControl
    {
        public DesignerSurface()
        {
            DefaultStyleKey = typeof(DesignerSurface);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DesignerItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DesignerItem;
        }

        public Binding LeftBinding { get; set; }
        public Binding TopBinding { get; set; }
        public Binding HeightBinding { get; set; }
        public Binding WidthBinding { get; set; }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var di = (DesignerItem) element;

            SetBindings(di);

            base.PrepareContainerForItemOverride(element, item);
        }

        private void SetBindings(DesignerItem di)
        {
            if (LeftBinding != null)
            {
                di.SetBinding(DesignerItem.LeftProperty, LeftBinding);
            }

            if (TopBinding != null)
            {
                di.SetBinding(DesignerItem.TopProperty, TopBinding);
            }

            if (WidthBinding != null)
            {
                di.SetBinding(WidthProperty, WidthBinding);
            }

            if (HeightBinding != null)
            {
                di.SetBinding(HeightProperty, HeightBinding);
            }
        }
    }
}
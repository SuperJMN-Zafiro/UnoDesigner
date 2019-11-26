using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using UnoDesigner.Design;

namespace UnoDesigner
{
    public class DesignerSurface : ItemsControl
    {
        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(
            "SelectedItems", typeof(IEnumerable), typeof(DesignerSurface), new PropertyMetadata(default(IEnumerable)));
        
        public bool IsMultiSelectionEnabled = false;
        private CompositeDisposable subscriptions;

        public DesignerSurface()
        {
            DefaultStyleKey = typeof(DesignerSurface);
            Unloaded += OnUnloaded;

            Observable
                .FromEventPattern<TappedEventHandler, TappedRoutedEventArgs>(h => Tapped += h, h => Tapped -= h)
                .Subscribe(_ => ResetAll());
        }

        public Binding LeftBinding { get; set; }
        public Binding TopBinding { get; set; }
        public Binding HeightBinding { get; set; }
        public Binding WidthBinding { get; set; }

        private IEnumerable<DesignerItem> Containers => Items.Select(o => (DesignerItem) ContainerFromItem(o));

        public IEnumerable SelectedItems
        {
            get => (IEnumerable) GetValue(SelectedItemsProperty);
            set => SetValue(SelectedItemsProperty, value);
        }

        private void ResetAll()
        {
            ClearSelection();
            ClearEditMode();
        }

        private void ClearEditMode()
        {
            foreach (var designerItem in Containers)
            {
                designerItem.IsEditing = false;
            }
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            subscriptions.Dispose();
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DesignerItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DesignerItem;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var di = (DesignerItem) element;

            SetBindings(di);

            subscriptions = new CompositeDisposable();

            subscriptions.Add(di.SelectionRequest.Subscribe(ea =>
            {
                ea.EventArgs.Handled = true;
                if (!IsMultiSelectionEnabled)
                {
                    ClearSelection();
                }

                di.IsSelected = true;
                SelectedItems = GetSelectedItems();
            }));

            subscriptions.Add(di.EditRequest.Subscribe(_ => di.IsEditing = true));

            base.PrepareContainerForItemOverride(element, item);
        }

        private void ClearSelection()
        {
            if (SelectedItems != null)
            {
                foreach (var selectedItem in SelectedItems)
                {
                    var di = (DesignerItem) ContainerFromItem(selectedItem);
                    di.IsSelected = false;
                }
            }

            SelectedItems = GetSelectedItems();
        }

        private IList<object> GetSelectedItems()
        {
            return Containers.Where(x => x.IsSelected).Select(ItemFromContainer).ToList();
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
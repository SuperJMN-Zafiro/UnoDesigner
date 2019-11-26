using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Uno.Disposables;
using UnoDesigner.Design;

namespace UnoDesigner
{
    public partial class DesignerSurface : ItemsControl
    {
        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(
            "SelectedItems", typeof(IEnumerable), typeof(DesignerSurface), new PropertyMetadata(default(IEnumerable)));

        private readonly CompositeDisposable disposables = new CompositeDisposable();

        public bool IsMultiSelectionEnabled = false;

        public DesignerSurface()
        {
            DefaultStyleKey = typeof(DesignerSurface);

            Observable
                .FromEventPattern<RoutedEventHandler, RoutedEventArgs>(h => Unloaded += h, h => Unloaded -= h)
                .Subscribe(_ => disposables.Dispose())
                .DisposeWith(disposables);

            Observable
                .FromEventPattern<TappedEventHandler, TappedRoutedEventArgs>(h => Tapped += h, h => Tapped -= h)
                .Subscribe(_ => ResetAll())
                .DisposeWith(disposables);
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

            di.SelectionRequest
                .Subscribe(ea => { OnSelectionRequest(di, ea.EventArgs); })
                .DisposeWith(disposables);

            di.EditRequest
                .Subscribe(_ => di.IsEditing = true)
                .DisposeWith(disposables);

            base.PrepareContainerForItemOverride(element, item);
        }

        private void OnSelectionRequest(DesignerItem di, TappedRoutedEventArgs tappedRoutedEventArgs)
        {
            tappedRoutedEventArgs.Handled = true;
            if (!IsMultiSelectionEnabled)
            {
                ClearSelection();
            }

            di.IsSelected = true;
            SelectedItems = GetSelectedItems();
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
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using UnoDesigner.Misc;

namespace UnoDesigner.Design
{
    public partial class DesignerItem : ContentControl
    {
        readonly CompositeDisposable disposables = new CompositeDisposable();

        public DesignerItem()
        {
            DefaultStyleKey = typeof(DesignerItem);

            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            SetSelectionState(false);
            SetEditState(false);
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
        }

        public static readonly DependencyProperty LeftProperty = DependencyProperty.Register(
            "Left", typeof(double), typeof(DesignerItem), new PropertyMetadata(default(double)));

        public double Left
        {
            get { return (double)GetValue(LeftProperty); }
            set { SetValue(LeftProperty, value); }
        }

        public static readonly DependencyProperty TopProperty = DependencyProperty.Register(
            "Top", typeof(double), typeof(DesignerItem), new PropertyMetadata(default(double)));

        public double Top
        {
            get { return (double)GetValue(TopProperty); }
            set { SetValue(TopProperty, value); }
        }

        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(
            "Angle", typeof(double), typeof(DesignerItem), new PropertyMetadata(default(double)));

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(
            "IsSelected", typeof(bool), typeof(DesignerItem), new PropertyMetadata(default(bool), IsSelectedChanged));

        private static void IsSelectedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs changedArgs)
        {
            var d = (DesignerItem)dependencyObject;
            d.OnSelected((bool)changedArgs.OldValue, (bool)changedArgs.NewValue);
        }

        private void OnSelected(bool oldValue, bool newValue)
        {
            SetSelectionState(newValue);
        }

        private void SetSelectionState(bool newValue)
        {
            VisualStateManager.GoToState(this, newValue ? "Selected" : "Unselected", true);
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        protected override void OnApplyTemplate()
        {
            var mover = (FrameworkElement)GetTemplateChild("Mover");
            if (mover != null)
            {
                Observable
                    .FromEventPattern<TappedEventHandler, TappedRoutedEventArgs>(h => mover.Tapped += h, h => mover.Tapped -= h)
                    .Subscribe(SelectionRequest)
                    .DisposeWith(disposables);

                Observable
                    .FromEventPattern<DoubleTappedEventHandler, DoubleTappedRoutedEventArgs>(h => mover.DoubleTapped += h,
                        h => mover.DoubleTapped -= h)
                    .Select(_ => Unit.Default)
                    .Subscribe(EditRequest)
                    .DisposeWith(disposables);
            }

            base.OnApplyTemplate();
        }

        public static readonly DependencyProperty IsEditingProperty = DependencyProperty.Register(
            "IsEditing", typeof(bool), typeof(DesignerItem), new PropertyMetadata(default(bool), IsEditingChanged));

        private static void IsEditingChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var target = (DesignerItem)dependencyObject;
            var newValue = (bool)dependencyPropertyChangedEventArgs.NewValue;
            target.IsEditingChanged(newValue);
        }

        private void IsEditingChanged(bool newValue)
        {
            SetEditState(newValue);

            if (newValue)
            {
                TrySetFocus();
            }
        }

        private void TrySetFocus()
        {
            //var child = this.GetVisualDescendents<Control>();
            //child.FirstOrDefault()?.Focus(FocusState.Programmatic);
        }

        private void SetEditState(bool newValue)
        {
            VisualStateManager.GoToState(this, newValue ? "Editing" : "Default", true);
        }

        public bool IsEditing
        {
            get { return (bool)GetValue(IsEditingProperty); }
            set { SetValue(IsEditingProperty, value); }
        }

        public ISubject<EventPattern<TappedRoutedEventArgs>> SelectionRequest { get; } = new Subject<EventPattern<TappedRoutedEventArgs>>();
        public ISubject<Unit> EditRequest { get; } = new Subject<Unit>();
    }
}
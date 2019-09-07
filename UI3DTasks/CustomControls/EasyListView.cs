using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace UI3DTasks.CustomControls
{
    public class EasyListView : ItemsControl
    {
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.RegisterAttached(
            "IsSelected",
            typeof(bool),
            typeof(EasyListView),
            new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.Inherits));

        public static void SetIsSelected(UIElement element, bool value) => element.SetValue(IsSelectedProperty, value);

        public static bool GetIsSelected(UIElement element) => (bool)element.GetValue(IsSelectedProperty);

        private static readonly DependencyPropertyKey SelectedItemPropertyKey = DependencyProperty.RegisterReadOnly(
            nameof(SelectedItem),
            typeof(object),
            typeof(EasyListView),
            new FrameworkPropertyMetadata(default(object), new PropertyChangedCallback(OnSelectedItemChanged)));

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => (d as EasyListView)?.OnSelectedItemChanged(e);

        private void OnSelectedItemChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                var oldValueContainer = ItemContainerGenerator.ContainerFromItem(e.OldValue);
                SetIsSelected((UIElement)oldValueContainer, false);
            }
            SetIsSelected((UIElement)ItemContainerGenerator.ContainerFromItem(e.NewValue), true);
            
        }

        public static readonly DependencyProperty SelectedItemProperty = SelectedItemPropertyKey.DependencyProperty;

        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            private set => SetValue(SelectedItemPropertyKey, value);
        }

        static EasyListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EasyListView), new FrameworkPropertyMetadata(typeof(EasyListView)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            var container = new ContentControl();
            container.MouseLeftButtonUp += Container_MouseLeftButtonUp;
            return container;
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return base.IsItemItsOwnContainerOverride(item);
        }

        private void Container_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is ContentControl contentControl)
                SetValue(SelectedItemPropertyKey, contentControl.Content);
        }        
    }
}

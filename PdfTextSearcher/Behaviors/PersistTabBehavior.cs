using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PdfTextSearcher.Behaviors
{
    public class PersistTabBehavior
    {
        #region ItemsSource
        private static readonly Dictionary<TabControl, PersistTabItemsSourceHandler> ItemsSourceHandlers = new Dictionary<TabControl, PersistTabItemsSourceHandler>();
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.RegisterAttached("ItemsSource", typeof(IEnumerable), typeof(PersistTabBehavior), new UIPropertyMetadata(null, OnItemsSourcePropertyChanged));

        private static void OnItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TabControl tabControl && tabControl.ItemsSource is null)
            {
                PersistTabItemsSourceHandler handler;

                if (ItemsSourceHandlers.ContainsKey(tabControl))
                {
                    handler = ItemsSourceHandlers[tabControl];
                }
                else
                {
                    handler = new PersistTabItemsSourceHandler(tabControl);
                    ItemsSourceHandlers.Add(tabControl, handler);
                    tabControl.Unloaded += ItemsSourceTabControlUnloaded;
                }

                handler.Load();
            }
        }

        private static void ItemsSourceTabControlUnloaded(object sender, RoutedEventArgs e)
        {
            if (sender is TabControl tabControl)
            {
                RemoveFromItemsSourceHandlers(tabControl);
                tabControl.Unloaded -= ItemsSourceTabControlUnloaded;
            }
        }

        private static void RemoveFromItemsSourceHandlers(TabControl tabControl)
        {
            if (ItemsSourceHandlers.ContainsKey(tabControl))
            {
                ItemsSourceHandlers[tabControl].Dispose();
                ItemsSourceHandlers.Remove(tabControl);
            }
        }

        public static IEnumerable GetItemsSource(DependencyObject obj)
        {
            return (IEnumerable)obj.GetValue(ItemsSourceProperty);
        }

        public static void SetItemsSource(DependencyObject obj, IEnumerable value)
        {
            obj.SetValue(ItemsSourceProperty, value);
        }
        #endregion

        #region SelectedItem
        private static readonly Dictionary<TabControl, PersistTabSelectedItemHandler> SelectedItemHandlers = new Dictionary<TabControl, PersistTabSelectedItemHandler>();
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.RegisterAttached("SelectedItem", typeof(object), typeof(PersistTabBehavior), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnSelectedItemPropertyChanged));

        private static void OnSelectedItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TabControl tabControl && tabControl.ItemsSource is null)
            {
                PersistTabSelectedItemHandler handler;

                if (SelectedItemHandlers.ContainsKey(tabControl))
                {
                    handler = SelectedItemHandlers[tabControl];
                }
                else
                {
                    handler = new PersistTabSelectedItemHandler(tabControl);
                    SelectedItemHandlers.Add(tabControl, handler);
                    tabControl.Unloaded += SelectedItemTabControlUnloaded;
                }

                handler.ChangeSelectionFromProperty();
            }
        }

        private static void SelectedItemTabControlUnloaded(object sender, RoutedEventArgs e)
        {
            if (sender is TabControl tabControl)
            {
                RemoveFromSelectedItemHandlers(tabControl);
                tabControl.Unloaded -= SelectedItemTabControlUnloaded;
            }
        }

        private static void RemoveFromSelectedItemHandlers(TabControl tabControl)
        {
            if (SelectedItemHandlers.ContainsKey(tabControl))
            {
                SelectedItemHandlers[tabControl].Dispose();
                SelectedItemHandlers.Remove(tabControl);
            }
        }

        public static object GetSelectedItem(DependencyObject obj)
        {
            return obj.GetValue(SelectedItemProperty);
        }

        public static void SetSelectedItem(DependencyObject obj, object value)
        {
            obj.SetValue(SelectedItemProperty, value);
        }
        #endregion
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PdfTextSearcher.Behaviors
{
    public class PersistTabItemsSourceHandler : IDisposable
    {
        public TabControl Tab { get; private set; }

        public PersistTabItemsSourceHandler(TabControl tab)
        {
            Tab = tab;
            Tab.Loaded += Tab_Loaded;
        }

        private void Tab_Loaded(object sender, RoutedEventArgs e)
        {
            AttachCollectionChangedEvent();
            LoadItemSource();
        }

        private void LoadItemSource()
        {
            if (Tab.GetValue(PersistTabBehavior.ItemsSourceProperty) is IEnumerable source)
            {
                Load(source);
            }
        }

        public void Load()
        {
            if (Tab.GetValue(PersistTabBehavior.ItemsSourceProperty) is IEnumerable source)
            {
                Load(source);
            }
        }

        private void Load(IEnumerable source)
        {
            Tab.Items.Clear();

            foreach (var page in source)
            {
                AddTabItem(page);
            }

            SelectItem();
        }

        private void AttachCollectionChangedEvent()
        {
            if (Tab.GetValue(PersistTabBehavior.ItemsSourceProperty) is INotifyCollectionChanged source)
            {
                source.CollectionChanged += SourceCollectionChanged;
            }
        }

        private void SourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var view in e.NewItems)
                {
                    AddTabItem(view);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var view in e.OldItems)
                {
                    RemoveTabItem(view);
                }
            }
        }

        private void RemoveTabItem(object view)
        {
            var foundItem = Tab.Items.Cast<TabItem>().FirstOrDefault(t => t.DataContext == view);

            if (foundItem != null)
            {
                Tab.Items.Remove(foundItem);
            }
        }

        private void AddTabItem(object view)
        {
            var contentControl = new ContentControl();
            contentControl.SetBinding(ContentControl.ContentProperty, new Binding());
            var item = new TabItem
            {
                DataContext = view,
                Content = contentControl
            };
            Tab.Items.Add(item);

            if (Tab.SelectedItem is null)
            {
                item.IsSelected = true;
            }
        }

        private void SelectItem()
        {
            var selectedObject = Tab.GetValue(PersistTabBehavior.SelectedItemProperty);

            if (selectedObject == null)
            {
                return;
            }

            foreach (TabItem item in Tab.Items)
            {
                if (item.DataContext == selectedObject)
                {
                    item.IsSelected = true;
                    return;
                }
            }
        }

        public void Dispose()
        {
            if (Tab.GetValue(PersistTabBehavior.ItemsSourceProperty) is INotifyCollectionChanged source)
            {
                source.CollectionChanged -= SourceCollectionChanged;
            }

            Tab = null;
        }
    }
}
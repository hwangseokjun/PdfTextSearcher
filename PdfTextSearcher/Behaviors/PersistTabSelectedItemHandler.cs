using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PdfTextSearcher.Behaviors
{
    public class PersistTabSelectedItemHandler : IDisposable
    {
        public TabControl Tab { get; private set; }

        public PersistTabSelectedItemHandler(TabControl tab)
        {
            Tab = tab;
            Tab.SelectionChanged += ChangeSelectionFromUI;
        }

        private void ChangeSelectionFromUI(object sender, SelectionChangedEventArgs e)
        {
            if (1 <= e.AddedItems.Count)
            {
                var selectedObject = e.AddedItems[0];

                if (selectedObject is TabItem selectedItem)
                {
                    SelectedItemProperty(selectedItem);
                }
            }
        }

        private void SelectedItemProperty(TabItem selectedItem)
        {
            if (Tab.GetValue(PersistTabBehavior.ItemsSourceProperty) is IEnumerable tabObjects)
            {
                foreach (var tabObject in tabObjects)
                {
                    if (tabObject == selectedItem.DataContext)
                    {
                        PersistTabBehavior.SetSelectedItem(Tab, tabObject);
                        return;
                    }
                }
            }
        }

        public void Dispose()
        {
            Tab.SelectionChanged -= ChangeSelectionFromUI;
            Tab = null;
        }

        public void ChangeSelectionFromProperty()
        {
            var selectedObject = Tab.GetValue(PersistTabBehavior.SelectedItemProperty);

            if (selectedObject == null)
            {
                Tab.SelectedItem = null;
                return;
            }

            foreach (TabItem tabItem in Tab.Items)
            {
                if (tabItem.DataContext == selectedObject)
                {
                    if (!tabItem.IsSelected)
                    {
                        tabItem.IsSelected = true;
                    }

                    break;
                }
            }
        }
    }
}
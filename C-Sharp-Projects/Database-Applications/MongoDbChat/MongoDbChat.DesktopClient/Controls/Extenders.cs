namespace MongoDbChat.DesktopClient.Controls
{
    using System.Collections.Specialized;
    using System.Windows;
    using System.Windows.Controls;

    public class Extenders : DependencyObject
    {
        public static readonly DependencyProperty AutoScrollToEndProperty = DependencyProperty.RegisterAttached(
            "AutoScrollToEnd", typeof(bool), typeof(Extenders), new UIPropertyMetadata(default(bool), OnAutoScrollToEndChanged));

        public static bool GetAutoScrollToEnd(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToEndProperty);
        }

        public static void SetAutoScrollToEnd(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToEndProperty, value);
        }

        public static void OnAutoScrollToEndChanged(DependencyObject listbox, DependencyPropertyChangedEventArgs e)
        {
            var listBox = (ListBox)listbox;
            var listBoxItems = listBox.Items;
            var data = listBoxItems.SourceCollection as INotifyCollectionChanged;
            var scrollToEndHandler = new NotifyCollectionChangedEventHandler((x, y) =>
            {
                if (listBox.Items.Count > 0)
                {
                    var lastItem = listBox.Items[listBox.Items.Count - 1];
                    listBoxItems.MoveCurrentTo(lastItem);
                    listBox.ScrollIntoView(lastItem);
                }
            });

            if ((bool)e.NewValue)
            {
                data.CollectionChanged += scrollToEndHandler;
            }
            else
            {
                data.CollectionChanged -= scrollToEndHandler;
            }
        }
    }
}

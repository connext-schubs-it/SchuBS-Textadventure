using System.Windows;
using System.Windows.Controls;

namespace SchuBS_Textadventure.MyControls
{
    // http://web.archive.org/web/20120711175633/http://blogs.microsoft.co.il/blogs/eladkatz/archive/2011/05/29/what-is-the-easiest-way-to-set-spacing-between-items-in-stackpanel.aspx
    public class MarginSetter
    {
        public static Thickness GetMargin(DependencyObject obj)
        {
            return (Thickness)obj.GetValue(MarginProperty);
        }

        public static void SetMargin(DependencyObject obj, Thickness value)
        {
            obj.SetValue(MarginProperty, value);
        }

        // Using a DependencyProperty as the backing store for Margin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MarginProperty =
            DependencyProperty.RegisterAttached("Margin", typeof(Thickness),
                typeof(MarginSetter), new UIPropertyMetadata(new Thickness(), MarginChangedCallback));

        public static void MarginChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Make sure this is put on a panel

            if (sender is Panel panel)
            {
                panel.Loaded += new RoutedEventHandler(Panel_Loaded);
            }
        }

        private static void Panel_Loaded(object sender, RoutedEventArgs e)
        {
            var panel = sender as Panel;

            // Go over the children and set margin for them:
            foreach (var child in panel.Children)
            {
                if (child is FrameworkElement fe)
                {
                    fe.Margin = GetMargin(panel);
                }
            }
        }
    }
}

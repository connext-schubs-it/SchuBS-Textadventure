using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SchuBS_Textadventure.MyControls
{
    // http://web.archive.org/web/20120711175633/http://blogs.microsoft.co.il/blogs/eladkatz/archive/2011/05/29/what-is-the-easiest-way-to-set-spacing-between-items-in-stackpanel.aspx
    /// <summary>
    /// Setzt den Margin der <see cref="Panel.Children"/>-Elemente.
    /// </summary>
    public class MarginSetter
    {
        /// Die Margin, die für alle <see cref="Panel.Children"/> gesetzt werden soll.
        public static Thickness GetMargin(DependencyObject obj) => (Thickness)obj.GetValue(MarginProperty);

        /// Setzt die Margin, die für alle <see cref="Panel.Children"/> gesetzt werden soll.
        public static void SetMargin(DependencyObject obj, Thickness value) => obj.SetValue(MarginProperty, value);

        /// <summary>Using a DependencyProperty as the backing store for Margin.  This enables animation, styling, binding, etc...</summary>
        public static readonly DependencyProperty MarginProperty =
            DependencyProperty.RegisterAttached("Margin", typeof(Thickness),
                typeof(MarginSetter), new UIPropertyMetadata(new Thickness(),
                    (d, e) =>
                    {
                        // Make sure this is put on a panel
                        if (d is Panel panel)
                        {
                            if (panel.IsLoaded)
                            {
                                SetMarginForChildren(panel);
                            }
                            else
                            {
                                panel.Loaded += new RoutedEventHandler(Panel_Loaded);
                            }
                        }
                    }));

        private static void Panel_Loaded(object sender, RoutedEventArgs e)
        {
            Panel panel = (Panel)sender;

            SetMarginForChildren(panel);

            panel.Loaded -= Panel_Loaded;
        }

        private static void SetMarginForChildren(Panel panel)
        {
            Thickness margin = (Thickness)panel.GetValue(MarginProperty);
            foreach (FrameworkElement frameworkElement in panel.Children.OfType<FrameworkElement>())
            {
                frameworkElement.Margin = margin;
            }
        }
    }
}

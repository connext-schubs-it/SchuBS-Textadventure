using ModernWpf;
using System.Windows;
using System.Windows.Media;

namespace SchuBS_Textadventure
{
    internal class ColorHelper : DependencyObject
    {
        #region DependencyProperties

        public static readonly DependencyProperty AccentColorBrushProperty =
            DependencyProperty.Register("AccentColorBrush", typeof(SolidColorBrush), typeof(ColorHelper), new PropertyMetadata());

        public static readonly DependencyProperty ThemeForegroundBrushProperty =
            DependencyProperty.Register("ThemeForegroundBrush", typeof(SolidColorBrush), typeof(ColorHelper), new PropertyMetadata(null));

        public static readonly DependencyProperty ThemeBackgroudBrushProperty =
            DependencyProperty.Register("ThemeBackgroudBrush", typeof(SolidColorBrush), typeof(ColorHelper), new PropertyMetadata(null));

        #endregion

        public static ColorHelper Instance { get; } = new ColorHelper();

        private ColorHelper()
        {
            AccentColorBrush = new SolidColorBrush();
            ThemeBackgroudBrush = new SolidColorBrush();
            ThemeForegroundBrush = new SolidColorBrush();

            ActualAccentColorChanged(null, null);
            ActualApplicationThemeChanged(null, null);

            ThemeManager.Current.ActualAccentColorChanged += ActualAccentColorChanged;
            ThemeManager.Current.ActualApplicationThemeChanged += ActualApplicationThemeChanged;
        }

        ~ColorHelper()
        {
            ThemeManager.Current.ActualAccentColorChanged -= ActualAccentColorChanged;
            ThemeManager.Current.ActualApplicationThemeChanged -= ActualApplicationThemeChanged;
        }

        private void ActualAccentColorChanged(ThemeManager _, object _1) => AccentColorBrush.Color = ThemeManager.Current.ActualAccentColor;

        private void ActualApplicationThemeChanged(ThemeManager _, object _1)
        {
            ThemeBackgroudBrush.Color = ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Dark
                ? Colors.Black
                : Colors.White;
            ThemeForegroundBrush.Color = ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Dark
                ? Colors.White
                : Colors.Black;
        }

        public static SolidColorBrush GetAccentColorBrush() => Instance.AccentColorBrush;

        public SolidColorBrush AccentColorBrush
        {
            get => (SolidColorBrush)GetValue(AccentColorBrushProperty);
            set => SetValue(AccentColorBrushProperty, value);
        }

        public static SolidColorBrush GetThemeForegroundBrush() => Instance.ThemeForegroundBrush;

        public SolidColorBrush ThemeForegroundBrush
        {
            get => (SolidColorBrush)GetValue(ThemeForegroundBrushProperty);
            set => SetValue(ThemeForegroundBrushProperty, value);
        }

        public static SolidColorBrush GetThemeBackgroudBrush() => Instance.ThemeBackgroudBrush;

        public SolidColorBrush ThemeBackgroudBrush
        {
            get => (SolidColorBrush)GetValue(ThemeBackgroudBrushProperty);
            set => SetValue(ThemeBackgroudBrushProperty, value);
        }
    }
}

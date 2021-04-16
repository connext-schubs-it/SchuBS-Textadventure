using System.ComponentModel;
using System.Windows;

namespace SchuBS_Textadventure.Objects.Verlauf
{
    /// <summary>
    /// Eine Auswahl zwischen verschiedenen Aktionen.
    /// </summary>
    public class Auswahl : DependencyObject
    {
        /// <summary>
        /// Die beschreibungen der Aktionen der Auswahl.
        /// </summary>
        public string[] Aktionen { get; set; } = new string[0];

        /// <summary>
        /// Der Index der gewählten Aktion. Standard ist <c>-1</c>.
        /// </summary>
        public int GewaehlterAktionsIndex
        {
            get => (int)GetValue(GewaehlterAktionsIndexProperty);
            set => SetValue(GewaehlterAktionsIndexProperty, value);
        }

        private static readonly DependencyProperty GewaehlterAktionsIndexProperty =
            DependencyProperty.Register(nameof(GewaehlterAktionsIndex), typeof(int), typeof(Auswahl), new PropertyMetadata(-1));

        internal static readonly DependencyPropertyDescriptor GewaehlterAktionsIndexPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(GewaehlterAktionsIndexProperty, typeof(Auswahl));
    }
}

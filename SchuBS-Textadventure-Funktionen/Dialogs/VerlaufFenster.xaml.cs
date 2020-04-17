using System.Windows;
using System.Windows.Controls;

namespace SchuBS_Textadventure.Dialogs
{
    public partial class VerlaufFenster : Window
    {
        /// <summary>
        /// Erstellt ein neuers Objekt vom Typ <see cref="VerlaufFenster"/> mit dem <paramref name="text"/>.
        /// </summary>
        /// <param name="text"></param>
        public VerlaufFenster(string text)
        {
            InitializeComponent();
            TextBlockVerlaufText.Text = text;
        }

        private void ScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            ((ScrollViewer)sender).ScrollToBottom();
        }
    }
}

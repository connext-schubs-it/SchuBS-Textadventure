using System.Windows;

namespace SchuBS_Textadventure.Dialogs
{
    public partial class VerlaufFenster : Window
    {
        public VerlaufFenster(string text)
        {
            InitializeComponent();
            TextBlockVerlaufText.Text = text;
        }
    }
}

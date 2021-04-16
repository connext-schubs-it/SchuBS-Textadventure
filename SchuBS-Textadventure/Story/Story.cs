using SchuBS_Textadventure.KampfHelper;
using SchuBS_Textadventure.Objects;

using System.Windows;

using static SchuBS_Textadventure.TextadventureHelper;

namespace SchuBS_Textadventure
{
    public partial class Textadventure : Window
    {
        #region Variablen

        private Previous previous;

        private Kampf Kampf { get; set; } = null;

        #endregion

        #region Inhalt

        public void Start()
        {
            WriteText("Hallo!");
            SetzeHintergrundBild("landschaft_1.jpg");
            SetButtonsText("");
        }
        #endregion
    }
}

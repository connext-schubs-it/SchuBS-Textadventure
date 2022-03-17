using SchuBS_Textadventure.Objects;
using System.Windows;

using static SchuBS_Textadventure.TextadventureHelper;

namespace SchuBS_Textadventure
{
    public partial class Textadventure : Window
    {
        public void Start()
        {
            SetzeHintergrundBild("landschaft_1.jpg");
            SetzePersonenBild();
            WriteText("Einfaches Beispiel");

            SetActions((Text: "Beispiel1", ContinueWith: Beispiel1), (Text: "Beispiel2", ContinueWith: Beispiel2));
        }

        public void Beispiel1()
        {
            WriteText("Beispiel1");
            SpielZuende();
        }

        public void Beispiel2()
        {
            WriteText("Beispiel2");
            SpielZuende();
        }
    }
}

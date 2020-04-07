using System.Windows;

namespace SchuBS_Textadventure
{
    public partial class Textadventure
    {
        #region Variablen

        private int previous = -1;

        #endregion

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            switch (previous)
            {
                case 0:
                    AugenOeffnen();
                    break;
                default:
                    break;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            switch (previous)
            {
                case 0:
                    AugenGeschlossen();
                    break;
                default:
                    break;
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            switch (previous)
            {
                default:
                    break;
            }
        }

        public void Start()
        {
            SetzeHintergrundBild("landschaft_1.jpg");
            WriteText("Seid gegrüßt, Held!",
                "Willkommen in der Welt von ##Weltname##!",
                "In dieser Welt durchlauft Ihr ein einzigartiges Abenteuer voller Mythen und Geheimnisse, Menschen und Monstern, Zauber und Flüche.",
                "Die Länder dieser Welt verbergen viele Schätze, doch gebt Acht! Auf euren Wegen erwarten euch viele Gefahren und Herausforderungen...",
                "Ihr erwacht.",
                "Ihr spürt, dass Ihr auf dem Boden liegt.",
                "Ihr fühlt keinen Schmerz, alles scheint wie immer und doch könnt Ihr Euch an nichts mehr erinnern...", "");

            SetButtonsText("Augen öffnen", "Augen geschlossen lassen");
            previous = 0;
        }

        private void AugenOeffnen()
        {
            WriteText("Ihr öffnet eure Augen. Es scheint ein Vormittag im frühen Sommer zu sein. Ihr liegt auf einem Feldweg. Um euch herum ist nicht viel, grüne Flächen, vereinzelte Felder und der Feldweg scheint bis an den Horizont zu führen.",
                "Plötzlich fangt ihr an etwas zu erkennen. Eine Gestalt befindet sich auf dem Feldweg und bewegt sich in eure Richtung, zuerst langsam, doch als sie euch bemerkt, beginnt sie schneller zu laufen. Nun steht ein fremder Mann vor euch: ",
                "Fremder Mann: 'Ein Mittagsschlaf hier unter der prallen Sonne? Recht ungewöhnlich für diese Gegend...",
                "Verratet ihr mir euren Namen?'", "Hallo Fremder. Wie ist dein Name?");
            previous = 1;
        }

        private void AugenGeschlossen()
        {
            WriteText("Euer ungestillter Durst nach Abenteuern führt zum unweigerlichen Ende.", "");
            previous = 2;
        }
    }
}

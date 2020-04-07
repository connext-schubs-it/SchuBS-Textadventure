using System.Windows;
using System.Windows.Input;
using SchuBS_IT_2020;
using SchuBS_Textadventure.Objects;

namespace SchuBS_Textadventure
{
    public partial class Textadventure
    {
        #region Variablen

        private Previous previous;

        #endregion

        #region Eingaben

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            switch (previous)
            {
                case Previous.Start:
                    AugenOeffnen();
                    break;

                case Previous.AugenGeschlossen:
                    Start();
                    break;

                case Previous.BerufungErfragt:
                    Beruf();
                    break;

                default:
                    break;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            switch (previous)
            {
                case Previous.Start:
                    AugenGeschlossen();
                    break;

                case Previous.BerufungErfragt:
                    AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Keine);
                    Muenze();
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

        private void TextBoxEingabe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                switch (previous)
                {
                    case Previous.NameErfragt:
                        AktuellerHeld.Name = TextBoxEingabe.Text;
                        Namen();
                        break;

                    case Previous.BerufErfragt:
                        switch (TextBoxEingabe.Text)
                        {
                            case "Krieger":
                                AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Krieger);
                                Muenze();
                                break;
                            case "Waldläufer":
                                AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Waldlaeufer);
                                Muenze();
                                break;
                            case "Magier":
                                AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Magier);
                                Muenze();
                                break;
                            case "Assassine":
                                AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Assassine);
                                Muenze();
                                break;
                            default:
                                WriteText("Diesen Beruf kenne ich nicht. Kannst du ihn nochmal wiederholen?", "");
                                break;
                        }
                        break;
                }
                TextBoxEingabe.Text = "";
            }
        }

        #endregion

        #region Inhalt

        public void Start()
        {
            SetzeHintergrundBild("landschaft_1.jpg");
            AktuellerHeld.Inventar.Add(new Item("Test", GetBild("ei.png")));
            AktuellerHeld.Inventar.Add(new Item("Test2", null));
            WriteText("Seid gegrüßt, Held!",
                "Willkommen in der Welt von ##Weltname##!",
                "In dieser Welt durchlauft Ihr ein einzigartiges Abenteuer voller Mythen und Geheimnisse, Menschen und Monstern, Zauber und Flüche.",
                "Die Länder dieser Welt verbergen viele Schätze, doch gebt Acht! Auf euren Wegen erwarten euch viele Gefahren und Herausforderungen...",
                "Ihr erwacht.",
                "Ihr spürt, dass Ihr auf dem Boden liegt.",
                "Ihr fühlt keinen Schmerz, alles scheint wie immer und doch könnt Ihr Euch an nichts mehr erinnern...");

            SetButtonsText("Augen öffnen", "Augen geschlossen lassen");
            previous = Previous.Start;
        }

        private void AugenOeffnen()
        {
            WriteText("Ihr öffnet eure Augen. Es scheint ein Vormittag im frühen Sommer zu sein. Ihr liegt auf einem Feldweg. Um euch herum ist nicht viel, grüne Flächen, vereinzelte Felder und der Feldweg scheint bis an den Horizont zu führen.",
                "Plötzlich fangt ihr an etwas zu erkennen. Eine Gestalt befindet sich auf dem Feldweg und bewegt sich in eure Richtung, zuerst langsam, doch als sie euch bemerkt, beginnt sie schneller zu laufen. Nun steht ein fremder Mann vor euch: ",
                "Fremder Mann: 'Ein Mittagsschlaf hier unter der prallen Sonne? Recht ungewöhnlich für diese Gegend...",
                "Verratet ihr mir euren Namen?'");
            EingabefeldNutzen();
            previous = Previous.NameErfragt;
        }

        private void AugenGeschlossen()
        {
            WriteText("Euer ungestillter Durst nach Abenteuern führt zum unweigerlichen Ende.");
            SetButtonsText("Neustarten");
            previous = Previous.AugenGeschlossen;
        }

        private void Namen()
        {
            WriteText("Ah, ##SpielerName##!",
                "Von dir habe ich schon gehört, alle hier erzählen von dir!",
                "Was führt dich hier her?");
            SetButtonsText("Mein Beruf", "Pure Abenteuerlust");
            previous = Previous.BerufungErfragt;
        }

        private void Beruf()
        {
            WriteText("Was ist denn dein Beruf?", "");
            EingabefeldNutzen();
            previous = Previous.BerufErfragt;
        }

        private void Muenze()
        {
            WriteText("Ein ##SpielerKlasse## also! Es ist schön dich kennenzulernen.",
                "Hier hast du eine Münze, die wird bestimmt mal hilfreich. Aber nicht alles auf einmal ausgeben.",
                "Viel Erfolg auf deinem Weg, ##SpielerName##!",
                "Achso, eine Frage noch: Was leitet dich auf deinem Weg?");
            SetButtonsText("Macht", "Reichtum");
            previous = Previous.ZielErfragt;
        }

        #endregion
    }
}

using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using SchuBS_IT_2020;
using SchuBS_Textadventure.Helpers;
using SchuBS_Textadventure.Objects;

namespace SchuBS_Textadventure
{
    public partial class Textadventure
    {
        #region Variablen

        private Previous previous;

        private Kampf Kampf { get; set; } = null;

        #endregion

        #region Eingaben

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            switch (previous)
            {
                case Previous.Start:
                    NameErfragen();
                    break;

                case Previous.EndeAugenGeschlossen:
                    Start();
                    break;

                case Previous.BerufungErfragt:
                    BerufErfragen();
                    break;

                case Previous.ZielErfragt:
                    MachtStart();
                    break;

                case Previous.TiefseegrotteErfragt:
                    TiefseegrotteSchwimmen();
                    break;

                case Previous.TiefseegrotteGeschwommen:
                    TiefseegrotteLinksSchwimmen();
                    break;

                case Previous.MachtGestartet:
                    KaffeBohnenplantage();
                    break;

                case Previous.KaffeBohnenplantage:
                    istMachtWichtig();
                    break;

                case Previous.EisKaufen:
                    Taube(true);
                    break;

                case Previous.TiefseegrotteUngeheuerBegegnet:
                    TiefseegrotteUngeheuerKaempfen();
                    break;

                case Previous.Taube:
                    DeckungSuchen();
                    break;

                case Previous.TaubeTreten:
                    BrueckenZoll();
                    break;

                default:
                    KaempfeWennMoeglich(buttonIndex: 0);
                    break;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            switch (previous)
            {
                case Previous.Start:
                    EndeAugenGeschlossen();
                    break;

                case Previous.BerufungErfragt:
                    AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Keine);
                    ZielErfragen();
                    break;

                case Previous.ZielErfragt:
                    EisKaufen();
                    break;

                case Previous.EisKaufen:
                    Taube(false);
                    break;

                case Previous.Taube:
                    TaubeTreten();
                    break;

                case Previous.MachtGestartet:
                    TiefseegrotteFragen();
                    break;

                case Previous.TiefseegrotteGeschwommen:
                    TiefseegrotteBegegnungUngeheuer();
                    break;

                case Previous.KaffeBohnenplantage:
                    ZielErfragen();
                    break;

                case Previous.TiefseegrotteUngeheuerBegegnet:
                    TiefseegrotteVorbeimogeln();
                    break;


                default:
                    KaempfeWennMoeglich(buttonIndex: 1);
                    break;
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            switch (previous)
            {
                default:
                    KaempfeWennMoeglich(buttonIndex: 2);
                    break;
            }
        }

        private void KaempfeWennMoeglich(int buttonIndex)
        {
            if (Kampf != null)
            {
                if (Kampf.IstZuende)
                {
                    Kampf = null;

                    switch (previous)
                    {
                        case Previous.TiefseegrotteUngeheuerKaempfen:
                            TiefseegrotteUngeheuerBesiegt();
                            break;
                    }
                }
                else
                {
                    switch (buttonIndex)
                    {
                        case 1:
                            Kampf.Button1Angriff();
                            break;
                        case 2:
                            Kampf.Button2Magie();
                            break;
                        case 3:
                            Kampf.Button3Item();
                            break;
                    }

                    if (Kampf.IstZuende)
                    {
                        SetButtonsText("Kampf beenden");
                    }
                }
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
                        BerufungErfragen();
                        break;

                    case Previous.BerufErfragt:
                        switch (TextBoxEingabe.Text.ToLower())
                        {
                            case "krieger":
                                AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Krieger);
                                ZielErfragen();
                                break;
                            case "waldläuferin":
                                AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Waldlaeufer);
                                ZielErfragen();
                                break;
                            case "magierin":
                                AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Magier);
                                ZielErfragen();
                                break;
                            case "assassine":
                                AktuellerHeld.Klasse = Klasse.GetByKlassenTyp(KlassenTyp.Assassine);
                                ZielErfragen();
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
            WriteText("Seid gegrüßt, Held!",
                "Willkommen in der Welt von ##Weltname##!",
                "In dieser Welt durchläufst du ein einzigartiges Abenteuer voller Mythen und Geheimnisse, Menschen und Monster, Zauber und Flüche. Und ganz viele Kürbisse. ",
                "Die Länder von Cucurbita beherbergen viele Schätze, doch gib Acht! Auf deinen Wegen erwarten dich viele Gefahren und Herausforderungen. Entscheide weise, denn jede Entscheidung könnte deine letzte sein...  ",
                "Du erwachst.",
                "Du spürst, dass du auf hartem Boden liegst.",
                "Du fühlst keinen Schmerz, alles scheint wie immer. Trotzdem kannst du dich an nichts mehr erinnern…");

            SetButtonsText("Augen öffnen", "Augen geschlossen lassen");
            previous = Previous.Start;
        }

        private void NameErfragen()
        {
            WriteText("Du öffnest deine Augen. Das helle Sonnenlicht blendet dich für einen Moment. Es scheint ein sonniger Vormittag im frühen Sommer zu sein. Du liegst auf einem staubigen Feldweg. In der Umgebung gibt es nicht viel zu sehen. Grüne Flächen, vereinzelte Felder und der Feldweg, der bis an den Horizont zu führen scheint.",
                "Da regt sich etwas in der Ferne. Eine Gestalt befindet sich auf dem Weg und bewegt sich in eure Richtung, zuerst langsam, dann schneller, als sie dich bemerkt.",
                "Nun steht ein fremder Mann vor dir.",
                "'Ein Mittagsschlaf, hier in der prallen Sonne? Recht ungewöhnlich für diese Gegend. Fast schon verdächtig... ",
                "Verrätst du mir deinen Namen?'");
            EingabefeldNutzen();
            previous = Previous.NameErfragt;
        }

        private void EndeAugenGeschlossen()
        {
            SetzeHintergrundBild("feldweg_deathscreen.png");
            WriteText("Euer ungestillter Durst nach Abenteuern führt zum unweigerlichen Ende.");
            SetButtonsText("Neustarten");
            previous = Previous.EndeAugenGeschlossen;
        }

        private void BerufungErfragen()
        {
            WriteText("'Naja, jemand mit dem Namen kann gar nicht feindlich gesinnt sein! Freut mich dich kennenzulernen, ##SpielerName##!",
                "Ich bin Thoron, der Wanderer, erster seines Namens, Sprenger der Ketten und Vater der Kürbisse. Aber du darfst mich ruhig Thoron nennen.",
                "Was führt dich in unsere Lande, ##SpielerName##?'");
            SetButtonsText("Ich bin beruflich hier.", "Pure Abenteuerlust.");
            previous = Previous.BerufungErfragt;
        }

        private void BerufErfragen()
        {

            SetzeHintergrundBild("klassenvorschau.png");
            WriteText("'Beruflich also? Was ist denn dein Beruf?'",
                "(Mögliche Eingaben: Krieger, Waldläufer, Magier, Assassine. Entscheide weise!) "); ;
            EingabefeldNutzen();
            previous = Previous.BerufErfragt;
        }

        private void ZielErfragen()
        {
            WriteText("'Ein ##SpielerKlasse##! Spannend.",
                "Dann wünsche ich dir viel Erfolg auf deinem Weg.",
                "Hier hast du eine Münze. Gebrauche sie klug. Sie wird sich bestimmt noch als hilfreich erweisen.",
                "Eine Frage noch, ##SpielerName## Welches Begehren wird dich auf deinem Weg leiten?'?");
            AktuellerHeld.Inventar.Add(new Item("Münze", GetBild("muenze.png")));
            SetButtonsText("Macht.", "Reichtum.");
            previous = Previous.ZielErfragt;
        }

        public void StarteKampf(Textadventure adventure, Gegner gegner)
        {
            TextBoxEingabe.Text = "";

            Kampf = new Kampf(AktuellerHeld, gegner, null, adventure);
            WriteText($"{gegner.Name} fordert dich zum Kampf! ", "Was wirst du tun?!");
            Kampf.Aktion();
        }

        #endregion
    }
}

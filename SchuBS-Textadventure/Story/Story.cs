﻿using SchuBS_Textadventure.Helpers;
using SchuBS_Textadventure.Objects;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

                case Previous.Gestorben:
                    new Textadventure().Show();
                    Close();
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
                    IstMachtWichtig();
                    break;

                case Previous.EisKaufen:
                    EisGekauft();
                    break;

                case Previous.EisGekauft:
                case Previous.EisNichtGekauft:
                    Taube();
                    break;

                case Previous.TiefseegrotteLinksSchwimmen:
                    IstMachtWichtig();
                    break;

                case Previous.TiefseegrotteBegegnungUngeheuer:
                    TiefseegrotteUngeheuerKaempfen();
                    break;

                case Previous.Taube:
                    DeckungSuchen();
                    break;

                case Previous.DeckungSuchen:
                    WegZurTiefseegrotte();
                    break;

                case Previous.TaubeTreten:
                    BrueckenZoll();
                    break;

                case Previous.MachtWichtig:
                    GnadeFlehen();
                    break;

                case Previous.BrueckenZollMuenzeVorhanden:
                    RaetselMauer();
                    break;

                case Previous.BrueckenZollMuenzeNichtVorhanden:
                    WegZurTiefseegrotte();
                    break;

                case Previous.WegZurTiefseegrotte:
                    TiefseegrotteSchwimmen();
                    break;

                case Previous.Windstoß:
                    BrueckenZoll();
                    break;

                case Previous.Weggabelung:
                    Aufzug();
                    break;

                case Previous.TiefseegrotteRichtigeAntwort:
                    IstMachtWichtig();
                    break;

                case Previous.IstMachtWichtig:
                    KuerberlinGnadeFlehen();
                    break;

                case Previous.KuerberlinGnadeFlehen:
                case Previous.KuerberlinEier:
                    KuerberlinKoboldKampf();
                    break;

                case Previous.Fußweg:
                case Previous.Aufzug:
                    JoshkaBegegnen();
                    break;

                case Previous.JoshkaBegegnen:
                    StarteKampfFeuerdrache();
                    break;

                case Previous.TauschMesserblock:
                    EndeThemenpark();
                    break;

                case Previous.MitEierWerfen:
                    GeschenkeAbweisen();
                    break;

                case Previous.Geschenkeabweisen:
                    MitEiernWerfen();
                    break;

                case Previous.TiefseegrotteVorbeimogeln:
                    TiefseegrotteVorbeimogeldTod();
                    break;
               case Previous.GeschenkeAnnehmen:
                  WeiteSuchen();
                  break;
                default:
                    if (TextBoxEingabe.IsEnabled)
                    {
                        VerarbeiteTextEingabe();
                    }
                    else
                    {
                        KaempfeWennMoeglich(buttonIndex: 0);
                    }

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
                    EisNichtGekauft();
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
                    AktuellerHeld.EntferneItem("Münze");
                    ZielErfragen();
                    break;

                case Previous.TiefseegrotteBegegnungUngeheuer:
                    TiefseegrotteVorbeimogeln();
                    break;

                case Previous.TiefseegrotteVorbeimogeln:
                    TiefseegrotteKonversation();
                    break;
                case Previous.BrueckenZollMuenzeVorhanden:
                    WegZurTiefseegrotte();
                    break;

                case Previous.KuerbistanAnkunft:
                    KuerbistanGeschenkeAblehnen();
                    break;

                case Previous.Weggabelung:
                    Fußweg();
                    break;

                case Previous.JoshkaBegegnen:
                    Tauschgeschaeft();
                    break;

                case Previous.MachtWichtig:
                    KaempfenKaffeeGegenKobolde();
                    break;

                case Previous.MitEierWerfen:
                    GeschenkeAnnehmen();
                    break;
                // case Previous.istMachtWichtig:
                //    MitEiernWerfen();
                //  break;

                default:
                    KaempfeWennMoeglich(buttonIndex: 1);
                    break;
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            switch (previous)
            {
                case Previous.MachtWichtig:
                    MitEiernWerfen();
                    break;
                //case Previous.istMachtWichtig:
                //KuerberlinEier();
                  // break;

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

                        case Previous.KaempfenKaffeeKobolde:
                            KaempfenKoboldanfuehrer();
                            break;
                    }
                }
                else
                {
                    switch (buttonIndex)
                    {
                        case 0:
                            Kampf.Button1Angriff();
                            break;
                        case 1:
                            Kampf.Button2Magie();
                            break;
                        case 2:
                            Kampf.Button3Item();
                            break;
                    }

                    if (Kampf.IstZuende)
                    {
                        if (AktuellerHeld.Lebenspunkte <= 0)
                        {
                            WriteText("Du bist im Kampf gestorben!");
                            SpielerTod();
                        }
                        else
                        {
                            SetButtonsText("Kampf beenden");
                        }
                    }
                }
            }
        }

        private void TextBoxEingabe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                VerarbeiteTextEingabe();
            }
        }

        private void TextBoxEingabe_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxEingabe.IsEnabled)
            {
                ButtonsAktionen[0].IsEnabled = !string.IsNullOrWhiteSpace(TextBoxEingabe.Text);
            }
        }

        private void VerarbeiteTextEingabe()
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

                case Previous.RaetselMauer:
                    switch (TextBoxEingabe.Text.ToLower())
                    {
                        case "kürbis":
                        case "vierunddreißig":
                        case "fünf":
                        case "eins":
                            Raetsel2();
                            break;

                        case "acht":
                            Weggabelung();
                            break;

                        default:
                            WriteText("Das ist auf jeden Fall keine Antwortmöglichkeit!", "");
                            break;
                    }

                    break;

                case Previous.Raetsel2:
                    switch (TextBoxEingabe.Text.ToLower())
                    {
                        case "thoron":
                        case "Eierkarton":
                        case "donald j trumpkin":
                        case "blau":
                            Windstoß();
                            break;

                        case "acht":
                            Weggabelung();
                            break;

                        default:
                            WriteText("Das ist auf jeden Fall keine Antwortmöglichkeit!", "");
                            break;
                    }

                    break;

                case Previous.Tauschgeschaeft:
                    switch (TextBoxEingabe.Text.ToLower())
                    {
                        case "nunchakus":
                            if (AktuellerHeld.HatItem("Nunchakus"))
                            {
                                TauschNunchakus();
                            }
                            else
                            {
                                WriteText("Dieses Item befindet sich nicht in deinem Inventar.");
                            }

                            break;

                        case "messerblock":
                            if (AktuellerHeld.HatItem("Messerblock"))
                            {
                                TauschMesserblock();
                            }
                            else
                            {
                                WriteText("Dieses Item befindet sich nicht in deinem Inventar.");
                            }

                            break;

                        default:
                            WriteText("Dieses Item befindet sich nicht in deinem Inventar.");
                            break;
                    }

                    break;
            }
            TextBoxEingabe.Text = "";
        }

        #endregion

        #region Inhalt

        public void Start()
        {
            SetzeHintergrundBild("landschaft_1.jpg");
            SetzePersonenBild();
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
            WriteText(
                "Du öffnest deine Augen. Das helle Sonnenlicht blendet dich für einen Moment. Es scheint ein sonniger Vormittag im frühen Sommer zu sein. Du liegst auf einem staubigen Feldweg. In der Umgebung gibt es nicht viel zu sehen. Grüne Flächen, vereinzelte Felder und der Feldweg, der bis an den Horizont zu führen scheint.",
                "Da regt sich etwas in der Ferne. Eine Gestalt befindet sich auf dem Weg und bewegt sich in eure Richtung, zuerst langsam, dann schneller, als sie dich bemerkt.",
                "Nun steht ein fremder Mann vor dir.",
                "“Ein Mittagsschlaf, hier in der prallen Sonne? Recht ungewöhnlich für diese Gegend. Fast schon verdächtig... ",
                "Verrätst du mir deinen Namen?”");
            EingabefeldNutzen();
            previous = Previous.NameErfragt;
        }

        private void EndeAugenGeschlossen()
        {
            SetzeHintergrundBild("feldweg_deathscreen.png");
            WriteText("So schnell wie dein Abenteuer anfing, so schnell ist es auch zu Ende. " +
                "Du hast dich entschieden, deinem Schicksal zu entkommen. Dein ungestillter Durst nach Abenteuern führt zum unweigerlichen Ende.");
            SpielerTod();
        }

        private void BerufungErfragen()
        {
            WriteText(
                "“Naja, jemand mit deinem Namen kann gar nicht feindlich gesinnt sein! Freut mich dich kennenzulernen, ##SpielerName##!",
                "Ich bin Thoron, der Wanderer, erster seines Namens, Sprenger der Ketten und Vater der Kürbisse. Aber du darfst mich ruhig Thoron nennen.",
                "Was führt dich in unsere Lande, ##SpielerName##?”");
            SetButtonsText("Ich bin beruflich hier.", "Pure Abenteuerlust.");
            previous = Previous.BerufungErfragt;
        }

        private void BerufErfragen()
        {
            SetzeHintergrundBild("klassenvorschau.png");
            WriteText("“Beruflich also? Was ist denn dein Beruf?”",
                "(Mögliche Eingaben: Krieger, Waldläufer, Magier, Assassine. Entscheide weise!) ");
            EingabefeldNutzen();
            previous = Previous.BerufErfragt;
        }

        private void ZielErfragen()
        {
            WrapPanelStats.Visibility = Visibility.Visible;
            WriteText("“Ein ##SpielerKlasse##! Spannend.",
                "Dann wünsche ich dir viel Erfolg auf deinem Weg.",
                "Hier hast du eine Münze. Gebrauche sie klug. Sie wird sich bestimmt noch als hilfreich erweisen.",
                "Eine Frage noch, ##SpielerName##. Welches Begehren wird dich auf deinem Weg leiten?”");
            AktuellerHeld.FuegeItemHinzu(new Item("Münze", GetBild("muenze.png")));
            SetButtonsText("Macht.", "Reichtum.");
            previous = Previous.ZielErfragt;
        }

        #endregion
    }
}
